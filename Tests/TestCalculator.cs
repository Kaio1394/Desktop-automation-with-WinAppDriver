using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestOverview.Pages;
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
        private PageObject page;
        
       
        [TestInitialize]
        public void Start()
        {
            //Params
            page = new PageObject(null, "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App", "http://127.0.0.1:4723/");
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
            // Click in calculator elements
            page.ClickInElementOrElementsById("num3Button", "plusButton", "num3Button", "equalButton");

            Assert.AreEqual("A exibição é 6", page.ReturnTextOfElement("CalculatorResults"));
        }
        [TestMethod]
        public void TestMethodMinus()
        {
            // Click in calculator elements
            page.ClickInElementOrElementsById("num3Button", "minusButton", "num3Button", "equalButton");

            Assert.AreEqual("A exibição é 0", page.ReturnTextOfElement("CalculatorResults"));
        }
    }
}