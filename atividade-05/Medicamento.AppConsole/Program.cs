using System;
using System.Linq;
using Medicamento.AppConsole.Controllers;
using Medicamento.Domain.Entities;
using MedicamentoEntity = Medicamento.Domain.Entities.Medicamento;

namespace Medicamento.AppConsole
{
  class Program
  {
    private static readonly MedicamentoController _medicamentoController =
      new MedicamentoController();

    private static void MostrarOpcoes()
    {
      Console.WriteLine("Selecione uma das opções abaixo:");
      Console.Write("\n");

      Console.WriteLine("0. Finalizar processo");
      Console.WriteLine("1. Cadastrar medicamento");
      Console.WriteLine("2. Consultar medicamento (sintético: informar dados1)");
      Console.WriteLine("3. Consultar medicamento (analítico: informar dados1 + lotes2)");
      Console.WriteLine("4. Comprar medicamento (cadastrar lote)");
      Console.WriteLine("5. Vender medicamento (abater do lote mais antigo)");
      Console.WriteLine("6. Listar medicamentos (informando dados sintéticos) ");

      Console.Write("\n\n");
    }

    private static string FormatarMedicamento(MedicamentoEntity medicamento)
    {
      var medicamentoFormatado = "";
      medicamentoFormatado += $"ID: {medicamento.Id}\n";
      medicamentoFormatado += $"NOME: {medicamento.Nome}\n";
      medicamentoFormatado += $"LABORATÓRIO: {medicamento.Laboratorio}\n";
      medicamentoFormatado += $"QUANTIDADE DISPONÍVEL: {medicamento.QuantidadeDisponivel()}";

      return medicamentoFormatado;
    }
    private static string FormatarLote(Lote lote)
    {
      var loteFormatado = "";
      loteFormatado += $"ID: {lote.Id}\n";
      loteFormatado += $"QUANTIDADE: {lote.Quantidade}\n";
      loteFormatado += $"DATA VENCIMENTO: {lote.DataVencimento.ToString("dd/MM/yyyy")}";

      return loteFormatado;
    }

    static void Main(string[] args)
    {
      int opcao;
      string mensagem = null;
      bool falha = false;

      do
      {
        try
        {
          Console.Clear();

          if (mensagem != null)
          {
            Console.ForegroundColor = falha ? ConsoleColor.Red : ConsoleColor.Green;
            Console.WriteLine(mensagem + '\n');
            Console.ForegroundColor = ConsoleColor.White;
          }

          mensagem = null;
          falha = false;

          MostrarOpcoes();

          Console.Write("Sua escolha: ");
          opcao = int.Parse(Console.ReadLine());

          switch (opcao)
          {
            default:
              falha = true;
              mensagem = "Opção inválida.";
              break;

            case 0:
              break;

            case 1:
              {
                Console.Clear();

                Console.Write("Digite o ID: ");
                int id = int.Parse(Console.ReadLine());

                var medicamento = _medicamentoController.Pesquisar(
                  new MedicamentoEntity(
                    id,
                    nome: null,
                    laboratorio: null
                ));

                if (medicamento != null)
                {
                  falha = true;
                  mensagem = "ID em uso.";
                  break;
                }

                Console.Write("Digite o Nome: ");
                string nome = Console.ReadLine();

                Console.Write("Digite o Laboratorio: ");
                string laboratorio = Console.ReadLine();

                medicamento = new MedicamentoEntity(id, nome, laboratorio);

                _medicamentoController.Adicionar(medicamento);

                falha = false;
                mensagem = "Medicamento adicionado com sucesso.";
                break;
              }

            case 2:
              {
                Console.Clear();

                Console.Write("Digite o ID: ");
                int id = int.Parse(Console.ReadLine());

                var medicamento = _medicamentoController.Pesquisar(
                  new MedicamentoEntity(
                    id,
                    nome: null,
                    laboratorio: null
                ));

                if (medicamento == null)
                {
                  falha = false;
                  mensagem = "Medicamento não encontrado.";
                  break;
                }

                var medicamentoFormatado = FormatarMedicamento(medicamento);

                Console.WriteLine($"Medicamento: \n{medicamentoFormatado}\n");
                Console.Write("Pressione alguma tecla para continuar.");
                Console.ReadKey();

                falha = false;
                mensagem = null;
                break;
              }

            case 3:
              {
                Console.Clear();

                Console.Write("Digite o ID: ");
                int id = int.Parse(Console.ReadLine());

                var medicamento = _medicamentoController.Pesquisar(
                  new MedicamentoEntity(
                    id,
                    nome: null,
                    laboratorio: null
                ));

                if (medicamento == null)
                {
                  falha = true;
                  mensagem = "Medicamento não encontrado.";
                  break;
                }

                var medicamentoFormatado = FormatarMedicamento(medicamento);
                var lotesFormatados = string.Join(
                  '\n',
                  medicamento.Lotes.Select(lote => FormatarLote(lote))
                );

                Console.WriteLine($"Medicamento: \n{medicamentoFormatado}\n");
                Console.WriteLine($"Lotes:");
                Console.WriteLine($"\n{lotesFormatados}\n");

                Console.Write("Pressione alguma tecla para continuar.");
                Console.ReadKey();

                falha = false;
                mensagem = null;
                break;
              }

            case 4:
              {
                Console.Clear();

                Console.Write("Digite o ID do medicamento: ");
                int medicamentoId = int.Parse(Console.ReadLine());

                var medicamento = _medicamentoController.Pesquisar(
                  new MedicamentoEntity(
                    medicamentoId,
                    nome: null,
                    laboratorio: null
                ));

                if (medicamento == null)
                {
                  falha = true;
                  mensagem = "Medicamento não encontrado.";
                  break;
                }

                Console.Write("Digite o ID do lote: ");
                int loteId = int.Parse(Console.ReadLine());

                var lote = medicamento.Lotes.FirstOrDefault(pre => pre.Equals(
                  new Lote(loteId, 0, DateTime.Now)
                ));

                if (lote != null)
                {
                  falha = true;
                  mensagem = "ID em uso.";
                  break;
                }

                Console.Write("Digite a quantidade: ");
                int loteQuantidade = int.Parse(Console.ReadLine());

                Console.WriteLine($"Formato: \"dd/mm/yyy\".");
                Console.WriteLine($"Ex.: {DateTime.Now.ToString("dd/MM/yyyy")}\n");

                Console.Write("Digite a data de vencimento: ");
                var dadosDataVencimento = Console.ReadLine().Split('/');

                DateTime loteDataVencimento = new DateTime(
                  int.Parse(dadosDataVencimento[2]),
                  int.Parse(dadosDataVencimento[1]),
                  int.Parse(dadosDataVencimento[0])
                );

                lote = new Lote(loteId, loteQuantidade, loteDataVencimento);

                medicamento.Comprar(lote);

                falha = false;
                mensagem = "Medicamento aquirido com sucesso.";
                break;
              }

            case 5:
              {
                Console.Clear();

                Console.Write("Digite o ID: ");
                int medicamentoId = int.Parse(Console.ReadLine());

                var medicamento = _medicamentoController.Pesquisar(
                  new MedicamentoEntity(
                    medicamentoId,
                    nome: null,
                    laboratorio: null
                ));

                if (medicamento == null)
                {
                  falha = true;
                  mensagem = "Medicamento não encontrado.";
                  break;
                }

                Console.Write("Digite a quantidade a vender: ");
                int quantidade = int.Parse(Console.ReadLine());

                bool vendeu = medicamento.Vender(quantidade);

                falha = !vendeu;
                mensagem = vendeu
                  ? "Medicamento vendido com sucesso."
                  : "Falha ao vender.";

                break;
              }

            case 6:
              {
                Console.Clear();

                foreach (var medicamento in _medicamentoController.Medicamentos)
                {
                  var medicamentoFormatado = FormatarMedicamento(medicamento);

                  Console.WriteLine($"Medicamento: \n{medicamentoFormatado}\n");
                }

                Console.Write("Pressione alguma tecla para continuar.");
                Console.ReadKey();

                falha = false;
                mensagem = null;
                break;
              }
          }
        }
        catch (Exception exception)
        {
          opcao = 0;
          Console.ForegroundColor = ConsoleColor.Red;
          Console.Write($"Oops... deu ruim: ");
          Console.ForegroundColor = ConsoleColor.White;
          Console.Write(exception.Message + '\n');
        }
      } while (opcao != 0);
    }
  }
}
