using Lab2_korcz.Rest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Lab2_korcz.Rest.Context
{
    public class AzureDbContext : DbContext
    {
        public AzureDbContext(DbContextOptions<AzureDbContext> options) : base(options)
        {
        }

        protected AzureDbContext()
        {
        }

        public DbSet<Person> People { get; set; }
    }
}

