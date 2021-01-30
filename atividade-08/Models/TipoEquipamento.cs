using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locacao.Models
{
  class TipoEquipamento
  {
    private int id;
    private string nome;
    private List<Equipamento> itens;

    public TipoEquipamento()
    {
      id = 0;
      nome = "";
      itens = new List<Equipamento>();
    }

    public int Id
    {
      get { return id; }
      set { id = value; }
    }

    public string Nome
    {
      get { return nome; }
      set { nome = value; }
    }


    public List<Equipamento> Itens
    {
      get { return itens; }
      set { itens = value; }
    }

    public void incluir(Equipamento eq)
    {
      eq.Id = itens.Count + 1;
      itens.Add(eq);
    }

    public Equipamento buscar(int id)
    {
      Equipamento ret = new Equipamento();
      foreach (Equipamento e in itens)
      {
        if (e.Id == id)
        {
          ret = e;
        }
      }
      return ret;
    }

    public override bool Equals(object obj)
    {
      return (this.nome.Equals(((TipoEquipamento)obj).nome));
    }
  }
}
