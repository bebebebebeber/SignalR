using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreSignalR.Data
{
    [Table("tblUsers")]
    public class DbUser
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Message> SentMessages { get; set; }
        public virtual ICollection<UserReceiver> UserReceivers { get; set; }
    }
}
