using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Sdu.Data.Repositories;
using Sdu.WebApi.Models;
using Sdu.Data.Models;

namespace Sdu.WebApi.Controllers
{
    public class RecordsController : ApiController
    {
        [Route("records/gender")]
        [AcceptVerbs("get")]
        public IEnumerable<Person> Gender()
        {
           //todo:  windsor this.  also, don't return a data object or hardcode the path.  That's stupid.

    var repo = new Sdu.Data.Repositories.PipeDelimitedDataRepository<Person>(new FileProvider(@"C:\git\sdu\Sdu\Sdu.Data.IntegrationTests\Files"));

    return repo.AsQueryable().OrderBy(aa => aa.Gender);
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}