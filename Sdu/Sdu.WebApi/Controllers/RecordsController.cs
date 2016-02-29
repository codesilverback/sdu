using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.UI.WebControls;
using Sdu.Data.Repositories;
using Sdu.WebApi.Models;
using Sdu.Data.Models;

namespace Sdu.WebApi.Controllers
{
    public class RecordsController : ApiController
    {
        
        //todo:  windsor this.  also, don't return a data object or hardcode the path.  That's stupid.
        private IRepository<Person> _recordsRepository  ;


        public RecordsController()
        {
                _recordsRepository = new PipeDelimitedDataRepository<Person>(new FileProvider(@"C:\git\sdu\Sdu\Sdu.Data.IntegrationTests\Files\Pipes_web.txt"));

        }

        public RecordsController(IRepository<Person> repository)
        {
            _recordsRepository = repository;
        }

        [Route("records/gender")]
        [AcceptVerbs("get")]
        public HttpResponseMessage Gender()
        {
          return OKRecordsResponse(
            _recordsRepository.AsQueryable()
                    .OrderBy(aa => aa.Gender).ToList());
        
        }


        [Route("records/birthdate")]
        [AcceptVerbs("get")]
        public HttpResponseMessage BirthDate()
        {
            return OKRecordsResponse(
            _recordsRepository.AsQueryable().OrderBy(aa => aa.DateOfBirth).ToList());
        }

        [Route("records/name")]
        [AcceptVerbs("get")]
        public HttpResponseMessage LastName()
        {
            return OKRecordsResponse(
            _recordsRepository.AsQueryable().OrderByDescending(aa => aa.LastName).ToList());
        }


        private HttpResponseMessage OKRecordsResponse(IEnumerable<Person> result)
        {
            var msg = new HttpResponseMessage(HttpStatusCode.OK);
            msg.Content = new ObjectContent(
                typeof(IEnumerable<Person>),result, new JsonMediaTypeFormatter());
            return msg;

        }   

        [Route("records")]
        [AcceptVerbs("Post")]
        public HttpResponseMessage Post(Models.Record value)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var p = new Person();
                    p.FirstName = value.FirstName;
                    p.LastName = value.LastName;
                    p.Gender = value.Gender;
                    p.FavoriteColor = value.FavoriteColor;
                    p.DateOfBirth = value.DateOfBirth;
                    _recordsRepository.Insert(p);
                   return  new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                {
                    return new  HttpResponseMessage(HttpStatusCode.BadRequest);
                }
            }
            catch (Exception)
            {

                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

    }
}