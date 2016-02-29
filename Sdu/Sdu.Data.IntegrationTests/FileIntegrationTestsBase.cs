using System;
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

        protected void VerifyPerson(BaseFlatFileRepository<Person> sut, Person p, int count)
        {
            Assert.That(sut.AsQueryable().Count(aa => aa.LastName == p.LastName) == count);
            Assert.That(sut.AsQueryable().Count(aa => aa.FirstName == p.FirstName) == count);
            Assert.That(sut.AsQueryable().Count(aa => aa.FavoriteColor == p.FavoriteColor) == count);
            Assert.That(sut.AsQueryable().Count(aa => aa.DateOfBirth == p.DateOfBirth) == count);
            Assert.That(sut.AsQueryable().Count(aa => aa.Gender == p.Gender) == count);

        }

    }
}