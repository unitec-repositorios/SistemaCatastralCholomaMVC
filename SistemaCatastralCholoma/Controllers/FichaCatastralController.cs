using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SistemaCatastralCholoma.Controllers
{
    public class FichaCatastralController : ApiController
    {
        // GET: api/FichaCatastral
        [HttpGet]
        public HttpResponseMessage GetAllFichaCatastral()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/FichaCatastral/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/FichaCatastral
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/FichaCatastral/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/FichaCatastral/5
        public void Delete(int id)
        {
        }
    }
}
