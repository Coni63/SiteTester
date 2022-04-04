using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

using SiteTester.Domain.Entities;

namespace SiteTester.Infrastructure.Contexts
{
    public class BaseContext : DbContext
    {
        public DbSet<Site> Sites { get; set; }
        public DbSet<Result> Results { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Result>()
                //.HasOne(r => r.Site)
                //.WithMany(s => s.Results)
                //.HasForeignKey(r => r.SiteForeignKey);
        }
    }
}
