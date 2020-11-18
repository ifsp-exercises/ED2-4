using System;
using System.Linq;
using atividade_01.Controllers;
using atividade_01.Models;

namespace atividade_01.Handlers
{
  public class SalesHandler
  {
    private static readonly string OK = "✅  ";
    private static readonly string FAIL = "❌  ";

    private SalesPersonController salesPersonController { get; set; }

    public SalesHandler(SalesPersonController salesPersonController) =>
      this.salesPersonController = salesPersonController;

    public HandlerResult HandleCreateSalesPerson()
    {
      Console.Write("Informe o nome do vendedor: ");
      string name = Console.ReadLine();

      Console.Write("Informe o percentual de comissão: ");
      double commissionPercentage = double.Parse(Console.ReadLine());

      SalesPerson salesPerson = new SalesPerson(name, commissionPercentage);

      bool successfullyCreated = this.salesPersonController.Create(salesPerson);

      return new HandlerResult(
        success: successfullyCreated,
        message: successfullyCreated
          ? $"{SalesHandler.OK}Vendedor cadastrado com sucesso. ID: {salesPerson.Id}"
          : $"{SalesHandler.FAIL}Falha ao cadastrar vendedor: {salesPerson.ToJson()}"
      );
    }

    public HandlerResult HandleFindSalesPerson()
    {
      Console.Write("Informe o ID do vendedor: ");
      int salesPersonId = int.Parse(Console.ReadLine());

      SalesPerson findSalesPerson = this.salesPersonController
        .Find(new SalesPerson(salesPersonId));

      if (Equals(findSalesPerson, null)) return new HandlerResult(
        success: false,
        message: $"{SalesHandler.FAIL}Vendedor não encontrado."
      );

      return new HandlerResult(
        success: true,
        message: findSalesPerson.ToJson()
      );
    }

    public HandlerResult HandleDeleteSalesPerson()
    {
      Console.Write("Informe o ID do vendedor: ");
      int salesPersonId = int.Parse(Console.ReadLine());

      SalesPerson findSalesPerson = this.salesPersonController
        .Find(new SalesPerson(salesPersonId));

      if (Equals(findSalesPerson, null)) return new HandlerResult(
        success: false,
        message: $"{SalesHandler.FAIL}Vendedor não encontrado."
      );

      bool successfullyDeleted = this.salesPersonController.Destroy(findSalesPerson);

      return new HandlerResult(
        success: successfullyDeleted,
        message: successfullyDeleted
          ? $"{SalesHandler.OK}Vendedor removido com sucesso. ID: {findSalesPerson.Id}"
          : $"{SalesHandler.FAIL}Falha ao remover vendedor: {findSalesPerson.ToJson()}"
      );
    }

    public HandlerResult HandleCreateSale()
    {
      Console.Write("Informe o a quantidade da venda: ");
      int quantity = int.Parse(Console.ReadLine());

      Console.Write("Informe o preço total da venda: ");
      double price = double.Parse(Console.ReadLine());

      Sale sale = new Sale(quantity, price);

      Console.Write("Informe o ID do vendedor: ");
      int salesPersonId = int.Parse(Console.ReadLine());

      SalesPerson findSalesPerson = this.salesPersonController
        .Find(new SalesPerson(salesPersonId));

      if (Equals(findSalesPerson, null)) return new HandlerResult(
        success: false,
        message: $"{SalesHandler.FAIL}Vendedor não encontrado."
      );

      findSalesPerson.RegisterSale(sale);

      bool successfullyUpdated = this.salesPersonController.Update(findSalesPerson);

      return new HandlerResult(
        success: successfullyUpdated,
        message: successfullyUpdated
          ? $"{SalesHandler.OK}Nova venda associada ao vendedor de ID: {findSalesPerson.Id}"
          : $"{SalesHandler.FAIL}Falha ao associar venda ao vendedor de ID: {findSalesPerson.Id}"
      );
    }

    public void HandleListSalesPeople()
    {
      string formattedList = "";
      double totalPriceValue = 0, totalCommissionValue = 0;

      foreach (SalesPerson salesPerson in this.salesPersonController.Index())
      {
        totalPriceValue += salesPerson.GetSalesValue();
        totalCommissionValue += salesPerson.GetCommissionValue();
        formattedList += $"Id: {salesPerson.Id}\nNome: {salesPerson.Name}\nValor total das vendas: {salesPerson.GetSalesValue()}\nValor total da commisão: {salesPerson.GetCommissionValue()}\n\n";
      }

      // string formattedList = string.Join(
      //   "\n",
      //   this.salesPersonController.Index().Select(salesPerson =>
      //     $"Id: {salesPerson.Id}\nNome: {salesPerson.Name}\nValor total das vendas: {salesPerson.GetSalesValue()}\nValor total da commisão: {salesPerson.GetCommissionValue()}\n"
      //   )
      // );

      Console.WriteLine($"{formattedList}");

      Console.WriteLine($"Total geral das vendas: {totalPriceValue}");
      Console.WriteLine($"Total geral das comissões: {totalCommissionValue}\n");

      Console.WriteLine("Pressione alguma tecla para continuar...");
      Console.ReadKey();
    }
  }
}
