using DI.API.Models;
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
    [RoutePrefix("Api/Tools")]
    public class ToolsController : ApiController
    {
        private IShortenURL _shortenURL;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="shortenURL"></param>
        public ToolsController(IShortenURL shortenURL)
        {
            _shortenURL = shortenURL;
        }

        /// <summary>
        /// Shorten URL with Method Get
        /// </summary>
        /// <param name="URL"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetShortenURL")]
        public async Task<IHttpActionResult> GetShortenURL(string URL)
        {
            var result = await _shortenURL.TinyURL(URL);
            return Ok(result);
        }

        /// <summary>
        /// Shorten URL with Method Post, RESTAPI
        /// </summary>
        /// <param name="Req"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("PostShortenURL")]
        public async Task<IHttpActionResult> PostShortenURL(MShortenURL.Request Req)
        {
            var result = await _shortenURL.TinyURL(Req.URL);
            return Ok(new MShortenURL.Response { Service = "TinyURL", ShortenURL = result });
        }
    }
}
