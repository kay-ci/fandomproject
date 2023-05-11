using System.ComponentModel.DataAnnotations;
using System.Reactive;
using FandomAppSpace;
using ReactiveUI;
using UserInfo;
using System.Collections.ObjectModel;

namespace FandomAppSpace.ViewModels
{
    public class CreateMessageViewModel : ViewModelBase
    {
        
        public Message? newMsg {get; set;}
        public ReactiveCommand<Unit, Unit> Cancel { get; }
        public ReactiveCommand<Unit, Unit> Ok { get; }
        public string? _title;
        public string? _text;
        [Required]
        public List<User>? Recipients {get; set;} = new();

        ObservableCollection<User> ObservableRecips {get; set;}
        ObservableCollection<User> ObservableDBUsers {get; set;}
        MessageService Service = MessageService.getInstance();
        UserService U_Service = UserService.getInstance();
        FanAppContext context = new FanAppContext();
        public List<User> Database_users {get; set;} = new();
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
        public CreateMessageViewModel(){
            Service.setFanAppContext(context);
            U_Service.setFanAppContext(context);
            ObservableRecips = new ObservableCollection<User>(Recipients);
            Database_users = U_Service.GetUsers();
            ObservableDBUsers = new ObservableCollection<User>(Database_users);
            Ok = ReactiveCommand.Create(() => { });
            Cancel = ReactiveCommand.Create(() => { });
        }

        public void CreateMessage(Login user){

            if(Recipients.Count != 0) newMsg = new Message(user.CurrentUser, Recipients, Title, Text);
            else throw new ArgumentException("ERROR : Recipients is empty");
            Service.AddMessage(newMsg);
        }

        public void RemoveUser(User usr){
            if(Recipients.Contains(usr)){
                Recipients.Remove(usr);
                Database_users.Add(usr);
                ObservableRecips.Remove(usr);
                ObservableDBUsers.Add(usr);
            }
        }

        public void AddUser(User usr){
            if(Database_users.Contains(usr)){
                Recipients.Add(usr);
                Database_users.Remove(usr);
                ObservableRecips.Add(usr);
                ObservableDBUsers.Remove(usr);
            }
        }
    }
}