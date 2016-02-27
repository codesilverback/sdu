﻿using System;
using System.Linq;
using Sdu.Data.Models;
using Sdu.Data.Repositories;
using NUnit.Framework;

namespace Sdu.Data.IntegrationTests
{
    [TestFixture]
    public class SpacesIntegrationTests :FileIntegrationTestsBase
    {
        private Guid _runId = System.Guid.NewGuid();
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
                DateOfBirth = "10/22/2016"
            };


            var sut = new SpaceDelimitedDataRepository<Person>(new FileProvider(RunFilePath));
            sut.Insert(p);
            Assert.That(sut.AsQueryable().Count(aa => aa.LastName == "Loblaw") == 1);
            sut.Insert(p);
            Assert.That(sut.AsQueryable().Count(aa => aa.LastName == "Loblaw") == 2);
        }


    }
}