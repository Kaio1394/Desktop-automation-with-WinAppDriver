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
- Output terminal: 
```
Ferramenta de Linha de Comando de Execução de Teste da Microsoft (R) Versão 16.11.0
Copyright (c) Microsoft Corporation. Todos os direitos reservados.

Iniciando execução de teste, espere...
1 arquivos de teste no total corresponderam ao padrão especificado.
  Aprovado TestMethodSum [2 s]
  Aprovado TestMethodMinus [2 s]
  Aprovado AddNewTimer [12 s]
  Aprovado AddNewTimer (04,031,028) [4 s]
  Aprovado AddNewTimer (08,010,029) [4 s]
  Aprovado AddNewTimer (14,033,015) [4 s]
  Aprovado EditingSecondItemTimer [3 s]
  Aprovado ExcluingSecondItemTimer [2 s]
  Aprovado AddNewAlarm [6 s]
  Aprovado AddWorldClock [5 s]
  Aprovado DeleteWorldClock [2 s]
Arquivo de resultados: C:\Users\Usuario\source\repos\MSTestOverview\MSTestOverview\bin\Debug\TestResults\Usuario_DESKTOP-AF03160_2022-01-21_18_37_42.trx

Execução de Teste Bem-sucedida.
Total de testes: 10
     Aprovados: 10
Tempo total: 38,1124 Segundos
```


***Study source:***
- Udemy plataform: https://www.udemy.com/course/appium-winappdriver-automation-testing/.

