using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Listing: IEntity
    {
        public int ID { get; set; }
        public int StoreID { get; set; }
        public int CategoryID { get; set; }
        public int NeedLvl { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? PhotoLink { get; set; }
        public string? BuyFromLink { get; set; }
        public string? Code { get; set; }
        public string? DownloadLink { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool? IsActive { get; set; }
    }
}
