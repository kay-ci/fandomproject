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
        
        public ReactiveCommand<Unit, Unit> Login { get; }

        public ReactiveCommand<Unit, Unit> Register { get; }


        public LogInViewModel()
        {
            uService.setFanAppContext(new FanAppContext());
            //Enable the register button only when the user has entered a valid username
            var loginEnabled = this.WhenAnyValue(
                x => x.Username, x=>x.Password,
                (username, password) =>
                !string.IsNullOrWhiteSpace(username)&&
                !string.IsNullOrWhiteSpace(password));
            
            //Create the command to bind to the login and register buttons. Enable it only when loginEnabled is set to true.
            Login = ReactiveCommand.Create(() => { }, loginEnabled);
            Register = ReactiveCommand.Create(() => { });
            
        }

        public void LoginUser(){
            ViewModelBase.UserManager = uService.LogIn(Username, Password);
        }
    }
}