using NUnit.Framework;
using Sdu.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using Moq;
using Sdu.Data.Models;
using Sdu.Data.Repositories;
using Sdu.WebApi.Models;

namespace Sdu.WebApi.Controllers.UnitTests
{
    [TestFixture()]
    public class RecordsControllerUnitTests
    {

        private List<Person> PersonList()
        {
            return new List<Person>()
            {
                new Person()
                {


                    FirstName = "Bob",
                    LastName = "Loblaw",
                    Gender = "male",
                    FavoriteColor = "indigo",
                    DateOfBirth = new DateTime(1960,09,22)
                     },

                new Person()
                {


                    FirstName = "Lucille",
                    LastName = "Bluth",
                    Gender = "female",
                    FavoriteColor = "red",
                    DateOfBirth = new DateTime(1921,10,22)
                                    },
                new Person()
                {


                    FirstName = "Lindsay Bluth",
                    LastName = "Funke",
                    Gender = "female",
                    FavoriteColor = "blue",
                    DateOfBirth =  new DateTime(1973,1,31)
                }

            };

       
    }

        private IQueryable<Person> CastIt(HttpResponseMessage resp)
        {

            //holy casting batman!
            var retval = (resp.Content as ObjectContent).Value;

            return (retval as IEnumerable<Person>).AsQueryable<Person>();

        }

        [Test()]
        public void GenderUnitTest()
        {
            var mockRepo = new Moq.Mock<IRepository<Person>>();
            mockRepo.Setup(aa=>aa.AsQueryable()).Returns( PersonList().AsQueryable<Person>());

            var controller = new RecordsController(mockRepo.Object);

var result =             controller.Gender();

       
            Assert.That(CastIt(result)!=null);

            Assert.That(CastIt(result).First().Gender=="female");
            Assert.That(CastIt(result).Last().Gender == "male"); 
        }


        [Test()]
        public void DOBUnitTest()
        {
            var mockRepo = new Moq.Mock<IRepository<Person>>();
            mockRepo.Setup(aa => aa.AsQueryable()).Returns(PersonList().AsQueryable<Person>());

            var controller = new RecordsController(mockRepo.Object);

            var result = controller.BirthDate();

            Assert.That(result != null);

            Assert.That(CastIt(result) != null);

            Assert.That(CastIt(result).First().FirstName == "Lucille");
            Assert.That(CastIt(result).Last().FirstName == "Lindsay Bluth");
        }


        [Test()]
        public void NameUnitTest()
        {
            var mockRepo = new Moq.Mock<IRepository<Person>>();
            mockRepo.Setup(aa => aa.AsQueryable()).Returns(PersonList().AsQueryable<Person>());

            var controller = new RecordsController(mockRepo.Object);

            var result = controller.LastName();

            Assert.That(result != null);


            Assert.That(CastIt(result) != null);

            Assert.That(CastIt(result).First().FirstName == "Bob");
            Assert.That(CastIt(result).Last().FirstName == "Lucille");
        }


        [Test()]
        public void PostUnitTest()
        {
            var mockFileProvider = new Mock<IFileProvider>();
            mockFileProvider.Setup(aa => aa.AppendLineToFile(It.IsAny<string>()));
            var repo = new SpaceDelimitedDataRepository<Person>(mockFileProvider.Object);

             var rec = new Record()
            {
                FirstName = "Bob",
                LastName = "Loblaw",
                Gender = "male",
                FavoriteColor = "indigo",
                DateOfBirth = new DateTime(2016, 10, 22)
            };

            var controller = new RecordsController(repo);
            var response = controller.Post(rec);

            mockFileProvider.Verify(aa => aa.AppendLineToFile(It.IsAny<string>()), Times.Once);
            mockFileProvider.Verify(aa => aa.AppendLineToFile(It.Is<string>(bb => bb == "\"Loblaw\" \"Bob\" \"male\" \"indigo\" \"10/22/2016\"")));
             
        }
      
    }
}