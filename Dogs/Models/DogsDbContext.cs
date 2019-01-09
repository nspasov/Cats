using Dogs.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Dogs.Models
{
    public class DogsDbContext : DbContext
    {
        public DbSet<Dog> Dogs { get; set; }

        public DogsDbContext()
             : base("Server=(localdb)\\mssqllocaldb;Database=Dogs;Trusted_Connection=True;Application Name=Dogs;")
        {
            Dogs = Set<Dog>();
        }
    }
}