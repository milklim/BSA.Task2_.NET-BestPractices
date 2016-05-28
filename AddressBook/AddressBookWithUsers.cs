using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBooks
{
    public class AddressBookWithUsers : AddressBook
    {
        public override void AddRecord() 
        {
            Records.Add(new User());
        }

        public override void AddRecord(string fname, string lname, string city, string address, long phoneNumber,
                                        string email, Gender gender, DateTime birthDate)
        {
            Records.Add(new User(fname, lname, city, address, phoneNumber, email, gender, birthDate));
        }

        public AddressBookWithUsers()
        {
            Records = new List<IRecord>();
        }

    }
}
