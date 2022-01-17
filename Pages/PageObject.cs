using MSTestOverview.ScreeShot;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace MSTestOverview.Pages
{
    public class PageObject
    {
        private AppiumOptions appOptions;
        private WindowsDriver<WindowsElement> _element;
        public WindowsDriver<WindowsElement> Element{ get { return _element;}}

        public PageObject(WindowsDriver<WindowsElement> element, string propertyElement, string uriDriver)
        {
            //Microsoft.WindowsCalculator_8wekyb3d8bbwe!App
            //http://127.0.0.1:4723/
            if(element == null)
            {
                this.appOptions = new AppiumOptions();
                this.appOptions.AddAdditionalCapability("app", propertyElement);
                this._element = new WindowsDriver<WindowsElement>(new Uri(uriDriver), appOptions);
                //_element.Manage().Window.Maximize();
            }
            else
            {
                _element = element;
            } 
        }


        public void ClickInElementOrElementsById(params string[] elements)
        {
            foreach(string element in elements)
            {
                //WebDriverWait wait = new WebDriverWait(_element, TimeSpan.FromSeconds(4));
                _element.FindElementByAccessibilityId(element).Click();
            }
        }

        public string ReturnTextOfElement(string element)
        {
            return _element.FindElementByAccessibilityId(element).Text;
        }

        public void CloseWindows()
        {
            if(_element != null)
            {
                _element.Quit();
            }
        }

        public void TakeScreenShot()
        {
            var shot = new ScreenShotRun(_element);
            shot.TakeScreenShot();
        }

        public void WaitUntil(WindowsDriver<WindowsElement> element, int time, string id)
        {
            WebDriverWait wait = new WebDriverWait(element, TimeSpan.FromSeconds(time));
            wait.Until(a => element.FindElementByAccessibilityId(id).Displayed);
        }
    }
}