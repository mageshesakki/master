using GlobussoftTechnologies.ChatlistUIModule.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobussoftTechnologies.ChatlistUIModule.Services
{
    public interface IDataService
    {
        ObservableCollection<Users> GetUsers();
        string GetLastMessage(long id, long selectedId);
        CurrentUser GetCurrentDetail();
        ObservableCollection<ChatLists> GetChatDetails(long currentUserId, long selectedUserId);
        Users GetUser(long selectedId);

        void AddDetails(long senderId, long receiverId, string text);
    }
}
