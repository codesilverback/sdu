﻿using System;
using System.Linq;
using Sdu.Data.Models;
using Sdu.Data.Repositories;
using NUnit.Framework;

namespace Sdu.Data.IntegrationTests
{
    [TestFixture]
    public class CommaIntegrationTests
    {
        [Test]
        public void SimpleNoQuotes()
        {
            var sut = new CommaDelimitedDataRepository<Person>(new FileProvider(@"..\..\Files\Commas_Simple.txt"));
            Assert.That(sut.AsQueryable().First().FirstName == "Hillary", String.Format("expected Hillary, , got {0}", sut.AsQueryable().First().FirstName));
            Assert.That(sut.AsQueryable().Count() == 100, String.Format("expected 100 rows, got {0}", sut.AsQueryable().Count()));

        }

        [Test]
        public void Quotes()
        {
            var sut = new CommaDelimitedDataRepository<Person>(new FileProvider(@"..\..\Files\Commas_Quotes.txt"));
            Assert.That(sut.AsQueryable().First().FirstName == "Hillary", String.Format("expected Hillary, , got {0}", sut.AsQueryable().First().FirstName));
            Assert.That(sut.AsQueryable().Count() == 100, String.Format("expected 100 rows, got {0}", sut.AsQueryable().Count()));

        }

    }
}