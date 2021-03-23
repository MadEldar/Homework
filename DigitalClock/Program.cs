using System;

namespace App_2021_03_23
{
    class Program
    {
        static void Main(string[] args)
        {
            ClockPublisher publisher = new ClockPublisher();
            ClockSubscriber subscriber = new ClockSubscriber();
            subscriber.Subscribe(publisher);

            publisher.Run();
        }
    }
}
