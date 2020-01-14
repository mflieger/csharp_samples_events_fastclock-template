using System;

namespace EventsDemo.FastClockWpf
{
    /// <summary>
    /// Interaction logic for DigitalClock.xaml
    /// </summary>
    public partial class DigitalClock
    {
        public DigitalClock()
        {
            InitializeComponent();
        }

        private void DigitalClock_OneMinuteIsOver(object sender, DateTime e)
        {
            TextBlockClock.Text = e.ToShortTimeString();
        }
        private void Window_Initialized(object sender, EventArgs e)
        {
            FastClock.TheFastClock.Instance.OneMinuteIsOver += DigitalClock_OneMinuteIsOver;
        }

    }
}
