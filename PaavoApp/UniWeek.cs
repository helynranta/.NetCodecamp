using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaavoApp
{
    public class UniMonday
    {
        public string category { get; set; }
        public string price { get; set; }
        public string title_en { get; set; }
        public string properties { get; set; }
        public string title_fi { get; set; }
    }

    public class UniTuesday
    {
        public string category { get; set; }
        public string price { get; set; }
        public string title_en { get; set; }
        public string properties { get; set; }
        public string title_fi { get; set; }
    }

    public class UniFriday
    {
        public string category { get; set; }
        public string price { get; set; }
        public string title_en { get; set; }
        public string properties { get; set; }
        public string title_fi { get; set; }
    }

    public class UniWednesday
    {
        public string category { get; set; }
        public string price { get; set; }
        public string title_en { get; set; }
        public string properties { get; set; }
        public string title_fi { get; set; }
    }

    public class UniThursday
    {
        public string category { get; set; }
        public string price { get; set; }
        public string title_en { get; set; }
        public string properties { get; set; }
        public string title_fi { get; set; }
    }

    public class UniDays
    {
        public List<UniMonday> monday { get; set; }
        public List<UniTuesday> tuesday { get; set; }
        public List<UniFriday> friday { get; set; }
        public List<UniWednesday> wednesday { get; set; }
        public List<UniThursday> thursday { get; set; }
    }

    public class UniRootObject
    {
        public UniDays days { get; set; }

    }
}
