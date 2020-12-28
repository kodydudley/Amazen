using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using amazen_server.Models;

namespace amazen_server.Repositories
{
  public class WishListProductsRepository
  {
    private readonly IDbConnection _db;

    public WishListProductsRepository(IDbConnection db)
    {
      _db = db;
    }

    public int Create(WishListProduct newWishListProduct)
    {
      string sql = @"
        INSERT INTO wishlistproducts
        (wishlistId, productId)
        VALUES
        (@WishlistId, @ProductId);
        SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newWishListProduct);
    }

    internal IEnumerable<Product> GetProductsByWishListId(int wishlistId)
    {
      string sql = @"
        SELECT product.*,
        wlp.id as WishListProductId,
        profile.*
        FROM wishlistproducts wlp
        JOIN products product ON product.id = wlp.productId
        JOIN profiles profile ON profile.id = product.creatorId
        WHERE wishlistId = @wishlistId;";
      return _db.Query<WishListProductsViewModel, Profile, WishListProductsViewModel>(sql, (product, profile) => { product.Creator = profile; return product; }, new { wishlistId }, splitOn: "id");
    }

    internal bool Remove(int id)
    {
      string sql = "DELETE from wishlistproducts WHERE id = @id";
      int valid = _db.Execute(sql, new { id });
      return valid > 0;
    }

    internal WishListProduct Get(int id)
    {
      string sql = @"SELECT * from wishlistproducts WHERE id = @id";
      return _db.QueryFirstOrDefault<WishListProduct>(sql, new { id });
    }
  }
}