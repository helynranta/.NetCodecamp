using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaavoApp
{
    public class Tuesday
    {
        public string allergies { get; set; }
        public string description { get; set; }
        public string coursetype { get; set; }
        public string name { get; set; }
    }

    public class Thursday
    {
        public string allergies { get; set; }
        public string description { get; set; }
        public string coursetype { get; set; }
        public string name { get; set; }
    }

    public class Friday
    {
        public string allergies { get; set; }
        public string description { get; set; }
        public string coursetype { get; set; }
        public string name { get; set; }
    }

    public class Wednesday
    {
        public string allergies { get; set; }
        public string description { get; set; }
        public string coursetype { get; set; }
        public string name { get; set; }
    }

    public class Monday
    {
        public string allergies { get; set; }
        public string description { get; set; }
        public string coursetype { get; set; }
        public string name { get; set; }
    }

    public class Days
    {
        public List<Tuesday> tuesday { get; set; }
        public List<Thursday> thursday { get; set; }
        public List<Friday> friday { get; set; }
        public List<Wednesday> wednesday { get; set; }
        public List<Monday> monday { get; set; }
    }

    public class RootObject
    {
        public Days days { get; set; }
        public string restaurant { get; set; }
    }
}
