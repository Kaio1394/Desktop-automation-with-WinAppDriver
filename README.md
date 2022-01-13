# Desktop-automation-with-WinAppDriver
This is a little automation with WinAppDriver and the framework MSTest using Page Objects.

***Project settings:***
- .NET Core 4.7.2;
- Microsoft Visual Studio 2019.
- WinAppDriver v1.2.1
- WinAppDriver UI Recorder v1.1

***Installation:***
- Access a page https://visualstudio.microsoft.com/pt-br/vs/older-downloads/ and downloading Microsoft Visual Studio 2019.
- Access a page https://github.com/microsoft/WinAppDriver/releases downloading WinAppDriver.exe and WinAppDriverUiRecorder to map elements.
- After that, make mapping with  WinAppDriver UI Recorder, in this case to calculator: ``` "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App" ``` through constructor class Page Object:
```C#
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
        
```
- Also its done mapping calculator elements Id to calculate sum(3 + 3): "num3Button", "plusButton", "num3Button", "equalButton" and done a assert to validate test:
```C#
public void ClickInElementById(params string[] elements)
        {
            foreach(string element in elements)
            {
                _element.FindElementByAccessibilityId(element).Click();
            }
        }
```
```C#
[TestMethod]
        public void TestMethodSum()
        {
            page.ClickInElementOrElementsById("num3Button", "plusButton", "num3Button", "equalButton");

            Assert.AreEqual("A exibição é 6", page.ReturnTextOfElement("CalculatorResults"));
        }
```

***Study source:***
- Udemy plataform: https://www.udemy.com/course/appium-winappdriver-automation-testing/.

