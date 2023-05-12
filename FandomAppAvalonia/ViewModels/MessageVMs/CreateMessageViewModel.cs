using System.ComponentModel.DataAnnotations;
using System.Reactive;
using FandomAppSpace;
using ReactiveUI;
using UserInfo;
using System.Collections.ObjectModel;

namespace FandomAppSpace.ViewModels
{
    public class CreateMessageViewModel : MainWindowViewModel
    {
        
        public Message? newMsg {get; set;}
        public ReactiveCommand<Unit, Unit> Cancel { get; }
        public ReactiveCommand<Unit, Unit> Ok { get; }
        public string? _title;
        public string? _text;
        public List<User>? Recipients {get; set;} = new();

        ObservableCollection<User> ObservableRecips {get; set;}
        ObservableCollection<User> ObservableDBUsers {get; set;}
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
        Login UserManager;
        public CreateMessageViewModel(Login userManager){
            UserManager = userManager;
            ObservableRecips = new ObservableCollection<User>(Recipients);
            Database_users = uService.GetUsers();
            ObservableDBUsers = new ObservableCollection<User>(Database_users);
            RemoveLogin();
            Ok = ReactiveCommand.Create(() => { });
            Cancel = ReactiveCommand.Create(() => { });
            // RecipientText = "test";
        }

        public CreateMessageViewModel(Login userManager, User chosen_recipient){
            UserManager = userManager;
            ObservableRecips = new ObservableCollection<User>(Recipients);
            Database_users = new List<User>(uService.GetUsers());
            ObservableDBUsers = new ObservableCollection<User>(Database_users);
            RemoveLogin();
            AddRecipient(chosen_recipient);
            
            Ok = ReactiveCommand.Create(() => { });
            Cancel = ReactiveCommand.Create(() => { });
            // chosen_recipient.Username += ",";
            // RecipientText = chosen_recipient.Username;
        }

        public void CreateMessage(){
            // string[] str_recipients = RecipientText.Split(",");
            // foreach(string str_recipient in str_recipients){
            //     Recipients.Add(U_Service.GetUser(str_recipient));
            // }


            foreach(User usr in ObservableDBUsers) Database_users.Remove(usr);
            if(Recipients.Count != 0) newMsg = new Message(UserManager.CurrentUser, Recipients, Title, Text);
            else throw new ArgumentException("ERROR : Recipients is empty");
            msgService.AddMessage(newMsg);
        }

        public void RemoveRecipient(User recipient){
            
            Recipients.Remove(recipient);
            Database_users.Add(recipient);
            ObservableRecips.Remove(recipient);
            ObservableDBUsers.Add(recipient);
        }

        public void AddRecipient(User recipient){
            
            Recipients.Add(recipient);
            Database_users.Remove(recipient);
            ObservableRecips.Add(recipient);
            ObservableDBUsers.Remove(recipient);
        }

        public void RemoveLogin(){
            Database_users.Remove(UserManager.CurrentUser);
            ObservableDBUsers.Remove(UserManager.CurrentUser);
        }
    }
}