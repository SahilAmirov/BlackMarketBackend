using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Category: IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int? NeedLvl { get; set; }
        public bool? IsActive { get; set; }
    }
}
