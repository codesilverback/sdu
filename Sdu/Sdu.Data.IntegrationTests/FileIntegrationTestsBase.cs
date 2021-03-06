﻿using System;
using System.Linq;
using Sdu.Data.Models;
using Sdu.Data.Repositories;
using NUnit.Framework;

namespace Sdu.Data.IntegrationTests
{
    [TestFixture]
    public abstract class FileIntegrationTestsBase
    {
        protected Guid _runId = System.Guid.NewGuid();
         protected abstract string FileName { get; }

        protected string RunFilePath
        {
            get { return String.Format(@"..\..\Files\{0}{1}.ignore", this.FileName, _runId); }
        }

        protected string SourceFilePath {
            get { return String.Format(@"..\..\Files\{0}.txt", this.FileName); }
        }

        [TestFixtureSetUp]
        public void Setup()
        {
            System.IO.File.Copy(SourceFilePath,RunFilePath);
        }


        [TestFixtureTearDown]
        public void Teardown()
        {
            if (System.IO.File.Exists(RunFilePath))
            {
                System.IO.File.Delete(RunFilePath);
            }
        }

        protected void VerifyPerson(BaseFlatFileRepository<Person> sut, Person p, int count, ConsoleOutput co = null)
        {

var  test = new Func<Person, bool>(aa => aa.LastName == p.LastName && aa.FirstName == p.FirstName && aa.FavoriteColor == p.FavoriteColor && aa.DateOfBirth == p.DateOfBirth && aa.Gender == p.Gender);
            var actualCount = sut.AsQueryable().Count(test);
            if (co == null)
            {
                Assert.That(actualCount == count, String.Format("Fail! Expected {0} got {1}", count,actualCount));
            }
            else
            {

                Assert.That(actualCount == count, String.Format("Fail! Expected {0} got {1}", count, actualCount) + Environment.NewLine + co.GetOuput());
            }
        }

        protected void InsertAndVerify(BaseFlatFileRepository<Person> sut, Person p, int count, ConsoleOutput co =null )
        {
            for (var i = 0; i < count; i++)
            {
                sut.Insert(p);
                VerifyPerson(sut, p, i + 1, co);
            }
        }

    }
}