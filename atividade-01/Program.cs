using System;
using System.Linq;
using atividade_01.Handlers;
using atividade_01.Controllers;
using atividade_01.Models;

namespace atividade_01
{
  class Program
  {
    private static readonly OptionsController optionsController = new OptionsController();

    private static void ShowOptions()
    {
      Console.WriteLine("Selecione uma das opções abaixo:");
      Console.Write("\n");

      Console.Write(
        string.Join(
          "\n",
          optionsController.Index()
            .Select(option => $"{option.Code} - {option.Text}")
        )
      );
      Console.Write("\n\n");
    }

    private static void Execute()
    {
      int chosenOption = 0;
      bool invalidOptionChosen = false;
      HandlerResult lastHandleExecutionResult = null;

      SalesHandler salesHandler = new SalesHandler(new SalesPersonController(10));

      do
      {
        if (!Equals(lastHandleExecutionResult, null))
        {
          Console.ForegroundColor = lastHandleExecutionResult.Success
            ? ConsoleColor.Green
            : ConsoleColor.Red;

          Console.WriteLine(lastHandleExecutionResult.Message);
          Console.ForegroundColor = ConsoleColor.White;

          lastHandleExecutionResult = null;
        }

        if (invalidOptionChosen)
        {
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine(
            "A opção anterior era inválida, veja as opções novamente\n"
          );
          Console.ForegroundColor = ConsoleColor.White;
          invalidOptionChosen = false;
        }

        ShowOptions();

        Console.Write("Sua escolha: ");

        try
        {
          chosenOption = int.Parse(Console.ReadLine());

          if (!optionsController.ValidateOption(chosenOption))
            throw new Exception();
        }
        catch
        {
          invalidOptionChosen = true;
        }
        finally
        {
          Console.Clear();
        }

        if (invalidOptionChosen) continue;

        switch (chosenOption)
        {
          case 1:
            lastHandleExecutionResult = salesHandler.HandleCreateSalesPerson();
            break;

          case 2:
            lastHandleExecutionResult = salesHandler.HandleFindSalesPerson();
            break;

          case 3:
            lastHandleExecutionResult = salesHandler.HandleDeleteSalesPerson();
            break;

          case 4:
            lastHandleExecutionResult = salesHandler.HandleCreateSale();
            break;

          case 5:
            salesHandler.HandleListSalesPeople();
            break;
        }

        Console.Clear();
      } while (!chosenOption.Equals(0) || invalidOptionChosen);
    }

    static void Main(string[] args)
    {
      try
      {
        Execute();
      }
      catch (Exception exception)
      {
        ErrorsHandler.HandleGenericError(exception);
      }
    }
  }
}
