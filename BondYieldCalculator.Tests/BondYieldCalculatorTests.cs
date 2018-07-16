using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BondYieldCalculator.Tests
{
    [TestClass]
    public class BondYieldCalculatorTests
    {
        [TestMethod]
        public void TestPrice()
        {
            var bondPriceCalculator = new Lib.BondYieldCalculator();

            Assert.AreEqual(bondPriceCalculator.CalcPrice(0.10, 5, 1000, 0.15).ToString("F7"), "832.3922451");
            Assert.AreEqual(bondPriceCalculator.CalcPrice(0.15, 5, 1000, 0.15).ToString("F7"), "1000.0000000");
            Assert.AreEqual(bondPriceCalculator.CalcPrice(0.10, 5, 1000, 0.08).ToString("F7"), "1079.8542007");
            Assert.AreEqual(bondPriceCalculator.CalcPrice(0.10, 30, 1000, 0.19).ToString("F7"), "528.8807463");
        }

        [TestMethod]
        public void TestYield()
        {
            var bondPriceCalculator = new Lib.BondYieldCalculator();

            Assert.AreEqual(bondPriceCalculator.CalcYield(0.10, 5, 1000, 832.4).ToString("F7"), "0.1499974");
            Assert.AreEqual(bondPriceCalculator.CalcYield(0.1, 5, 1000, 1000.0).ToString("F7"), "0.1000000");
            Assert.AreEqual(bondPriceCalculator.CalcYield(0.1, 5, 1000, 1079.85).ToString("F7"), "0.0800010");
            Assert.AreEqual(bondPriceCalculator.CalcYield(0.10, 30, 1000, 528.8807463).ToString("F7"), "0.1900000");

            Assert.AreEqual(bondPriceCalculator.CalcYield(0.1, 5, 1000, 832.3922451).ToString("F7"), "0.1500000");
            Assert.AreEqual(bondPriceCalculator.CalcYield(0.15, 5, 1000, 1000.0).ToString("F7"), "0.1500000");
            Assert.AreEqual(bondPriceCalculator.CalcYield(0.1, 5, 1000, 1079.8542007).ToString("F7"), "0.0800000");
        }
    }
}
