using Example.TodoWebApp.Global.BaseObjects.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.TodoWebApp.Global.BaseObjects.Interfaces
{
    public interface IResponse<T> : IResponse
    {
        T Data { get; set; }
        List<CustomValidationErrorModel> Errors { get; set; }
    }
}
