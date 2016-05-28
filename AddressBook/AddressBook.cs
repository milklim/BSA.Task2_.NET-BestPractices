using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogInfo;

namespace AddressBooks
{
    public abstract class AddressBook : IEnumerable
    {
        /// <summary>
        /// Список для хранения записей, приведенных к интерфейсу IRecord
        /// </summary>
        protected List<IRecord> Records = null;

        /// <summary>
        ///  Возвращает запись по заданному индексу
        /// </summary>
        /// <param name="index">Задаваемый индекс</param>
        /// <returns>Запись с заданным индексом</returns>
        public IRecord this[int index]
        {
            get { return Records[index]; }
        }

        /// <summary>
        /// Метод добавляет новую запись с заданными парамертами в адресную книгу
        /// </summary>
        /// <param name="fname">Имя</param>
        /// <param name="lname">Фамилия</param>
        /// <param name="city">Город</param>
        /// <param name="address">Адресс</param>
        /// <param name="phoneNumber">Номер телефона</param>
        /// <param name="email">E-mail</param>
        /// <param name="gender">Пол</param>
        /// <param name="birthDate">Дата рождения</param>
        public abstract void AddRecord(string fname, string lname, string city = "n/a", string address = "n/a", long phoneNumber = 0,
                                        string email = "n/a", Gender gender = Gender.unknown, DateTime birthDate = new DateTime());
        /// <summary>
        /// Удаляет запись по заданному индексу
        /// </summary>
        /// <param name="index">Индекс элемента, который требуется удалить</param>
        public abstract void RemoveRecord(int index);
        /// <summary>
        /// Удаляет первую найденную запись с заданным именем.
        /// </summary>
        /// <param name="name">Имя для поиска нужной записи. "Фамилия" или "Фамилия Имя" через пробел.</param>
        public abstract void RemoveRecord(string name);
   
        /// <summary>
        /// Реализация интерфейса IEnumerable
        /// </summary>
        /// <returns>Возвращает перечислитель для перебора элементов.</returns>
        public IEnumerator GetEnumerator()
        {
            return Records.GetEnumerator();
        }


    }
}
