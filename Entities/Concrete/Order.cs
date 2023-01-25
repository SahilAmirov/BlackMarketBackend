using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Order : IEntity
    {
        public int ID { get; set; }
        public int ListingID { get; set; }
        public int UserID { get; set; }
        public DateTime Date { get; set; }
        public bool? IsRated { get; set; }
        public int? Rate { get; set; }
        public string? Comment { get; set; }
        public bool? IsActive { get; set; }
    }
}
