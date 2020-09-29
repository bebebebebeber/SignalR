using FastDostavka.Data.Entities;
using Microsoft.AspNetCore.Identity;
using MVCCoreSignalR.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastDostavka.Data.Entities.IdentityUser
{
    public class DbUser:IdentityUser<int>
    {
        public virtual ICollection<DbUserRole> UserRoles { get; set; }
        public virtual ICollection<Message> SentMessages { get; set; }
        public virtual ICollection<UserReceiver> UserReceivers { get; set; }
    }
}
