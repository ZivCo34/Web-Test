using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebTest.Models
{
    public class WebTestContext : DbContext
    {
        public WebTestContext (DbContextOptions<WebTestContext> options)
            : base(options)
        {
        }

        public DbSet<WebTest.Models.Site> Site { get; set; }
    }
}
