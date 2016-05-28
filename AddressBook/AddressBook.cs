using System;
using System.Collections;
using System.Collections.Generic;

namespace AddressBooks
{
    public abstract class AddressBook : IEnumerable
    {
        // The list to store records, implementing the IRecord interface
        protected List<IRecord> Records = null;

        public IRecord this[int index]
        {
            get { return Records[index]; }
        }

        // The method adds a new record with the specified parameters in address book
        public abstract void AddRecord(string fname, string lname, string city = "n/a", string address = "n/a", long phoneNumber = 0,
                                        string email = "n/a", Gender gender = Gender.unknown, DateTime birthDate = new DateTime());

        // The method removes the entry at the specified index
        public abstract void RemoveRecord(int index);

        // The method removes the first entry with the specified name.
        public abstract void RemoveRecord(string name);

        // Implementation of the IEnumerable interface
        public IEnumerator GetEnumerator()
        {
            return Records.GetEnumerator();
        }


    }
}
