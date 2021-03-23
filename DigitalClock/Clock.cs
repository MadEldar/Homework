using System;

namespace App_2021_03_23
{
    public class Clock
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }

        public Clock(DateTime time) {
            Hour = time.Hour;
            Minute = time.Minute;
            Second = time.Second;
        }
    }
}