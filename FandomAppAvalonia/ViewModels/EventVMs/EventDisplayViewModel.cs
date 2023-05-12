using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using ReactiveUI;
using System.Reactive;
using FandomAppSpace;
using UserInfo;

namespace FandomAppSpace.ViewModels
{
    public class EventDisplayViewModel : MainWindowViewModel
    {
        private Event _e;
        public Event SelectedEvent 
        {
            get => _e;
            private set { 
                this.RaiseAndSetIfChanged(ref _e, value);
        }}

        public List<Event> EventList {get;}
        ObservableCollection<Event> Events {get; set;}
       
        public ReactiveCommand<Unit, Unit> CreateEventPageBtn { get; }
        public ReactiveCommand<Unit, Unit> EditEventPageBtn { get; }
        public ReactiveCommand<Unit, Unit> EventPageBtn { get; }
        public ReactiveCommand<Unit, Unit> SearchEventBtn { get; }
    
        public EventDisplayViewModel()
        {
            CreateEventPageBtn =  ReactiveCommand.Create(() => { AddEventPage(); });
            EditEventPageBtn =  ReactiveCommand.Create(() => { EditEventPage(); });
            EventPageBtn =  ReactiveCommand.Create(() => { EventPage(); });
            //SearchEventBtn =  ReactiveCommand.Create(() => { AddEventPage(); });
            
            EventList = evService.GetAllEvents();
            Events = new ObservableCollection<Event>(EventList);
        }


        //Create and display a new event
        public NewEventViewModel AddEventPage()
        {   
            var vm = new NewEventViewModel();
            return vm;
        }

        //Navigate to edit event view from event display view
        public EventEditViewModel EditEventPage()
        {
            var vm = new EventEditViewModel(SelectedEvent);
            return vm;
        }

        public EventPageViewModel EventPage(Event e)
        {
            return new EventPageViewModel(e);
        }

        public EventPageViewModel EventPage()
        {
            return new EventPageViewModel(SelectedEvent);
        }

        
    }
}
