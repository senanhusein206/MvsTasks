using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MVCSimulation2.BL.ViewModels;
using MVCSimulation2.DAL.Contexts;
using MVCSimulation2.DAL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCSimulation2.BL.Services;

public class CollectionService
{
    private readonly AppDbContext _context;
    public CollectionService(AppDbContext dbContext)
    {
        _context = dbContext;
    }

    #region Create
    public void Create(CreateCollectionVM product)
    {
        Collection col = new Collection();
        col.Name = product.Name;
        col.OldCount = product.OldCount;
        col.NewCount = product.NewCount;
        col.Category = product.Category;

        string fileName = Path.GetFileNameWithoutExtension(product.ImgFile.FileName);
        string extension = Path.GetExtension(product.ImgFile.FileName);
        string finalName = fileName + Guid.NewGuid().ToString() + extension;
        col.ImgUrl = finalName;

        string path = "C:\\Users\\II Novbe\\Desktop\\MvsTasks\\MVCSimulation2\\MVCSimulation2.MVC\\wwwroot\\assets\\uploadImages";

        path = Path.Combine(path, finalName);
        if (Directory.Exists(path))
        {
            Directory.CreateDirectory(path);  
        }


        using FileStream stream = new FileStream(path,FileMode.Create);
        product.ImgFile.CopyTo(stream);


        _context.Collections.Add(col);
        _context.SaveChanges();
    }
    #endregion

    #region Read
    public List<Collection> GetAllCollections()
    {
        var model = _context.Collections.ToList();
        if (model is null)
        {
            throw new Exception("yoxdur");
        }
        return model;

    }

    public Collection GetCollectionById(int id)
    {
        var mod = _context.Collections.Find(id);
        if (mod is null)
        {
            throw new Exception("vallah yoxdur");
        }
        return mod;
        #endregion
    }

    #region Update
    public void Update(CreateCollectionVM col, int id)
    {
        var mod = _context.Collections.Find(id);
        if (mod is null)
        {
            throw new Exception("vallah yoxdur");
        }
        mod.NewCount = col.NewCount;
        mod.OldCount = col.OldCount;
        mod.Name = col.Name;

        string fileName = Path.GetFileNameWithoutExtension(col.ImgFile.FileName);
        string extension = Path.GetExtension(col.ImgFile.FileName);
        string finalname = fileName + Guid.NewGuid().ToString() + extension;
        mod.ImgUrl = finalname;
        string path = "C:\\Users\\II Novbe\\Desktop\\MvsTasks\\MVCSimulation2\\MVCSimulation2.MVC\\wwwroot\\assets\\uploadImages";
        if (Directory.Exists(path))
        {
            Directory.CreateDirectory(path);

        }
        path = Path.Combine(path, finalname);


        using FileStream stream = new FileStream(path,FileMode.Create);
        col.ImgFile.CopyTo(stream);


        _context.SaveChanges();
    }

    #endregion

    #region Delete
    public void Delete(int id)
    {
        var mod = _context.Collections.Find(id);
        if (mod is null)
        {
            throw new Exception("vallah yoxdur");
        }
        _context.Collections.Remove(mod);
        _context.SaveChanges();
    }
    #endregion

}