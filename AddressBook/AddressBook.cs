using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBooks
{
    public abstract class AddressBook : IEnumerable
    {
        protected List<IRecord> Records = null;

        public abstract void AddRecord();
        public abstract void AddRecord(string fname, string lname, string city = "n/a", string address = "n/a", long phoneNumber = 0,
                                        string email = "n/a", Gender gender = Gender.unknown, DateTime birthDate = new DateTime());

        public bool RemoveRecord(int index)
        {
            Records.RemoveAt(index);
            return true;
        }

        delegate void AddLogDelegate();
        delegate void RemoveLogDelegate();

        public event AddLogDelegate UserAdding;
        public event RemoveLogDelegate UserRemoved;

        public IEnumerator GetEnumerator()
        {
            return Records.GetEnumerator();
        }

        public IRecord this[int index]
        {
            get { return Records[index]; }
        }
    }
}
