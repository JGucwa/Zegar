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
        public MainPage()
        {
            InitializeComponent();
            SetCurrentTime();
        }
        void SetCurrentTime()
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                TimeDate.Text = DateTime.Now.ToString("HH:mm:ss");
                Date.Text = DateTime.Now.ToString("dd MMMM yyyy");
                SetCurrentTime();
                return false;
            });

        }
    }
}
