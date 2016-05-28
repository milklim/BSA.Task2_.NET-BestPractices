using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBooks
{
    /// <summary>
    /// Класс описывает пользовательские данные, которые будут содержаться в экземплярах класса
    /// </summary>
    class User : IRecord
    {
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

 #region Реализация интерфейса IRecord
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
 #endregion
        public override string ToString()
        {
            // Формируем формат вывода номера телефона и даты рождения
            string tel = (PhoneNumber != 0) ? PhoneNumber.ToString("(000) 000-00-00") : "n/a";
            string born = (BirthDate.Year == 1) ? "n/a" : BirthDate.ToString("dd/MM/yyyy");

            return string.Format("[{0} {1}, gender: {6}][city: {2}, address: {3}][tel: {4}, e-mail: {5}][born: {7:yyyy}][added: {8:dd/MM/yy HH:mm}]", LastName, FirstName, City, Address, tel, Email, Gender, born, TimeAdded);
        }
    }
}
