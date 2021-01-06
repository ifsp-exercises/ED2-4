using System;

namespace Medicamento.Domain.Entities
{
  public class Lote
  {
    public Lote(int id, int quantidade, DateTime dataVencimento)
    {
      Id = id;
      Quantidade = quantidade;
      DataVencimento = dataVencimento;
    }

    public int Id { get; private set; }
    public int Quantidade { get; private set; }
    public DateTime DataVencimento { get; private set; }
    public bool Vencido { get => DataVencimento < DateTime.Now; }

    public void VenderUnidade() => Quantidade--;

    public override string ToString() =>
      $"{Id} - {Quantidade} - {DataVencimento}";

    public override bool Equals(object obj)
    {
      if (!(obj is Lote)) return false;

      var lote = (Lote)obj;

      return Id == lote.Id;
    }

    public override int GetHashCode() => Id;
  }
}