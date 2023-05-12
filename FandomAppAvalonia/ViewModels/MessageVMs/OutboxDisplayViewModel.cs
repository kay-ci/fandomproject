using System.Collections.Generic;
using System.Collections.ObjectModel;
using FandomAppSpace;
using UserInfo;

namespace FandomAppSpace.ViewModels
{
    public class OutboxDisplayViewModel : MainWindowViewModel
    {
        public List<Message> Messages { get;}
        public OutboxDisplayViewModel(){
            Messages = UserManager.CurrentUser.Outbox;
        }
    }
}