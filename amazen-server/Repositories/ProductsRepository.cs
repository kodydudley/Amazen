using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using amazen_server.Models;
using System.Linq;

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
        (title, description, picture, price, creatorId)
        VALUES
        (@Title, @Description, @Picture, @Price, @CreatorId);
        SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newProduct);
    }

    public IEnumerable<Product> Get()
    {
      string sql = populateCreator;
      return _db.Query<Product, Profile, Product>(sql, (product, profile) => { product.Creator = profile; return product; }, splitOn: "id");
    }

    public Product GetById(int id)
    {
      string sql = "SELECT * FROM products WHERE id = @Id";
      return _db.QueryFirstOrDefault<Product>(sql, new { id });
    }

    public bool Delete(int id)
    {
      string sql = "DELETE FROM products WHERE id = @Id LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id });
      return affectedRows > 0;
    }

    public Product Edit(Product updated)
    {
      string sql = @"
        UPDATE products
        SET
         title = @Title,
         description = @Description,
         picture = @Picture,
         price = @Price,
        WHERE id = @Id;";
      _db.Execute(sql, updated);
      return updated;
    }

    public IEnumerable<Product> getProductsByProfile(string profileId)
    {
      string sql = @"
        SELECT
        product.*,
        profile.*
        FROM products product
        JOIN profiles profile ON product.creatorId = profile.id
        WHERE product.creatorId = @profileId; ";
      return _db.Query<Product, Profile, Product>(sql, (product, profile) => { product.Creator = profile; return product; }, new { profileId }, splitOn: "id");
    }
  }
}