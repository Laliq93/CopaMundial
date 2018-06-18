using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CopaMundialAPI.Comun.Entidades;

namespace CopaMundialAPI.Controllers
{
    [RoutePrefix ( "api/Test" )]
    public class TestController : ApiController
    {
        [Route ( "Testing/{hola}" )]
        [System.Web.Http.AcceptVerbs ( "GET", "PUT" )]
        [System.Web.Http.HttpPut]
        public HttpResponseMessage Testing ( string hola )
        {
            return Request.CreateResponse ( HttpStatusCode.OK, "String: " + hola );
        }
    }
}
