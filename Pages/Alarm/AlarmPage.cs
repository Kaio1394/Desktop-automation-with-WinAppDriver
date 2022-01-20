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
            // PageObject(WindowsDriver<WindowsElement> element, string propertyElement, string uriDriver)
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
        public void SetHourAndMinutesAlarm(params string[] values)
        {
            this.SetHour(values[0]);
            this.SetMinutes(values[1]);
        }


        public void SetHour(string hour)
        {
            this.SendKeysByName("horas", hour);
        }
        public void SetMinutes(string minutes)
        {
            this.SendKeysByName("minutos", minutes);
        }

        public void SetNameTimerPlusRandoNumber(string text)
        {
            Random numAleatorio = new Random();
            this.SendKeysByClassName("TextBox", text + numAleatorio.Next(1, 20));
        }
        public void SetNameTimerOrAlarm(string text)
        {
            this.SendKeysByClassName("TextBox", text);
        }
        public void SetSeconds(string seconds)
        {
            this.SendKeysByName("segundos", seconds);
        }

        public void ClickSaveNewTimerOrTimer(string alaramOrTimer)
        {
            if(alaramOrTimer == "timer")
            {
                this.ClickInElementOrElementsByName("Salvar");
                
            }else if (alaramOrTimer == "alarm")
            {
                this.ClickInElementOrElementsById("SaveButton");
            }
        }

        public void ClickExcludeSecondItemTimer()
        {
            this.WaitUntilXPath(this.Element, 5, "/Window/Window[2]/Pane/List/ListItem[2]/Button[3]");
            this.ClickInElementOrElementsByXPath("/Window/Window[2]/Pane/List/ListItem[2]/Button[3]");
        }

        public void ClickEditingTimerButtom()
        {
            this.WaitUntil(this.Element, 5, "EditTimersButton");
            this.ClickInElementOrElementsById("EditTimersButton");
        }

        public void ClickSecondItemTimer()
        {
            try
            {
                this.ClickInElementOrElementsByXPath("/Window/Window[2]/Pane/List/ListItem[2]");
            }
            catch (Exception)
            {
                throw new Exception("Not second items in list view");
            }          
        }
        public string ReturnTextBoxNameTimer()
        {
            return this.ReturnTextOfElementByClassName("TextBox");
        }

        public void ChooseDayWeekend(string day)
        {
            this.ClickInElementOrElementsByName(day);
        }

        internal void ChooseAlarmMusic(string music)
        {
            this.ClickInElementOrElementsById("ChimeComboBox");
            this.ClickInElementOrElementsByName(music);    
        }

        public void ChooseRepeatTime(int time, string hourOrMinutes)
        {
            this.ClickInElementOrElementsById("SnoozeComboBox");
            var repeatTime = $"{time} " + hourOrMinutes;
            this.ClickInElementOrElementsByName(repeatTime);
        }

        public void SetNameWorldClock(string country)
        {
            this.WaitUntilName(this.Element, 5, "Inserir um local");
            this.SendKeysByName("Inserir um local", country);
            this.ClickInElementOrElementsById("SuggestionsList");
        }

        internal void ClickAddNewWorldClock()
        {
            this.ClickInElementOrElementsById("AddClockButton");
        }

        internal void ClickCardWorldClock()
        {
            this.RightClickElement("/Window/Window[2]/Pane/List/ListItem[2]");
        }
        
        public void ClickAlarmBottom()
        {
            this.ClickInElementOrElementsById("AlarmButton");
        }
        
        public void ClickAddNewAlarm()
        {
            this.WaitUntilXPath(this.Element, 4, "/Window/Window[2]/Pane/Button[2]");
            this.ClickInElementOrElementsByXPath("/Window/Window[2]/Pane/Button[2]");
        }
        public void ClickWorldClock()
        {
            this.ClickInElementOrElementsByXPath("/Window/Window[2]/Custom/Window/Pane/Group/ListItem[3]");
        }

        public void ClickDeleteCardWorldCLock()
        {
            this.ClickInElementOrElementsById("ContextMenuDelete");
        }
    }
}
