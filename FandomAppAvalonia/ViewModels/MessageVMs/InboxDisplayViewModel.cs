using System.Collections.Generic;
using System.Collections.ObjectModel;
using FandomAppSpace;
using UserInfo;

namespace FandomAppSpace.ViewModels
{
    public class InboxDisplayViewModel : MainWindowViewModel
    {
        public List<Message> Messages { get;}
        public InboxDisplayViewModel(){
            Messages = UserManager.CurrentUser.Inbox;
        }
    }
}