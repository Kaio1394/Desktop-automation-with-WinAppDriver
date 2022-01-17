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
            this.ClickInElementOrElementsById("PART_Pane1ScrollViewer");
        }
        public void SendKeysByName(string name, string keys)
        {
            this.ReturnWindowDriverElementByName(name).SendKeys(keys);
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
        public void SetSeconds(string seconds)
        {
            this.SendKeysByName("segundos", seconds);
        }

        internal void ClickSaveNewTimer()
        {
            this.ClickInElementOrElementsByName("Salvar");
        }
    }
}
