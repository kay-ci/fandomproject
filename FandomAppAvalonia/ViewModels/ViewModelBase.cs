using ReactiveUI;
using FandomAppSpace;
using UserInfo;

namespace FandomAppSpace.ViewModels;

public class ViewModelBase : ReactiveObject
{
    
    protected UserService uService = UserService.getInstance();
    protected EventService evService = EventService.getInstance();
    protected MessageService msgService = MessageService.getInstance();

    private static Login _login = new Login();
    public static Login UserManager 
    {
        get => _login;
        protected set => _login=value;
    }
    public ViewModelBase(){}
}
