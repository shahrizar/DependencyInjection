using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DI.API.Models
{
    public class MShortenURL
    {
        public class Request
        {
            public string URL { get; set; }
        }

        public class Response
        {
            public string ShortenURL { get; set; }
            public string Service { get; set; }
        }
    }
}