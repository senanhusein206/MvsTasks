using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCSimulation2.DAL.Models;

public class Collection
{
  
    public int Id { get; set; }
    public string Name { get; set; }
    public string ImgUrl { get; set; }
    public string Category { get; set; }
    public int NewCount { get; set; }
    public int OldCount { get; set; }
}
