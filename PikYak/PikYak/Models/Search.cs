using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PikYak.Models
{
    public class Search
    {
        public int Id { get; set; }

        public int Search()
        {
            foreach (int i in Id)
            {
                return i;
            }
        }

       
    }
}