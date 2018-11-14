using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBase.DTO
{
    public class DataTableRequest
    {
        public virtual int draw { get; set; }
        public virtual int start { get; set; }
        public virtual int length { get; set; }
        public virtual Dictionary<string, string> search { get; set; }
        public virtual List<Dictionary<string, string>> order { get; set; }
        public virtual List<Dictionary<string, string>> columns { get; set; }
        public virtual List<Dictionary<string, string>> filter { get; set; }
    }
}