using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Sdu.Data.Models;
using Sdu.Data.Repositories;
using NUnit.Framework;

namespace Sdu.Data.IntegrationTests
{
    [TestFixture]
    public class SpacesIntegrationTests :FileIntegrationTestsBase
    { 
       protected override string FileName{get { return "Spaces"; }
        }


        [Test]
        public void SimpleNoQuotes()
        {
            var sut = new SpaceDelimitedDataRepository<Person>(new FileProvider(@"..\..\Files\Spaces.txt"));
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
                DateOfBirth = new DateTime(1972,10,21)
            };


            var sut = new SpaceDelimitedDataRepository<Person>(new FileProvider(RunFilePath));
            InsertAndVerify(sut, p, 100);

        }



    }
}