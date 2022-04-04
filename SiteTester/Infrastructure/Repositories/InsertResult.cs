using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SiteTester.Infrastructure.Contexts;
using SiteTester.Domain.Entities;

namespace SiteTester.Infrastructure.Repositories
{
    internal class InsertResult
    {
        public static Result addResult(Result result)
        {
            using (PostGreContext db = new PostGreContext())
            {
                db.Results.Add(result);
                db.SaveChanges();
            }
            return result;
        }

        public static List<Result> addResults(List<Result> results)
        {
            using (PostGreContext db = new PostGreContext())
            {
                db.Results.AddRange(results);
                db.SaveChanges();
            }
            return results;
        }

    }
}
