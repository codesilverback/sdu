using NUnit.Framework;
using Sdu.WebApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks; 
namespace Sdu.WebApi.Models.UnitTests
{
    [TestFixture()]
    public class ValidationTests
    {

        private Record GetValidRecord()
        {
            return  new Record()
              {
                  FirstName = "Tobias",
                  LastName = "Fünke",
                  Gender = "male",
                  FavoriteColor = "red",
                  DateOfBirth = new DateTime(1970,1,2)
              };
         
        }

        public void AssertValid(Record r, bool shouldBeValid)
        {
            var vr = new List<ValidationResult>();
            var context = new ValidationContext(r, serviceProvider: null, items: null);
            var isValid = Validator.TryValidateObject(r, context, vr,true);


            if (vr.Any())
            {
                Assert.That(isValid == shouldBeValid, vr.Select(aa => aa.ErrorMessage).Aggregate((i, j) => i + j));
            }
            else
            {
                Assert.That(isValid == shouldBeValid);
            }
        }

        [Test()]
        public void ModelValidation_BadDate()
        {
            var p = GetValidRecord();
            p.DateOfBirth = DateTime.UtcNow.AddHours(1);
            AssertValid(p,false);

            p.DateOfBirth = DateTime.UtcNow.AddYears(-123);
            AssertValid(p, false);

            p.DateOfBirth = DateTime.UtcNow.AddYears(-42);
            AssertValid(p, true);

        }

        [Test()]
        public void ModelValidation_LastName()
        {
            var p = GetValidRecord();
            p.LastName=string.Empty;
            AssertValid(p, false);

            p.LastName = "Wolfe­schlegel­stein­hausen­berger­dorff­welche­vor­altern­waren­gewissen­haft­schafers­wessen­schafe­waren­wohl­gepflege­und­sorg­faltig­keit­be­schutzen­vor­an­greifen­durch­ihr­raub­gierig­feinde­welche­vor­altern­zwolf­hundert­tausend­jah­res­voran­die­er­scheinen­von­der­erste­erde­mensch­der­raum­schiff­genacht­mit­tung­stein­und­sieben­iridium­elek­trisch­motors­ge­brauch­licht­als­sein­ur­sprung­von­kraft­ge­start­sein­lange­fahrt­hin­zwischen­stern­artig­raum­auf­der­suchen­nach­bar­schaft­der­stern­welche­ge­habt­be­wohn­bar­planeten­kreise­drehen­sich­und­wo­hin­der­neue­rasse­von­ver­stand­ig­mensch­lich­keit­konnte­fort­pflanzen­und­sicher­freuen­an­lebens­lang­lich­freude­und­ru­he­mit­nicht­ein­furcht­vor­an­greifen­vor­anderer­intelligent­ge­schopfs­von­hin­zwischen­stern­art­ig­raum";
            AssertValid(p, false);

            p.LastName = "Wolfe";
            AssertValid(p, true);

        }

        [Test()]
        public void ModelValidation_FirstName()
        {
            var p = GetValidRecord();
            p.FirstName = string.Empty;
            AssertValid(p, false);

            p.FirstName =
                "Barnaby Marmaduke Aloysius Benjy Cobweb Dartagnan Egbert Felix Gaspar Humbert Ignatius Jayden Kasper Leroy Maximilian Neddy Obiajulu Pepin Quilliam Rosencrantz Sexton Teddy Upwood Vivatma Wayland Xylon Yardley Zachary Neddy Obiajulu Pepin Quilliam Rosencrantz Sexton Teddy Neddy Obiajulu Pepin Quilliam Rosencrantz Sexton Teddy";
            AssertValid(p, false);

            p.FirstName = "Steve";
            AssertValid(p, true);

        }

        [Test()]
        public void ModelValidation_Gender()
        {
            var p = GetValidRecord();
            p.Gender = string.Empty;
            AssertValid(p, false);

            p.Gender = "your categories cannot contain me.";
            AssertValid(p, false);

            p.Gender = "female";
            AssertValid(p, true);

            p.Gender = "male";
            AssertValid(p, true);

            p.Gender = "Male";
            AssertValid(p, true);
        }

    }
}