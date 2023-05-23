using System.Collections.ObjectModel;
using ReactiveUI;
using System.Reactive;
using UserInfo;
namespace FandomAppSpace.ViewModels
{
    public class EventDisplayViewModel : ViewModelBase
    {

        public List<Event> EventList {get;}
        ObservableCollection<Event> AllEvents {get; set;}
        ObservableCollection<Event> MyCreatedEvents {get; set;}
        ObservableCollection<Event> MyAttendingEvents {get; set;}
        
        public ReactiveCommand<Unit, Unit> CreateNewEventBtn { get; }
        public EventDisplayViewModel()
        {
            CreateNewEventBtn =  ReactiveCommand.Create(() => { });
            
            EventList = evService.GetAllEvents();
            AllEvents = new ObservableCollection<Event>(EventList);
            //Filtering events
            List<Event> MyEventsCreatedList = EventList.Where(e=> e.Owner.UserID==ViewModelBase.UserManager.CurrentUser.UserID).ToList();
            List<Event> MyEventsAttendingList = EventList.Where(e=> e.Attendees.Any(a => a.UserID==ViewModelBase.UserManager.CurrentUser.UserID)).ToList();
            
            MyCreatedEvents = new ObservableCollection<Event>(MyEventsCreatedList);
            MyAttendingEvents = new ObservableCollection<Event>(MyEventsAttendingList);
        }

    }
}
