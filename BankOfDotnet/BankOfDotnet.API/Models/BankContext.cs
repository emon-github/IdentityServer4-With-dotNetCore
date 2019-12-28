using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankOfDotnet.API.Models
{
    public class BankContext : DbContext
    {
        public BankContext(DbContextOptions<BankContext> option): base(option)
        { }

        public DbSet<Customer> Customers { get; set; }
    }
}
