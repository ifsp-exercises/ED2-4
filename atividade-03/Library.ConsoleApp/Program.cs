using System;
using System.Linq;
using Library.Domain.Controllers;

namespace Library.ConsoleApp
{
  class Program
  {
    private static void ShowOptions()
    {
      Console.WriteLine("Selecione uma das opções abaixo:");
      Console.Write("\n");

      Console.WriteLine("0. Sair");
      Console.WriteLine("1. Adicionar livro");
      Console.WriteLine("2. Pesquisar livro (sintético)");
      Console.WriteLine("3. Pesquisar livro (analítico)");
      Console.WriteLine("4. Adicionar exemplar");
      Console.WriteLine("5. Registrar empréstimo");
      Console.WriteLine("6. Registrar devolução");

      Console.Write("\n\n");
    }

    static void Main(string[] args)
    {
      LivroController livroController = new LivroController();

      int[] validOptions = new int[] { 0, 1, 2, 3, 4, 5, 6 };
      bool invalidOptionChosen = false;
      int chosenOption = 0;


      do
      {
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

          if (!validOptions.Any(option => Equals(option, chosenOption)))
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
            Console.WriteLine("Case 1");
            break;

          case 2:
            Console.WriteLine("Case 2");
            break;

          case 3:
            Console.WriteLine("Case 3");
            break;

          case 4:
            Console.WriteLine("Case 4");
            break;

          case 5:
            Console.WriteLine("Case 5");
            break;

          case 6:
            Console.WriteLine("Case 6");
            break;
        }

        Console.Clear();
      } while (!chosenOption.Equals(0) || invalidOptionChosen);
    }
  }
}
