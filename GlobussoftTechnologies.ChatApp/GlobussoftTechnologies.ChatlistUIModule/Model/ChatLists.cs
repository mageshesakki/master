using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobussoftTechnologies.ChatlistUIModule.Model
{
    public class ChatLists
    {
        public DateTime LastUpdatedTime { get; set; }

        public ObservableCollection<Chat> ChatDetails { get; set; }
    }
}
