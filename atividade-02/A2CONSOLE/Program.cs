using System;
using System.Linq;
using A2CONSOLE.Classes;
using A2CONSOLE.Controllers;

namespace A2CONSOLE
{
  class Program
  {
    private static void ShowOptions()
    {
      Console.WriteLine("Selecione uma das opções abaixo:");
      Console.Write("\n");

      Console.WriteLine("0. Sair");
      Console.WriteLine("1. Adicionar contato");
      Console.WriteLine("2. Pesquisar contato");
      Console.WriteLine("3. Alterar contato");
      Console.WriteLine("4. Remover contato");
      Console.WriteLine("5. Listar contatos");

      Console.Write("\n\n");
    }

    static void Main(string[] args)
    {
      ContactsController contactsController = new ContactsController();
      int[] validOptions = new int[] { 0, 1, 2, 3, 4, 5 };
      bool invalidOptionChosen = false;
      int chosenOption = 0;

      Contact foundContact = null, contactToFind = null;
      string name = null, email = null, telephone = null;

      do
      {
        name = null;
        email = null;
        telephone = null;
        foundContact = null;
        contactToFind = null;

        if (invalidOptionChosen)
        {
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine(
            "A opção anterior era inválida, veja as opções novamente\n"
          );
          Console.ForegroundColor = ConsoleColor.White;
          invalidOptionChosen = false;
        }

        ShowOptions();

        Console.Write("Sua escolha: ");

        try
        {
          chosenOption = int.Parse(Console.ReadLine());

          if (!validOptions.Any(option => Equals(option, chosenOption)))
            throw new Exception();
        }
        catch
        {
          invalidOptionChosen = true;
        }
        finally
        {
          Console.Clear();
        }

        if (invalidOptionChosen) continue;

        switch (chosenOption)
        {
          case 1:
            Console.Write("Informe o nome do contato: ");
            name = Console.ReadLine();

            Console.Write("Informe o email do contato: ");
            email = Console.ReadLine();

            Console.Write("Informe o telefone do contato: ");
            telephone = Console.ReadLine();

            Contact newContact = new Contact(name, email, telephone);
            bool added = contactsController.Add(newContact);

            if (!added) throw new Exception($"An error occurred while adding contact: {newContact.ToString()}");
            break;

          case 2:
            Console.WriteLine("Digite o email do contato a pesquisar: ");
            email = Console.ReadLine();

            contactToFind = new Contact(name: "", email, telephone: "");

            foundContact = contactsController.Find(contactToFind);

            if (Equals(foundContact, null))
            {
              Console.WriteLine("Contato não encontrado.");
            }
            else
            {
              Console.WriteLine(foundContact.ToString());
            }
            break;

          case 3:
            Console.Write("Digite o email do contato a atualizar: ");
            email = Console.ReadLine();

            contactToFind = new Contact(name: "", email, telephone: "");

            foundContact = contactsController.Find(contactToFind);

            if (Equals(foundContact, null))
            {
              Console.WriteLine("Contato não encontrado.");
              break;
            }

            Console.Write("Digite o novo nome: ");
            foundContact.Name = Console.ReadLine();

            Console.Write("Digite o novo email: ");
            foundContact.Email = Console.ReadLine();

            Console.Write("Digite o novo telefone: ");
            foundContact.Telephone = Console.ReadLine();

            Console.Write("Digite o ano de nascimento: ");
            foundContact.Birthdate.Year = int.Parse(Console.ReadLine());

            Console.Write("Digite o mês de nascimento: ");
            foundContact.Birthdate.Month = int.Parse(Console.ReadLine());

            Console.Write("Digite o dia de nascimento: ");
            foundContact.Birthdate.Day = int.Parse(Console.ReadLine());

            bool updated = contactsController.Update(foundContact);

            if (!updated) throw new Exception($"An error occurred while updating contact: {foundContact.ToString()}");
            break;

          case 4:
            Console.Write("Digite o email do contato a excluir: ");
            email = Console.ReadLine();

            contactToFind = new Contact(name: "", email, telephone: "");

            foundContact = contactsController.Find(contactToFind);

            if (Equals(foundContact, null))
            {
              Console.WriteLine("Contato não encontrado.");
              break;
            }

            bool deleted = contactsController.Delete(foundContact);

            if (!deleted) throw new Exception($"An error occurred while updating contact: {foundContact.ToString()}");
            break;

          case 5:
            foreach (Contact contact in contactsController.Book)
              Console.WriteLine(contact.ToString());

            Console.WriteLine();
            Console.WriteLine("Pressione alguma tecla para continuar...");
            Console.ReadKey();
            break;
        }

        Console.Clear();
      } while (!chosenOption.Equals(0) || invalidOptionChosen);
    }
  }
}
