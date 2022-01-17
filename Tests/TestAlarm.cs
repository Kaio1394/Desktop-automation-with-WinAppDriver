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
        public void Alarm()
        {

        }
    }
}
