using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinallySimulation.BL.ViewModels;

public class CreateOurVM
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public IFormFile ImgFile { get; set; }
}
