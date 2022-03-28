﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Change
    {//give back money after transaction is complete
        //give back money after transaction is complete
        //the customer's money is returned using nickels, dimes, and quarters (using the smallest amount of coins possible)
        //The machine's current balance must be updated to $0 remaining
        public int Nickels { get; private set; }
        public int Dimes { get; private set; }
        public int Quarters { get; private set; }

        public int nickelReturn = 0;
        public int dimeReturn = 0;
        public int quarterReturn = 0;
       

       

        public string ChangeReturn(decimal balance)
        {
            
            int coinReturn = (int)(balance * 100);
            quarterReturn = coinReturn / 25;
            coinReturn = coinReturn % 25;
            dimeReturn = coinReturn / 10;
            coinReturn = coinReturn % 10;
            nickelReturn = coinReturn / 5;
            coinReturn = coinReturn % 5;


            //return $"Returned: {quarterReturn} quarters, {dimeReturn} dimes, and {nickelReturn} nickels.";

            string returnedCoins = "\n-----------------\n|  Coin Return  |\n-----------------";

            if (quarterReturn > 0) 
            {
                returnedCoins += $"\n  Quarters: {quarterReturn}";
            }
            if (dimeReturn > 0)
            {
                returnedCoins += $"\n     Dimes: {dimeReturn}";
            }
            if (nickelReturn > 0)
            {
                returnedCoins += $"\n   Nickels: {nickelReturn}";
            }

            return returnedCoins;

            //return $"Coin Return: \nQuarters: {quarterReturn}\nDimes: {dimeReturn}\nNickels: {nickelReturn}";

        }






    }
    }
