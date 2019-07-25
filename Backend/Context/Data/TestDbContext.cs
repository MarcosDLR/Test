using Microsoft.EntityFrameworkCore;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contexts.Data
{
    public class TestDbContext : DbContext
    {
        //public TestDbContext()
        //{
        //}

        public TestDbContext(DbContextOptions<TestDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accion> Accion { get; set; }
        public virtual DbSet<Actividad> Actividad { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

    }
}
