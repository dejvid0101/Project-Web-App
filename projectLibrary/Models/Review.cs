using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Client_Side.Models
{
    public class Review
    {
        public int ApartmentId { get; set; }
        public int UserId { get; set; }
        public string Details { get; set; }
        public int Stars { get; set; }
    }
}