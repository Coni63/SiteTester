using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SiteTester.Infrastructure.Contexts;
using SiteTester.Domain.Entities;

namespace SiteTester.Infrastructure.Repositories
{
    internal class InsertSite
    {
        public static Site addSite(Site site)
        {
            using (PostGreContext db = new PostGreContext())
            {
                Site? siteInDb = RetrieveSite.getSiteByClientId(site.ClientId);
                if (siteInDb == null)
                {
                    db.Sites.Add(site);
                    db.SaveChanges();
                    return site;
                }
                else
                {
                    return siteInDb;
                }
            }
        }

    }
}
