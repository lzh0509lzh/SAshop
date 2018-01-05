using Fm.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SaAPI.Controllers
{
    public class ValuesController : ApiController
    {
        [HttpPost]
        [Route("Test/{id}")]        
        public IHttpActionResult Test(int id)
        {
            LzHandle Handle = new LzHandle();
            string strJson = Handle.GetProductinfo();
            return Ok(strJson);
        }
    }
}
