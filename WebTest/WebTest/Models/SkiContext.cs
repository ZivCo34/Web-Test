using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebTest.Models
{
    public class SkiContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Site> Sites { get; set; }
    }
}
