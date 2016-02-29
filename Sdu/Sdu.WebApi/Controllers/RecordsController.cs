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
        
        //todo:  windsor this.  also, don't return a data object or hardcode the path.  That's stupid.
        private IRepository<Person> _recordsRepository  = new PipeDelimitedDataRepository<Person>(new FileProvider(@"C:\git\sdu\Sdu\Sdu.Data.IntegrationTests\Files\Pipes_web.txt"));

        [Route("records/gender")]
        [AcceptVerbs("get")]
        public IEnumerable<Person> Gender()
        {
            return
                _recordsRepository.AsQueryable()
                    .OrderBy(aa => aa.Gender)
                    .ThenBy(aa => aa.LastName)
                    .ThenBy(aa => aa.FirstName)
                    .ThenBy(aa => aa.DateOfBirth);
        }


        [Route("records")]
        [AcceptVerbs("Post")]
        public void Post([FromBody] Models.Record value)
        {
            var p = new Person();
            p.FirstName = value.FirstName;
            p.LastName = value.LastName;
            p.Gender = value.Gender;
            p.FavoriteColor = value.FavoriteColor;
            p.DateOfBirth = value.DateOfBirth.ToString();
            _recordsRepository.Insert(p);

        }

    }
}