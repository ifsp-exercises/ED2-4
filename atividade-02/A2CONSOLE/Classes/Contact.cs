using System;

namespace A2CONSOLE.Classes
{
  public class Contact
  {
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Telephone { get; private set; }
    public Date Birthdate { get; set; }

    public int GetAge()
    {
      DateTime today = DateTime.Now;
      int age = 0;

      age = today.Year - this.Birthdate.Year;

      if (today.Month <= this.Birthdate.Month
        && today.Day <= this.Birthdate.Year)
      {
        age++;
      }

      return age;
    }

    public override string ToString() =>
      $"Name: {this.Name}; Email: {this.Email}; Telephone: {this.Telephone}; Birthdate: {this.Birthdate};";

    public override bool Equals(object obj)
    {
      if (!(obj is Contact))
        return false;

      return Equals(((Contact)obj).Email, this.Email);
    }
  }
}

