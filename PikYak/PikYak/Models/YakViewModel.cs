using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PikYak.Models
{
    public class YakViewModel
    {
        
        public Yak Yak { get; set; }
        public int LikeCount { get; set; }
        public int ReportCount { get; set; }
        public double DistanceAway { get; set; }
        public int ReplyID { get; set; }

    }
}