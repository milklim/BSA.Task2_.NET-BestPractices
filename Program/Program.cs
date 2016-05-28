using System;
using AddressBooks;
using LogInfo;

namespace Program
{
    class Program
    {
        static void Main()
        {
            AddressBook Users = new AddressBookWithUsers();

     // Configure logger: (by default - output to console)
            //Logger.Source = new LogToFile();

            Users.AddRecord("Vasiliy", "Pupkin", "Zhitomir", phoneNumber: 0990484566, gender: Gender.male, birthDate: new DateTime(1980, 05, 28));
            Users.AddRecord("Vladimir", "Klimenko", "Pavlograd", phoneNumber: 0507757568, email: "klimbox@gmail.com", gender: Gender.male, birthDate: new DateTime(1987, 01, 27));
            Users.AddRecord("Sherlock", "Holms", "London", "Baker str.", 0985647531, "eioo@git.ua", Gender.male, new DateTime(1985, 12, 05));
            Users.AddRecord("", "Vatson", gender: Gender.male); Users.AddRecord("Vasiliy", "Pupkin", "Zhitomir", phoneNumber: 0990484566, gender: Gender.male, birthDate: new DateTime(1980, 05, 28));

            Users.RemoveRecord(0);
            Users.RemoveRecord(6);
            Users.RemoveRecord("Holms");
            Users.RemoveRecord("karabas");

            Logger.Source = new LogToConsole();
            Users.AddRecord("T","G");

            Console.ReadKey();
        }
    }
}
