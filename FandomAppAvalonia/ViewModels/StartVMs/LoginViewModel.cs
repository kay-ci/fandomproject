using FandomAppSpace;
using ReactiveUI;
using System.Reactive;
using UserInfo;

namespace FandomAppSpace.ViewModels
{
    public class LogInViewModel : ViewModelBase
    {

        public string _username;
        public string _password;
        public Profile _profile;
        public string Username
        {
            get => _username;
            private set => this.RaiseAndSetIfChanged(ref _username, value);
        }
        public string Password 
        {
            get => _password;
            private set => this.RaiseAndSetIfChanged(ref _password, value);
        }
        public Profile Profile{
            get => _profile;
        }

        FanAppContext Context = new FanAppContext();
        UserService service = UserService.getInstance();
        Login UserManager {get; set;}
        
        public ReactiveCommand<Unit, Unit> Login { get; }

        public ReactiveCommand<Unit, Unit> Register { get; }


        public LogInViewModel()
        {
            service.setFanAppContext(Context);
            //Enable the register button only when the user has entered a valid username
            var loginEnabled = this.WhenAnyValue(
                x => x.Username,
                x => !string.IsNullOrWhiteSpace(x));
            
            //Create the command to bind to the login and register buttons. Enable it only when loginEnabled is set to true.
            Login = ReactiveCommand.Create(() => { }, loginEnabled);
            Register = ReactiveCommand.Create(() => { });
            
        }

        public Login RegisterUser(){
            
            User newUser = service.CreateUser(Username, Password, Profile);
            this.UserManager = new Login(newUser);
            return this.UserManager;
        }

        public Login LoginUser(){
            this.UserManager = service.LogIn(Username, Password);
            return this.UserManager;
        }
    }
}