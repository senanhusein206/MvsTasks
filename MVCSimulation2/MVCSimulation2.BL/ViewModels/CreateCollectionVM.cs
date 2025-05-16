using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCSimulation2.BL.ViewModels
{
    public class CreateCollectionVM
    {
        [Required(ErrorMessage ="Bele admi olar ay bala")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Bele Category olar ay bala")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Bele saymi olar ay bala")]
        public int NewCount { get; set; }


        [Required(ErrorMessage = "Bele say olar ay bala")]
        public int OldCount { get; set; }


        [Required(ErrorMessage = "bir file sec")]
        public IFormFile ImgFile { get; set; }

    }
}
