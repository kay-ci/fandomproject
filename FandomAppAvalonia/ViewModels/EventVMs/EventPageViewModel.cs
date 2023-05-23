using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using ReactiveUI;
using System.Reactive;
using FandomAppSpace;
using UserInfo;

namespace FandomAppSpace.ViewModels
{
    public class EventPageViewModel : ViewModelBase
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
        private Boolean _showRemoveAttendButton;
        public Boolean ShowRemoveAttendButton
        {
            get => _showAttendButton;
            private set => this.RaiseAndSetIfChanged(ref _showAttendButton, value);
        }

        public Event Event{get;set;}

        public ReactiveCommand<Unit, Unit> AttendEventBtn { get; }
        public ReactiveCommand<Unit, Unit> RemoveAttendEventBtn { get; }
        public ReactiveCommand<Unit, Unit> DeleteEventBtn { get; }
       
        public EventPageViewModel(Event e)
        {
            Event = e;

            ShowButtons = false;
            ShowRemoveAttendButton = false;
            ShowAttendButton = true;

            if(e.Owner.UserID == ViewModelBase.UserManager.CurrentUser.UserID){
                ShowButtons = true;
            }

            if(e.Attendees.Contains(ViewModelBase.UserManager.CurrentUser)){
                ShowRemoveAttendButton = true;
                ShowAttendButton = false;
            }
            
            AttendEventBtn =  ReactiveCommand.Create(() => { });
            RemoveAttendEventBtn =  ReactiveCommand.Create(() => { });
            DeleteEventBtn =  ReactiveCommand.Create(() => { DeleteEvent();});
            
        }
        public void AttendEvent()
        {
            Event.AddAttendee(ViewModelBase.UserManager.CurrentUser);
            evService.UpdateAttendees(ViewModelBase.UserManager,Event);
        }
        public void RemoveAttendEvent()
        {
            Event.RemoveAttendee(ViewModelBase.UserManager.CurrentUser);
            evService.UpdateAttendees(ViewModelBase.UserManager,Event);
        }

        public void DeleteEvent()
        {
            evService.DeleteEvent(ViewModelBase.UserManager, Event);
        }
    }
}
