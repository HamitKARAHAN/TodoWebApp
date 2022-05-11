using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.TodoWebApp.Global.BaseObjects.Concrete
{
    public class CustomValidationErrorModel
    {
        public string ErrorMessage { get; set; }
        public string PropertyName { get; set; }
    }
}
