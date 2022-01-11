﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestOverview.ScreeShot;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;

namespace MSTestOverview
{
    [TestClass]
    public class TestCalculator
    {
        private WindowsDriver<WindowsElement> sessionCalc;
        private AppiumOptions appOptions;

        [TestInitialize]
        public void Start()
        {
            appOptions = new AppiumOptions();
            appOptions.AddAdditionalCapability("app", "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");
            sessionCalc = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723/"), appOptions);
        }
        [TestCleanup]
        public void EndTest()
        {
            var shot = new ScreenShotRun(sessionCalc);
            shot.TakeScreenShot();
            sessionCalc.Quit();
        }

        [TestMethod]
        public void TestMethodSum()
        {           
            sessionCalc.FindElementByAccessibilityId("num3Button").Click();
            sessionCalc.FindElementByAccessibilityId("plusButton").Click();
            sessionCalc.FindElementByAccessibilityId("num3Button").Click();
            sessionCalc.FindElementByAccessibilityId("equalButton").Click();

            Assert.AreEqual("A exibição é 6", sessionCalc.FindElementByAccessibilityId("CalculatorResults").Text);
        }
    }
}