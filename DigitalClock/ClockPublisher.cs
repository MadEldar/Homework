using System;
using System.Threading;

namespace App_2021_03_23
{
    public class ClockPublisher
    {
        public delegate void SecondChangedHandler(ClockPublisher publisher, Clock time);
        public event SecondChangedHandler SecondChanged;
        public void OnSecondChanged(ClockPublisher publisher, Clock time) {
            SecondChanged(publisher, time);
        }

        public void Run() {
            while (true) {
                Thread.Sleep(1000);
                var time = DateTime.Now;
                Clock clock = new Clock(time);
                OnSecondChanged(this, clock);
            }
        }
    }
}