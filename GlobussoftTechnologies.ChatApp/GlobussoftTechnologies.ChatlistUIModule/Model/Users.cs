using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobussoftTechnologies.ChatlistUIModule.Model
{
    public class Users
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string LastMassage { get; set; }

        public Byte[] UserImage { get; set; }
        public string LastReceivedTime { get; set; }
    }
}
