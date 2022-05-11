using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.TodoWebApp.Global.Utils
{
    public class Enums
    {
        public enum ResponseType
        {
            Success = 0,
            NotFound = 1,
            ValidationError = 2
        }
    }
}
