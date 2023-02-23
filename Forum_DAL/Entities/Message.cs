using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum_DAL.Entities
{
    public class Message:BaseEntiti
    {
        public int comp_id { get; set; }
        public int sender_id { get; set; }
        public int receiver_id { get; set; }

        public string message { get; set; }
        public DateTime created_at { get; set; }
        
    }
}
