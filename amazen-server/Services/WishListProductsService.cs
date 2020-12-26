using System;
using System.Collections.Generic;
using amazen_server.Models;
using amazen_server.Repositories;

namespace amazen_server.Services
{
  public class WishListProductsService
  {
    private readonly WishListProductsRepository _repo;

    public WishListProductsService(WishListProductsRepository repo)
    {
      _repo = repo;
    }

    public WishListProduct Create(WishListProduct newWishListProduct)
    {
      newWishListProduct.Id = _repo.Create(newWishListProduct);
      return newWishListProduct;
    }

    internal IEnumerable<Product> GetProductsByWishListId(int wishlistId)
    {
      return _repo.GetProductsByWishListId(wishlistId);
    }

    internal string Delete(int id, string userId)
    {
      WishListProduct original = _repo.Get(id);
      if (original == null) { throw new Exception("Bad Id"); }
      if (original.CreatorId != userId)
      {
        throw new Exception("Not the User : Access Denied");
      }
      if (_repo.Remove(id))
      {
        return "deleted succesfully";
      }
      return "did not remove succesfully";
    }
  }
}