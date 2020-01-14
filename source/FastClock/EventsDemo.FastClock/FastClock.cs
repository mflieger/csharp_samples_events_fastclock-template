using System;
using System.Windows.Threading;

namespace EventsDemo.FastClock
{
    public class TheFastClock
    {
        //Event
        public event EventHandler<DateTime> OneMinuteIsOver;

        //Fields
        private readonly DispatcherTimer _timer;
        private bool _isRunning;
        private int _factor = 60;

        //Properties
        public int Factor
        {
            get => _factor;
            set
            {
                if(value >= 1 && value <= 60000)
                {
                    _factor = value;
                    _timer.Interval = TimeSpan.FromMilliseconds(60000 / value);
                }
            }
        }


        public bool IsRunning
        {
            get => _isRunning;
            set
            {
                if(!_isRunning && value)
                {
                    _timer.Start();
                }
                else if(_isRunning && !value)
                {
                    _timer.Stop();
                }
                _isRunning = value;
            }
        }
        public DateTime CurrentTime { get; private set; }

        private static TheFastClock _instance;
        public static TheFastClock Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new TheFastClock();
                }
                return _instance;
            }
        }


        //Constructor
        private TheFastClock() 
        {
            CurrentTime = DateTime.Now;
            _timer = new DispatcherTimer();
            _timer.Tick += OnTimerTick;
            _timer.Interval = TimeSpan.FromMilliseconds(60000/Factor);
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            CurrentTime = CurrentTime.AddMinutes(1);
            OnOneMinuteIsOver(CurrentTime);
        }

        protected void OnOneMinuteIsOver(DateTime time)
        {
            OneMinuteIsOver?.Invoke(this, time);
        }
    }
}
