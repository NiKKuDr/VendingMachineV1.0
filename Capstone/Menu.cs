﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Capstone
{
    public class Menu
    {
        public VendingMachine VM { get; } = new VendingMachine();

        public Menu(VendingMachine vm)
        {
            VM = vm;

            //VendingMachine VM = new VendingMachine();
        }




        public void WelcomeMessage()
        {
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n");
            Console.WriteLine("\t\t\t\t\tWELCOME TO THE VENDO-MATIC 800");
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n");
        }

        public void MainMenu()
        {
            //VendingMachine VM = new VendingMachine();

            // figure out how to remove this one empty line at the top
            Console.WriteLine("(1) Display Vending Machine Items");
            Console.WriteLine("(2) Purchase");
            Console.WriteLine("(3) Exit\n");
            string selection = Console.ReadLine();
            Console.WriteLine("");

            while (!(selection.Equals("1") || selection.Equals("2") || selection.Equals("3")))
            {
                // nothing will happen
                // allows the user to keep entering other options
                // can add a message here if needed but was thinking might leave out a message for a Vending Machine?

                Console.Clear();
                MainMenu();
                selection = Console.ReadLine();
            }

            if (selection.Equals("1"))
            {
                //VendingMachine VM1 = new VendingMachine();
                Console.Clear();
                VM.CurrentInventory();
                Console.WriteLine("\n\n");
                MainMenu();
                selection = Console.ReadLine();
                // call on the class.method the shows the list of all items in the vending machine with remaining quanity.
            }
            else if (selection.Equals("2"))
            {
                // go to the Purchase submenu
                Console.Clear();
                PurchaseMenu();
                // do we want to keep the list of items above?
            }
            else if (selection.Equals("3"))
            {
                // exit out of the application
                Console.Clear();
                Console.WriteLine("Thank you for using the VENDO-MATIC 800!");
                Environment.Exit(0);
            }


        }


        public void PurchaseMenu()
        {
            Console.WriteLine("(1) Feed Money");
            Console.WriteLine("(2) Select Product");
            Console.WriteLine("(3) Finish Transaction");
            Console.WriteLine($"\nCurrent Money Provided: ${VM.Balance}\n");     // have to get the balance to return to this string!!!
            string selection = Console.ReadLine();


            while (!(selection.Equals("1") || selection.Equals("2") || selection.Equals("3")))
            {
                // nothing will happen
                // allows the user to keep entering other options until they enter correct input
                // can add a message here if needed but was thinking might leave out a message for a Vending Machine?
                // maybe clear what was entered 

                Console.Clear();
                PurchaseMenu();
                selection = Console.ReadLine();


                /* selection = Console.ReadLine();
                 Console.Clear();*/
            }

            if (selection.Equals("1"))    // Feeding money Menu

            {

                // call on the class.method that allows the user to feed money (The FeedMoney() method)
                // what should the console display during this??
                // maybe change the console to reflect "Feeding money" but keeping the balance at the bottom still?


                decimal money = (Decimal.Parse(FeedingMoneyMenu()));   // nesting the FeedingMoneyMenu in this argument because it returns a string for the decimal variable to parse
                VM.FeedMoney(money);

                Console.Clear();
                PurchaseMenu();




            }
            else if (selection.Equals("2"))
            {

                Console.WriteLine("");
                VM.CurrentInventory();   // need to make an if/else statement here to account for if the user doesn't choose to see the list at the beginning, then
                // build inventory here.  Need to build the inventory BEFORE accessing the menu.

                Console.Write("\n\nEnter Purchase Code: ");
                selection = Console.ReadLine();


                SelectProductMenu(selection.ToUpper());

                //VM.SelectProduct(selection);

                // Select Product
                // calls on method to show the list of available products(and their purchase code?) and allows customer to enter code
                // If product code doesn't exist, then inform customer and (Thread.Sleep(3000)) - equal to 3 seconds...before returning to Purchase Menu
                // If product is sold out, then inform customer and (Thread.Sleep(3000)) - equal to 3 seconds...before returning to Purchase Menu
                // NOTE: can't call the build inventory method because that will restock the VM

            }
            else if (selection.Equals("3"))
            {
                // Finish Transaction
                // Customer's money is returned using nickels, dimes, quarters (smallest amount of coins possible)
                // Machine's current balance returns to 0

                Console.Clear();
                VM.FinishTransaction();
                Thread.Sleep(5000);
                Console.Clear();
                MainMenu();

            }


        }


        public string FeedingMoneyMenu()
        {

            Console.Clear();
            Console.WriteLine("Please insert a valid bill [ $1 | $2 | $5 | $10 ]\n\n");
            Console.WriteLine($"\nCurrent Money Provided: ${VM.Balance}\n");
            Console.Write("Insert: $");
            string inputMoney = Console.ReadLine();

            while (!(inputMoney.Equals("1") || inputMoney.Equals("2") || inputMoney.Equals("5") || inputMoney.Equals("10")))
            {
                Console.Write("\n(Not a valid bill)");
                Thread.Sleep(3000);
                Console.Clear();
                Console.WriteLine("Please insert a valid bill [ $1 | $2 | $5 | $10 ]\n\n");
                Console.WriteLine($"\nCurrent Money Provided: ${VM.Balance}\n");
                Console.Write("Insert: $");
                inputMoney = Console.ReadLine();

            }

            return inputMoney;

        }


        public void SelectProductMenu(string slotID)
        {
            //VM.SlotID = slotID;
            decimal startBal = VM.Balance;
            if (VM.Inventory.ContainsKey(slotID))
            {
                //VM.Inventory[slotID].VendItem();  //slotID

                if (VM.Inventory[slotID].Inv <= 0)
                {
                    Console.WriteLine("SORRY, THAT ITEM IS CURRENTLY OUT OF STOCK!");
                    Thread.Sleep(4000);
                    Console.Clear();
                    PurchaseMenu();    //then return to Purchase Menu
                }

                if (VM.Inventory[slotID].Inv > 0 && startBal < VM.Inventory[slotID].Price)
                {
                    Console.WriteLine($"\nInsufficient funds!\n{VM.Inventory[slotID].Name} is ${VM.Inventory[slotID].Price} | Current Balance: ${startBal}");
                    Thread.Sleep(5000);
                    Console.Clear();
                    PurchaseMenu();    //then return to Purchase Menu

                }

                else
                {
                    // call on the SelectProduct method from VendingMachine class
                    VM.SelectProduct(slotID);
                    // print the message from the product here
                    Console.Clear();
                    Console.WriteLine($"Dispensing...\n\n{VM.Inventory[slotID].Name}\n{VM.Inventory[slotID].Price}\n{VM.Inventory[slotID].ItemMessage()} \nRemaining Balance: {VM.Balance}");
                    Thread.Sleep(5000);
                    Console.Clear();
                    PurchaseMenu();

                }
            }
            else
            {
                Console.WriteLine("\n\n(Invalid Product Entered!)");   // then return to the Purchase menu
                Thread.Sleep(3000);
                Console.Clear();
                PurchaseMenu();

            }

        }

    }
}









