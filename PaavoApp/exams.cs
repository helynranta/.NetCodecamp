using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaavoApp
{
    public class ExamsRoot
    {
        public List<Exam> Exams { get; set; }
    }
    public class Exam
    {
        public string nro { get; set; }
        public string name { get; set; }
        public List<ExamsTime> times { get; set;}
        public Exam()
        {
            times = new List<ExamsTime>();
        }
    }
    public class ExamsTime
    {
        public string date { get; set; }
        public string time_ { get; set; }
        public string fullTime { get; set; }
    }
}
