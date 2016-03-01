using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdu.Data.Helpers;
using Sdu.Data.Models;
using Sdu.Data.Repositories;

namespace Sdu.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepository<Person> repo = null;
            if (!args.Any())
            {
                System.Console.Write("please select commas, pipes or spaces, followed by gender, DOB, or lastname.");

            }

            switch (args[0])
            {
                case "commas":
                    repo =
                        new CommaDelimitedDataRepository<Person>(
                            new FileProvider(ConfigHelper.GetAppSetting("commasRepoPath", @"c:\temp\commas.txt")));
                    break;
                case "pipes":
                    repo =
                        new PipeDelimitedDataRepository<Person>(
                            new FileProvider(ConfigHelper.GetAppSetting("pipesRepoPath", @"c:\temp\pipes.txt")));
                    break;
                default:
                    repo =
                        new SpaceDelimitedDataRepository<Person>(
                            new FileProvider(ConfigHelper.GetAppSetting("spacesRepoPath", @"c:\temp\spaces.txt")));
                    break;

            }

            var query = repo.AsQueryable();

            switch (args[1])
            {

                case "gender":
                    query = query.OrderBy(aa => aa.Gender);
                    break;
                case "lastname":
                    query = query.OrderByDescending(aa => aa.LastName);
                    break;
                case "DOB":
                    query = query.OrderBy(aa => aa.DateOfBirth);
                    break;

            }


            foreach (var p in query.ToList())
            {
                System.Console.WriteLine(String.Format("{0},{1},{2},{3},{4}", p.LastName, p.FirstName, p.Gender, p.DateOfBirth.ToShortDateString(), p.FavoriteColor));
            }
        }
    }
}
