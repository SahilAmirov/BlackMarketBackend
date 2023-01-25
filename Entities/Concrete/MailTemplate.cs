using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class MailTemplate: IEntity
    {
        public int ID { get; set; }
        public int StoreID { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
    }
}
