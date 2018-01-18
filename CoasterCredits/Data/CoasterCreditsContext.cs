using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoasterCredits.Models;

namespace CoasterCredits.Models
{
    public class CoasterCreditsContext : DbContext
    {
        public CoasterCreditsContext (DbContextOptions<CoasterCreditsContext> options)
            : base(options)
        {
        }

        public DbSet<CoasterCredits.Models.Manufacturer> Manufacturer { get; set; }

        public DbSet<CoasterCredits.Models.Coaster> Coaster { get; set; }

        public DbSet<CoasterCredits.Models.Park> Park { get; set; }
    }
}
