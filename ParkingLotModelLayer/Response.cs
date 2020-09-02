using System.Net;

namespace ParkingLotModelLayer
{
    public class Response
    {
        public Response(HttpStatusCode StatusCode,string Message,object Data)
        {
            this.StatusCode = StatusCode;
            this.Message = Message;
            this.Data = Data;
        }
        public HttpStatusCode StatusCode { get; }
        public string Message { get;}
        public object Data { get;}
    }
}
