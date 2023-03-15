using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Tour.Models;

namespace Tour.Controllers
{
    public class AttrationsAPIController : ApiController
    {
        // GET: Covid19API 先用自己的伺服器和對方取資料  再ajax傳給html
        public async Task<IEnumerable<AtData>> Get()
        {
            string url = "https://media.taiwan.net.tw/XMLReleaseALL_public/scenic_spot_C_f.json";
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;
            var resp = await client.GetStringAsync(url);

            var collection = JsonConvert.DeserializeObject<IEnumerable<AtData>>(resp);

            return collection;
        }
    }
}
