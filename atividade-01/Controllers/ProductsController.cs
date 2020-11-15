using System;
using System.Collections.Generic;
using System.Linq;
using atividade_01.Models;

namespace atividade_01.Controllers
{
  class ProductsController
  {
    private List<Product> products { get; set; }
    private int lastInsertedId = 0;

    public ProductsController()
    {
      this.products = new List<Product>();
    }

    public List<Product> Index()
    {
      return this.products;
    }

    public Product Find(int productId)
    {
      return this.products.FirstOrDefault(product => product.Id == productId);
    }

    public Product Update(Product product, int productId)
    {
      Product productToUpdate = this.products.FirstOrDefault(p => p.Id == productId);

      if (object.Equals(productToUpdate, null))
      {
        throw new Exception("Product not found");
      }

      productToUpdate.UpdateFrom(product);

      return productToUpdate;
    }

    public Product Create(Product product)
    {
      product.Id = ++this.lastInsertedId;

      this.products.Add(product);

      return product;
    }

    public bool Destroy(int id)
    {
      Product findProduct = this.products
        .FirstOrDefault(product => product.Id == id);

      bool productExists = !object.Equals(findProduct, null);

      if (!productExists)
      {
        throw new Exception("Product not found");
      }

      this.products = this.products
        .Where(product => !product.Id.Equals(id))
        .ToList();

      return productExists;
    }
  }
}