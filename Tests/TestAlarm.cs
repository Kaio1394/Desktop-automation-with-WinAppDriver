using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestOverview.Pages.Alarm;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
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
            page.CloseWindows();
        }

        [TestMethod]
        [DataRow("04", "031", "028")]
        [DataRow("08", "010", "029")]
        [DataRow("14", "033", "015")]
        public void AddNewTimer(params string[] values)
        {
            
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
            string  name = "Kaio Timer";
            // Click in item second in list view
            page.ClickSecondItemTimer();

            //Setter timer name
            page.SetNameTimerOrAlarm(name);
           
            page.ClickSaveNewTimerOrTimer("timer");

            page.ClickSecondItemTimer();

            Assert.AreEqual(name, page.ReturnTextBoxNameTimer());
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

            //Music options: Alarmes, Xilofones, Acordes, Toque, Jingle, Transição, Decrescente, Quico, Eco e Crescente.
            page.ChooseAlarmMusic("Transição");

            // Options: (5, "minutos"), (10, "minutos"), (20, "minutos"), (30, "minutos") or (1, "hora").
            page.ChooseRepeatTime(5, "minutos");

            page.ClickSaveNewTimerOrTimer("alarm");

        }
    }
}
