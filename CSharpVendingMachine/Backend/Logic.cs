using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpVendingMachine.Backend
{
    class Logic
    {
        public static Person getUserByUsername(string username)
        {
            List<Person> Admins = DatabaseMethods.getAdmins();
            List<Person> Stockers = DatabaseMethods.getStockers();

            foreach (Admin admin in Admins)
            {
                if (admin.Username.Equals(username))
                {
                    return admin;
                }
            }

            foreach (Stocker stocker in Stockers)
            {
                if (stocker.Username.Equals(username))
                {
                    return stocker;
                }
            }

            return null;

        }

        public static decimal getTotalFromCart(List<Item> items)
        {
            decimal total = 0;

            foreach(Item item in items)
            {
                total += item.Cost;
            }

            return total;
        }

        public static bool isValidProductCode(string input, List<Item> items)
        {
            foreach (Item item in items)
            {
                if (item.Code.Equals(input))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
