using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoBase.Helpers.Exceptions
{
    public class SemPermissaoException : ApplicationException
    {
        public SemPermissaoException()
        {
        }

        public SemPermissaoException(string message) : base(message)
        {
        }

        public SemPermissaoException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}