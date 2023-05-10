using System.Reactive;
using FandomAppSpace;
using ReactiveUI;
using UserInfo;

namespace FandomAppSpace.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        public string _username;
        public string _password;
        public string _name;
        public string _pronouns;
        public int _age;
        public string _country;
        public string _city;
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
        public string Name 
        {
            get => _name;
            private set => this.RaiseAndSetIfChanged(ref _name, value);
        }
        public string Pronouns 
        {
            get => _pronouns;
            private set => this.RaiseAndSetIfChanged(ref _pronouns, value);
        }
        public int Age 
        {
            get => _age;
            private set => this.RaiseAndSetIfChanged(ref _age, value);
        }
        public string Country 
        {
            get => _country;
            private set => this.RaiseAndSetIfChanged(ref _country, value);
        }
        public string City 
        {
            get => _city;
            private set => this.RaiseAndSetIfChanged(ref _city, value);
        }
        FanAppContext Context = new FanAppContext();
        UserService service = UserService.getInstance();
        Login UserManager;
        public Profile Profile {get; set;}
        public ReactiveCommand<Unit, Unit> Register { get; }
        public RegisterViewModel()
        {
            Profile = new Profile("...", "...",0,"...", "...");
            var registerEnabled = this.WhenAnyValue(
                x => x.Username,
                x => !string.IsNullOrWhiteSpace(x)
            );
            service.setFanAppContext(Context);
            Register = ReactiveCommand.Create(() => { }, registerEnabled);

        }

        public Login RegisterUser(){
            User newUser = service.CreateUser(Username, Password, Profile);
            this.UserManager = new Login(newUser);
            return this.UserManager;
        }
        
    }
}