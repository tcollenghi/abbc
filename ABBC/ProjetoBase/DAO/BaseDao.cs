using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoBase.Helpers;
using ProjetoBase.Models;
using System.Transactions;
using System.Data.Entity;

namespace ProjetoBase.DAO
{
    public class BaseDao<TEntity> where TEntity : BaseModel
    {
        /// <summary>
        /// Context do Entity Framework para essa request
        /// </summary>
        public static ProjetoBaseContext db
        {
            get
            {
                return SessionHelper.getProjetoBaseContext();
            }
        }

        /// <summary>
        /// Set específico do tipo da entidade que está sendo trabalhada
        /// </summary>
        public static IDbSet<TEntity> Set
        {
            get
            {
                return SessionHelper.getProjetoBaseContext().Set<TEntity>();
            }
        }

        /// <summary>
        /// Os objetos retornados por essa query não são rastreados pelo contexto do entity, 
        /// portanto, modificações realizadas neles não são presistidas no banco.
        /// </summary>
        public static IQueryable<TEntity> queryNoTracking
        {
            get
            {
                return SessionHelper.getProjetoBaseContext().Set<TEntity>().AsNoTracking();
            }
        }

        /// <summary>
        /// Retorna um querable com Track Change no context do Entity Framework
        /// </summary>
        /// <returns></returns>
        public static IQueryable<TEntity> getQuery()
        {
            return getQuery(true);
        }

        /// <summary>
        /// Retorna um querable com ou sem Track Change no context do Entity Framework
        /// </summary>
        /// <param name="track"></param>
        /// <returns></returns>
        public static IQueryable<TEntity> getQuery(bool track)
        {
            if (track)
            {
                return Set.AsQueryable();
            }
            else
            {
                return queryNoTracking;
            }
        }
        
        public static TEntity Find(long id)
        {
            return Find(id, true);
        }

        public static TEntity Find(long id, bool track)
        {
            IQueryable<TEntity> query = getQuery(track);
            return query.Where(x => x.ID == id).SingleOrDefault();
        }

        public static List<TEntity> FindAll()
        {
            return FindAll(true);
        }

        public static List<TEntity> FindAll(bool track)
        {
            IQueryable<TEntity> query = getQuery(track);
            return query.ToList();
        }

        public static List<TEntity> FindAllByID(List<long> ids)
        {
            return FindAllByID(ids, true);
        }

        public static List<TEntity> FindAllByID(List<long> ids, bool track)
        {
            return Set.Where(x => ids.Contains(x.ID)).ToList();
        }

        public static void Save(TEntity item)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                Set.Add(item);
                db.SaveChanges();
                transaction.Commit();
            }
        }

        public static void Save(List<TEntity> items)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                foreach(var item in items)
                {
                    Set.Add(item);
                }
                db.SaveChanges();
                transaction.Commit();
            }
        }

        public static void Update(List<TEntity> items)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                foreach (var item in items)
                {
                    db.Entry(item).State = EntityState.Modified;
                }
                db.SaveChanges();
                transaction.Commit();
            }
        }

        public static void Update(TEntity item)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                transaction.Commit();
            }
        }

        public static void Delete(TEntity item)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                Set.Attach(item);
                Set.Remove(item);
                db.SaveChanges();
                transaction.Commit();
            }
        }

        public static void Delete(List<TEntity> itens)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                foreach(var item in itens)
                {
                    Set.Attach(item);
                    Set.Remove(item);
                }
                db.SaveChanges();
                transaction.Commit();
            }
        }

        public static void SaveUpdateAll()
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                db.SaveChanges();
                transaction.Commit();
            }
        }

        public static int Count()
        {
            return Set.Count();
        }

        public static void RejectChanges()
        {
            foreach (var entry in db.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified; //Revert changes made to deleted entity.
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                }
            }
        }
    }
}