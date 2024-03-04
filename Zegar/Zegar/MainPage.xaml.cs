using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Zegar
{
    public partial class MainPage : TabbedPage
    {
        private TimeSpan CurrentAlarm;
        public MainPage()
        {
            InitializeComponent();
            SetCurrentTime();
        }
        void SetCurrentTime()
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                string hour = DateTime.Now.ToString("HH");
                string minute = DateTime.Now.ToString("mm");
                string sencond = DateTime.Now.ToString("ss");
                if (CurrentAlarm.ToString() == new TimeSpan(Convert.ToInt32(hour), Convert.ToInt32(minute), Convert.ToInt32(sencond)).ToString())
                {
                    DisplayAlert("Alarm", "Pobudka", "OK");
                }

                TimeDate.Text = DateTime.Now.ToString("HH:mm:ss");
                Date.Text = DateTime.Now.ToString("dd MMMM yyyy");
                SetCurrentTime();
                return false;
            });
        }
        void SetAlarm(object sender, EventArgs e)
        {
            CurrentAlarm = Alarm.Time;
            Alarm.Time = new TimeSpan();
        }
    }
}
