using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locacao.Models
{
  class Equipamentos
  {
    private List<TipoEquipamento> estoque;

    public Equipamentos()
    {
      estoque = new List<TipoEquipamento>();
    }

    public List<TipoEquipamento> Estoque
    {
      get { return estoque; }
      set { estoque = value; }
    }

    public void incluir(TipoEquipamento eTip)
    {
      eTip.Id = estoque.Count + 1;
      estoque.Add(eTip);
    }

    public TipoEquipamento buscar(string nome)
    {
      TipoEquipamento ret = new TipoEquipamento();
      foreach (TipoEquipamento te in estoque)
      {
        if (te.Nome == nome)
        {
          ret = te;
        }
      }
      return ret;
    }

  }
}
