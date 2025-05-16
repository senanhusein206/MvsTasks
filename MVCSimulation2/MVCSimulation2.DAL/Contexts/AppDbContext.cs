using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCSimulation2.DAL.Models;


namespace MVCSimulation2.DAL.Contexts;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions options):base(options)
    {
       
    }

    public DbSet<Collection> Collections { get; set; }


}
