using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBooks
{
    class User : IRecord
    {
        private DateTime _birthDate;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public DateTime TimeAdded { get; set; }
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set 
            {
                if (value < DateTime.Now)
                    _birthDate = value;
                else
                    _birthDate = new DateTime();
            }
        }

        
        public User() : this("John", "Doe") { }
        public User(string fname, string lname, string city = "n/a", string address = "n/a", long phoneNumber = 0,
                        string email = "n/a", Gender gender = Gender.unknown, DateTime birthDate = new DateTime())
        {
            FirstName = fname;
            LastName = lname;
            City = city;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
            Gender = gender;
            BirthDate = birthDate;
            TimeAdded = DateTime.Now;
        }
//TODO: User.ToString() - Настроить вывод 
        public override string ToString()
        {
            return string.Format("{0} | {1} | {2} | {3}", FirstName, LastName, City, TimeAdded);
        }
    }
}
