using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestOverview.Pages.Alarm;
using System;
using System.Collections.Generic;
using System.Text;

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
            
            //Button Save
            page.ClickSaveNewTimer();

            Assert.AreEqual("s", page.ReturnTextOfElement("ListViewItem"));
        }

    }
}
