using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Threading;
using Sdu.Data.Models;
using Sdu.Data.Repositories;
using NUnit.Framework;

namespace Sdu.Data.IntegrationTests
{
    [TestFixture]
    public class CommaIntegrationTests : FileIntegrationTestsBase
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

        [Test]

        public void SimpleInsert()
        {
            using (var co = new ConsoleOutput())
            {
                var p = new Person()
                {
                    FirstName = "Bob",
                    LastName = "Loblaw",
                    Gender = "male",
                    FavoriteColor = "indigo",
                    DateOfBirth = "10/22/2016"
                };

                var sut = new CommaDelimitedDataRepository<Person>(new FileProvider(this.RunFilePath));

                InsertAndVerify(sut, p, 100,co);
            }
        }

        public static void LockAndWait(string filePath, int holdLockForHowManyMilliseconds)
        {


            Console.WriteLine("locking file...");
            var fileLock = System.IO.File.OpenWrite(filePath);
            System.Threading.Thread.Sleep(holdLockForHowManyMilliseconds);
            fileLock.Close();
            fileLock.Dispose();
            Console.WriteLine("file unlocked...");
        }

        [Test]

        public void LockedFileTest()
        {


            var p = new Person()
            {
                FirstName = "Tobias",
                LastName = "Fünke",
                Gender = "male",
                FavoriteColor = "red",
                DateOfBirth = "10/21/1974"
            };

            using (var co = new ConsoleOutput())
            {
                var sut = new CommaDelimitedDataRepository<Person>(new FileProvider(this.RunFilePath));

                Thread t = new Thread(() =>
                {
                    LockAndWait(this.RunFilePath, 2000);
                });

                t.Start();
                Console.WriteLine("testing insert #1");
                InsertAndVerify(sut, p, 1, co);
                Console.WriteLine("testing insert #2");
                sut.Insert(p);
VerifyPerson(sut,p,2,co);

            }
        }

        protected override string FileName
        {
            get { return "Commas_Quotes"; }
        }
    }
}