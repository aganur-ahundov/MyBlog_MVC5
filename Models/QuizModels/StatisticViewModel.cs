using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpamBlog.Models.QuizModels
{
    public class StatisticViewModel
    {
        public string Title { get; set; }

        public double PersentPerPoint { get; set; }

        public Dictionary<string, int> Data { get; set; }
    }
}