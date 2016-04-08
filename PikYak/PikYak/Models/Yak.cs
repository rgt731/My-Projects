using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PikYak.Models
{
    public class Yak
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime Timestamp { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int LikeCount { get; set; }
    }
}