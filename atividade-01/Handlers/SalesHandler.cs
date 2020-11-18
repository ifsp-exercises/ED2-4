using System;
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
      SalesPerson salesPerson = new SalesPerson(
        name: "Angelo",
        commissionPercentage: 25.0
      );

      bool successfullyCreated = this.salesPersonController.Create(salesPerson);

      return new HandlerResult(
        success: successfullyCreated,
        message: successfullyCreated
          ? $"{SalesHandler.OK}Vendedor cadastrado com sucesso."
          : $"{SalesHandler.FAIL}Falha ao cadastrar vendedor: {salesPerson.ToJson()}"
      );
    }

    public HandlerResult HandleFindSalesPerson()
    {
      int salesPersonId = 0;

      Console.Write("Informe o ID do vendedor: ");
      salesPersonId = int.Parse(Console.ReadLine());

      SalesPerson findSalesPerson = this.salesPersonController
        .Find(new SalesPerson(salesPersonId));

      if (Equals(findSalesPerson, null)) return new HandlerResult(
        success: false,
        message: $"{SalesHandler.FAIL}Vendedor não encontrado."
      );

      return new HandlerResult(
        success: true,
        message: findSalesPerson.ToJson() // formata certo aqui man kkkkkk
      );
    }

    public void HandleDeleteSalesPerson()
    {

    }

    public void HandleCreateSale()
    {

    }

    public void HandleListSalesPeople()
    {

    }
  }
}
