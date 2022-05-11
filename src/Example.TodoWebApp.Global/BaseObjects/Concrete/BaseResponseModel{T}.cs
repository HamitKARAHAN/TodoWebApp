using Example.TodoWebApp.Global.BaseObjects.Interfaces;
using Example.TodoWebApp.Global.Utils;

namespace Example.TodoWebApp.Global.BaseObjects.Concrete
{
    public class BaseResponseModel<T> : BaseResponseModel, IResponse<T>
    {
        public BaseResponseModel(Enums.ResponseType responseType ,T data) : base(responseType)
        {
            Data = data;
        }

        public BaseResponseModel(Enums.ResponseType responseType, string message) : base(responseType, message)
        {
        }

        public BaseResponseModel(Enums.ResponseType responseType, T data, List<CustomValidationErrorModel> errors) : base(responseType)
        {
            Data = data;
            Errors = errors;
        }

        public T Data { get; set; }
        public List<CustomValidationErrorModel> Errors { get; set; }
    }
}
