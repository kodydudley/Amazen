using System;
using System.Data;
using System.Collections.Generic;
using amazen_server.Models;
using amazen_server.Repositories;

namespace amazen_server.Services
{
  public class WishListsService
  {
    private readonly WishListsRepository _repo;

    public WishListsService(WishListsRepository repo)
    {
      _repo = repo;
    }

    public WishList Create(WishList newWishList)
    {
      newWishList.Id = _repo.Create(newWishList);
      return newWishList;
    }

    public IEnumerable<WishList> Get()
    {
      return _repo.Get();
    }
  }
}