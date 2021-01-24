using System;
using System.Collections.Generic;
using System.Linq;
using AccessLogger.Domain.Enums;

namespace AccessLogger.Domain.Entities
{
  public class User
  {
    private readonly IList<Environment> _environments;

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public IReadOnlyCollection<Environment> Environments { get => _environments.ToArray(); }

    private bool CheckEnvironmentIsRegistered(Environment environment) =>
      _environments.Any(
        pre => pre.Id.Equals(environment.Id)
      );

    public bool GivePermission(Environment environment)
    {
      if (CheckEnvironmentIsRegistered(environment))
        return false;

      environment.RegisterLog(new Log(this, EAccessType.Allowed));
      _environments.Add(environment);

      return true;
    }

    public bool RevokePermission(Environment environment)
    {
      if (!CheckEnvironmentIsRegistered(environment))
        return false;

      environment.RegisterLog(new Log(this, EAccessType.NotAllowed));
      _environments.Add(environment);

      return true;
    }
  }
}