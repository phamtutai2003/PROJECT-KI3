using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using POST.Models;

namespace POST.Data
{
    public class POSTContext : DbContext
    {
        public POSTContext (DbContextOptions<POSTContext> options)
            : base(options)
        {
        }

      

        public DbSet<POST.Models.Customer> Customer { get; set; } = default!;

        public DbSet<POST.Models.Payment> Payment { get; set; } = default!;

        public DbSet<POST.Models.Shipping> Shipping { get; set; } = default!;

        public DbSet<POST.Models.Personnel> Personnel { get; set; } = default!;

        public DbSet<POST.Models.Shipment> Shipment { get; set; } = default!;
    }
}
