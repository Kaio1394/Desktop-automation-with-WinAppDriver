# Desktop-automation-with-WinAppDriver
This is a little automation with WinAppDriver and the framework MSTest using Page Objects.

***Project settings:***
- .NET Core 4.7.2;
- Microsoft Visual Studio 2019.
- WinAppDriver v1.2.1
- WinAppDriver UI Recorder v1.1
- Appium Server GUI windows v1.15.1

***Installation:***
- Access a page https://visualstudio.microsoft.com/pt-br/vs/older-downloads/ and downloading Microsoft Visual Studio 2019.
- Access a page https://github.com/microsoft/WinAppDriver/releases downloading WinAppDriver.exe and WinAppDriverUiRecorder to map elements.
- After that, make mapping with WinAppDriver UI Recorder or Appium Serve, in this case to calculator and Windows Alarm Clock: ``` "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App" ```, ``` "Microsoft.WindowsAlarms_8wekyb3d8bbwe!App" ``` through constructor class Page Object:
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
- Create two class, AlarmPage and CalculatorPage, that inherit PageObject:

```C#
 class AlarmPage : PageObject
    {
        public AlarmPage() : base(null, "Microsoft.WindowsAlarms_8wekyb3d8bbwe!App", "http://127.0.0.1:4723/")
        {
            // PageObject(WindowsDriver<WindowsElement> element, string propertyElement, string uriDriver)
        }
    }
        
```

```C#
 class CalculatorPage : PageObject
    {
        public CalculatorPage() : base(null, "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App", "http://127.0.0.1:4723/")
        {
            // PageObject(WindowsDriver<WindowsElement> element, string propertyElement, string uriDriver)
        }
    }
        
```
- In the folder "\bin\debug\" open vs terminal and digit: ```vstest.console.exe <MSTestOverview.dll> /logger:trx``` to see test results.
***Study source:***
- Udemy plataform: https://www.udemy.com/course/appium-winappdriver-automation-testing/.

