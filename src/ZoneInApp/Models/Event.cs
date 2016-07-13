using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZoneInApp.Models
{
    public class Event
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string EventAddr { get; set; }
        public DateTime EventStart { get; set; }
        public DateTime EventEnd { get; set; }
        public int Going { get; set; }
        public int Maybe { get; set; }
        public int Declined { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}
