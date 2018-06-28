using static BertoniTest.Library.Models.Enums;

namespace BertoniTest.Library.Models
{
    public class Response
    {
        public Response()
        {
            Status = false;
            Type =  ResponseType.Error;
        }

        public bool Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public string Trace { get; set; }
        public ResponseType Type { get; set; }
    }
}
