using FinallySimulation.BL.ViewModels;
using FinallySimulation.DAL.Contexts;
using FinallySimulation.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace FinallySimulation.BL.Services;

public class OurCauseService
{
    private readonly AppDbContext _context;
    public OurCauseService()
    {
        _context = new AppDbContext();
    }

    #region Create
    public void Create(CreateOurVM our)
    {
        OurCause ours = new OurCause();
        ours.Price = our.Price;
        ours.Description = our.Description;
        ours.Name = our.Name;

        string filename = Path.GetFileNameWithoutExtension(our.ImgFile.FileName);
        string extension = Path.GetExtension(our.ImgFile.FileName);
        string finalname = filename + Guid.NewGuid().ToString() + extension;
        ours.ImgUrl = finalname;

        string upload = @"C:\Users\II Novbe\Desktop\MvsTasks\FinallySimulation\FinallySimulation.MVC\wwwroot\assets\uploadImages";
        if (!Directory.Exists(upload))
        {
            Directory.CreateDirectory(upload);
        }
        upload = Path.Combine(upload, finalname);
        using FileStream stream = new FileStream(upload, FileMode.Create);
        our.ImgFile.CopyTo(stream);

        _context.OurCauses.Add(ours);
        _context.SaveChanges();
    }
    #endregion


    #region Read
    public List<OurCause> GetAllOurCauses()
    {
        var model = _context.OurCauses.ToList();
        return model;
    }

    public OurCause GetOurCauseById(int id)
    {
        var model = _context.OurCauses.Find(id);
        if (model is null)
        {
            throw new Exception($"{id}-idye sahib yoxdur");
        }
        return model;
    }
    #endregion

    #region Update
   
    public void Update(int id, CreateOurVM our)
    {
        var model = _context.OurCauses.Find(id);
        if (model is null)
        {
            throw new Exception($"{id}-idye sahib yoxdur");
        }

        model.Description = our.Description;
        model.Price = our.Price;
        model.Name = our.Name;
       

        if (our.ImgFile is null)
        {
            throw new Exception("nvjdsabjhbxu");
        }
        OurCause ours = new OurCause();
        ours.Price = our.Price;
        ours.Description = our.Description;
        ours.Name = our.Name;

        string filename = Path.GetFileNameWithoutExtension(our.ImgFile.FileName);
        string extension = Path.GetExtension(our.ImgFile.FileName);
        string finalname = filename + Guid.NewGuid().ToString() + extension;
        ours.ImgUrl = finalname;

        string upload = @"C:\Users\II Novbe\Desktop\MvsTasks\FinallySimulation\FinallySimulation.MVC\wwwroot\assets\uploadImages";
        if (!Directory.Exists(upload))
        {
            Directory.CreateDirectory(upload);
        }
        upload = Path.Combine(upload, finalname);
        using FileStream stream = new FileStream(upload, FileMode.Create);
        our.ImgFile.CopyTo(stream);

        _context.SaveChanges();

    }
    #endregion


    #region Delete
    public void Delete(int id)
    {
        var model = _context.OurCauses.Find(id);
        if (model is null)
        {
            throw new Exception($"{id}-idye sahib yoxdur");
        }
        _context.OurCauses.Remove(model);
        _context.SaveChanges();
    }
    #endregion

    public CreateOurVM ReMap(OurCause causeModel) {



        return new CreateOurVM() {
        
        Name=causeModel.Name,
        Description=causeModel.Description,
        Price=causeModel.Price
        };
    } 

}
