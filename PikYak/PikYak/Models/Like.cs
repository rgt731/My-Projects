using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PikYak.Models
{
    public class Like
    {
        //create a convience constructor
        public Like(int number)
        {
            //set intial value to Number
            Number = number;
        }
    
        //generaically a number
        //data that we are modeling 
        public int Number { get; set; }

        //because this feels right to be first
        public int Id { get; set; }

        public DateTime Timestamp { get; set; }

        public string UserId { get; set; }

        public string YakId { get; set; }

    }
}