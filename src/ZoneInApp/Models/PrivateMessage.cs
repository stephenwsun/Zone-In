using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZoneInApp.Models
{
    public class PrivateMessage
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime Time { get; set; }

        public string FromUserId { get; set; }

        [ForeignKey("FromUserId")]
        public ApplicationUser FromUser { get; set; }

        public string ToUserId { get; set; }

        [ForeignKey("ToUserId")]
        public ApplicationUser ToUser { get; set; }

        public bool IsOriginal { get; set; }
        public int ParentId { get; set; }
    }
}