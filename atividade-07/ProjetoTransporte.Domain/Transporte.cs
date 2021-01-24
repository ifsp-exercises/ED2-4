namespace ProjetoTransporte.Domain
{
  public class Transporte
  {
    public Transporte(Veiculo veiculo)
    {
      this.veiculo = veiculo;
      QtdeTransportada = 1;
    }

    public Veiculo veiculo { get; set; }
    public int QtdeTransportada { get; set; }

    public void addTransporte()
    {
      QtdeTransportada++;
    }
  }
}
