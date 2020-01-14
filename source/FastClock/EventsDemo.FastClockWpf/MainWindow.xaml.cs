using System;
using System.Windows;
using EventsDemo.FastClock;

namespace EventsDemo.FastClockWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        TheFastClock _fastClock = TheFastClock.Instance;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MetroWindow_Initialized(object sender, EventArgs e)
        {
            DatePickerDate.SelectedDate = DateTime.Today;
            TextBoxTime.Text = DateTime.Now.ToShortTimeString();
        }

        private void ButtonSetTime_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void SetFastClockStartDateAndTime()
        {
        }

        private void FastClockOneMinuteIsOver(object sender, DateTime fastClockTime)
        {
            TextBlockTime.Text = fastClockTime.ToShortTimeString();
        }

        private void CheckBoxClockRuns_Click(object sender, RoutedEventArgs e)
        {
            _fastClock.OneMinuteIsOver += FastClockOneMinuteIsOver;
            _fastClock.Factor = Convert.ToInt32(TextBoxFactor.Text);
            if (!_fastClock.IsRunning)
            {
                _fastClock.IsRunning = true;
            }
            else
            {
                _fastClock.IsRunning = false;
            }
        }

        private void ButtonCreateView_Click(object sender, RoutedEventArgs e)
        {
            DigitalClock digitalClock = new DigitalClock();
            digitalClock.Owner = this;
            digitalClock.Show();
        }
    }
}
