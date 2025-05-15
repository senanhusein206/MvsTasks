using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCSimilotion1.BL.ViewsModels
{
   public class CreateProgramVM
    { 
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile ImgFile { get; set; }
    }
}
