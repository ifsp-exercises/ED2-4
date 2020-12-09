using System;
using System.Collections.Generic;
using A2CONSOLE.Classes;

namespace A2CONSOLE.Controllers
{
  public class ContactsController
  {
    public List<Contact> Book { get; set; }

    public ContactsController()
    {
      this.Book = new List<Contact>();
    }

    public bool Add(Contact contact)
    {
      throw new NotImplementedException();
    }

    public bool Find(Contact contact)
    {
      throw new NotImplementedException();
    }

    public bool Update(Contact contact)
    {
      throw new NotImplementedException();
    }

    public bool Delete(Contact contact)
    {
      throw new NotImplementedException();
    }


  }
}
