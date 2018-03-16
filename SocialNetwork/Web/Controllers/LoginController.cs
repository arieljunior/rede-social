using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web.Models;

namespace Web.Controllers
{
    //[RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        // GET: api/Login
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Login/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]//, Route("CreateLogin")]
        // POST: api/Login
        public HttpResponseMessage CreateLogin([FromBody] LoginViewModel dataLogin)
        {
            var x = dataLogin;

            return Request.CreateResponse(HttpStatusCode.OK, x);
        }

        // PUT: api/Login/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Login/5
        public void Delete(int id)
        {
        }
    }
}
