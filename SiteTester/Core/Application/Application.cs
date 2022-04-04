
using System;
using System.Collections.Generic;

using SiteTester.Domain.Entities;
using SiteTester.Infrastructure.Repositories;

namespace SiteTester.Core.Application
{
    class Application
    {
        public static void Main()
        {
            List<Site> sites = RetrieveSite.getAllSites();

            ThreadAgent agents = new ThreadAgent(sites, 2);
            List<Result> results = agents.run();
            InsertResult.addResults(results);
        }
    }
}
