using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreSignalR.Data
{
    [Table("tblUserReceiver")]
    public class UserReceiver
    {

        //[ForeignKey("User"), Key, Column(Order = 1)]
        public int UserId { get; set; }
        public virtual DbUser User { get; set; }

        //[ForeignKey("Message"), Key, Column(Order = 2)]
        public int MessageId { get; set; }
        public virtual Message Message { get; set; }
    }
}
