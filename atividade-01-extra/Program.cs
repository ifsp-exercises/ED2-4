using System;
using System.Linq;
using atividade_01.Controllers;
using atividade_01.Models;

namespace atividade_01
{
  class Program
  {
    private static void HandleError(Exception exception)
    {
      Console.ForegroundColor = ConsoleColor.Red;
      Console.Write("An error occurred: ");
      Console.ForegroundColor = ConsoleColor.White;

      Console.WriteLine(exception.Message);
    }

    static void Main(string[] args)
    {
      ProductsController productsController = new ProductsController();

      int product_01_id = productsController.Create(new Product("Positivo Computer")).Id;
      int product_02_id = productsController.Create(new Product("NVIDIA GeForce GTX 1050")).Id;
      int product_03_id = productsController.Create(new Product("Barra de chocolate")).Id;

      Console.WriteLine(productsController.Find(product_01_id).ToString());
      Console.WriteLine(productsController.Find(product_01_id).ToJson());

      string productList = "";

      productList = String.Join("", productsController.Index().Select(product => $"\n- {product.Name}"));

      Console.WriteLine();
      Console.WriteLine("Product list");
      Console.WriteLine(productList);

      try
      {
        productsController.Destroy(product_01_id);
      }
      catch (Exception exception)
      {
        HandleError(exception);
      }

      productList = String.Join("", productsController.Index().Select(product => $"\n- {product.Name}"));

      Console.WriteLine();
      Console.WriteLine("Product list");
      Console.WriteLine(productList);

      try
      {
        productsController.Update(new Product("NVIDIA GeForce GTX 1050 Ti"), product_02_id);
      }
      catch (Exception exception)
      {
        HandleError(exception);
      }

      productList = String.Join("", productsController.Index().Select(product => $"\n- {product.Name}"));

      Console.WriteLine();
      Console.WriteLine("Product list");
      Console.WriteLine(productList);
    }
  }
}
