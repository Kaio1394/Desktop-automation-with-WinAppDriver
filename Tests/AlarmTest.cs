using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestOverview.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTestOverview.Tests
{
    [TestClass]
    class AlarmTest
    {
        private PageObject page;

        [TestInitialize]
        public void Start()
        {
            page = new PageObject(null, "Microsoft.WindowsAlarms_8wekyb3d8bbwe!App", "http://127.0.0.1:4723/");
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
