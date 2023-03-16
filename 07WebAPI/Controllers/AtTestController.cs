using _07WebAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using static _07WebAPI.Models.AtData;

namespace _07WebAPI.Controllers
{
    public class AtTestController : ApiController
    {
        public async Task<Info[]> Get()
        {
            string url = "https://media.taiwan.net.tw/XMLReleaseALL_public/scenic_spot_C_f.json";
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;
            var resp = await client.GetStringAsync(url);

            var collection = JsonConvert.DeserializeObject<Info[]>(resp);

            return collection;
        }
    }
}
