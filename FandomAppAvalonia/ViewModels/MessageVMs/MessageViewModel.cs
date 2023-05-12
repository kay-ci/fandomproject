using System.Collections.Generic;
using System.Collections.ObjectModel;
using FandomAppSpace;
using UserInfo;

namespace FandomAppSpace.ViewModels
{
    public class MessageViewModel : ViewModelBase
    {
        public Message Msg { get;}
        public bool ShowEditButton {get; set;}
        public MessageViewModel(Message m, bool showEditButton){
            Msg = m;
            ShowEditButton = showEditButton;
        }
    }
}