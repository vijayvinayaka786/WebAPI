using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AuthenticationInWebAPI.Controllers
{
    //[Authorize]

    [RoutePrefix("V1")]
    public class ValuesController : ApiController
    {
        // GET api/values

        [AcceptVerbs("Get", "Head")]
        public IEnumerable<string> GetData()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5

        [Route("")]
        public string Get(int id)
        {
            return "value";
        }

        [Route("{name}")]
        public string GetStudent(string name)
        {
            Delete(1);
            return name;
        }

        // POST api/values
        ///[AcceptVerbs("put", "options")]
        //public string Post([FromBody]string value)
        //{
        //    return value;
        //}

        public string HelloWorld([FromBody]string value)
        {
            return value;
        }

        [HttpOptions]
        public string GetOptionsAction()
        {
            return "GetOptionsAction";
        }

     
        // PUT api/values/5
        //public string Put(int id, [FromBody]string value)
        //{
        //    return id.ToString()+""+value;
        //}

        // DELETE api/values/5
        public int Delete(int id)
        {
            return id;
        }        
    }
}
