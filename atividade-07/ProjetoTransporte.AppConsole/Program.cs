using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ProjetoTransporte.Domain;

namespace ProjetoTransporte.AppConsole
{
  class Program
  {
    static void Main(string[] args)
    {
      int result;
      Veiculos _veiculos = new Veiculos();
      Garagens _garagens = new Garagens();
      Viagens _viagens = new Viagens();
      List<Transporte> transportes = new List<Transporte>();

      _veiculos.incluir(new Veiculo(1, "BRASIL-1", 30));
      _veiculos.incluir(new Veiculo(2, "BRASIL-2", 30));
      _veiculos.incluir(new Veiculo(3, "BRASIL-3", 30));
      _veiculos.incluir(new Veiculo(4, "BRASIL-4", 30));
      _veiculos.incluir(new Veiculo(5, "BRASIL-5", 30));
      _veiculos.incluir(new Veiculo(6, "BRASIL-6", 30));
      _veiculos.incluir(new Veiculo(7, "BRASIL-7", 30));
      _veiculos.incluir(new Veiculo(8, "BRASIL-8", 30));
      _garagens.Garagems.Add(new Garagem(1, "guarulhos"));
      _garagens.Garagems.Add(new Garagem(2, "congonhas"));

      do
      {
        Console.Clear();
        Console.WriteLine(
        "0. Sair  \n" +
        "1. Cadastrar veículo \n" +
        "2. Cadastrar garagem \n" +
        "3. Iniciar jornada \n" +
        "4. Encerrar jornada \n" +
        "5. Liberar viagem de uma determinada origem para um determinado destino \n" +
        "6. Listar veículos em determinada garagem (informando a qtde de veículos e seu potencial de transporte) \n" +
        "7. Informar qtde de viagens efetuadas de uma determinada origem para um determinado destino \n" +
        "8. Listar viagens efetuadas de uma determinada origem para um determinado destino \n" +
        "9. Informar qtde de passageiros transportados de uma determinada origem para um determinado destino \n");
        Console.Write("O que deseja fazer?: ");
        result = int.Parse(Console.ReadLine());

        switch (result)
        {

          case 1:
            {
              int id = _veiculos.VeiculosList.Count + 1;

              Console.Write("Placa do Veiculos: ");
              string placa = Console.ReadLine();

              Console.Write("Quantidade de Passageiros permitidos: ");
              int lotacao = int.Parse(Console.ReadLine());
              _veiculos.incluir(new Veiculo(id, placa, lotacao));

              break;
            }

          case 2:
            {
              Console.Write("Local da garagem: ");
              var local = Console.ReadLine();
              int codGaragem = _garagens.Garagems.Count + 1;
              _garagens.Garagems.Add(new Garagem(codGaragem, local));

              break;
            }

          case 3:
            {
              var counts = _veiculos.VeiculosList.Count;
              double distribuicao = _veiculos.VeiculosList.Count / _garagens.Garagems.Count;
              var seila = (distribuicao * _garagens.Garagems.Count) == _veiculos.VeiculosList.Count ? true : false;
              int popula = 0;
              for (int i = 0; i < _garagens.Garagems.Count; i++)
              {

                do
                {
                  if (popula == distribuicao)
                  {
                    popula = 0;
                  }
                  if (counts == 0)
                  {
                    break;
                  }
                  _garagens.Garagems[i].Veiculos.Push(_veiculos.VeiculosList[counts - 1]);
                  popula++;
                  counts--;

                }
                while (distribuicao != popula);

              }
              if (!seila)
              {
                for (int j = 0; j < counts; j++)
                {
                  if (counts == 0)
                  {
                    break;
                  }
                  _garagens.Garagems[0].Veiculos.Push(_veiculos.VeiculosList[counts - 1]);
                };
              }
              _garagens.iniciarJornada();
              break;
            }

          case 4:
            {
              for (int i = 0; i < _veiculos.VeiculosList.Count; i++)
              {
                var cont = transportes.Where(x => x.veiculo.Id == _veiculos.VeiculosList[i].Id).ToList();

                if (cont.Count != 0)
                {
                  Console.WriteLine($"veiculo placa: { _veiculos.VeiculosList[i].Placa} | Quantidade transportado: { _veiculos.VeiculosList[i].Lotacao * cont[0].QtdeTransportada }");
                }
                else
                {
                  Console.WriteLine($"veiculo placa: { _veiculos.VeiculosList[i].Placa} => Não fez viagem.");
                }
              }
              _garagens.encerrarJornada();
              _viagens.ViagensQueue.Clear();
              transportes.Clear();
              Console.ReadLine();
              break;
            }

          case 5:
            {
              Console.Write("Origem: ");
              var origemDesc = Console.ReadLine();
              var isvalid = true;
              if (!_garagens.Garagems.Exists(x => x.Local == origemDesc))
              {
                Console.Clear();
                Console.WriteLine("Origem não existe!");
                Thread.Sleep(2000);
                Console.Clear();
                isvalid = false;
              }

              if (_garagens.Garagems.Find(x => x.Local == origemDesc).Veiculos.Count == 0)
              {
                Console.Clear();
                Console.WriteLine("É necessário que tenha veiculo disponivel");
                Thread.Sleep(2000);
                Console.Clear();
                isvalid = false;
              };

              if (isvalid)
              {
                Console.Write("Destino: ");
                var destinoDesc = Console.ReadLine();

                var garagemOrigem = _garagens.Garagems.Find(x => x.Local == origemDesc);
                var garagemDestino = _garagens.Garagems.Find(x => x.Local == destinoDesc);
                var veiculoSaida = garagemOrigem.Veiculos.Pop();

                _viagens.incluir(new Viagem(_viagens.ViagensQueue.Count + 1, garagemOrigem, garagemDestino, veiculoSaida));
                garagemDestino.Veiculos.Push(veiculoSaida);

                var xablau = transportes.Find(x => x.veiculo.Id == veiculoSaida.Id);
                if (xablau == null)
                {
                  transportes.Add(new Transporte(veiculoSaida));
                }
                else
                {
                  xablau.addTransporte();
                }

              }

              break;
            }

          case 6:
            {
              Console.Write("Qual Garagem deseja : ");
              var qualGaragemVoceQuer = Console.ReadLine();
              var mostraGaragem = _garagens.Garagems.Find(x => x.Local == qualGaragemVoceQuer);

              Console.Clear();
              Console.WriteLine($"A garagem possui: { mostraGaragem.qtdeDeVeiculos()} veiculos\n");
              foreach (var lv in mostraGaragem.Veiculos)
              {
                Console.WriteLine($"Placa: {lv.Placa} - Lotação Máxima: {lv.Lotacao}");
              }
              Console.WriteLine("\n\n--------------- Pressiona qualquer tecla para continuar -----------------");

              Console.ReadLine();
            }
            break;

          case 7:
            {
              Console.Write("Qual origem deseja saber: ");
              var org = Console.ReadLine();

              Console.Write("Qual destino deseja saber: ");
              var dest = Console.ReadLine();
              var bvvc = _viagens.ViagensQueue.ToArray();

              var x19 = bvvc.Where(x => x.Destino.Local == dest && x.Origem.Local == org).ToList().Count;

              Console.Clear();
              Console.Write($"Foram feitas nesta rota {x19} viagens!");
              Console.Write("\n\n------------- Pressiona Enter para continuar ------------------- ");
              Console.ReadLine();

              break;
            }


          case 8:
            {
              Console.Write("Qual origem deseja saber: ");
              var orgx = Console.ReadLine();

              Console.Write("Qual destino deseja saber: ");
              var destx = Console.ReadLine();
              var bvvcx = _viagens.ViagensQueue.ToArray();

              var x19x = bvvcx.Where(x => x.Destino.Local == destx && x.Origem.Local == orgx).ToList();

              Console.Clear();

              for (int i = 0; i < x19x.Count; i++)
              {
                Console.WriteLine($"Veiculo: { x19x[i].Veiculo.Placa }| Viagens de {x19x[i].Origem} - para { x19x[i].Destino } ");
              }
              Console.Write("\n\n------------- Pressiona Enter para continuar ------------------- ");
              Console.ReadLine();
              break;
            }

          case 9:
            {
              Console.Write("Qual origem deseja saber: ");
              var orgxy = Console.ReadLine();

              Console.Write("Qual destino deseja saber: ");
              var destxy = Console.ReadLine();
              var bvvcxy = _viagens.ViagensQueue.ToArray();

              var x19xy = bvvcxy.Where(x => x.Destino.Local == destxy && x.Origem.Local == orgxy).ToList();

              Console.Clear();
              int contagem = 0;
              for (int i = 0; i < x19xy.Count; i++)
              {
                contagem += x19xy[i].Veiculo.Lotacao;
              }

              Console.Write($"Quantidade transportadas neste destino: {contagem}");
              Console.Write("\n\n------------- Pressiona Enter para continuar ------------------- ");
              Console.ReadLine();

              break;
            }
        }


      } while (result != 0);
    }
  }
}
