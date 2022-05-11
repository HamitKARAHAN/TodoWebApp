using Example.TodoWebApp.Global.BaseObjects.Interfaces;
using Example.TodoWebApp.Global.Utils;

namespace Example.TodoWebApp.Global.BaseObjects.Concrete
{
    public class BaseResponseModel : IResponse
    {
        public BaseResponseModel(Enums.ResponseType responseType)
        {
            ResponseType = responseType;
        }

        public BaseResponseModel(Enums.ResponseType responseType, string message) : this(responseType)
        {
            Message = message;
        }

        public string Message { get; set; }
        public Enums.ResponseType ResponseType { get; set; }
    }
}
