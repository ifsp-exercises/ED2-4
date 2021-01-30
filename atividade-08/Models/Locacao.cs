using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locacao.Models
{
  class Locacao
  {
    private int id;
    private bool liberado = false;
    private DateTime dt_saida;
    private DateTime dt_retorno;
    private Stack<TipoEquipamento> itens;

    public Locacao()
    {
      id = 0;
      liberado = false;
      dt_saida = new DateTime();
      dt_retorno = new DateTime();
      itens = new Stack<TipoEquipamento>();
    }

    public int Id
    {
      get { return id; }
      set { id = value; }
    }

    public bool Liberado
    {
      get { return liberado; }
      set { liberado = value; }
    }

    public DateTime Dt_saida
    {
      get { return dt_saida; }
      set { dt_saida = value; }
    }

    public DateTime Dt_retorno
    {
      get { return dt_retorno; }
      set { dt_retorno = value; }
    }

    public Stack<TipoEquipamento> Itens
    {
      get { return itens; }
      set { itens = value; }
    }

    public void incluir(TipoEquipamento eTip)
    {
      eTip.Id = itens.Count + 1;
      itens.Push(eTip);
    }

    public TipoEquipamento buscar(string nome)
    {
      TipoEquipamento ret = new TipoEquipamento();
      foreach (TipoEquipamento te in itens)
      {
        if (te.Nome == nome)
        {
          ret = te;
        }
      }
      return ret;
    }

    public override bool Equals(object obj)
    {
      return this.id.Equals(((Locacao)obj).id);
    }
  }
}
