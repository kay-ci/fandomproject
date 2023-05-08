using FandomApp;
using UserInfo;
using ReactiveUI;
using System.Reactive;
namespace FandomAppSpace.ViewModels;
public class LoginViewModel : ViewModelBase
{
    public string _username;
    public string _password;
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

    public ReactiveCommand<Unit, Unit> Login { get; }

    public ReactiveCommand<Unit, Unit> Register { get; }


    public FanAppContext context = new FanAppContext();
    public UserService service = UserService.getInstance();

    public Login? UserManager { get; private set;}
    public LoginViewModel()
        {
            service.setFanAppContext(context);
            //Enable the register button only when the user has entered a valid username
            var loginEnabled = this.WhenAnyValue(
                x => x.Username,
                x => !string.IsNullOrWhiteSpace(x));

            //Create the command to bind to the login and register buttons. Enable it only when loginEnabled is set to true.
            Login = ReactiveCommand.Create(() => { }, loginEnabled);
            Register = ReactiveCommand.Create(() => { }, loginEnabled);
        }


    public Login RegisterUser(){
        User newUser = service.CreateUser(Username, Password);
        this.UserManager = new Login(newUser);
        return UserManager;
    }

    public User LoginUser(){
        this.User = new User(Username, Password);
        return this.User;
    }


}