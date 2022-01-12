using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTestOverview.Pages
{
    class PageObject
    {
        public AppiumOptions appOptions;


        private WindowsDriver<WindowsElement> _element;
        public WindowsDriver<WindowsElement> Element{ get { return _element;}}

        public PageObject(WindowsDriver<WindowsElement> element, string propertyElement, string uriDriver)
        {
            //Microsoft.WindowsCalculator_8wekyb3d8bbwe!App
            //http://127.0.0.1:4723/
            if(element == null)
            {
                appOptions = new AppiumOptions();
                appOptions.AddAdditionalCapability("app", propertyElement);
                _element = new WindowsDriver<WindowsElement>(new Uri(uriDriver), appOptions);
            }
            else
            {
                _element = element;
            }
            
            
        }
        public void ClickInElementById(params string[] elements)
        {
            foreach(string element in elements)
            {
                _element.FindElementByAccessibilityId(element).Click();
            }
        }

        public string ReturnTextOfElement(string element)
        {
            return _element.FindElementByAccessibilityId(element).Text;
        }
        public void CloseWindows()
        {
            _element.Quit();
        }
    }
}
