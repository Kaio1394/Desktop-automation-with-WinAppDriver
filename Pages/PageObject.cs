using MSTestOverview.ScreeShot;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;


namespace MSTestOverview.Pages
{
    public class PageObject
    {
        private AppiumOptions appOptions;
        private WindowsDriver<WindowsElement> _element;
        public WindowsDriver<WindowsElement> Element{ get { return _element;}}

        public PageObject(WindowsDriver<WindowsElement> element, string propertyElement, string uriDriver)
        {

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
                _element.FindElementByAccessibilityId(element).Click();
            }
        }
        public void ClickInElementOrElementsByXPath(params string[] elements)
        {
            foreach(string element in elements)
            {
                _element.FindElementByXPath(element).Click();
            }
        }
        public void ClickInElementOrElementsByName(params string[] elements)
        {
            foreach(string element in elements)
            {
                _element.FindElementByName(element).Click();
            }
        }
        public WindowsElement ReturnWindowDriverElementByName(string name)
        {
            return _element.FindElementByName(name);
        }

        public WindowsElement ReturnWindowDriverElementByXPath(string xpath)
        {
            return _element.FindElementByXPath(xpath);
        }
        
        public WindowsElement ReturnWindowDriverElementById(string id)
        {
            return _element.FindElementByXPath(id);
        }
        public WindowsElement ReturnWindowDriverElementByClassName(string className)
        {
            return _element.FindElementByClassName(className);
        }
        public string ReturnTextOfElement(string id)
        {
            return _element.FindElementByAccessibilityId(id).Text;
        }

        public string ReturnTextOfElementByClassName(string className)
        {
            return _element.FindElementByClassName(className).Text;
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
        public void WaitUntilXPath(WindowsDriver<WindowsElement> element, int time, string xpath)
        {
            WebDriverWait wait = new WebDriverWait(element, TimeSpan.FromSeconds(time));
            wait.Until(a => element.FindElementByXPath(xpath).Displayed);
        }
        public void WaitUntilName(WindowsDriver<WindowsElement> element, int time, string name)
        {
            WebDriverWait wait = new WebDriverWait(element, TimeSpan.FromSeconds(time));
            wait.Until(a => element.FindElementByName(name).Displayed);
        }

        public void SendKeysByName(string name, string keys)
        {
            this.ReturnWindowDriverElementByName(name).SendKeys(keys);
        }
        
        public void SendKeysByClassName(string name, string keys)
        {
            this.ReturnWindowDriverElementByClassName(name).SendKeys(keys);
        }
        
        public void SendKeysById(string id, string keys)
        {
            this.ReturnWindowDriverElementById(id).SendKeys(keys);
        }
        public void SendKeysByXPath(string xpath, string keys)
        {
            this.ReturnWindowDriverElementByXPath(xpath).SendKeys(keys);
        }

        public bool HasElementPage(string xpath, string contains)
        {
            return this._element.PageSource.Contains(contains);
        }

        public void DoubleClickElement(string xpath)
        {
            var element = this.ReturnWindowDriverElementByXPath(xpath);
            Actions action = new Actions(this._element);
            action.ContextClick(element);
            action.DoubleClick().Perform();
        }

        public void RightClickElement(string xpath)
        {
            var element = this.ReturnWindowDriverElementByXPath(xpath);
            Actions action = new Actions(this._element);
            action.ContextClick(element);
            action.Perform();
        }
    }
}