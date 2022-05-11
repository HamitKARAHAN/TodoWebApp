using Example.TodoWebApp.Global.BaseObjects.Concrete;

namespace Example.TodoWebApp.Global.BaseObjects.Interfaces
{
    public interface IResponse<T> : IResponse
    {
        T Data { get; set; }
        List<CustomValidationErrorModel> Errors { get; set; }
    }
}
