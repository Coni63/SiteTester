using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteTester.Domain.Entities
{
    public class Result
    {
        public int Id { get; set; }
        //public Site Site { get; set; }
        public string TestedUrl { get; set; }
        public DateTime TestDate { get; set; }
        public string StatusCode { get; set; }
        public int SiteForeignKey { get; set; }


        public Result()
        {
            TestedUrl = string.Empty;
            TestDate = DateTime.UtcNow;
            StatusCode = String.Empty;
            SiteForeignKey = 1;
        }

        public Result(Site site, string testedUrl, string statusCode)
        {
            TestedUrl = testedUrl;
            TestDate = DateTime.UtcNow;
            StatusCode = statusCode;
            SiteForeignKey = site.Id;
        }

        public Result(Site site, Uri testedUrl, string statusCode)
        {
            TestedUrl = testedUrl.ToString();
            TestDate = DateTime.UtcNow;
            StatusCode = statusCode;
            SiteForeignKey = site.Id;
        }
    }
}
