using System.ComponentModel.DataAnnotations;
using System.Reactive;
using FandomAppSpace;
using ReactiveUI;
using UserInfo;
using System.Collections.ObjectModel;

namespace FandomAppSpace.ViewModels
{
    public class EditMessageViewModel : ViewModelBase
    {
        
        public Message? newMsg {get; set;}
        public Message oldMsg {get; set;}
        public ReactiveCommand<Unit, Unit> Cancel { get; }
        public ReactiveCommand<Unit, Unit> Ok { get; }
        public string? _title;
        public string? _text;
        [Required]
        public string Title{
            get => _title;
            private set { 
                this.RaiseAndSetIfChanged(ref _title, value);
                
            }
        }
        [Required]
        public string Text{
            get => _text;
            private set { 
                this.RaiseAndSetIfChanged(ref _text, value);
                
            }
        }
        Login UserManager;
        public EditMessageViewModel(Message msg){
            UserManager = ViewModelBase.UserManager;
            oldMsg = msg;
            Ok = ReactiveCommand.Create(() => { });
            Cancel = ReactiveCommand.Create(() => { });
        }

        public void EditMessage(){
            newMsg = new Message(UserManager.CurrentUser, oldMsg.Recipients, Title, Text);
            for(int i = 0; i < UserManager.CurrentUser.Outbox.Count; i++){
                if(UserManager.CurrentUser.Outbox[i] == oldMsg) UserManager.CurrentUser.Outbox[i] = new Message(newMsg.Sender, newMsg.Recipients, Title, Text);
            }

            msgService.EditMessage(UserManager, newMsg, oldMsg.Title);
        }
        
    }
}