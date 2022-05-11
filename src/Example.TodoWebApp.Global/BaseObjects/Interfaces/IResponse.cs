using Example.TodoWebApp.Global.Utils;

namespace Example.TodoWebApp.Global.BaseObjects.Interfaces
{
    public interface IResponse
    {
        string Message { get; set; }
        Enums.ResponseType ResponseType { get; set; }
    }
}
