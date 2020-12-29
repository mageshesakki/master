using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobussoftTechnologies.ChatlistUIModule.Model
{
    public class Chat
    {
        public int Id { get; set; }
        public long SenderId { get; set; }

        public long ReceiverId { get; set; }

        public string Message { get; set; }

        public DateTime UpdatedDateTime { get; set; }
    }
}
