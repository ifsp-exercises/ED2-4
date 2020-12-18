using System;
using System.Linq;
using Library.Domain.Controllers;
using Library.Domain.Entities;

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

      Livro livroEncontrado;
      string titulo, autor, editora;
      int isbn, tombo, tomboExemplarEmprestado;

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
            Console.Write("Informe o ISBN do livro: ");
            int.TryParse(Console.ReadLine(), out isbn);

            Console.Write("Informe o título do livro: ");
            titulo = Console.ReadLine();

            Console.Write("Informe o autor do livro: ");
            autor = Console.ReadLine();

            Console.Write("Informe a editora do livro: ");
            editora = Console.ReadLine();


            var livro = new Livro(isbn, titulo, autor, editora);

            livroController.Adicionar(livro);
            break;

          case 2:
            Console.Write("Informe o ISBN do livro: ");
            int.TryParse(Console.ReadLine(), out isbn);

            livroEncontrado = livroController.Pesquisar(new Livro(isbn, "", "", ""));

            if (livroEncontrado != null)
              Console.WriteLine($"Livro encontrado: {livroEncontrado.Titulo}");
            else
              Console.WriteLine("Livro não encontrado");

            Console.WriteLine();

            Console.Write("Digite algum tecla para continuar...");
            Console.ReadKey();
            break;

          case 3:
            Console.Write("Informe o ISBN do livro: ");
            int.TryParse(Console.ReadLine(), out isbn);

            livroEncontrado = livroController.Pesquisar(new Livro(isbn, "", "", ""));

            if (livroEncontrado != null)
              Console.WriteLine($"Livro encontrado: {livroEncontrado.Titulo}");
            else
              Console.WriteLine("Livro não encontrado");

            Console.WriteLine();

            Console.Write("Digite algum tecla para continuar...");
            Console.ReadKey();
            break;

          case 4:
            Console.Write("Informe o ISBN do livro: ");
            int.TryParse(Console.ReadLine(), out isbn);

            livroEncontrado = livroController.Pesquisar(new Livro(isbn, "", "", ""));

            if (livroEncontrado == null)
            {
              Console.WriteLine("Livro não encontrado");
              Console.Write("Digite algum tecla para continuar...");
              Console.ReadKey();
              break;
            }

            Console.Write("Informe o tombo do livro: ");
            int.TryParse(Console.ReadLine(), out tombo);

            var exemplar = new Exemplar(tombo);
            livroEncontrado.AdicionarExemplar(exemplar);
            break;

          case 5:
            Console.Write("Informe o ISBN do livro: ");
            int.TryParse(Console.ReadLine(), out isbn);

            livroEncontrado = livroController.Pesquisar(new Livro(isbn, "", "", ""));

            if (livroEncontrado == null)
            {
              Console.WriteLine("Livro não encontrado");
              Console.Write("Digite algum tecla para continuar...");
              Console.ReadKey();
              break;
            }

            if (livroEncontrado.QtdeDisponiveis() > 0)
            {
              tomboExemplarEmprestado = livroEncontrado.EmprestarExemplar();

              Console.WriteLine("Guarde o tombo do livro para devolver.");
              Console.WriteLine($"Tombo do livro: {tomboExemplarEmprestado}");
            }
            else
            {
              Console.WriteLine("Livro não disponível");
            }

            Console.Write("Digite algum tecla para continuar...");
            Console.ReadKey();

            break;

          case 6:
            Console.Write("Informe o ISBN do livro: ");
            int.TryParse(Console.ReadLine(), out isbn);

            livroEncontrado = livroController.Pesquisar(new Livro(isbn, "", "", ""));

            if (livroEncontrado == null)
            {
              Console.WriteLine("Livro não encontrado");
              Console.Write("Digite algum tecla para continuar...");
              Console.ReadKey();
              break;
            }

            Console.Write("Informe o tombo do exemplar: ");
            int.TryParse(Console.ReadLine(), out tomboExemplarEmprestado);

            if (livroEncontrado.ChecarExemplarEmprestado(tomboExemplarEmprestado))
              livroEncontrado.DevolverExemplar(tomboExemplarEmprestado);
            else
              Console.WriteLine("Livro não está emprestado.");

            break;
        }

        Console.Clear();
      } while (!chosenOption.Equals(0) || invalidOptionChosen);
    }
  }
}


/*
* . Informar dos dados básicos do livro com as qtdes:
    total de exemplares, de exemplares disponíveis,
    de empréstimos e o respectivo percentual de
    disponibilidade do título
**. Informando, além dos dados acima, os detalhes dos
    seus exemplares e respectivos empréstimos
    */
