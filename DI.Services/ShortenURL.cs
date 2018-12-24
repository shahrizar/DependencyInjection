using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DI.Services
{
    public class ShortenURL : IShortenURL
    {
        public async Task<string> TinyURL(string URL)
        {
            try
            {
                var WebReq = (HttpWebRequest)WebRequest.Create("http://tinyurl.com/api-create.php?url=" + URL);
                using (WebResponse response = await WebReq.GetResponseAsync())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            return await reader.ReadToEndAsync();
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                return ex.Message;
            }
        }
    }
}
