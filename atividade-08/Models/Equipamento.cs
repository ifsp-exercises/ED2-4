using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locacao.Models
{
  class Equipamento
  {

    private int id;
    private bool avariado;
    private bool locado;

    public Equipamento()
    {
      id = 0;
      avariado = false;
      locado = false;
    }

    public int Id
    {
      get { return id; }
      set { id = value; }
    }

    public bool Avariado
    {
      get { return avariado; }
      set { avariado = value; }
    }

    public bool Locado
    {
      get { return locado; }
      set { locado = value; }
    }

    public override bool Equals(object obj)
    {
      return this.id.Equals(((Equipamento)obj).id);
    }
  }
}
