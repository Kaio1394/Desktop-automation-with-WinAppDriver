using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTestOverview.Pages.Alarm
{
    class AlarmPage : PageObject
    {
        public AlarmPage() : base(null, "Microsoft.WindowsAlarms_8wekyb3d8bbwe!App", "http://127.0.0.1:4723/")
        {

        }
        public void ClickInAddNewTimer()
        {
            this.ClickInElementOrElementsById("AddTimerButton");
        }
        

        public void SetHourMinuteSecond(params string[] values)
        {
            this.SetHour(values[0]);
            this.SetMinutes(values[1]);
            this.SetSeconds(values[2]);
        }


        public void SetHour(string hour)
        {
            this.SendKeysByName("horas", hour);
        }
        public void SetMinutes(string minutes)
        {
            this.SendKeysByName("minutos", minutes);
        }

        public void SetNameTimer(string text)
        {
            Random numAleatorio = new Random();
            this.SendKeysByClassName("TextBox", text + numAleatorio.Next(1, 20));
        }

        public void SetSeconds(string seconds)
        {
            this.SendKeysByName("segundos", seconds);
        }

        public void ClickSaveNewTimer()
        {
            this.ClickInElementOrElementsByName("Salvar");
        }

        
    }
}
