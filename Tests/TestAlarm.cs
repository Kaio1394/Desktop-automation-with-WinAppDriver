using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestOverview.Pages.Alarm;
using MSTestOverview.ScreeShot;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MSTestOverview.Tests
{
    /// <summary>
    /// Descrição resumida para TestAlarm
    /// </summary>
    /// 
    [TestClass]
    public class TestAlarm
    {
        public TestContext TestContext { get; set; }
        private AlarmPage page;

        
        [TestInitialize]
        public void Start()
        {
            page = new AlarmPage();
        }
        [TestCleanup]
        public void EndTest()
        {
            page.TakeScreenShot();
            Boolean boolFailFlag = false;
            Report.extent.Flush();
            page.CloseWindows();
        }

        [TestMethod]
        [DataRow("04", "031", "028")]
        [DataRow("08", "010", "029")]
        [DataRow("14", "033", "015")]
        public void AddNewTimer(params string[] values)
        {
            page.ClickTimerButtom();

            // Click in Buttom Add New Timer
            page.ClickInAddNewTimer();

            // Setter hours, minutes and seconds
            page.SetHourMinuteSecond(values);

            // Timer name field
            page.SetNameTimerPlusRandoNumber("Timer");

            //Button Save
            page.ClickSaveNewTimerOrTimer("timer");

            //Assert.AreEqual("Timer", page.ReturnWindowDriverElementByXPath("/Window/Window[2]/Pane/List/ListItem[2]/Text").Text);
            Assert.IsTrue(page.HasElementPage("/Window/Window[2]/Pane/List/ListItem[2]/Text", "Timer"));
        }

        [TestMethod]
        public void EditingSecondItemTimer()
        {
            // Click in item second in list view
            page.ClickSecondItemTimer();

            //Setter timer name
            page.SetNameTimerOrAlarm("Kaio Timer");
           
            // Bottom save timer 
            page.ClickSaveNewTimerOrTimer("timer");

            page.ClickSecondItemTimer();

            Assert.AreEqual("Kaio Timer", page.ReturnTextBoxNameTimer());
        }

        [TestMethod]
        public void ExcluingSecondItemTimer()
        {
            // Click in Edit buttom
            page.ClickEditingTimerButtom();

            // And exclude second element
            page.ClickExcludeSecondItemTimer();

        }
        
        [TestMethod]
        public void AddNewAlarm()
        {
            // Click in alarm buttom
            page.ClickAlarmBottom();

            // And click add new alarm
            page.ClickAddNewAlarm();

            // Setter alarm name
            page.SetNameTimerOrAlarm("kaio");

            // Setter hour and minutes
            page.SetHourAndMinutesAlarm("10", "20");

            // Options: Segunda-feira, Terça-feira, Quarta-feira, Quinta-feira, Sexta-feira, sábado and Domingo.
            page.ChooseDayWeekend("Domingo");

            // Music options: Alarmes, Xilofones, Acordes, Toque, Jingle, Transição, Decrescente, Quico, Eco e Crescente.
            page.ChooseAlarmMusic("Transição");

            // Options: (5, "minutos"), (10, "minutos"), (20, "minutos"), (30, "minutos") or (1, "hora").
            page.ChooseRepeatTime(5, "minutos");

            // Save
            page.ClickSaveNewTimerOrTimer("alarm");

        }
        [TestMethod]
        public void AddWorldClock()
        {
            // World Clock Bottom
            page.ClickWorldClock();

            // Add new world clock
            page.ClickAddNewWorldClock();

            // Setter country
            page.SetNameWorldClock("São Paulo");

            page.ClickAddNewWorldClock();

            page.SetNameWorldClock("Belo Horizonte");

        }

        [TestMethod]
        public void DeleteWorldClock()
        {
            // World Clock Bottom
            page.ClickWorldClock();
           
            // Click in card to delete
            page.ClickCardWorldClock();

            // Click in delete
            page.ClickDeleteCardWorldCLock();

        }

        //Report
        [TestMethod, TestCategory("ExtentTest")]
        public void ExtentTestCasePass()
        {
            Report.ReportLogger(TestContext.TestName);
            Report.exParentTest = Report.extent.CreateTest(TestContext.TestName);
            Report.exChildTest = Report.exParentTest.CreateNode("Provide parameter 1");
            Report.exChildTest.Log(AventStack.ExtentReports.Status.Pass, "Passed1");
            DeleteWorldClock();
            int a = 10;
            int b = 15;
            int c = a + b;
            Report.exChildTest = Report.exParentTest.CreateNode("Add parameters 1");
            Report.exChildTest.Log(AventStack.ExtentReports.Status.Pass, "Passed1");
        }

    }
}
