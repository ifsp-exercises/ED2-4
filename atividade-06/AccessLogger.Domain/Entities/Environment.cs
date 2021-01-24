using System;
using System.Collections.Generic;

namespace AccessLogger.Domain.Entities
{
  public class Environment
  {
    private readonly Queue<Log> _logs;

    public Environment(string name)
    {
      Name = name;
      Id = new Guid();
      _logs = new Queue<Log>();
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public IReadOnlyCollection<Log> Logs { get => _logs.ToArray(); }

    public void RegisterLog(Log log)
    {
      CheckAndFreeLogStorage();

      _logs.Enqueue(log);
    }

    private void CheckAndFreeLogStorage()
    {
      if (_logs.Count == 100)
        _logs.Dequeue();
    }
  }
}