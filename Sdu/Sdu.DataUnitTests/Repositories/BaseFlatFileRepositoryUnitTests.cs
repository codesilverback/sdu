using NUnit.Framework;
using Sdu.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdu.Data.Models;

namespace Sdu.Data.Repositories.UnitTests
{
    [TestFixture()]
    public class BaseFlatFileRepositoryUnitTests
    {
        [Test()]
        public void LoadDataUnitTestSimpleHappyPath()
        {
            var sut = new PipeDelimitedDataRepository<Person>(null);
            var result = sut.SplitLine("foo|bar");
            Assert.That(result.Length == 2);
            Assert.That(result[0] == "foo");
            Assert.That(result[1] == "bar");
        }


        [Test()]
        public void LoadDataUnitTestSimpleCommasInData()
        {
            var sut = new PipeDelimitedDataRepository<Person>(null);
            var result = sut.SplitLine("foo,foo|bar");
            Assert.That(result.Length == 2);
            Assert.That(result[0] == "foo,foo");
            Assert.That(result[1] == "bar");
        }

       
    }
}