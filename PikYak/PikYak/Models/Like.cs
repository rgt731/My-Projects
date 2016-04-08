using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PikYak.Models
{
    public class Like
    {
        //because this feels right to be first
        public int Id { get; set; }

        public DateTime Timestamp { get; set; }

        public string UserId { get; set; }

        public string YakId { get; set; }

    }
}