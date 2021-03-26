using System;
using System.Collections.Generic;

namespace Homework_2021_03_25.Services
{
    public class LocationService
    {
        public List<String> GetLocation() {
            return new List<string> {
                "Ha Noi",
                 "Hai Phong",
                 "Can Tho",
                 "Da Nang",
                 "Quang Ninh",
                 "Tp. Ho Chi Minh",
                 "Thanh Hoa"
            };
        }
    }
}