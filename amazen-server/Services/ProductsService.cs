using System;
using System.Collections.Generic;
using amazen_server.Models;
using amazen_server.Repositories;

namespace amazen_server.Services
{
  public class ProductsService
  {
    private readonly ProductsRepository _repo;

    public ProductsService(ProductsRepository repo)
    {
      _repo = repo;
    }

    public Product Create(Product newProduct)
    {
      newProduct.Id = _repo.Create(newProduct);
      return newProduct;
    }

    public IEnumerable<Product> Get()
    {
      return _repo.Get();
    }

    public Product GetById(int id)
    {
      var foundProduct = _repo.GetById(id);
      if (foundProduct == null)
      {
        throw new Exception("Invalid Id");
      }
      return foundProduct;
    }

    public string Delete(int id)
    {
      if (_repo.Delete(id))
      {
        return ("The product has been deleted.");
      }
      throw new Exception("That didn't work! It's still there!");
    }

    internal Product Edit(Product updated)
    {
      var data = GetById(updated.Id);
      if (data.CreatorId != updated.CreatorId)
      {
        throw new Exception("Invalid Edit Permissions");
      }
      updated.Description = updated.Description != null ? updated.Description : data.Description;
      updated.Title = updated.Title != null && updated.Title.Length > 2 ? updated.Title : data.Title;
      updated.Price = updated.Price != 0 ? updated.Price : data.Price;
      updated.Picture = updated.Picture != null ? updated.Picture : data.Picture;
      // updated.IsAvailable = updated.IsAvailable != true ? updated.IsAvailable : data.IsAvailable;

      return _repo.Edit(updated);
    }
  }
}
