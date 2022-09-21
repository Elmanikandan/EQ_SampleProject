using System.Net;

namespace Property.Services.Models
{
    public class ResponseModel<T>
    {
        public HttpStatusCode ResponseCode { get; set; }
        public string Message { get; set; } = "";
        public T? Record { get; set; }
    }
}
