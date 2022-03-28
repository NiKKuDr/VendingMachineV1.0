using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChangeTests.Tests
{
    [TestClass()]
    public class ProductTests
    {
        [TestMethod()]
        public void ItemMessageTestGum()
        {
            Gum gum = new Gum("Gum", 1.75M);
            Assert.AreEqual("Chew Chew, Yum!", gum.ItemMessage());


        }
        [TestMethod()]
        public void ItemMessageTestChip()
        {
            Chip chip = new Chip("Chip", 1.75M);
            Assert.AreEqual("Crunch Crunch, Yum!", chip.ItemMessage());


        }
        [TestMethod()]
        public void ItemMessageTestCandy()
        {
            Candy candy = new Candy("candy", 1.75M);
            Assert.AreEqual("Munch Munch, Yum!", candy.ItemMessage());


        }
        [TestMethod()]
        public void ItemMessageTestDrink()
        {
            Drink drink = new Drink("Drink", 1.75M);
            Assert.AreEqual("Glug Glug, Yum!", drink.ItemMessage());
        }

        [TestMethod]
        public void VendItemTest_Chip()
        {
            Chip sut = new Chip("The Crunchies", 2.00M);            

            sut.VendItem();
            int actual = sut.Inv;
            int expected = 4;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void VendItemTest_Candy()
        {
            Candy sut = new Candy("Fruity pops", 2.00M);

            sut.VendItem();
            sut.VendItem();
            int actual = sut.Inv;
            int expected = 3;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void VendItemTest_Drink()
        {
            Drink sut = new Drink("Fruity pops", 2.00M);

            sut.VendItem();
            sut.VendItem();
            sut.VendItem();
            int actual = sut.Inv;
            int expected = 2;

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void VendItemTest_Gum()
        {
            Gum sut = new Gum("Loud Chewing", 0.95M);

            sut.VendItem();
            sut.VendItem();
            sut.VendItem();
            sut.VendItem();
            sut.VendItem();
            int actual = sut.Inv;
            int expected = 0;

            Assert.AreEqual(expected, actual);
        }
    }
}