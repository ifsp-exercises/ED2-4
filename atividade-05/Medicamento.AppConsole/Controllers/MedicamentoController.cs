using System.Collections.Generic;
using System.Linq;
using MedicamentoEntity = Medicamento.Domain.Entities.Medicamento;

namespace Medicamento.AppConsole.Controllers
{
  public class MedicamentoController
  {
    private readonly IList<MedicamentoEntity> _listaMedicamentos;

    public MedicamentoController()
    {
      _listaMedicamentos = new List<MedicamentoEntity>();
    }

    public IReadOnlyCollection<MedicamentoEntity> Medicamentos =>
      _listaMedicamentos.ToArray();
    
    public MedicamentoController Adicionar(MedicamentoEntity medicamento)
    {
      _listaMedicamentos.Add(medicamento);

      return this;
    }

    public bool Remover(MedicamentoEntity medicamento)
    {
      int indiceDoMedicamento = _listaMedicamentos.IndexOf(medicamento);

      if (indiceDoMedicamento == -1)
        return false;

      bool restamItens = _listaMedicamentos
        .ElementAt(indiceDoMedicamento)
        .QuantidadeDisponivel() > 0;

      if (restamItens)
        return false;

      _listaMedicamentos.RemoveAt(indiceDoMedicamento);

      return true;
    }

    public MedicamentoEntity Pesquisar(MedicamentoEntity medicamento) =>
      _listaMedicamentos.FirstOrDefault(pre => pre.Equals(medicamento));
  }
}