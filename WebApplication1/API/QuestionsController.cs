using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DomainModel;

namespace WebApplication1.API
{
    public class QuestionsController : ApiController
    {
        // GET: api/Questions
        public IEnumerable<Questions> Get()
        {
            IGenericRepository<Questions> RepQ = new GenericRepository<Questions>();
            List<Questions> ListQ = RepQ.GetAll().ToList();
            return ListQ;

            //return new string[] { "value1", "value2" };
        }

        // GET: api/Questions/5
        public Questions Get(int id)
        {
            IGenericRepository<Questions> RepQ = new GenericRepository<Questions>();
            Questions question = RepQ.FindBy(item => item.Id == id).FirstOrDefault();
            return question;
        }

        // POST: api/Questions
        public void Post([FromBody]Questions quetstion)
        {
            if (quetstion.Question != null || quetstion.UserMail != null || quetstion.UserName != null)
            {
                IGenericRepository<Questions> RepQ = new GenericRepository<Questions>();
                quetstion.TimeQuestion = DateTime.Now;
                RepQ.Add(quetstion);
                RepQ.Save();

            }
    
        }

        // PUT: api/Questions/5
        public void Put(int id, [FromBody]Questions quetstion)
        {
            if (quetstion != null || quetstion.UserMail != null || quetstion.UserName != null)
            {
                IGenericRepository<Questions> RepQ = new GenericRepository<Questions>();
                RepQ.Edit(quetstion);
                RepQ.Save();
            } 
        }

        // DELETE: api/Questions/5
        public void Delete(int id)
        {
            IGenericRepository<Questions> RepQ = new GenericRepository<Questions>();
            Questions quetstion = RepQ.FindBy(item => item.Id == id).FirstOrDefault();
            RepQ.Delete(quetstion);
            RepQ.Save();
        }
    }
}
