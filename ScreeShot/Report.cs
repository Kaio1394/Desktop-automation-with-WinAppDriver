using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTestOverview.ScreeShot
{
    public class Report
    {
        public static ExtentReports extent;
        public static ExtentTest exParentTest;
        public static ExtentTest exChildTest;
        public static string dirpath;
        
        public static void ReportLogger(string testcasename)
        {
            extent = new ExtentReports();
            var dir = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
            
            Directory.CreateDirectory(dir + "\\Test_Executation_Reports\\");

            Random rand = new Random();
            string randoono = rand.Next(1000).ToString();
            dirpath = dir + "\\Test_Executation_Reports\\Test_Executation_Reports" + "_" + testcasename;

            AventStack.ExtentReports.Reporter.ExtentHtmlReporter htmlReporter = 
                new AventStack.ExtentReports.Reporter.ExtentHtmlReporter(dirpath);

            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host name", /*System.Net.Dns.GetHostName()*/"Kaio");
            extent.AddSystemInfo("User name", /*System.Security.Principal.WindowsIdentity.GetCurrent().Name*/"p-santiago.kaio");
            extent.AddSystemInfo("Date", new DateTime().ToString());
        }
    }
}
