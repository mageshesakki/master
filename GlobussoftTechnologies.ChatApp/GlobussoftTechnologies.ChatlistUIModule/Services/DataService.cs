using GlobussoftTechnologies.ChatlistUIModule.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GlobussoftTechnologies.ChatlistUIModule.Services
{
    public class DataService : IDataService
    {
        #region Private property
        private ChatDBContext _chatDBContext;
        #endregion Private property

        #region Public property
        private ChatDBContext ChatDBContext
        {
            get
            {
                if (_chatDBContext == null)
                    _chatDBContext = new ChatDBContext();
                

                return _chatDBContext;
            }
        }

        #endregion Public property

        #region Public methods

        /// <summary>        
        /// Method to get users details      
        /// </summary>             
        public ObservableCollection<Users> GetUsers()
        {
            return new ObservableCollection<Users>(ChatDBContext.Users.ToList());
        }

        /// <summary>        
        /// Method to get users details      
        /// </summary>     
        public Users GetUser(long selectedId)
        {
            return ChatDBContext.Users.Where(i => i.Id == selectedId).SingleOrDefault();
        }

        /// <summary>        
        /// Method to get chat details      
        /// </summary>     
        public ObservableCollection<ChatLists> GetChatDetails(long currentUserId, long selectedUserId)
        {
            List<Chat> senddata = new List<Chat>();
            List<Chat> receiveddata = new List<Chat>();

            var sData = ChatDBContext.Chat.Where(i => i.SenderId == currentUserId && i.ReceiverId == selectedUserId).ToList();
            var RData = ChatDBContext.Chat.Where(i => i.SenderId == selectedUserId && i.ReceiverId == currentUserId).ToList();
            var data = RData.Union(sData).OrderBy(i => i.UpdatedDateTime);
            var finalQuery = data.GroupBy(i => i.UpdatedDateTime).Select(g => new ChatLists { LastUpdatedTime = g.Key, ChatDetails = new ObservableCollection<Chat>(g.Select(s => new Chat { Id = s.Id , SenderId = s.SenderId, Message=s.Message, ReceiverId=s.ReceiverId, UpdatedDateTime=s.UpdatedDateTime}))});
            return new ObservableCollection<ChatLists>(finalQuery);

        }

        /// <summary>        
        /// Method to GetLastMessage     
        /// </summary>  
        /// <param name="id"></param>
        public string GetLastMessage(long currentUserId, long selectedId)
        {
            var sData = ChatDBContext.Chat.Where(i => i.SenderId == currentUserId && i.ReceiverId == selectedId).ToList();
            var RData = ChatDBContext.Chat.Where(i => i.SenderId == selectedId && i.ReceiverId == currentUserId).ToList();
            var message = RData.Union(sData).OrderByDescending(i=>i.UpdatedDateTime).FirstOrDefault().Message;
            return message;
        }

        /// <summary>        
        /// Method to GetCurrentDetail     
        /// </summary> 
        public CurrentUser GetCurrentDetail()
        {
            //LoadSampleData();
            return ChatDBContext.CurrentUser.FirstOrDefault();
        }

        /// <summary>        
        /// Method to AddDetails     
        /// </summary>  
        /// <param name="senderId"></param>
        /// <param name="receiverId"></param>
        /// <param name="text"></param>
        public void  AddDetails(long senderId, long receiverId, string text)
        {
           ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = senderId, ReceiverId = receiverId, Message =  text, UpdatedDateTime = DateTime.Now.ToUniversalTime() });
           ChatDBContext.SaveChanges();
        }


        #endregion Public methods

        #region Sample Data
        private void LoadSampleData()
        {
            ChatDBContext.Users.Add(new Model.Users { Id = 8675616071, Name = "magesh", LastMassage = "how r u", LastReceivedTime = "20.12-2020", UserImage = Utilities.Utilities.ImageToByte(@"D:\UserImage.jpg") });
            ChatDBContext.Users.Add(new Model.Users { Id = 8675616072, Name = "rajesh", LastMassage = "how r u", LastReceivedTime = "20.12-2020", UserImage = Utilities.Utilities.ImageToByte(@"D:\UserImage.jpg") });
            ChatDBContext.Users.Add(new Model.Users { Id = 8675616073, Name = "hari", LastMassage = "how r u", LastReceivedTime = "20.12-2020", UserImage = Utilities.Utilities.ImageToByte(@"D:\UserImage.jpg") });
            ChatDBContext.Users.Add(new Model.Users { Id = 8675616074, Name = "selva", LastMassage = "how r u", LastReceivedTime = "20.12-2020", UserImage = Utilities.Utilities.ImageToByte(@"D:\UserImage.jpg") });
            ChatDBContext.Users.Add(new Model.Users { Id = 8675616075, Name = "vignesh", LastMassage = "how r u", LastReceivedTime = "20.12-2020", UserImage = Utilities.Utilities.ImageToByte(@"D:\UserImage.jpg") });
            ChatDBContext.Users.Add(new Model.Users { Id = 8675616076, Name = "vignesh", LastMassage = "how r u", LastReceivedTime = "20.12-2020", UserImage = Utilities.Utilities.ImageToByte(@"D:\UserImage.jpg") });
            ChatDBContext.Users.Add(new Model.Users { Id = 8675616077, Name = "vignesh", LastMassage = "how r u", LastReceivedTime = "20.12-2020", UserImage = Utilities.Utilities.ImageToByte(@"D:\UserImage.jpg") });
            ChatDBContext.Users.Add(new Model.Users { Id = 8675616078, Name = "vignesh", LastMassage = "how r u", LastReceivedTime = "20.12-2020", UserImage = Utilities.Utilities.ImageToByte(@"D:\UserImage.jpg") });
            ChatDBContext.Users.Add(new Model.Users { Id = 8675616079, Name = "vignesh", LastMassage = "how r u", LastReceivedTime = "20.12-2020", UserImage = Utilities.Utilities.ImageToByte(@"D:\UserImage.jpg") });
            ChatDBContext.Users.Add(new Model.Users { Id = 86756160710, Name = "vignesh", LastMassage = "how r u", LastReceivedTime = "20.12-2020", UserImage = Utilities.Utilities.ImageToByte(@"D:\UserImage.jpg") });
            ChatDBContext.Users.Add(new Model.Users { Id = 86756160711, Name = "vignesh", LastMassage = "how r u", LastReceivedTime = "20.12-2020", UserImage = Utilities.Utilities.ImageToByte(@"D:\UserImage.jpg") });

            ChatDBContext.CurrentUser.Add(new CurrentUser { Id = 8675616071, Name = "Ram", Login = true });
            DateTime dateFromStringone = DateTime.Parse("7/10/1974 7:10:24 AM", System.Globalization.CultureInfo.InvariantCulture);
            DateTime dateFromStringtwo = DateTime.Parse("8/10/1974 7:10:24 AM", System.Globalization.CultureInfo.InvariantCulture);
            DateTime dateFromStringthree = DateTime.Parse("9/10/1974 7:10:24 AM", System.Globalization.CultureInfo.InvariantCulture);
            DateTime dateFromStringfour = DateTime.Parse("10/10/1974 7:10:24 AM", System.Globalization.CultureInfo.InvariantCulture);
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616071, ReceiverId = 8675616072, Message = "Hi", UpdatedDateTime = dateFromStringone.ToUniversalTime() });
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616072, ReceiverId = 8675616071, Message = "Hii", UpdatedDateTime = dateFromStringtwo.ToUniversalTime() });
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616072, ReceiverId = 8675616071, Message = "How are you", UpdatedDateTime = dateFromStringthree.ToUniversalTime() });
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616071, ReceiverId = 8675616072, Message = "Fine what about u", UpdatedDateTime = dateFromStringfour.ToUniversalTime() });
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616071, ReceiverId = 8675616072, Message = "How is your work going", UpdatedDateTime = dateFromStringfour.ToUniversalTime() });
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616071, ReceiverId = 8675616072, Message = "How is your work going", UpdatedDateTime = dateFromStringfour.ToUniversalTime() });

            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616071, ReceiverId = 8675616073, Message = "Hi", UpdatedDateTime = dateFromStringone.ToUniversalTime() });
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616073, ReceiverId = 8675616071, Message = "Hii", UpdatedDateTime = dateFromStringtwo.ToUniversalTime() });
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616073, ReceiverId = 8675616071, Message = "How are you", UpdatedDateTime = dateFromStringthree.ToUniversalTime() });
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616071, ReceiverId = 8675616073, Message = "Fine what about u", UpdatedDateTime = dateFromStringfour.ToUniversalTime() });
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616071, ReceiverId = 8675616073, Message = "How is your work going", UpdatedDateTime = dateFromStringfour.ToUniversalTime() });
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616071, ReceiverId = 8675616073, Message = "How is your work going", UpdatedDateTime = dateFromStringfour.ToUniversalTime() });

            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616071, ReceiverId = 8675616074, Message = "Hi", UpdatedDateTime = dateFromStringone.ToUniversalTime() });
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616074, ReceiverId = 8675616071, Message = "Hii", UpdatedDateTime = dateFromStringtwo.ToUniversalTime() });
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616074, ReceiverId = 8675616071, Message = "How are you", UpdatedDateTime = dateFromStringthree.ToUniversalTime() });
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616071, ReceiverId = 8675616074, Message = "Fine what about u", UpdatedDateTime = dateFromStringfour.ToUniversalTime() });
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616071, ReceiverId = 8675616074, Message = "How is your work going", UpdatedDateTime = dateFromStringfour.ToUniversalTime() });
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616071, ReceiverId = 8675616074, Message = "How is your work going", UpdatedDateTime = dateFromStringfour.ToUniversalTime() });

            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616071, ReceiverId = 8675616075, Message = "Hi", UpdatedDateTime = dateFromStringone.ToUniversalTime() });
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616075, ReceiverId = 8675616071, Message = "Hii", UpdatedDateTime = dateFromStringtwo.ToUniversalTime() });
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616075, ReceiverId = 8675616071, Message = "How are you", UpdatedDateTime = dateFromStringthree.ToUniversalTime() });
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616071, ReceiverId = 8675616075, Message = "Fine what about u", UpdatedDateTime = dateFromStringfour.ToUniversalTime() });
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616071, ReceiverId = 8675616075, Message = "How is your work going", UpdatedDateTime = dateFromStringfour.ToUniversalTime() });
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616071, ReceiverId = 8675616075, Message = "How is your work going", UpdatedDateTime = dateFromStringfour.ToUniversalTime() });

            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616071, ReceiverId = 8675616076, Message = "Hi", UpdatedDateTime = dateFromStringone.ToUniversalTime() });
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616076, ReceiverId = 8675616071, Message = "Hii", UpdatedDateTime = dateFromStringtwo.ToUniversalTime() });
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616076, ReceiverId = 8675616071, Message = "How are you", UpdatedDateTime = dateFromStringthree.ToUniversalTime() });
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616071, ReceiverId = 8675616076, Message = "Fine what about u", UpdatedDateTime = dateFromStringfour.ToUniversalTime() });
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616071, ReceiverId = 8675616076, Message = "How is your work going", UpdatedDateTime = dateFromStringfour.ToUniversalTime() });
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616071, ReceiverId = 8675616076, Message = "How is your work going", UpdatedDateTime = dateFromStringfour.ToUniversalTime() });
                                                                                                                                                            
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616071, ReceiverId = 8675616077, Message = "Hi", UpdatedDateTime = dateFromStringone.ToUniversalTime() });
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616077, ReceiverId = 8675616071, Message = "Hii", UpdatedDateTime = dateFromStringtwo.ToUniversalTime() });
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616077, ReceiverId = 8675616071, Message = "How are you", UpdatedDateTime = dateFromStringthree.ToUniversalTime() });
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616071, ReceiverId = 8675616077, Message = "Fine what about u", UpdatedDateTime = dateFromStringfour.ToUniversalTime() });
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616071, ReceiverId = 8675616077, Message = "How is your work going", UpdatedDateTime = dateFromStringfour.ToUniversalTime() });
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616071, ReceiverId = 8675616077, Message = "How is your work going", UpdatedDateTime = dateFromStringfour.ToUniversalTime() });
                                                                                                                                                            
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616071, ReceiverId = 8675616078, Message = "Hi", UpdatedDateTime = dateFromStringone.ToUniversalTime() });
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616078, ReceiverId = 8675616071, Message = "Hii", UpdatedDateTime = dateFromStringtwo.ToUniversalTime() });
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616078, ReceiverId = 8675616071, Message = "How are you", UpdatedDateTime = dateFromStringthree.ToUniversalTime() });
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616071, ReceiverId = 8675616078, Message = "Fine what about u", UpdatedDateTime = dateFromStringfour.ToUniversalTime() });
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616071, ReceiverId = 8675616078, Message = "How is your work going", UpdatedDateTime = dateFromStringfour.ToUniversalTime() });
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616071, ReceiverId = 8675616078, Message = "How is your work going", UpdatedDateTime = dateFromStringfour.ToUniversalTime() });
                                                                                                                                                            
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616071, ReceiverId = 8675616079, Message = "Hi", UpdatedDateTime = dateFromStringone.ToUniversalTime() });
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616079, ReceiverId = 8675616071, Message = "Hii", UpdatedDateTime = dateFromStringtwo.ToUniversalTime() });
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616079, ReceiverId = 8675616071, Message = "How are you", UpdatedDateTime = dateFromStringthree.ToUniversalTime() });
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616071, ReceiverId = 8675616079, Message = "Fine what about u", UpdatedDateTime = dateFromStringfour.ToUniversalTime() });
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616071, ReceiverId = 8675616079, Message = "How is your work going", UpdatedDateTime = dateFromStringfour.ToUniversalTime() });
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616071, ReceiverId = 8675616079, Message = "How is your work going", UpdatedDateTime = dateFromStringfour.ToUniversalTime() });
                                                                                                                                                          
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616071, ReceiverId = 86756160710, Message ="Hi", UpdatedDateTime = dateFromStringone.ToUniversalTime() });
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 86756160710, ReceiverId = 8675616071, Message ="Hii", UpdatedDateTime = dateFromStringtwo.ToUniversalTime() });
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 86756160710, ReceiverId = 8675616071, Message ="How are you", UpdatedDateTime = dateFromStringthree.ToUniversalTime() });
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616071, ReceiverId = 86756160710, Message ="Fine what about u", UpdatedDateTime = dateFromStringfour.ToUniversalTime() });
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616071, ReceiverId = 86756160710, Message ="How is your work going", UpdatedDateTime = dateFromStringfour.ToUniversalTime() });
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616071, ReceiverId = 86756160710, Message ="How is your work going", UpdatedDateTime = dateFromStringfour.ToUniversalTime() });
                                                                                                                                                            
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616071, ReceiverId = 86756160711, Message ="Hi", UpdatedDateTime = dateFromStringone.ToUniversalTime() });
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 86756160711, ReceiverId = 8675616071, Message ="Hii", UpdatedDateTime = dateFromStringtwo.ToUniversalTime() });
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 86756160711, ReceiverId = 8675616071, Message ="How are you", UpdatedDateTime = dateFromStringthree.ToUniversalTime() });
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616071, ReceiverId = 86756160711, Message ="Fine what about u", UpdatedDateTime = dateFromStringfour.ToUniversalTime() });
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616071, ReceiverId = 86756160711, Message ="How is your work going", UpdatedDateTime = dateFromStringfour.ToUniversalTime() });
            ChatDBContext.Chat.Add(new Chat { Id = new Random().Next(int.MinValue, int.MaxValue), SenderId = 8675616071, ReceiverId = 86756160711, Message ="How is your work going", UpdatedDateTime = dateFromStringfour.ToUniversalTime() });
            ChatDBContext.SaveChanges();

            #endregion Sample Data
        }
    }
}
