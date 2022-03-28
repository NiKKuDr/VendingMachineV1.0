using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChangeTests.Tests
{
    [TestClass()]
    public class VendingMachineTests
    {
        [TestMethod]
        public void FeedMoneyTest_OneDollarBil()
        {           
            VendingMachine sut = new VendingMachine();
           

            sut.FeedMoney(1.00M);
            Assert.IsTrue(sut.Balance == 1);
            //Assert.IsTrue(true);           

        }

        [TestMethod]
        public void FeedMoneyTest_TwoDollarBill()
        {
            VendingMachine sut = new VendingMachine();


            sut.FeedMoney(2.00M);
            Assert.IsTrue(sut.Balance == 2);
            //Assert.IsTrue(true);           

        }

        [TestMethod]
        public void FeedMoneyTest_FiveDollarBill()
        {
            VendingMachine sut = new VendingMachine();


            sut.FeedMoney(5.00M);
            Assert.IsTrue(sut.Balance == 5);
                    

        }

        [TestMethod]
        public void FeedMoneyTest_TenDollarBill()
        {
            VendingMachine sut = new VendingMachine();


            sut.FeedMoney(10.00M);
            Assert.IsTrue(sut.Balance == 10);
                     

        }

        [TestMethod]
        public void FeedMoneyTest_MultipleFeeds()
        {
            VendingMachine sut = new VendingMachine();


            sut.FeedMoney(1.00M);
            sut.FeedMoney(1.00M);
            sut.FeedMoney(1.00M);
            sut.FeedMoney(1.00M);

            sut.FeedMoney(2.00M);
            sut.FeedMoney(2.00M);
            sut.FeedMoney(2.00M);
                        
            sut.FeedMoney(5.00M);
            sut.FeedMoney(5.00M);

            sut.FeedMoney(10.00M);
            
            Assert.IsTrue(sut.Balance == 30);
                     

        }

        [TestMethod]
        public void FeedMoneyTest_FalseTest()
        {
            VendingMachine sut = new VendingMachine();


            sut.FeedMoney(5.00M);
            Assert.IsFalse(sut.Balance == 10);
                  

        }



        [TestMethod]
        public void SelectProduct_RemainingBalance_Buy2bagsOfGrainWaves()
        {
            //testing that the Balance is reduced after purchasing an item
            
            VendingMachine sut = new VendingMachine();

            sut.FeedMoney(10.00M);   //Starting with a blance of 10
            sut.buildInventory();
            sut.SelectProduct("A3");
            sut.SelectProduct("A3");

            Assert.IsTrue(sut.Balance == 4.50M);
            

        }

        [TestMethod]
        public void SelectProduct_RemainingBalance_BuyOneItemFromEachProductCategory()
        {
            //testing that the Balance is reduced after purchasing an item

            VendingMachine sut = new VendingMachine();

            sut.FeedMoney(10.00M);   //Starting with a blance of 10; Total prices should 7.15
            sut.buildInventory();
            sut.SelectProduct("A4");   // 3.65   //Chip
            sut.SelectProduct("B2");   // 1.50   //Candy
            sut.SelectProduct("C1");   // 1.25   //Drink
            sut.SelectProduct("D3");   // 0.75   //Gum     
            

            Assert.IsTrue(sut.Balance == 2.85M);


        }


        [TestMethod]
        public void SelectProduct_RemainingBalance_BuyWholeInventory()
        {
            //testing that the Balance is reduced after purchasing an item

            VendingMachine sut = new VendingMachine();

            sut.FeedMoney(135.00M);   //Starting with a blance of 135; Total price of all inventory is $132.50
            sut.buildInventory();
            
            foreach (KeyValuePair<string, Capstone.Products.Product> entry in sut.Inventory)
            {
                for (int i = 0; i < 5; i++)
                {
                    sut.SelectProduct(entry.Key);
                }
            }

            Assert.IsTrue(sut.Balance == 2.50M);

        }
    }
}