using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZoneInApp.Models
{
    public class Recommendation
    {
        public int Id { get; set; }
        public string BusinessName { get; set; }
        public string BusAddr { get; set; }
        public string BusPhone { get; set; }
        public string Url { get; set; }
        public int NumRecos { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
