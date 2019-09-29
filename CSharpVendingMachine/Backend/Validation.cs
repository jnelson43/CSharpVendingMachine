using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpVendingMachine.Backend
{
    class Validation
    {
        public static bool UsernameExistsAdmin(string username)
        {
            List<Person> Admins = DatabaseMethods.getAdmins();

            foreach(Admin admin in Admins)
            {
                if (admin.Username.Equals(username)){
                    return true;
                }
            }
            return false;
        }

        public static bool UsernameExistsStocker(string username)
        {
            List<Person> Stockers = DatabaseMethods.getStockers();

            foreach (Stocker stocker in Stockers)
            {
                if (stocker.Username.Equals(username))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool ValidatePassword(string username, string password) {
            Person user = getUserByUsername(username);
            if (user.Password.Equals(password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
