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
        public List<User>? Recipients {get; set;} = new();

        ObservableCollection<User> ObservableRecips {get; set;}
        ObservableCollection<User> ObservableDBUsers {get; set;}
        MessageService Service = MessageService.getInstance();
        UserService U_Service = UserService.getInstance();
        FanAppContext context = new FanAppContext();
        public List<User> Database_users {get; set;} = new();
        // public string _recipientText;
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
        // [Required]
        // public string RecipientText {
        //     get => _recipientText;
        //     private set {
        //         this.RaiseAndSetIfChanged(ref _recipientText, value);
        //     }
        // }
        public CreateMessageViewModel(Login usr){
            Service.setFanAppContext(context);
            U_Service.setFanAppContext(context);
            ObservableRecips = new ObservableCollection<User>(Recipients);
            Database_users = U_Service.GetUsers();
            ObservableDBUsers = new ObservableCollection<User>(Database_users);
            Database_users.Remove(usr.CurrentUser);
            ObservableDBUsers.Remove(usr.CurrentUser);
            Ok = ReactiveCommand.Create(() => { });
            Cancel = ReactiveCommand.Create(() => { });
            // RecipientText = "test";
        }

        // public CreateMessageViewModel(Login usr, User chosen_recipient){
        //     Service.setFanAppContext(context);
        //     U_Service.setFanAppContext(context);
        //     ObservableRecips = new ObservableCollection<User>(Recipients);
        //     Database_users = U_Service.GetUsers();
        //     ObservableDBUsers = new ObservableCollection<User>(Database_users);
        //     Database_users.Remove(usr.CurrentUser);
        //     ObservableDBUsers.Remove(usr.CurrentUser);
        //     Ok = ReactiveCommand.Create(() => { });
        //     Cancel = ReactiveCommand.Create(() => { });
        //     chosen_recipient.Username += ",";
        //     RecipientText = chosen_recipient.Username;
        // }

        public void CreateMessage(Login user){
            // string[] str_recipients = RecipientText.Split(",");
            // foreach(string str_recipient in str_recipients){
            //     Recipients.Add(U_Service.GetUser(str_recipient));
            // }

            if(Recipients.Count != 0) newMsg = new Message(user.CurrentUser, Recipients, Title, Text);
            else throw new ArgumentException("ERROR : Recipients is empty");
            Service.AddMessage(newMsg);
        }

        public void RemoveRecipient(User usr){
            
            Recipients.Remove(usr);
            Database_users.Add(usr);
            ObservableRecips.Remove(usr);
            ObservableDBUsers.Add(usr);
        }

        public void AddRecipient(User usr){
            
            Recipients.Add(usr);
            Database_users.Remove(usr);
            ObservableRecips.Add(usr);
            ObservableDBUsers.Remove(usr);
        }
    }
}