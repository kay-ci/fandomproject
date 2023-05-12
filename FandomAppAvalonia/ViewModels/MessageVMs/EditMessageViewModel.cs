// using System.ComponentModel.DataAnnotations;
// using System.Reactive;
// using FandomAppSpace;
// using ReactiveUI;
// using UserInfo;

// namespace FandomAppSpace.ViewModels
// {
//     public class EditMessageViewModel : ViewModelBase
//     {
        
//         public Message? newMsg {get; set;}
//         public ReactiveCommand<Unit, Unit> Cancel { get; }
//         public ReactiveCommand<Unit, Unit> Ok { get; }
//         public string? _title;
//         public string? _text;
//         public List<User>? recipients {get; set;} = new();
//         MessageService service = MessageService.getInstance();
//         [Required]
//         public string Title{
//             get => _title;
//             private set { 
//                 this.RaiseAndSetIfChanged(ref _title, value);
                
//             }
//         }
//         [Required]
//         public string Text{
//             get => _text;
//             private set { 
//                 this.RaiseAndSetIfChanged(ref _text, value);
                
//             }
//         }
//         public EditMessageViewModel(Message msg){
//             newMsg = msg;
//             Title = msg.Title;
//             Text = msg.Text;
//             recipients = msg.Recipients;
//             Ok = ReactiveCommand.Create(() => { });
//             Cancel = ReactiveCommand.Create(() => { });
//         }

//         public void EditMessage(Login user){

//             if(recipients.Count != 0) newMsg = new Message(user.CurrentUser, recipients, Title, Text);
//             else throw new ArgumentException("Recipients is empty and recipient is null, how did we get here?");
//             service.EditMessage(user, newMsg);
//         }
        
//     }
// }