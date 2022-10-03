using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectLibrary.Models
{

    public enum DropDownEnum
    {
        Uzlazno,
        Silazno
    }
    public class Apartman:IComparable<Apartman>
    {
        public DropDownEnum DropDownEnum { get; set; }
        public int Id { get; set; }
        public string Guid { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int OwnerId { get; set; }
        public int TypeId { get; set; }
        public int StatusId { get; set; }
        public int CityId { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
        public double Price { get; set; }
        public int MaxAdults { get; set; }
        public int MaxChildren { get; set; }
        public int TotalRooms { get; set; }
        public int BeachDistance { get; set; }
        public string HelperStatus { get; set; }
        public string FrontendHelperNameID { get; set; }

        public int CompareTo(Apartman other)
        {
            if (this.Price < other.Price)
            {
                return 1;
            }
            else if (this.Price > other.Price)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public override string ToString()
        {
            return $"{Price}, {CreatedAt}, {DeletedAt}";
        }

        
    }
}