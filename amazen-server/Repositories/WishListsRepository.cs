using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using amazen_server.Models;

namespace amazen_server.Repositories
{
  public class WishListsRepository
  {
    private readonly IDbConnection _db;
    // private readonly string populateCreator = "SELECT blog.*, profile.* FROM blogs blog INNER JOIN profiles profile ON blog.creatorId = profile.id ";

    public WishListsRepository(IDbConnection db)
    {
      _db = db;
    }
    public int Create(WishList newWishList)
    {
      string sql = @"
            INSERT INTO wishlists 
            (name)
            VALUES
            (@Name);
            SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newWishList);
    }

    public IEnumerable<WishList> Get()
    {
      string sql = "SELECT * from wishlists";
      return _db.Query<WishList>(sql);
    }
  }
}