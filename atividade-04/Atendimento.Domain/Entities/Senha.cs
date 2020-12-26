using System;

namespace Atendimento.Domain.Entities
{
  public class Senha
  {
    private int Id { get; set; }
    private DateTime DataGeracao { get; set; }
    private DateTime DataAtendimento { get; set; }


    public Senha(int id)
    {
      Id = id;
      DataGeracao = DateTime.Now;
    }

    public string DadosParciais() =>
      $"{Id} - {DataGeracao.ToString("dd/MM/yyyy")} - {DataGeracao.ToString("HH:mm:ss")}";


    public string DadosCompletos() =>
      $"{DadosParciais()} - {DataAtendimento.ToString("dd/MM/yyyy")} - {DataAtendimento.ToString("HH:mm:ss")}";
  }
}