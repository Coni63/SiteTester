using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SiteTester.Infrastructure.Contexts;
using SiteTester.Domain.Entities;

namespace SiteTester.Infrastructure.Repositories
{
    internal class RetrieveSite
    {
        public static Site? getSiteByClientId(int clientID)
        {
            using (PostGreContext db = new PostGreContext())
            {
                return db.Sites
                    .Where(s => s.ClientId == clientID)
                    .FirstOrDefault();
            }
        }

        public static List<Site> getAllSites()
        {
            using (PostGreContext db = new PostGreContext())
            {
                return db.Sites.ToList();
            }
        }

    }
}
