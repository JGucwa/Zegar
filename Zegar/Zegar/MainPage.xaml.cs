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
        private int TimerSeconds = -1;
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

                if(TimerSeconds != -1)
                {
                    TimerSeconds--;
                    TimerTime.Text = new DateTime(2024, 1, 1).AddSeconds(TimerSeconds).ToString("mm:ss");
                }
                if(TimerSeconds == 0)
                {
                    TimerSeconds = -1;

                    TimerTime.Text = new DateTime(2024, 1, 1).AddSeconds(0).ToString("mm:ss");

                    DisplayAlert("Minutnik", "Czas Minął", "OK");
                }
                return false;
            });
        }
        void SetAlarm(object sender, EventArgs e)
        {
            CurrentAlarm = Alarm.Time;
            Alarm.Time = new TimeSpan();
        }
        void SetTimer(object sender, EventArgs e)
        {
            TimerSeconds = int.Parse(Timer.Text) * 60;
            TimerTime.Text = new DateTime(2024,1,1).AddSeconds(TimerSeconds).ToString("mm:ss");
        }
    }
}
