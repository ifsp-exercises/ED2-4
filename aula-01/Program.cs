using System;
using aula_01.Controller;
using aula_01.Model;

namespace aula_01
{
  class Program
  {
    static void Main(string[] args)
    {
      CoisasController coisas = new CoisasController(5);

      Console.WriteLine(coisas.MostrarCoisas());
      Console.WriteLine("---");

      coisas.AddCoisa(new Coisa(55, "Cinquenta e cinco"));
      coisas.AddCoisa(new Coisa(66, "Sessenta e seis"));

      Console.WriteLine(coisas.MostrarCoisas());

      Console.WriteLine(coisas.FindCoisa(new Coisa(66, "Sessenta e seis")).dados());
    }
  }
}
