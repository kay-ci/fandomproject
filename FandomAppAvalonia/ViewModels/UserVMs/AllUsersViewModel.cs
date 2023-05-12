using System.Collections.Generic;
using System.Collections.ObjectModel;
using FandomAppSpace;
using UserInfo;

namespace FandomAppSpace.ViewModels
{
    public class AllUsersViewModel : ViewModelBase
    {
        public ObservableCollection<User> Users { get;}
        public UserService Service {get; set;}
        public FanAppContext context = new FanAppContext();
        public AllUsersViewModel(){
            Service = UserService.getInstance();
            Service.setFanAppContext(context);
            List<User> u = Service.GetUsers();
            Users = new ObservableCollection<User>(u);
        }
    }
}