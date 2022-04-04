using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SiteTester.Infrastructure.Contexts;
using SiteTester.Domain.Entities;

namespace SiteTester.Infrastructure.Repositories
{
    internal class RetrieveResult
    {
        public static List<Result> getResultBySite(Site site)
        {
            using (PostGreContext db = new PostGreContext())
            {
                return db.Results
                    .Where(s => s.SiteForeignKey == site.Id)
                    .ToList();
            }
        }

        public static List<Result> getallResults()
        {
            using (PostGreContext db = new PostGreContext())
            {
                return db.Results.ToList();
            }
        }
    }
}
