using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectLibrary.Models
{
    public class Reservation
    {
        public int ApartmentId { get; set; }
        public string Details { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}
