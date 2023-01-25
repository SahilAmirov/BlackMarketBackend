using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class User: IEntity
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string Email { get; set; }
        public bool? MailConfirm { get; set; }
        public string? ConfirmValue { get; set; }
        public DateTime? ConfirmDate { get; set; }
        public string? PhoneNumber { get; set; }
        public bool? PhoneConfirm { get; set; }
        public string? ProfilePhoto { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public byte[]? PasswordHash { get; set; }
        public int JoinedFromStoreID { get; set; }
        public DateTime JoinedAt { get; set; }
        public bool? IsActive { get; set; }
    }
}
