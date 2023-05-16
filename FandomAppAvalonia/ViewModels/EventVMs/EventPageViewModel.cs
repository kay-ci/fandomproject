using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using ReactiveUI;
using System.Reactive;
using FandomAppSpace;
using UserInfo;

namespace FandomAppSpace.ViewModels
{
    public class EventPageViewModel : EventDisplayViewModel
    {
        private Boolean _showButtons;
        public Boolean ShowButtons
        {
            get => _showButtons;
            private set => this.RaiseAndSetIfChanged(ref _showButtons, value);
        }

        private Boolean _showAttendButton;
        public Boolean ShowAttendButton
        {
            get => _showAttendButton;
            private set => this.RaiseAndSetIfChanged(ref _showAttendButton, value);
        }

        private Event _e;
        public Event Event{get;set;}

        public ReactiveCommand<Unit, Unit> AttendEventBtn { get; }
        public ReactiveCommand<Unit, Unit> DeleteEventBtn { get; }
       
        public EventPageViewModel(Event e)
        {
            Event = evService.GetEvent(e.Title);
            ShowButtons = false;
            ShowAttendButton = true;

            if(e.Owner.UserID == ViewModelBase.UserManager.CurrentUser.UserID){
                ShowButtons = true;
            }

            if(e.Attendees.Any(e=> e.UserID == ViewModelBase.UserManager.CurrentUser.UserID)){
                ShowAttendButton = false;
            }
            
            AttendEventBtn =  ReactiveCommand.Create(() => { });
            DeleteEventBtn =  ReactiveCommand.Create(() => { });
            
        }
        public void AttendEvent()
        {
            Event.AddAttendee(ViewModelBase.UserManager.CurrentUser);
            evService.UpdateEvent(Event);
        }

        public void DeleteEvent()
        {
            evService.DeleteEvent(ViewModelBase.UserManager, Event);
        }
    }
}
