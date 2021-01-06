using System.Collections.Generic;
using System.Linq;

namespace Medicamento.Domain.Entities
{
  public class Medicamento
  {
    private readonly Queue<Lote> _lotes;

    public Medicamento(int id, string nome, string laboratorio)
    {
      Id = id;
      Nome = nome;
      Laboratorio = laboratorio;
      _lotes = new Queue<Lote>();
    }

    public int Id { get; private set; }
    public string Nome { get; private set; }
    public string Laboratorio { get; private set; }
    public IReadOnlyCollection<Lote> Lotes { get => _lotes.ToArray(); }

    public int QuantidadeDisponivel()
    {
      return _lotes
        .Where(lote => !lote.Vencido)
        .Select(lote => lote.Quantidade)
        .Sum();
    }
    public void Comprar(Lote lote)
    {
      _lotes.Enqueue(lote);
    }

    public bool Vender(int quantidade)
    {
      bool existeSaldo = this.QuantidadeDisponivel() >= quantidade;

      if (!existeSaldo) return false;

      bool
        loteZerou = false,
        totalDeVendaAtingido = false;

      int totalVendido = 0;

      var loteAtual = _lotes.Peek();

      while (!totalDeVendaAtingido)
      {
        if (loteZerou)
        {
          _lotes.Dequeue();
          loteAtual = _lotes.Peek();
        }

        loteAtual.VenderUnidade();

        totalVendido++;

        totalDeVendaAtingido = totalVendido == quantidade;
      }

      return true;
    }

    public override string ToString() =>
      $"{Id} - {Nome} - {Laboratorio} - {QuantidadeDisponivel()}";

    public override bool Equals(object obj)
    {
      if (!(obj is Medicamento)) return false;

      var medicamento = (Medicamento)obj;

      return Id == medicamento.Id;
    }

    public override int GetHashCode() => Id;
  }
}