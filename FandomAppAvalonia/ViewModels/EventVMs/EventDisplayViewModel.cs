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
        private ViewModelBase _content;
        public Event Event {get;}
        public List<Event> Events {get;}
        

        private Boolean _visibleNavigation;

        public Boolean VisibleNavigation
        {
            get => _visibleNavigation;
            private set => this.RaiseAndSetIfChanged(ref _visibleNavigation, value);
        }
        public ViewModelBase Content
        {
            get => _content;
            private set => this.RaiseAndSetIfChanged(ref _content, value);
        }
        public ReactiveCommand<Unit, Unit> CreateEventBtn { get; }
        public ReactiveCommand<Unit, Unit> EditEventBtn { get; }
        public ReactiveCommand<Unit, Unit> DeleteEventBtn { get; }
         public ReactiveCommand<Unit, Unit> SearchEventBtn { get; }
        public ReactiveCommand<Unit, Unit> EventPageBtn { get; }
        public EventDisplayViewModel()
        {
            EventPageBtn =  ReactiveCommand.Create(() => {ShowNewEventPage();});
            Events = evService.GetAllEvents();
        }

        public void ShowEvent(Event e) 
        {

        }

        //Create and display a new event
        private void ShowNewEventPage()
        {
            Content = new NewEventViewModel();
        }

        //Navigate to edit event view from event display view
        public void EditEvent()
        {
            //EventDisplayViewModel dispvm = (EventDisplayViewModel) Content;
            //var vm = new EventEditViewModel(dispvm.Event);
            //vm.Ok.Subscribe(x => {Content = dispvm;});
            //Content = vm;
        }
        
    }
}
