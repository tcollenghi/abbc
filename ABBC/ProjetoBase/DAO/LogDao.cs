using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using ProjetoBase.DTO;
using ProjetoBase.Helpers;
using ProjetoBase.Models;

namespace ProjetoBase.DAO
{
    public class LogDao : BaseDao<Log>
    {
        public static int countAcessosHoje()
        {
            var dataHoje = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            return Set.Count(x => x.data >= dataHoje);
        }
    }
}