using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PikYak.Models
{
    public class YakClass
    {
        //this feels right to Dr. Casey
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime Timestamp { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public double Positivity { get; set; }

        public string PictureURL { get; set; }

        public int ReplyToYakId { get; set; }


    }
}