using System.Collections.Generic;
using Atendimento.Domain.Entities;

namespace Atendimento.Domain.ViewModels
{
  public class GuicheViewModel
  {
    public int Id { get; set; }
    public IEnumerable<Senha> Atendimentos { get; set; }
  }
}