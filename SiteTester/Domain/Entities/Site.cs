using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteTester.Domain.Entities
{
    public class Site
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string BaseUrl { get; set; }

        public Site()
        {
            ClientId = 1;
            BaseUrl = String.Empty;
        }

        public Site(int clientId, string baseUrl)
        {
            ClientId = clientId;
            BaseUrl = baseUrl;
        }

    }
}
