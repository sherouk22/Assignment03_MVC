using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Company.Data.Context
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server =DESKTOP-DIRMGF2; database =CompanyMVC; trusted_connection = true; TrustServerCertificate = True; ");

        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }


    }
}
