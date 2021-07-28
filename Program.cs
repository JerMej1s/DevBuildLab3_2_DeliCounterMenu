using System;
using System.Collections.Generic;

namespace Lab3_2_DeliCounterMenu
{
    class Program
    {
        static void printMenu(Dictionary<string, decimal> menu)  // Prints the menu
        {            
            Console.WriteLine("\n===============================");
            Console.WriteLine("\n\tMenu");
            Console.WriteLine("\nItem\t\t\tCost");
            Console.WriteLine("======\t\t\t======");

            foreach (var menuItem in menu)
            {
                Console.WriteLine($"\n{menuItem.Key}\t\t${menuItem.Value}");
            }

            Console.WriteLine("\n===============================");
        }

        static void askPrintMenu(Dictionary<string, decimal> menu)  // Asks user whether to print menu
        {
            Console.Write("\nDo you want to see the menu? (y/n) ");
            string userPrintMenu = Console.ReadLine().ToUpper();

            switch (userPrintMenu)
            {
                case "Y":
                    printMenu(menu);
                    break;
                default:
                    break;
            }
        }
        static void Main(string[] args)
        {
            Dictionary<string, decimal> menu = new Dictionary<string, decimal>();
            menu["CLUB SANDWICH"] = 9.99m;
            menu["FRENCH DIP"] = 11.99m;
            menu["HOUSE SALAD"] = 7.99m;
            menu["SOUP OF THE DAY"] = 3.99m;
            menu["HOUSE CHIPS"] = 2.99m;

            Console.WriteLine("Welcome to Jeremy's Deli Counter!");
            printMenu(menu);

            bool quit = false;
            do
            {
                Console.WriteLine("\n\tMAIN MENU");
                Console.WriteLine("*******************************");
                Console.WriteLine("Enter A to ADD a new menu item.");
                Console.WriteLine("Enter R to REMOVE a menu item.");
                Console.WriteLine("Enter C to CHANGE a menu item.");
                Console.WriteLine("Enter V to VIEW menu.");
                Console.WriteLine("Enter Q to QUIT.");
                Console.Write("\nWhat do you want to do? ");
                string userChoice = Console.ReadLine().ToUpper();

                switch (userChoice)
                {
                    case "A": // Adds a new menu item
                        Console.WriteLine("\nThis will ADD a new menu item. Please provide the following information (or enter CANCEL to start over):");
                        Console.Write("NAME: ");
                        string newMenuItem = Console.ReadLine().ToUpper();

                        if (menu.ContainsKey(newMenuItem))
                        {
                            Console.WriteLine($"\n{newMenuItem} is already on the menu."); 
                        }
                        else if (newMenuItem == "CANCEL")
                        {
                            break;
                        }
                        else
                        {
                            Console.Write("PRICE: ");
                            decimal newPrice = decimal.Parse(Console.ReadLine());
                            menu[newMenuItem] = newPrice;
                            Console.WriteLine($"\nYou ADDED {newMenuItem} for {newPrice} to the menu.");
                            askPrintMenu(menu);
                        }

                        break;

                    case "R": // Removes a menu item
                        Console.WriteLine("\nThis will REMOVE an item from the menu. Please provide the following information (or enter CANCEL to start over):");
                        Console.Write("NAME of the menu item to REMOVE: ");
                        string removeMenuItem = Console.ReadLine().ToUpper();

                        if (removeMenuItem == "CANCEL")
                        {
                            break;
                        }
                        else if (menu.ContainsKey(removeMenuItem))
                        {
                            menu.Remove(removeMenuItem);
                            Console.WriteLine($"\nYou REMOVED {removeMenuItem} from the menu");
                            askPrintMenu(menu);
                        }
                        else
                        {
                            Console.WriteLine($"\n{removeMenuItem} is not on the menu and therefore cannot be removed.");
                        }

                        break;

                    case "C": // Changes a menu item
                        Console.WriteLine("\nThis will CHANGE the price of a menu item. Please provide the following information (or enter CANCEL to start over):");
                        Console.Write("NAME of the menu item to CHANGE: ");
                        string changeMenuItem = Console.ReadLine().ToUpper();

                        if (changeMenuItem == "CANCEL")
                        {
                            break;
                        }
                        else if (menu.ContainsKey(changeMenuItem))
                        {
                            Console.WriteLine($"The current price for {changeMenuItem} is ${menu[changeMenuItem]}.");
                            Console.Write("New price: ");
                            decimal changePrice = decimal.Parse(Console.ReadLine());
                            menu[changeMenuItem] = changePrice;
                            Console.WriteLine($"\nYou CHANGED the price of {changeMenuItem} to ${changePrice}.");
                            askPrintMenu(menu);
                        }
                        else
                        {
                            Console.WriteLine($"\n{changeMenuItem} is not on the menu and therefore cannot be changed.");
                        }

                        break;

                    case "V": // Prints menu
                        printMenu(menu);
                        break;
                    
                    case "Q": // Exits program
                        quit = true;
                        break;

                    default: // Invalid entry
                        Console.WriteLine("\nThat's an invalid entry.");
                        break;
                }
            }
            while (!quit);
        }
    }
}