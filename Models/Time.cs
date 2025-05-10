using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bicycleRent.Models
{
    public class Time
    {
        public int Id { get; set; }
        public string TimeLabel { get; set; }

        public Time() { }

        public Time(int id, string timeLabel) 
        {
            Id = id;
            TimeLabel = timeLabel;
        }
    }
}
