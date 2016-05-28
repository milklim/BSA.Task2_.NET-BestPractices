using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogInfo;

namespace AddressBooks
{
    public class AddressBookWithUsers : AddressBook
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса AddressBookWithUsers
        /// Здесь происходит подписка на события создания/удаления записи
        /// </summary>
        public AddressBookWithUsers()
        {
            Records = new List<IRecord>();
            UserAdded += Logger.Instance.Info;
            UserRemoved += Logger.Instance.Info;
            OnWarning += Logger.Instance.Warning;
        }

        // события по которым будет осуществляться запись в лог
        public delegate void AddLogDelegate(string s);
        public delegate void RemoveLogDelegate(string s);
        public delegate void WarningDelegate(string s);
        public delegate void DebugDelegate(string s);
        public event AddLogDelegate UserAdded;
        public event RemoveLogDelegate UserRemoved;
        public event WarningDelegate OnWarning;
        public event DebugDelegate OnDebug;
       
#region Реализация абстактных методов класса AddressBook
        public override void AddRecord(string fname, string lname, string city, string address, long phoneNumber, string email, Gender gender, DateTime birthDate)
        {
            try
            {
                User newUser = new User(fname, lname, city, address, phoneNumber, email, gender, birthDate);
                string message = newUser.ToString();
                Records.Add(newUser);
                UserAdded("User added: " + message);
            }
            catch (Exception ex)
            {
                OnDebug(string.Format("Failed to create new entry. (Args: {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}). -- {8}", fname, lname, city, address, phoneNumber, email, gender, birthDate, ex.StackTrace));
            }
        }
        public override void RemoveRecord(int index)
        {
            try
            {
                string message = Records[index].ToString();
                Records.RemoveAt(index);
                UserRemoved(string.Format("User removed: {0}", message));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                OnWarning(string.Format("Failed to remove the entry at index {0}. -- {1}", index, ex.GetType()));
            }

        }
        public override void RemoveRecord(string name)
        {
            string[] fullName = name.Split(' ');
            bool removed = false;
            switch (fullName.Length)
            {
               case 1:
                   foreach (IRecord user in Records)
	               {
                       if (user.LastName.ToLower() == fullName[0].ToLower())
                       {
                           RemoveRecord(Records.IndexOf(user));
                           removed = true;
                           break;
                       }
	               }
                   break;
                case 2:
                   foreach (IRecord user in Records)
	               {
                       if (user.LastName.ToLower() == fullName[0].ToLower())
                       {
                           if (user.FirstName.ToLower() == fullName[1].ToLower())
                           {
                               RemoveRecord(Records.IndexOf(user));
                               removed = true;
                               break;
                           }
                       }
	               }
                   break;
            }

            if (!removed)
                UserRemoved(string.Format("Failed to remove the entry by name. (name: {0})", name));
        }
#endregion




    }
}
