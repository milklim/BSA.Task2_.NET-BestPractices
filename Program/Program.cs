using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AddressBooks;

namespace Program
{
    class Program
    {
        static void Main()
        {
            AddressBook Users = new AddressBookWithUsers();
            Users.AddRecord("Vladimir", "Klimenko");
            Users.AddRecord();

            foreach (var item in Users)
            {
                Console.WriteLine("1: {0}", item);
            }

            Users.RemoveRecord(1);

            foreach (var item in Users)
            {
                Console.WriteLine("2: {0}",item);
            }

            Console.ReadKey();
        }
    }
}
