using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Store: IEntity
    {
        public int ID { get; set; }
        public string StoreName { get; set; }
        public string? StoreAbout { get; set; }
        public string? StorePP { get; set; }
        public DateTime AddedAt { get; set; }
        public bool? IsActive { get; set; }
    }
}
