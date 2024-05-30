using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinPro_PSD.Helpers
{
    public class Response<T>
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public T Payload { get; set; }
    }
}