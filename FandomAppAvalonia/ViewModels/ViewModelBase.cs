using ReactiveUI;
using FandomAppSpace;
using UserInfo;

namespace FandomAppSpace.ViewModels;

public class ViewModelBase : ReactiveObject
{
    protected FanAppContext context = new FanAppContext();
    protected UserService uService = UserService.getInstance();
    protected EventService evService = EventService.getInstance();
    protected MessageService msgService = MessageService.getInstance();

    private static Login _login = new Login();
    public static Login UserManager 
    {
        get => _login;
        set => _login=value;
        //protected set => this.RaiseAndSetIfChanged(ref _login, value);
    }
    public ViewModelBase()
    {
        uService.setFanAppContext(context);
        evService.setFanAppContext(context);
        msgService.setFanAppContext(context);
    }
}
