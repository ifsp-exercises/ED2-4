using System;
using AccessLogger.Domain.Enums;

namespace AccessLogger.Domain.Entities
{
  public class Log
  {
    public Log(User user, EAccessType accessType)
    {
      User = user;
      AccessType = accessType;
      AccessDate = DateTime.Now;
    }

    public User User { get; private set; }
    public DateTime AccessDate { get; private set; }
    public EAccessType AccessType { get; private set; }
  }
}