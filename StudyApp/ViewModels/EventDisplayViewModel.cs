using System.Collections.Generic;
using System.Collections.ObjectModel;
using FandomApp;

namespace StudyApp.ViewModels
{
    public class EventDisplayViewModel : ViewModelBase
    {
        public EventDisplayViewModel(Event e)
        {
            Event = e;
        }

        public Event Event { get; }
    }
}