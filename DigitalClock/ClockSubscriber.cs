using System;

namespace App_2021_03_23
{
    public class ClockSubscriber
    {
        public void Subscribe(ClockPublisher publisher) {
            publisher.SecondChanged += new ClockPublisher.SecondChangedHandler(OnTimeChanged);
        }

        private void OnTimeChanged(ClockPublisher publisher, Clock time) {
            Console.WriteLine($"The current time is {time.Hour}:{time.Minute}:{time.Second}");
        }
    }
}