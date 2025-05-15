using MVCSimilotion1.BL.ViewsModels;
using MVCSimilotion1.DAL.Contexts;
using MVCSimilotion1.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCSimilotion1.BL.Services
{
    public class ChooseProgramService
    {
        public readonly AppDbContext _context;
        public ChooseProgramService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        #region Create
        public void Create(CreateProgramVM chpro)
        {
            ChooseProgram chooseProgram = new ChooseProgram();
            chooseProgram.Name = chpro.Name;
            chooseProgram.Description = chpro.Description;

            string filename = Path.GetFileNameWithoutExtension(chpro.ImgFile.FileName);
            string extension = Path.GetExtension(chpro.ImgFile.FileName);
            string finalname = filename + Guid.NewGuid().ToString() + extension;
            chooseProgram.ImgUrl = finalname;

            string path = @"C:\Users\II Novbe\Desktop\MvsTasks\MVCSimilotion1\MVCSimilotion1.MVC\wwwroot\assets\images\uploadImage";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path = Path.Combine(path, finalname);

            using FileStream stream = new FileStream(path,FileMode.Create);
            chpro.ImgFile.CopyTo(stream);

            _context.ChoosePrograms.Add(chooseProgram);
            _context.SaveChanges();
        }
        #endregion


        #region Read

        public List<ChooseProgram> GetAllChoosePrograms()
        {
           var model= _context.ChoosePrograms.ToList();
            return model;
        }

        public ChooseProgram GetChooseProgramById(int id)
        {
            var model = _context.ChoosePrograms.Find(id);
            if (model is null)
            {
                throw new Exception("bu yoxdur");
            }
            return model;
        }

        #endregion

        #region Update
        public void Update(int id,CreateProgramVM chpro)
        {
            var model = _context.ChoosePrograms.Find(id);
            if (model is null)
            {
                throw new Exception("bu yoxdur");
            }

            model.Description = chpro.Description;
            model.Name = chpro.Name;
          




            ChooseProgram chooseProgram = new ChooseProgram();
            chooseProgram.Name = chpro.Name;
            chooseProgram.Description = chpro.Description;

            string filename = Path.GetFileNameWithoutExtension(chpro.ImgFile.FileName);
            string extension = Path.GetExtension(chpro.ImgFile.FileName);
            string finalname = filename + Guid.NewGuid().ToString() + extension;
            model.ImgUrl = finalname;

            string path = @"C:\Users\II Novbe\Desktop\MvsTasks\MVCSimilotion1\MVCSimilotion1.MVC\wwwroot\assets\images\uploadImage";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path = Path.Combine(path, finalname);

            using FileStream stream = new FileStream(path, FileMode.Create);
            chpro.ImgFile.CopyTo(stream);

            _context.SaveChanges();
        }
        #endregion

        #region Delete
        public void Delete(int id)
        {
            var model = _context.ChoosePrograms.Find(id);
            if (model is null)
            {
                throw new Exception("bu yoxdur");
            }
            _context.ChoosePrograms.Remove(model);
            _context.SaveChanges();
        }
        #endregion 



        



    }
}
