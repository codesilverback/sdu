using System;
using System.Linq;
using Sdu.Data.Models;
using Sdu.Data.Repositories;
using NUnit.Framework;

namespace Sdu.Data.IntegrationTests
{
    [TestFixture]
    public class PipeIntegrationTests:FileIntegrationTestsBase
    {

        protected override string FileName {
            get { return "Pipes"; }
        }
        [Test]
        public void SimpleNoQuotes()
        {
            var sut = new PipeDelimitedDataRepository<Person>(new FileProvider(@"..\..\Files\Pipes.txt"));
            Assert.That(sut.AsQueryable().First().FirstName == "Hillary", String.Format("expected Hillary, , got {0}", sut.AsQueryable().First().FirstName));
            Assert.That(sut.AsQueryable().Count() == 100, String.Format("expected 100 rows, got {0}", sut.AsQueryable().Count()));

        }

        [Test]
        public void Quotes()
        {
            var sut = new PipeDelimitedDataRepository<Person>(new FileProvider(@"..\..\Files\Pipes_Quotes.txt"));
            Assert.That(sut.AsQueryable().First().FirstName == "Hillary", String.Format("expected Hillary, , got {0}", sut.AsQueryable().First().FirstName));
            Assert.That(sut.AsQueryable().Count() == 100, String.Format("expected 100 rows, got {0}", sut.AsQueryable().Count()));
        }

        [Test]

        public void SimpleInsert()
        {
            var p = new Person()
            {
                FirstName = "Bob",
                LastName = "Loblaw",
                Gender = "male",
                FavoriteColor = "indigo",
                DateOfBirth = "10/22/2016"
            };


            var sut = new PipeDelimitedDataRepository<Person>(new FileProvider(RunFilePath));
            InsertAndVerify(sut, p, 100);

        }
    }
}