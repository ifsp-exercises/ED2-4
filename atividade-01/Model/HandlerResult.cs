namespace atividade_01.Models
{
  public class HandlerResult
  {
    public bool Success { get; private set; }
    public string Message { get; private set; }

    public HandlerResult(bool success, string message)
    {
      this.Success = success;
      this.Message = message;
    }
  }
}
