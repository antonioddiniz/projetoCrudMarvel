using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using projetoCrudMarvel.src.Models;

namespace moduloAPI.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Hero> Heroes{get; set;}
        public DbSet<Group> Groups{get; set;}
        
    }
}