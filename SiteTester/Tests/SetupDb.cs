using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SiteTester.Infrastructure.Repositories;
using SiteTester.Domain.Entities;

namespace SiteTester.Core.Application
{
    internal class SetupDb
    {
        public static void GenerateFakeSite()
        {
            Site[] sites = new Site[]
            {
                new Site(1, "http://www.wikipedia.fr/"),
                new Site(2, "http://www.yahoo.fr/"),
                new Site(3, "http://www.google.fr/"),
            };

            foreach (Site s in sites)
            {
                InsertSite.addSite(s);
            }
        }

        public static void GenerateFakeResults()
        {
            List<Site> sites = RetrieveSite.getAllSites();
            List<Result> results = new List<Result>();

            foreach (Site site in sites)
            {
                results.Add(new Result(site, "tested url", "200"));
            }

            InsertResult.addResults(results);
        }

    }
}
