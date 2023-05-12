using System.Collections.Generic;
using System.Collections.ObjectModel;
using FandomAppSpace;
using UserInfo;

namespace FandomAppSpace.ViewModels
{
    public class EventDisplayViewModel : ViewModelBase
    {
        public Event Event {get;}
        public List<Event> Events {get;}
        public ReactiveCommand<Unit, Unit> NewEvent { get; }

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
        public EventDisplayViewModel()
        {
            VisibleNavigation = true;

            NewEvent =  ReactiveCommand.Create(() => {CreateEvent();});

            Events = evService.GetAllEvents();
        }

        public void ShowEvent(Event e) 
        {


        }

        //Create and display a new event
        private void CreateEvent()
        {
            Profile owner_profile = new Profile("Owner", "they/them", 21, "Canada", "Montreal");
            List<Category> categories = new List<Category>(){new Category("Music")};

            User owner = new User("userOwner", owner_profile);
            
            ShowEvent(new Event("Title", new DateTime(2023, 12, 12), "Montreal", categories, 15, owner));
        }

        //Navigate to edit event view from event display view
        public void EditEvent()
        {
            EventDisplayViewModel dispvm = (EventDisplayViewModel) Content;
            var vm = new EventEditViewModel(dispvm.Event);
            
            vm.Ok.Subscribe(x => {Content = dispvm;});
            Content = vm;
        }
        
    }
}
