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

    //property holding the Current User logged in 
    protected Login? UserManager;
    
    public ViewModelBase()
    {
        uService.setFanAppContext(context);
        evService.setFanAppContext(context);
        msgService.setFanAppContext(context);
    }
}
