using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZoneInApp.Models
{
    public class Post: Audit
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }        
        public bool Urgent { get; set; }        
        public ICollection<Reply> Replies { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}
