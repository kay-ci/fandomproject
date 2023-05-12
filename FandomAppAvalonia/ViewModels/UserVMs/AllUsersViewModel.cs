using System.Collections.Generic;
using System.Collections.ObjectModel;
using FandomAppSpace;
using UserInfo;

namespace FandomAppSpace.ViewModels
{
    public class AllUsersViewModel : ViewModelBase
    {
        public ObservableCollection<User> Users { get;}
        public AllUsersViewModel(){
            
            List<User> u = uService.GetUsers();
            Users = new ObservableCollection<User>(u);
        }
    }
}