using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvsProject.BL.Exceptions;
using MvsProject.DAL.Contexts;
using MvsProject.DAL.Models;

namespace MvsProject.BL.Services;

public class ProductService
{
    private readonly AppDbContext _context;
    public ProductService()
    {
        _context = new AppDbContext();
    }

    #region Create
    public void Create(ProductVM product)
    {
        Product newproduct = new Product();
        newproduct.Name = product.Name;
        newproduct.Description = product.Description;
        newproduct.Price = product.Price;

        

        string fileName = Path.GetFileNameWithoutExtension(product.ImgFile.FileName);
        string extension = Path.GetExtension(product.ImgFile.FileName);
        string newName= fileName + Guid.NewGuid().ToString() + extension;

        string upload = "C:\\Users\\Senan\\Desktop\\AB2066MVC\\MvsProject\\MvsProject.MVC\\wwwroot\\assets\\uploadImages";
        if (!Directory.Exists(upload))
        {
            Directory.CreateDirectory(upload);
        }
        upload = Path.Combine(upload, newName);

       using FileStream stream=new FileStream(upload, FileMode.Create);

        product.ImgFile.CopyTo(stream);
        newproduct.ImgUrl = newName;


        _context.Products.Add(newproduct);
        _context.SaveChanges();
    }
    #endregion
    #region Read
    public List<Product> GetAllProducts()
    {
       var m= _context.Products.ToList();
        return m;
    }
    public Product GetProductById(int? id) 
    {
        var model=_context.Products.Find(id);
        if (id is null)
        {
            throw new ProductException ($"{id}-idye sahib product yoxdur");
        }
        return model;

    }

    #endregion
    #region Update
    public void Update(int? id, ProductVM product)
    {
        var model = _context.Products.Find(id);
        if (id is null)
        {
            throw new ProductException($"{id}-idye sahib product yoxdur");
        }

        model.Description = product.Description;
        model.Price = product.Price;    
        model.Name = product.Name;

        string fileName = Path.GetFileNameWithoutExtension(product.ImgFile.FileName);
        string extension = Path.GetExtension(product.ImgFile.FileName);
        string newName = fileName + Guid.NewGuid().ToString() + extension;

        string upload = "C:\\Users\\Senan\\Desktop\\AB2066MVC\\MvsProject\\MvsProject.MVC\\wwwroot\\assets\\uploadImages";
        if (!Directory.Exists(upload))
        {
            Directory.CreateDirectory(upload);
        }
        upload = Path.Combine(upload, newName);

        using FileStream stream = new FileStream(upload, FileMode.Create);

        product.ImgFile.CopyTo(stream);
        model.ImgUrl = newName;
        _context.SaveChanges();
    }

    #endregion
    #region Delete
    public void Delete(int? id) 
    {
        var model = _context.Products.Find(id);
        if (id is null)
        {
            throw new ProductException($"{id}-idye sahib product yoxdur"); ;
        }

        _context.Products.Remove(model);
        _context.SaveChanges();
    }


    #endregion

}
