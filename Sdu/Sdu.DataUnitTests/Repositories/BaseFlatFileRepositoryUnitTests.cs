﻿using System;
using System.Dynamic;
using System.Linq;
using Moq;
using NUnit.Framework;
using Sdu.Data.Models;
using Sdu.Data.Repositories;

 
namespace Sdu.DataUnitTests.Repositories
{
    [TestFixture()]
    public class BaseFlatFileRepositoryUnitTests
    {
 
        private string[] BigListOfFakeData_Pipes()
        {
            return  new[] {
            #region "big-ass list"
            
            "LastName|FirstName|Gender|FavoriteColor|DateOfBirth",
            "Holcomb|Hillary|male|red|12/23/2015",
            "Bolton|Hyacinth|male|indigo|07/12/2015",
            "Rogers|Madonna|male|violet|04/10/2016",
            "Norton|Lacy|male|red|09/02/2016",
            "Floyd|Jaden|male|green|02/22/2017",
            "Woods|Wylie|male|indigo|05/26/2016",
            "Roberts|Derek|male|yellow|09/06/2016",
            "Cook|Basia|male|yellow|01/05/2016",
            "Hogan|Stewart|male|green|10/05/2015",
            "Poole|Ramona|male|orange|05/22/2016",
            "Nguyen|Darrel|female|indigo|10/16/2016",
            "Butler|Ivy|female|indigo|10/12/2015",
            "Cochran|Wang|female|orange|05/13/2015",
            "Tucker|Drew|female|violet|12/21/2015",
            "Hurst|Jack|female|indigo|12/09/2016",
            "Ellis|Amena|female|blue|01/24/2016",
            "Evans|Claudia|female|red|09/30/2016",
            "Weeks|Jescie|female|blue|02/15/2016",
            "Eaton|Leroy|female|green|02/12/2016",
            "Fletcher|Dominic|female|violet|06/03/2016",
            "Peterson|Rose|male|indigo|08/19/2016",
            "Barber|Leah|male|violet|11/10/2016",
            "Hammond|Sylvia|male|yellow|01/02/2016",
            "Norris|Wang|male|red|09/04/2016",
            "Holman|Dora|male|yellow|06/02/2016",
            "Mckinney|Ruth|male|blue|10/05/2016",
            "Keith|Scott|male|violet|05/10/2015",
            "Jarvis|Fay|male|green|06/13/2015",
            "Davidson|Kasper|male|blue|08/11/2015",
            "Hoover|Janna|male|green|05/14/2016",
            "Mckay|Amos|female|red|12/14/2015",
            "Todd|Noble|female|orange|07/22/2016",
            "Foster|Jane|female|yellow|05/04/2015",
            "West|Alma|female|green|02/14/2017",
            "Lester|Francis|female|green|12/16/2015",
            "Mcgee|Ramona|female|violet|08/16/2016",
            "Cleveland|Jana|female|red|12/20/2015",
            "Fulton|Quon|female|red|07/23/2015",
            "Duke|Ulric|female|blue|06/29/2016",
            "Mays|Jade|female|blue|07/29/2016",
            "Wynn|Iona|male|yellow|06/09/2016",
            "Mayer|Emily|male|green|03/05/2015",
            "Rios|Amber|male|orange|03/25/2016",
            "Berger|Kenneth|male|orange|12/26/2015",
            "Perkins|Tyrone|male|orange|06/26/2016",
            "Walker|Lacy|male|orange|06/20/2016",
            "Norris|Rae|male|indigo|05/23/2016",
            "Norman|Harrison|male|green|06/04/2016",
            "Cummings|Dahlia|male|violet|04/29/2016",
            "Zimmerman|Jason|male|green|10/06/2015",
            "Lambert|Miranda|female|violet|07/26/2016",
            "Moore|Celeste|female|green|11/21/2015",
            "Marshall|Caleb|female|orange|06/26/2015",
            "Horton|Cain|female|orange|09/09/2016",
            "Armstrong|Mona|female|indigo|08/10/2016",
            "Gilmore|Roanna|female|red|01/11/2016",
            "Elliott|Upton|female|orange|02/06/2016",
            "Burgess|Nolan|female|violet|07/31/2016",
            "Preston|Gavin|female|red|02/26/2017",
            "Weber|Kelly|female|green|11/17/2016",
            "Baker|Tatiana|male|green|04/10/2016",
            "Rhodes|Quail|male|green|11/10/2016",
            "Schwartz|Iris|male|violet|10/06/2015",
            "Lancaster|Derek|male|yellow|12/14/2015",
            "Snider|Phoebe|male|red|11/20/2016",
            "Camacho|Sydnee|male|green|02/09/2017",
            "Short|Magee|male|orange|09/14/2016",
            "Craig|Silas|male|violet|12/04/2015",
            "Oneal|Theodore|male|violet|05/21/2016",
            "Beard|Abel|male|indigo|10/22/2016",
            "Fitzpatrick|Octavius|female|yellow|02/21/2017",
            "Sweeney|Lydia|female|green|03/16/2015",
            "Cooke|Maris|female|indigo|07/20/2015",
            "Bowman|Lareina|female|green|10/30/2016",
            "Porter|Wang|female|green|11/25/2015",
            "Franco|Sasha|female|indigo|06/08/2015",
            "Young|Hop|female|yellow|07/02/2015",
            "Jordan|Kay|female|red|07/03/2016",
            "Robertson|Astra|female|yellow|09/12/2016",
            "Swanson|Jordan|female|indigo|08/22/2015",
            "Tate|Justin|male|orange|09/15/2016",
            "Dunlap|Robin|male|orange|10/27/2016",
            "Bernard|Quintessa|male|red|08/17/2016",
            "Romero|David|male|indigo|08/02/2016",
            "Donaldson|Ora|male|red|12/10/2015",
            "Frank|Latifah|male|indigo|06/09/2016",
            "Garner|Jamalia|male|blue|05/02/2016",
            "Byers|Xenos|male|red|09/21/2016",
            "Brock|Hu|male|green|08/09/2015",
            "Mcclure|Andrew|male|orange|12/01/2016",
            "Hughes|Nigel|female|red|06/29/2015",
            "Ayala|Callum|female|violet|07/03/2016",
            "Fowler|Wade|female|indigo|12/06/2016",
            "Head|Rhea|female|green|09/21/2015",
            "Bullock|Cherokee|female|green|08/17/2015",
            "Woodard|Christine|female|blue|04/05/2015",
            "Shaw|Vanna|female|yellow|06/20/2016",
            "Shepard|Suki|female|violet|10/28/2016",
            "Gomez|Melinda|female|red|06/12/2016",
            "Juarez|Joan|female|violet|01/22/2016",

            #endregion
            };
        }

        private string[] BigListOfFakeData_CSV()
        {
            return new[] {
            #region "big-ass list"
            
            "LastName,FirstName,Gender,FavoriteColor,DateOfBirth",
            "Holcomb,Hillary,male,red,12/23/2015",
            "Bolton,Hyacinth,male,indigo,07/12/2015",
            "Rogers,Madonna,male,violet,04/10/2016",
            "Norton,Lacy,male,red,09/02/2016",
            "Floyd,Jaden,male,green,02/22/2017",
            "Woods,Wylie,male,indigo,05/26/2016",
            "Roberts,Derek,male,yellow,09/06/2016",
            "Cook,Basia,male,yellow,01/05/2016",
            "Hogan,Stewart,male,green,10/05/2015",
            "Poole,Ramona,male,orange,05/22/2016",
            "Nguyen,Darrel,female,indigo,10/16/2016",
            "Butler,Ivy,female,indigo,10/12/2015",
            "Cochran,Wang,female,orange,05/13/2015",
            "Tucker,Drew,female,violet,12/21/2015",
            "Hurst,Jack,female,indigo,12/09/2016",
            "Ellis,Amena,female,blue,01/24/2016",
            "Evans,Claudia,female,red,09/30/2016",
            "Weeks,Jescie,female,blue,02/15/2016",
            "Eaton,Leroy,female,green,02/12/2016",
            "Fletcher,Dominic,female,violet,06/03/2016",
            "Peterson,Rose,male,indigo,08/19/2016",
            "Barber,Leah,male,violet,11/10/2016",
            "Hammond,Sylvia,male,yellow,01/02/2016",
            "Norris,Wang,male,red,09/04/2016",
            "Holman,Dora,male,yellow,06/02/2016",
            "Mckinney,Ruth,male,blue,10/05/2016",
            "Keith,Scott,male,violet,05/10/2015",
            "Jarvis,Fay,male,green,06/13/2015",
            "Davidson,Kasper,male,blue,08/11/2015",
            "Hoover,Janna,male,green,05/14/2016",
            "Mckay,Amos,female,red,12/14/2015",
            "Todd,Noble,female,orange,07/22/2016",
            "Foster,Jane,female,yellow,05/04/2015",
            "West,Alma,female,green,02/14/2017",
            "Lester,Francis,female,green,12/16/2015",
            "Mcgee,Ramona,female,violet,08/16/2016",
            "Cleveland,Jana,female,red,12/20/2015",
            "Fulton,Quon,female,red,07/23/2015",
            "Duke,Ulric,female,blue,06/29/2016",
            "Mays,Jade,female,blue,07/29/2016",
            "Wynn,Iona,male,yellow,06/09/2016",
            "Mayer,Emily,male,green,03/05/2015",
            "Rios,Amber,male,orange,03/25/2016",
            "Berger,Kenneth,male,orange,12/26/2015",
            "Perkins,Tyrone,male,orange,06/26/2016",
            "Walker,Lacy,male,orange,06/20/2016",
            "Norris,Rae,male,indigo,05/23/2016",
            "Norman,Harrison,male,green,06/04/2016",
            "Cummings,Dahlia,male,violet,04/29/2016",
            "Zimmerman,Jason,male,green,10/06/2015",
            "Lambert,Miranda,female,violet,07/26/2016",
            "Moore,Celeste,female,green,11/21/2015",
            "Marshall,Caleb,female,orange,06/26/2015",
            "Horton,Cain,female,orange,09/09/2016",
            "Armstrong,Mona,female,indigo,08/10/2016",
            "Gilmore,Roanna,female,red,01/11/2016",
            "Elliott,Upton,female,orange,02/06/2016",
            "Burgess,Nolan,female,violet,07/31/2016",
            "Preston,Gavin,female,red,02/26/2017",
            "Weber,Kelly,female,green,11/17/2016",
            "Baker,Tatiana,male,green,04/10/2016",
            "Rhodes,Quail,male,green,11/10/2016",
            "Schwartz,Iris,male,violet,10/06/2015",
            "Lancaster,Derek,male,yellow,12/14/2015",
            "Snider,Phoebe,male,red,11/20/2016",
            "Camacho,Sydnee,male,green,02/09/2017",
            "Short,Magee,male,orange,09/14/2016",
            "Craig,Silas,male,violet,12/04/2015",
            "Oneal,Theodore,male,violet,05/21/2016",
            "Beard,Abel,male,indigo,10/22/2016",
            "Fitzpatrick,Octavius,female,yellow,02/21/2017",
            "Sweeney,Lydia,female,green,03/16/2015",
            "Cooke,Maris,female,indigo,07/20/2015",
            "Bowman,Lareina,female,green,10/30/2016",
            "Porter,Wang,female,green,11/25/2015",
            "Franco,Sasha,female,indigo,06/08/2015",
            "Young,Hop,female,yellow,07/02/2015",
            "Jordan,Kay,female,red,07/03/2016",
            "Robertson,Astra,female,yellow,09/12/2016",
            "Swanson,Jordan,female,indigo,08/22/2015",
            "Tate,Justin,male,orange,09/15/2016",
            "Dunlap,Robin,male,orange,10/27/2016",
            "Bernard,Quintessa,male,red,08/17/2016",
            "Romero,David,male,indigo,08/02/2016",
            "Donaldson,Ora,male,red,12/10/2015",
            "Frank,Latifah,male,indigo,06/09/2016",
            "Garner,Jamalia,male,blue,05/02/2016",
            "Byers,Xenos,male,red,09/21/2016",
            "Brock,Hu,male,green,08/09/2015",
            "Mcclure,Andrew,male,orange,12/01/2016",
            "Hughes,Nigel,female,red,06/29/2015",
            "Ayala,Callum,female,violet,07/03/2016",
            "Fowler,Wade,female,indigo,12/06/2016",
            "Head,Rhea,female,green,09/21/2015",
            "Bullock,Cherokee,female,green,08/17/2015",
            "Woodard,Christine,female,blue,04/05/2015",
            "Shaw,Vanna,female,yellow,06/20/2016",
            "Shepard,Suki,female,violet,10/28/2016",
            "Gomez,Melinda,female,red,06/12/2016",
            "Juarez,Joan,female,violet,01/22/2016",

            #endregion
            };
        }

        private string[] BigListOfFakeData_Spaces()
        {

            return new[]
            {
                #region "big-ass list"
"\"LastName\" \"FirstName\" \"Gender\" \"FavoriteColor\" \"DateOfBirth\"",
"\"Holcomb\" \"Hillary\" \"male\" \"red\" \"12/23/2015\"",
"\"Bolton\" \"Hyacinth\" \"male\" \"indigo\" \"07/12/2015\"",
"\"Rogers\" \"Madonna\" \"male\" \"violet\" \"04/10/2016\"",
"\"Norton\" \"Lacy\" \"male\" \"red\" \"09/02/2016\"",
"\"Floyd\" \"Jaden\" \"male\" \"green\" \"02/22/2017\"",
"\"Woods\" \"Wylie\" \"male\" \"indigo\" \"05/26/2016\"",
"\"Roberts\" \"Derek\" \"male\" \"yellow\" \"09/06/2016\"",
"\"Cook\" \"Basia\" \"male\" \"yellow\" \"01/05/2016\"",
"\"Hogan\" \"Stewart\" \"male\" \"green\" \"10/05/2015\"",
"\"Poole\" \"Ramona\" \"male\" \"orange\" \"05/22/2016\"",
"\"Nguyen\" \"Darrel\" \"female\" \"indigo\" \"10/16/2016\"",
"\"Butler\" \"Ivy\" \"female\" \"indigo\" \"10/12/2015\"",
"\"Cochran\" \"Wang\" \"female\" \"orange\" \"05/13/2015\"",
"\"Tucker\" \"Drew\" \"female\" \"violet\" \"12/21/2015\"",
"\"Hurst\" \"Jack\" \"female\" \"indigo\" \"12/09/2016\"",
"\"Ellis\" \"Amena\" \"female\" \"blue\" \"01/24/2016\"",
"\"Evans\" \"Claudia\" \"female\" \"red\" \"09/30/2016\"",
"\"Weeks\" \"Jescie\" \"female\" \"blue\" \"02/15/2016\"",
"\"Eaton\" \"Leroy\" \"female\" \"green\" \"02/12/2016\"",
"\"Fletcher\" \"Dominic\" \"female\" \"violet\" \"06/03/2016\"",
"\"Peterson\" \"Rose\" \"male\" \"indigo\" \"08/19/2016\"",
"\"Barber\" \"Leah\" \"male\" \"violet\" \"11/10/2016\"",
"\"Hammond\" \"Sylvia\" \"male\" \"yellow\" \"01/02/2016\"",
"\"Norris\" \"Wang\" \"male\" \"red\" \"09/04/2016\"",
"\"Holman\" \"Dora\" \"male\" \"yellow\" \"06/02/2016\"",
"\"Mckinney\" \"Ruth\" \"male\" \"blue\" \"10/05/2016\"",
"\"Keith\" \"Scott\" \"male\" \"violet\" \"05/10/2015\"",
"\"Jarvis\" \"Fay\" \"male\" \"green\" \"06/13/2015\"",
"\"Davidson\" \"Kasper\" \"male\" \"blue\" \"08/11/2015\"",
"\"Hoover\" \"Janna\" \"male\" \"green\" \"05/14/2016\"",
"\"Mckay\" \"Amos\" \"female\" \"red\" \"12/14/2015\"",
"\"Todd\" \"Noble\" \"female\" \"orange\" \"07/22/2016\"",
"\"Foster\" \"Jane\" \"female\" \"yellow\" \"05/04/2015\"",
"\"West\" \"Alma\" \"female\" \"green\" \"02/14/2017\"",
"\"Lester\" \"Francis\" \"female\" \"green\" \"12/16/2015\"",
"\"Mcgee\" \"Ramona\" \"female\" \"violet\" \"08/16/2016\"",
"\"Cleveland\" \"Jana\" \"female\" \"red\" \"12/20/2015\"",
"\"Fulton\" \"Quon\" \"female\" \"red\" \"07/23/2015\"",
"\"Duke\" \"Ulric\" \"female\" \"blue\" \"06/29/2016\"",
"\"Mays\" \"Jade\" \"female\" \"blue\" \"07/29/2016\"",
"\"Wynn\" \"Iona\" \"male\" \"yellow\" \"06/09/2016\"",
"\"Mayer\" \"Emily\" \"male\" \"green\" \"03/05/2015\"",
"\"Rios\" \"Amber\" \"male\" \"orange\" \"03/25/2016\"",
"\"Berger\" \"Kenneth\" \"male\" \"orange\" \"12/26/2015\"",
"\"Perkins\" \"Tyrone\" \"male\" \"orange\" \"06/26/2016\"",
"\"Walker\" \"Lacy\" \"male\" \"orange\" \"06/20/2016\"",
"\"Norris\" \"Rae\" \"male\" \"indigo\" \"05/23/2016\"",
"\"Norman\" \"Harrison\" \"male\" \"green\" \"06/04/2016\"",
"\"Cummings\" \"Dahlia\" \"male\" \"violet\" \"04/29/2016\"",
"\"Zimmerman\" \"Jason\" \"male\" \"green\" \"10/06/2015\"",
"\"Lambert\" \"Miranda\" \"female\" \"violet\" \"07/26/2016\"",
"\"Moore\" \"Celeste\" \"female\" \"green\" \"11/21/2015\"",
"\"Marshall\" \"Caleb\" \"female\" \"orange\" \"06/26/2015\"",
"\"Horton\" \"Cain\" \"female\" \"orange\" \"09/09/2016\"",
"\"Armstrong\" \"Mona\" \"female\" \"indigo\" \"08/10/2016\"",
"\"Gilmore\" \"Roanna\" \"female\" \"red\" \"01/11/2016\"",
"\"Elliott\" \"Upton\" \"female\" \"orange\" \"02/06/2016\"",
"\"Burgess\" \"Nolan\" \"female\" \"violet\" \"07/31/2016\"",
"\"Preston\" \"Gavin\" \"female\" \"red\" \"02/26/2017\"",
"\"Weber\" \"Kelly\" \"female\" \"green\" \"11/17/2016\"",
"\"Baker\" \"Tatiana\" \"male\" \"green\" \"04/10/2016\"",
"\"Rhodes\" \"Quail\" \"male\" \"green\" \"11/10/2016\"",
"\"Schwartz\" \"Iris\" \"male\" \"violet\" \"10/06/2015\"",
"\"Lancaster\" \"Derek\" \"male\" \"yellow\" \"12/14/2015\"",
"\"Snider\" \"Phoebe\" \"male\" \"red\" \"11/20/2016\"",
"\"Camacho\" \"Sydnee\" \"male\" \"green\" \"02/09/2017\"",
"\"Short\" \"Magee\" \"male\" \"orange\" \"09/14/2016\"",
"\"Craig\" \"Silas\" \"male\" \"violet\" \"12/04/2015\"",
"\"Oneal\" \"Theodore\" \"male\" \"violet\" \"05/21/2016\"",
"\"Beard\" \"Abel\" \"male\" \"indigo\" \"10/22/2016\"",
"\"Fitzpatrick\" \"Octavius\" \"female\" \"yellow\" \"02/21/2017\"",
"\"Sweeney\" \"Lydia\" \"female\" \"green\" \"03/16/2015\"",
"\"Cooke\" \"Maris\" \"female\" \"indigo\" \"07/20/2015\"",
"\"Bowman\" \"Lareina\" \"female\" \"green\" \"10/30/2016\"",
"\"Porter\" \"Wang\" \"female\" \"green\" \"11/25/2015\"",
"\"Franco\" \"Sasha\" \"female\" \"indigo\" \"06/08/2015\"",
"\"Young\" \"Hop\" \"female\" \"yellow\" \"07/02/2015\"",
"\"Jordan\" \"Kay\" \"female\" \"red\" \"07/03/2016\"",
"\"Robertson\" \"Astra\" \"female\" \"yellow\" \"09/12/2016\"",
"\"Swanson\" \"Jordan\" \"female\" \"indigo\" \"08/22/2015\"",
"\"Tate\" \"Justin\" \"male\" \"orange\" \"09/15/2016\"",
"\"Dunlap\" \"Robin\" \"male\" \"orange\" \"10/27/2016\"",
"\"Bernard\" \"Quintessa\" \"male\" \"red\" \"08/17/2016\"",
"\"Romero\" \"David\" \"male\" \"indigo\" \"08/02/2016\"",
"\"Donaldson\" \"Ora\" \"male\" \"red\" \"12/10/2015\"",
"\"Frank\" \"Latifah\" \"male\" \"indigo\" \"06/09/2016\"",
"\"Garner\" \"Jamalia\" \"male\" \"blue\" \"05/02/2016\"",
"\"Byers\" \"Xenos\" \"male\" \"red\" \"09/21/2016\"",
"\"Brock\" \"Hu\" \"male\" \"green\" \"08/09/2015\"",
"\"Mcclure\" \"Andrew\" \"male\" \"orange\" \"12/01/2016\"",
"\"Hughes\" \"Nigel\" \"female\" \"red\" \"06/29/2015\"",
"\"Ayala\" \"Callum\" \"female\" \"violet\" \"07/03/2016\"",
"\"Fowler\" \"Wade\" \"female\" \"indigo\" \"12/06/2016\"",
"\"Head\" \"Rhea\" \"female\" \"green\" \"09/21/2015\"",
"\"Bullock\" \"Cherokee\" \"female\" \"green\" \"08/17/2015\"",
"\"Woodard\" \"Christine\" \"female\" \"blue\" \"04/05/2015\"",
"\"Shaw\" \"Vanna\" \"female\" \"yellow\" \"06/20/2016\"",
"\"Shepard\" \"Suki\" \"female\" \"violet\" \"10/28/2016\"",
"\"Gomez\" \"Melinda\" \"female\" \"red\" \"06/12/2016\"",
"\"Juarez\" \"Joan\" \"female\" \"violet\" \"01/22/2016\""
                #endregion
            };
        }

        [Test()]
        public void AsQueryableTests_Pipes()
        {
            var fp = new Moq.Mock<IFileProvider>();

            fp.Setup(aa => aa.LoadFileContents()).Returns(BigListOfFakeData_Pipes);

            var sut = new PipeDelimitedDataRepository<Person>(fp.Object);
            Assert.That(sut.AsQueryable().Count() == 100, String.Format("expected 100 rows, got {0}", sut.AsQueryable().Count()));

        }



        [Test()]
        public void AsQueryableTests_Pipes_ActualData()
        {
            var fp = new Moq.Mock<IFileProvider>();

            fp.Setup(aa => aa.LoadFileContents()).Returns(BigListOfFakeData_Pipes);

            var sut = new PipeDelimitedDataRepository<Person>(fp.Object);
            Assert.That(sut.AsQueryable().First().FirstName=="Hillary" , String.Format("expected Hillary, , got {0}", sut.AsQueryable().First().FirstName));

        }


        [Test()]
        public void AsQueryableTests_Comma_ActualData()
        {
            var fp = new Moq.Mock<IFileProvider>();

            fp.Setup(aa => aa.LoadFileContents()).Returns(BigListOfFakeData_CSV);

            var sut = new CommaDelimitedDataRepository<Person>(fp.Object);
            Assert.That(sut.AsQueryable().First().FirstName == "Hillary", String.Format("expected Hillary, , got {0}", sut.AsQueryable().First().FirstName));

        }


        [Test()]
        public void AsQueryableTests_Space_ActualData()
        {
            var fp = new Moq.Mock<IFileProvider>();

            fp.Setup(aa => aa.LoadFileContents()).Returns(BigListOfFakeData_Spaces);

            var sut = new SpaceDelimitedDataRepository<Person>(fp.Object);
            Assert.That(sut.AsQueryable().First().FirstName == "Hillary", String.Format("expected Hillary, , got {0}", sut.AsQueryable().First().FirstName));

        }

        [Test()]
        public void AsQueryableTests_Commas()
        {
            var fp = new Moq.Mock<IFileProvider>();

            fp.Setup(aa => aa.LoadFileContents()).Returns(BigListOfFakeData_CSV);
            var sut = new CommaDelimitedDataRepository<Person>(fp.Object);
            Assert.That(sut.AsQueryable().Count() == 100, String.Format("expected 100 rows, got {0}", sut.AsQueryable().Count()));
        }

        [Test()]
        public void AsQueryableTests_Spaces()
        {
            var fp = new Moq.Mock<IFileProvider>();

            fp.Setup(aa => aa.LoadFileContents()).Returns(BigListOfFakeData_Spaces);

            var sut = new SpaceDelimitedDataRepository<Person>(fp.Object);
            Assert.That(sut.AsQueryable().Count() == 100, String.Format("expected 100 rows, got {0}", sut.AsQueryable().Count()));

        }


        [Test()]
        public void AddTest_Spaces()
        {
            var fp = new Moq.Mock<IFileProvider>();

            fp.Setup(aa => aa.AppendLineToFile(It.Is<string>(bb=> bb== "Bob")));

            var sut = new SpaceDelimitedDataRepository<Person>(fp.Object);
            sut.Insert(new Person()
            {
                FirstName = "Bob",
                LastName = "Loblaw",
                Gender = "male",
                FavoriteColor = "indigo",
                DateOfBirth = "10/22/2016"
            });

            fp.Verify(aa=>aa.AppendLineToFile(It.IsAny<string>()), Times.Once) ;
            fp.Verify(aa => aa.AppendLineToFile(It.Is<string>(bb => bb == "\"Loblaw\" \"Bob\" \"male\" \"indigo\" \"10/22/2016\"")));

        }
        [Test()]
        [ExpectedException(typeof(NotImplementedException))]
        public void AddTest_Cats()
        {
            var fp = new Moq.Mock<IFileProvider>();

            fp.Setup(aa => aa.AppendLineToFile(It.IsAny<string>()));

            var sut = new SpaceDelimitedDataRepository<Cat>(fp.Object);
            sut.Insert(new Cat());
         
        }
    }
}