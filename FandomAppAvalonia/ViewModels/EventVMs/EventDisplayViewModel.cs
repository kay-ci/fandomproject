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
        ObservableCollection<Event> MyEvents {get; set;}
       
        public ReactiveCommand<Unit, Unit> CreateEventPageBtn { get; }
        public EventDisplayViewModel()
        {
            CreateEventPageBtn =  ReactiveCommand.Create(() => { });
            
            EventList = evService.GetAllEvents();
            AllEvents = new ObservableCollection<Event>(EventList);
            //Filtering events
            List<Event> MyEventList = new List<Event>();
            foreach(Event e in EventList){
                if(e.Attendees.Any(a => a.Username.Contains(ViewModelBase.UserManager.CurrentUser.Username))) MyEventList.Add(e);
            }
            MyEvents = new ObservableCollection<Event>(MyEventList);
        }

    }
}
