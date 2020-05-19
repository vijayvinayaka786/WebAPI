using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AuthenticationInWebAPI.Controllers
{
    [Route("V2")]
    public class ValuesV2Controller : ApiController
    {
        // GET: api/ValuesV2
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
       
        // GET: api/ValuesV2/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ValuesV2
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ValuesV2/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ValuesV2/5
        public void Delete(int id)
        {
        }

        public HttpResponseMessage TestResponseMessage()
        {
            HttpResponseMessage test = new HttpResponseMessage(HttpStatusCode.OK);          
            return test;
        }

        public IHttpActionResult TestActionResult()
        {
            return Ok();
        }
    }
}
