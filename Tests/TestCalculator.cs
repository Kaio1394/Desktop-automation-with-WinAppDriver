using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestOverview.Pages;
using MSTestOverview.Pages.Calculator;
using MSTestOverview.ScreeShot;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;

namespace MSTestOverview
{
    [TestClass]
    public class TestCalculator
    {
        private CalculatorPage page;
               
        [TestInitialize]
        public void Start()
        {
            page = new CalculatorPage();           
        }
        
        [TestCleanup]
        public void EndTest()
        {
            page.TakeScreenShot();
            page.CloseWindows();
        }

        [TestMethod]
        public void TestMethodSum()
        {
            // Click in calculator elements(3 + 3)
            page.WaitUntil(page.Element, 4, "num3Button");
            page.MakeSumThreePlusThree();

            Assert.AreEqual("A exibição é 6", page.ReturnTextOfElement("CalculatorResults"));
        }
        [TestMethod] 
        public void TestMethodMinus()
        {
            // Click in calculator elements(3 - 3)
            page.MakeSumThreeMinusThree();

            Assert.AreEqual("A exibição é 0", page.ReturnTextOfElement("CalculatorResults"));
        }
    }
}