using System;
using Locacao.Models;

using LocacaoModel = Locacao.Models.Locacao;


namespace Locacao
{
  class Program
  {
    static void Main(string[] args)
    {
      Equipamentos equipamentos = new Equipamentos();
      Locacoes locacoes = new Locacoes();
      int opc;
      Console.WriteLine("0. Sair");
      Console.WriteLine("1. Cadastrar tipo de equipamento");
      Console.WriteLine("2. Consultar tipo de equipamento (com os respectivos itens cadastrados)");
      Console.WriteLine("3. Cadastrar equipamento (item em um determinado tipo)");
      Console.WriteLine("4. Registrar Contrato de Locação");
      Console.WriteLine("5. Consultar Contratos de Locação (com os respectivos itens contratados)");
      Console.WriteLine("6. Liberar de Contrato de Locação");
      Console.WriteLine("7. Consultar Contratos de Locação liberados (com os respectivos itens)");
      Console.WriteLine("8. Devolver equipamentos de Contrato de Locação liberado");
      Console.WriteLine("Escolha uma opção: ");
      opc = int.Parse(Console.ReadLine());


      while (opc != 0)
      {
        if (opc == 1)
        {
          Console.WriteLine("Digite o tipo de equipamento:");
          string tipo = Console.ReadLine();
          TipoEquipamento te = new TipoEquipamento();
          te.Nome = tipo;
          equipamentos.incluir(te);
        }
        if (opc == 2)
        {
          Console.WriteLine("Digite o tipo de equipamento:");
          string tipo = Console.ReadLine();
          TipoEquipamento te = new TipoEquipamento();
          te.Nome = tipo;
          foreach (TipoEquipamento t in equipamentos.Estoque)
          {
            if (t.Equals(te))
            {
              Console.WriteLine("Tipo:" + te.Nome);
              foreach (Equipamento e in t.Itens)
              {
                Console.WriteLine("Id:" + e.Id + " Avariado:" + e.Avariado + " Disponivel:" + e.Locado);
              }
            }
          }
        }
        if (opc == 3)
        {
          Console.WriteLine("Digite o tipo de equipamento:");
          string tipo = Console.ReadLine();
          TipoEquipamento te = new TipoEquipamento();
          te.Nome = tipo;
          foreach (TipoEquipamento t in equipamentos.Estoque)
          {
            if (t.Equals(te))
            {
              Console.WriteLine("Quantos equipamentos deseja cadastrar:");
              int qtdE = int.Parse(Console.ReadLine());
              for (int i = 0; i < qtdE; i++)
              {
                Equipamento e = new Equipamento();
                e.Locado = false;
                e.Avariado = false;
                t.incluir(e);
              }
            }
          }
        }
        if (opc == 4)
        {

          LocacaoModel loc = new LocacaoModel();
          Console.WriteLine("Digite a data de saida:");
          string dt_saida = Console.ReadLine();
          Console.WriteLine("Digite a data de retorno:");
          string dt_retorno = Console.ReadLine();
          loc.Dt_saida = DateTime.Parse(dt_saida);
          loc.Dt_retorno = DateTime.Parse(dt_retorno);
          string optC = "";
          while (optC != "0")
          {
            Console.WriteLine("Digite o tipo de equipamento:");
            string tipo = Console.ReadLine();
            TipoEquipamento te = new TipoEquipamento();
            te.Nome = tipo;
            Console.WriteLine("Quantos equipamentos deseja cadastrar:");
            int qtdE = int.Parse(Console.ReadLine());
            for (int i = 0; i < qtdE; i++)
            {
              Equipamento e = new Equipamento();
              e.Locado = false;
              e.Avariado = false;
              te.incluir(e);
              foreach (TipoEquipamento teqp in equipamentos.Estoque)
              {
                if (equipamentos.Estoque.Equals(te))
                {
                  foreach (Equipamento eqp in teqp.Itens)
                  {
                    if (eqp.Equals(e))
                    {
                      eqp.Locado = true;
                    }
                  }
                }
              }

            }
            loc.incluir(te);

            Console.WriteLine("Digite 0 se não quiser cadastrar outro equipamento: ");
            optC = Console.ReadLine();
          }

          locacoes.incluir(loc);

        }
        if (opc == 5)
        {
          Console.WriteLine("Digite o codigo do Contrato:");
          int lid = int.Parse(Console.ReadLine());
          LocacaoModel l = new LocacaoModel();
          l.Id = lid;
          foreach (LocacaoModel l1 in locacoes.Contratos)
          {
            if (l1.Equals(l))
            {
              l = l1;
              foreach (TipoEquipamento t in l.Itens)
              {
                Console.WriteLine("Tipo:" + t.Nome);
                foreach (Equipamento e in t.Itens)
                {
                  Console.WriteLine("Id:" + e.Id + " Avariado:" + e.Avariado + " Disponivel:" + e.Locado);

                }
              }
            }
          }
        }
        if (opc == 6)
        {

          Console.WriteLine("Digite o codigo do Contrato:");
          int lid = int.Parse(Console.ReadLine());
          LocacaoModel l = new LocacaoModel();
          l.Id = lid;
          foreach (LocacaoModel l1 in locacoes.Contratos)
          {
            if (l1.Equals(l))
            {
              l1.Liberado = true;
            }
          }
        }
        if (opc == 7)
        {
          foreach (LocacaoModel l1 in locacoes.Contratos)
          {
            if (l1.Liberado == true)
            {
              Console.WriteLine("Id:" + l1.Id + " DataSaida:" + l1.Dt_saida + " DataRetorno:" + l1.Dt_retorno);
            }
            foreach (TipoEquipamento te in l1.Itens)
            {
              Console.WriteLine("Tipo:" + te.Nome);
              foreach (Equipamento e in te.Itens)
              {
                Console.WriteLine("Id:" + e.Id + " Avariado:" + e.Avariado + " Disponivel:" + e.Locado);
              }
            }
          }
        }
        if (opc == 8)
        {
          Console.WriteLine("Digite o codigo do Contrato:");
          int lid = int.Parse(Console.ReadLine());
          LocacaoModel l = new LocacaoModel();
          l.Id = lid;
          foreach (LocacaoModel l1 in locacoes.Contratos)
          {
            if (l1.Equals(l))
            {
              l = l1;
              foreach (TipoEquipamento t in l.Itens)
              {
                foreach (TipoEquipamento t1 in equipamentos.Estoque)
                {
                  if (t == t1)
                  {
                    foreach (Equipamento e in t.Itens)
                    {
                      foreach (Equipamento e1 in t1.Itens)
                      {
                        if (e == e1)
                        {
                          e.Locado = false;
                        }
                      }
                    }
                  }
                }
              }
            }
          }

        }
        Console.WriteLine("-------------------------------");
        Console.WriteLine("0. Sair");
        Console.WriteLine("1. Cadastrar tipo de equipamento");
        Console.WriteLine("2. Consultar tipo de equipamento (com os respectivos itens cadastrados)");
        Console.WriteLine("3. Cadastrar equipamento (item em um determinado tipo)");
        Console.WriteLine("4. Registrar Contrato de Locação");
        Console.WriteLine("5. Consultar Contratos de Locação (com os respectivos itens contratados)");
        Console.WriteLine("6. Liberar de Contrato de Locação");
        Console.WriteLine("7. Consultar Contratos de Locação liberados (com os respectivos itens)");
        Console.WriteLine("8. Devolver equipamentos de Contrato de Locação liberado");
        Console.WriteLine("Escolha uma opção: ");
        opc = int.Parse(Console.ReadLine());
      }

    }
  }
}
