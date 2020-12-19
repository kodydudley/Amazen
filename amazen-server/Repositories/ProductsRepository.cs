using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using amazen_server.Models;

namespace amazen_server.Repositories
{
  public class ProductsRepository
  {
    private readonly IDbConnection _db;
    private readonly string populateCreator = "SELECT product.*, profile.* FROM products product INNER JOIN profiles profile ON product.creatorId = profile.id ";

    public ProductsRepository(IDbConnection db)
    {
      _db = db;
    }

    public int Create(Product newProduct)
    {
      string sql = @"
        INSERT INTO products
        (title, description, picture, creatorId)
        VALUES
        (@Title, @Description, @Picture, @CreatorId);
        SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newProduct);
    }

    public IEnumerable<Product> Get()
    {
      string sql = populateCreator;
      return _db.Query<Product, Profile, Product>(sql, (product, profile) => { product.Creator = profile; return product; }, splitOn: "id");
    }
  }
}