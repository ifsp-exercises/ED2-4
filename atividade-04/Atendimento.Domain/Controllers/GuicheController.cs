using System.Collections.Generic;
using Atendimento.Domain.Entities;

namespace Atendimento.Domain.Controllers
{
  public class GuicheController
  {
    private readonly IList<Guiche> _listaGuiches;

    public GuicheController() =>
      _listaGuiches = new List<Guiche>();

    public void Adicionar(Guiche guiche) =>
      _listaGuiches.Add(guiche);
  }
}