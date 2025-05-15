using Microsoft.EntityFrameworkCore;
using MVCSimilotion1.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCSimilotion1.DAL.Contexts;

public class AppDbContext:DbContext
{

    public AppDbContext(DbContextOptions options):base(options)
    {
        
    }

    public DbSet<ChooseProgram> ChoosePrograms { get; set; }
    
}