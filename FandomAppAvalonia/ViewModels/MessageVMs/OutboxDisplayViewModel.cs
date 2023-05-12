using System.Collections.Generic;
using System.Collections.ObjectModel;
using FandomAppSpace;
using UserInfo;

namespace FandomAppSpace.ViewModels
{
    public class OutboxDisplayViewModel : ViewModelBase
    {
        public List<Message> Messages { get;}
        public OutboxDisplayViewModel(List<Message> m){
            Messages = m;
        }
    }
}