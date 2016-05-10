﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PikYak.Models
{
    public class Report
    {

        public Report()
        {

        }

        //create a convience constructor
        public Report(int yakId)
        {
            //set intial value to Number
            YakId = yakId;
        }

        //because this feels right to be first
        public int Id { get; set; }

        public DateTime Timestamp { get; set; }

        public string UserId { get; set; }

        public int YakId { get; set; }

    }
}