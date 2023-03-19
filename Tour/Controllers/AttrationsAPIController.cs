using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Tour.Models;
using static Tour.Models.AtData;

namespace Tour.Controllers
{
    public class AttrationsAPIController : ApiController
    {

        // GET: Covid19API 先用自己的伺服器和對方取資料  再ajax傳給html
        public async Task<Rootobject> Get()
        {
            string url = "https://media.taiwan.net.tw/XMLReleaseALL_public/scenic_spot_C_f.json";
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = Int32.MaxValue;
            var resp = await client.GetStringAsync(url);

            var collection = JsonConvert.DeserializeObject<Rootobject>(resp);

            return collection;
        }



        //public IEnumerable<Customers> Get()
        //{
        //    return db.Customers;
        //}

        //public IEnumerable<Customers> Get(int page)
        //{
        //    const int pageSize = 15;
        //    int skip = (page - 1) * pageSize;

        //    return db.Customers.OrderBy(m => m.CustomerID).Skip(skip).Take(pageSize);
        //}

        //public Customers Get(string id)
        //{
        //    var c = db.Customers.Find(id);
        //    return c;
        //}


        //public IHttpActionResult Post([FromBody] Attrations value)
        //{

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    db.Attrations.Add(value);


        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (db.Attrations.Count(c => c.AttrationID == value.AttrationID) > 0)
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }


        //    return CreatedAtRoute("DefaultApi", new { id = value.AttrationID }, value);

        //}

            //public void Put(int id, [FromBody] string value)
            //{
            //}


            //public void Delete(int id)
            //{
            //}
       
        



    }
}
