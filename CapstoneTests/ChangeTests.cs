using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChangeTests.Tests
{
    [TestClass()]
    public class ChangeTests
    {
        [TestMethod()]
        public void ChangeReturnTestQuarters()
        {
            Change change = new Change();
            Assert.AreEqual("\n-----------------\n|  Coin Return  |\n-----------------\n  Quarters: 4", change.ChangeReturn(1.00M));
            Assert.AreEqual("\n-----------------\n|  Coin Return  |\n-----------------\n  Quarters: 8", change.ChangeReturn(2.00M));
        }
        [TestMethod()]
        public void ChangeReturnTestNickles()
        {
            Change change = new Change();
            Assert.AreEqual("\n-----------------\n|  Coin Return  |\n-----------------\n  Quarters: 4\n   Nickels: 1", change.ChangeReturn(1.05M));
            Assert.AreEqual("\n-----------------\n|  Coin Return  |\n-----------------\n  Quarters: 12\n   Nickels: 1", change.ChangeReturn(3.05M));
        }
        [TestMethod()]
        public void ChangeReturnTestDimes()
        {
            Change change = new Change();
            Assert.AreEqual("\n-----------------\n|  Coin Return  |\n-----------------\n  Quarters: 4\n     Dimes: 1", change.ChangeReturn(1.10M));
            Assert.AreEqual("\n-----------------\n|  Coin Return  |\n-----------------\n  Quarters: 12\n     Dimes: 1", change.ChangeReturn(3.10M));
        }
        [TestMethod()]
        public void ChangeReturnTestDimesNicklesQuarters()
        {
            Change change = new Change();
            Assert.AreEqual("\n-----------------\n|  Coin Return  |\n-----------------\n  Quarters: 4\n     Dimes: 1\n   Nickels: 1", change.ChangeReturn(1.15M));
            Assert.AreEqual("\n-----------------\n|  Coin Return  |\n-----------------\n  Quarters: 12\n     Dimes: 1\n   Nickels: 1", change.ChangeReturn(3.15M));
        }
    }
}