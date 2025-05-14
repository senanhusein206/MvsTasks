using FinallySimulation.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinallySimulation.DAL.Contexts
{
   public class AppDbContext:DbContext
    {
        public DbSet<OurCause> OurCauses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-GTVND9D\SQLEXPRESS;Database=Ab206simi;Trusted_Connection=True;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
