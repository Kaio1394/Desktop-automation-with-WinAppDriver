using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTestOverview.ScreeShot
{
    class ScreenShotRun
    {
        private WindowsDriver<WindowsElement> Elemento;

        public ScreenShotRun(WindowsDriver<WindowsElement> elemento)
        {
            Elemento = elemento;
        }

        public void TakeScreenShot() => 
            Elemento.GetScreenshot().SaveAsFile($".\\ScreenShot\\Screenshot{DateTime.Now.ToString("ddMMyyyyhhmmss")}.png", ScreenshotImageFormat.Png);        
    }
}
