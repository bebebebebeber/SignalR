using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreSignalR.Data
{
    [Table("tblMessages")]
    public class Message
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string Text { get; set; }
        [ForeignKey("Creator")]
        public int CreatorId { get; set; }
        public virtual DbUser Creator { get; set; }

        public virtual ICollection<UserReceiver> UserReceivers { get; set; }
    }
}
