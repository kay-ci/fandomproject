using System.Collections.Generic;
using System.Collections.ObjectModel;
using FandomAppSpace;
using UserInfo;

namespace FandomAppSpace.ViewModels
{
    public class MessageViewModel : ViewModelBase
    {
        public Message Msg { get;}
        public MessageViewModel(Message m){
            Msg = m;
        }
    }
}