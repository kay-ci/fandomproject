using System.Collections.Generic;
using System.Collections.ObjectModel;
using FandomAppSpace;

namespace FandomAppSpace.ViewModels
{
    public class EventDisplayViewModel : ViewModelBase
    {
        public Event Event {get;}
        public EventDisplayViewModel(Event e){
            Event = e;
        }
    }
}
