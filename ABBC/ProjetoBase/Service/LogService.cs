using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoBase.DAO;
using ProjetoBase.DTO;
using ProjetoBase.Models;

namespace ProjetoBase.Service
{
    public class LogService
    {
        /// <summary>
        /// Faz a paginação do servidor dos logs de acesso da aplicação
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public static DataTableResponse<LogDTO> Filter(DataTableRequest req)
        {
            int coluna = int.Parse(req.order.Count() > 0 ? req.order[0]["column"] : "-1");
            bool asc = req.order.Count() > 0 ? req.order[0]["dir"].ToLower().Equals("asc") : false;

            string search = req.search["value"];
            var termos = search.Split(' ').ToList();
            IQueryable<Log> query = LogDao.getQuery(false);
            if (search != null && search != "")
            {
                foreach (var termo in termos)
                {
                    query = query.Where(x => x.acao.Contains(termo)
                        || x.menu.Contains(termo)
                        || x.method.Contains(termo)
                        || x.nomeUsuario.Contains(termo)
                        || x.opcao.Contains(termo));
                }
                query = query.Distinct();
            }
            
            if (coluna == 0)
            {
                if ((bool)asc)
                {
                    query = query.OrderBy(x => x.ID);
                }
                else
                {
                    query = query.OrderByDescending(x => x.ID);
                }
            }
            if (coluna == 1)
            {
                if ((bool)asc)
                {
                    query = query.OrderBy(x => x.nomeUsuario);
                }
                else
                {
                    query = query.OrderByDescending(x => x.nomeUsuario);
                }
            }
            if (coluna == 2)
            {
                if ((bool)asc)
                {
                    query = query.OrderBy(x => x.menu);
                }
                else
                {
                    query = query.OrderByDescending(x => x.menu);
                }
            }
            if (coluna == 3)
            {
                if ((bool)asc)
                {
                    query = query.OrderBy(x => x.opcao);
                }
                else
                {
                    query = query.OrderByDescending(x => x.opcao);
                }
            }
            if (coluna == 4)
            {
                if ((bool)asc)
                {
                    query = query.OrderBy(x => x.acao);
                }
                else
                {
                    query = query.OrderByDescending(x => x.acao);
                }
            }
            if (coluna == 5)
            {
                if ((bool)asc)
                {
                    query = query.OrderBy(x => x.data);
                }
                else
                {
                    query = query.OrderByDescending(x => x.data);
                }
            }
            if (coluna == 6)
            {
                if ((bool)asc)
                {
                    query = query.OrderBy(x => x.method);
                }
                else
                {
                    query = query.OrderByDescending(x => x.method);
                }
            }
            
            var totalItensFiltered = query.Count();
            List<Log> logs = query.Skip(req.start).Take(req.length).ToList();
            List<LogDTO> logsDTO = LogDTO.ParseList(logs);

            DataTableResponse<LogDTO> resp = new DataTableResponse<LogDTO>();
            resp.data = logsDTO;
            resp.draw = req.draw;
            resp.recordsTotal = LogDao.Count();
            resp.recordsFiltered = totalItensFiltered;

            return resp;
        }
    }
}