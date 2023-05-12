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

        private Event _e;
        public Event Event{get;set;}

        public ReactiveCommand<Unit, Unit> EditEventBtn { get; }
        public ReactiveCommand<Unit, Unit> DeleteEventBtn { get; }
       
        public EventPageViewModel(Event e)
        {
            Event = e;
            if(e.Owner.UserID == ViewModelBase.UserManager.CurrentUser.UserID){
                ShowButtons = true;
            }
            else{
                ShowButtons = false;
            }
            
            EditEventBtn =  ReactiveCommand.Create(() => { EditEventPage(); });
            DeleteEventBtn =  ReactiveCommand.Create(() => { DeleteEvent(); });
            
        }
        public EventEditViewModel EditEventPage()
        {
            var vm = new EventEditViewModel(Event);
            return vm;
        }

        public void DeleteEvent()
        {
            evService.DeleteEvent(ViewModelBase.UserManager, Event);
        }
    }
}
