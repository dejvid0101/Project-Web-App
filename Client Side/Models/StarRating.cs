using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Client_Side.Models
{
    public class StarRating
    {
            public string Question { get; set; }
            public int Rating { get; set; }
            public int MaxRating { get; set; } = 5;
        
    }
}