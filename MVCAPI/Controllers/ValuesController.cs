﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DomainModel;
namespace MVCAPI.Controllers
{
    public class ValuesController : ApiController
    {
         IGenericRepository<Questions> RepQ= new GenericRepository<Questions>();
        // GET api/values
        public IEnumerable<Questions> Get()
        {
            return RepQ.GetAll();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
