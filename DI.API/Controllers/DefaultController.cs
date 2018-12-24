using DI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace DI.API.Controllers
{
    public class DefaultController : ApiController
    {
        private IShortenURL _shortenURL;

        public DefaultController(IShortenURL shortenURL)
        {
            _shortenURL = shortenURL;
        }

        [HttpGet]
        [Route("GetShortenURL")]
        public async Task<IHttpActionResult> GetShortenURL(string URL)
        {
            var result = await _shortenURL.TinyURL(URL);
            return Ok(result);
        }
    }
}
