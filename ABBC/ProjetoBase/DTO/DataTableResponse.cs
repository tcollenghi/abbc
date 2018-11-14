using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBase.DTO
{
    public class DataTableResponse<T>
    {
        public virtual int draw { get; set; }
        public virtual int recordsTotal { get; set; }
        public virtual int recordsFiltered { get; set; }
        public virtual IList<T> data { get; set; }
    }
}