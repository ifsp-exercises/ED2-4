using System;

namespace atividade_01.Handlers
{
  public static class ErrorsHandler
  {
    public static void HandleGenericError<Type>(Type exception) where Type : Exception
    {
      Console.ForegroundColor = ConsoleColor.Red;
      Console.Write("An error occurred: ");
      Console.ForegroundColor = ConsoleColor.White;

      Console.WriteLine(exception.Message);
    }
  }
}
