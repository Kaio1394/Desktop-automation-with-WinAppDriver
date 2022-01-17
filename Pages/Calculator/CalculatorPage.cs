using MSTestOverview.ScreeShot;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTestOverview.Pages.Calculator
{
    public class CalculatorPage : PageObject
    {
        public CalculatorPage ()   
            : base(null, "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App", "http://127.0.0.1:4723/"){}
        public void MakeSumThreePlusThree()
        {
            this.ClickInElementOrElementsById("num3Button", "plusButton", "num3Button", "equalButton");
        }
        public void MakeSumThreeMinusThree()
        {
            this.ClickInElementOrElementsById("num3Button", "minusButton", "num3Button", "equalButton");
        }
    }
}
