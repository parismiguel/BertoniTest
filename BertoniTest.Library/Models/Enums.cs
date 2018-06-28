using System;
using System.Collections.Generic;
using System.Text;

namespace BertoniTest.Library.Models
{
    public class Enums
    {
        public enum HttpMethod
        {
            GET,
            POST
        }

        public enum ResponseType
        {
            Success,
            Warning,
            Error
        }
    }
}
