using CSharpVendingMachine.Backend;
using System;
using System.Collections.Generic;

namespace CSharpVendingMachine
{
    class Program
    {
        private static Person LoggedUser = null;
        private static Machine currentMachine = new Machine();
        static void Main(string[] args)
        {
            DisplayWelcome();
        }

        static void DisplayWelcome()
        {
            Console.WriteLine("********** Welcome to my vending machine! **********");
            Console.WriteLine("Press space bar to continue");
            string input = Console.ReadLine();
            if (input.Equals("l"))
            {
                DisplayLogin();
            }
            else
            {
                DisplayMenu();
            }
        }

        static void DisplayLogin()
        {
            Console.WriteLine("********** Login Page **********");
            while (LoggedUser != null)
            {
                Console.Write("Enter Username");
                string input = Console.ReadLine();
                if (input.Equals("c"))
                {
                    DisplayWelcome();
                }
                if (Validation.UsernameExistsAdmin(input) || Validation.UsernameExistsStocker(input))
                {
                    LoggedUser = Logic.getUserByUsername(input);
                }
                else
                {
                    Console.WriteLine("Username Doesn't Exist, try again or enter 'c' to cancel");
                }
            }

            bool validPassword = false;
            while (validPassword == false)
            {
                Console.Write("Enter Password");
                string input = Console.ReadLine();
                if (input.Equals("c"))
                {
                    LoggedUser = null;
                    DisplayWelcome();
                }
                if (Validation.ValidatePassword(LoggedUser.Username,input))
                {
                    Type userType = LoggedUser.GetType();
                    if (userType.Equals(new Admin()))
                    {
                        DisplayAdminMenu();
                    }
                    else if(userType.Equals(new Stocker()))
                    {
                        DisplayStockerMenu();
                    }
                    else
                    {
                        Console.Write("Error: Logged user type not found");
                        DisplayLogin();
                    }
                    
                }
                else
                {
                    Console.WriteLine("Password Incorrect, try again or enter 'c' to cancel");
                }
            }
        }

        static void DisplayAdminMenu()
        {
            Console.WriteLine("Welcome " + LoggedUser.Username + "\n");
            Console.WriteLine("What would you like to do? Enter the corresponding number to select option");
            Console.WriteLine("1: Add new Admin");
            Console.WriteLine("2: Remove Admin");
            Console.WriteLine("3: Edit Admin");
            Console.WriteLine("4: Add new Stocker");
            Console.WriteLine("5: Remove Stocker");
            Console.WriteLine("6: Edit Stocker");
        }

        static void DisplayStockerMenu()
        {
            Console.WriteLine("Welcome " + LoggedUser.Username + "\n");
            Console.WriteLine("What would you like to do? Enter the corresponding number to select option");
            Console.WriteLine("1: Add Items");
            Console.WriteLine("2: Remove Items");
        }

        static void DisplayMenu()
        {
            Purchase purchase = new Purchase();
            currentMachine.Inventory = DatabaseMethods.getItems();
            currentMachine.PaymentsTotal = Logic.getTotalFromCart(purchase.Cart);
            DisplayVendingMachine(currentMachine);

            Console.WriteLine("Enter product code or select from the following options");
            Console.WriteLine("1: View Cart/Checkout");
            Console.WriteLine("2: Remove items from cart");
            Console.WriteLine("3: Cancel purchase");

            string input = Console.ReadLine();
            bool isValidInput = false;
            while (isValidInput == false)
            {
                if (input.Equals("1"))
                {
                    isValidInput = true;
                    ViewCart(purchase);
                }
                else if (input.Equals("2"))
                {
                    isValidInput = true;
                }
                else if (input.Equals("3"))
                {
                    isValidInput = true;
                }
                else if (input.Length == 3 && Logic.isValidProductCode(input, currentMachine.Inventory))
                {
                    isValidInput = true;
                }
                else
                {
                    Console.Write("Invalid Input: Please try again");

                }
            }

        }

        static void DisplayVendingMachine(Machine currentMachine)
        {
            Console.WriteLine("************************************************************");
            Console.WriteLine("                      Vending Machine                       ");
            Console.WriteLine("************************************************************");
            foreach (Item item in currentMachine.Inventory)
            {
                Console.WriteLine("* " + item.Name + " Cost:" + item.Cost + " Quantity:" + item.Quantity + " Product Code:" + item.Code + " *");
            }
            Console.WriteLine("************************************************************");
        }

        static void ViewCart(Purchase purchase)
        {
            Console.WriteLine("Your Cart");
            foreach (Item item in purchase.Cart)
            {
                Console.WriteLine("Item:" + item.Name + " Price:" + item.Cost + " Quantity:" + item.Quantity);
            }
            Console.WriteLine("Total:" + purchase.Total);

            Console.WriteLine("1: Checkout");
            Console.WriteLine("2: Edit Cart");

            string input = Console.ReadLine();
            bool isValidInput = false;

            while (isValidInput == false)
            {
                if (input.Equals("1"))
                {
                    isValidInput = true;
                    Checkout(purchase);
                }
                else if (input.Equals("2"))
                {
                    isValidInput = true;
                    EditCart(purchase);
                }
                else
                {
                    Console.WriteLine("Invalid Input: Please try again");
                }
            }
        }

        private static void Checkout(Purchase purchase)
        {
            Console.WriteLine("How would you like to pay?");
            Console.WriteLine("1: Cash");
            Console.WriteLine("2: Card");

            string input = Console.ReadLine();
            bool isValidInput = false;

            while (isValidInput == false)
            {
                if (input.Equals("1"))
                {
                    isValidInput = true;
                    CheckoutCash(purchase);
                }
                else if (input.Equals("2"))
                {
                    isValidInput = true;
                    CheckoutCard(purchase);
                }
                else
                {
                    Console.WriteLine("Invalid Input: Please try again");
                }
            }
        }

        private static void CheckoutCash(Purchase purchase)
        {
            

        }

        private static void CheckoutCard(Purchase purchase)
        {
            Console.WriteLine("Please enter the following information");
            Console.Write("Please enter card number:");
            string input = Console.ReadLine();
            bool isValidInput = false;

            while (isValidInput == false)
            {
                if (input.Length > 16 || input.Length < 16)
                {
                    isValidInput = false;
                    Console.WriteLine("Card numbers must be 16 characters");
                }
                else
                {
                    isValidInput = true;
                }
            }
            string cardNum = input;

            Console.Write("Please enter expiration date in ##/## format");
            input = Console.ReadLine();
            isValidInput = false;

            while (isValidInput == false)
            {
                if (input.Equals("1"))
                {
                    isValidInput = false;
                    Console.WriteLine("Invalid Input: Enter date in ##/## format");
                }
                else
                {
                    isValidInput = true;
                }
            }
            string expiration = input;
            Console.WriteLine("Please enter securtiy number on back of card");
            input = Console.ReadLine();
            isValidInput = false;

            while (isValidInput == false)
            {
                if (input.Length > 4 || input.Length < 3)
                {
                    isValidInput = false;
                    Console.WriteLine("Invalid Input: Input must be 3-4 digits");
                }
                else
                {
                    isValidInput = true;
                }
            }
            string securityNumber = input;

            Card card = new Card(purchase.Total,cardNum,expiration,securityNumber);

            purchase.Payment = card;
        }
    }
}
