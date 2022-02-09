using System;
using System.Windows.Controls;
using System.Windows.Threading;

namespace WpfWatch
{
    /// <summary>
    /// Логика взаимодействия для Watch.xaml
    /// </summary>
    public partial class Watch : UserControl
    {
        DispatcherTimer timer = new DispatcherTimer();
        
        public Watch()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(0.01);
            timer.Tick += TimerTick;
            timer.Start();
        }

        private void TimerTick (object sender, EventArgs e)
        {
            var time = DateTime.Now;
            RotationSecond.Angle = 6 * (time.Second + time.Millisecond / 1000.0);
            RotationMinute.Angle = 6 * time.Minute + RotationSecond.Angle / 60;
            RotationHour.Angle = 30 * (time.Hour % 12) + RotationMinute.Angle / 12;
        }
    }
}
