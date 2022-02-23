using Irimies_Mircea.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Irimies_Mircea.Data
{
    public class TeamContext : DbContext
    {
        public TeamContext(DbContextOptions<TeamContext> options) :
base(options)
        {
        }
        public DbSet<Jucator> Jucators { get; set; }
        public DbSet<Antrenor> Antrenors { get; set; }
        public DbSet<Echipa> Echipas { get; set; }
        public DbSet<Conferinta> Conferintas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Jucator>().ToTable("Jucator");
            modelBuilder.Entity<Antrenor>().ToTable("Antrenor");
            modelBuilder.Entity<Echipa>().ToTable("Echipa");
            modelBuilder.Entity<Conferinta>().ToTable("Conferinta");
        }
    }
}