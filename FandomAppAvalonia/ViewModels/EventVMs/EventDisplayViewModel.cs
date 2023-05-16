using System.Collections.ObjectModel;
using ReactiveUI;
using System.Reactive;

namespace FandomAppSpace.ViewModels
{
    public class EventDisplayViewModel : MainWindowViewModel
    {

        public List<Event> EventList {get;}
        ObservableCollection<Event> AllEvents {get; set;}
        ObservableCollection<Event> MyEvents {get; set;}
       
        public ReactiveCommand<Unit, Unit> CreateEventPageBtn { get; }
        public ReactiveCommand<Unit, Unit> SearchEventBtn { get; }
    
        public EventDisplayViewModel()
        {
            CreateEventPageBtn =  ReactiveCommand.Create(() => { });
            SearchEventBtn =  ReactiveCommand.Create(() => { });
            
            EventList = evService.GetAllEvents();
            AllEvents = new ObservableCollection<Event>(EventList);
            //Filtering events
            var MyEventList = evService.GetAllEvents(ViewModelBase.UserManager.CurrentUser);
            MyEvents = new ObservableCollection<Event>(MyEventList);
        }

    }
}
