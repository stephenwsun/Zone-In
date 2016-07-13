using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZoneInApp.Models
{
    public class Audit
    {
        public bool Active { get; set; }
        public DateTime DateCreated { get; set; }
        public int Thanks { get; set; }        
    }
}
