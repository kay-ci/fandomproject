using System.Collections.Generic;
using System.Collections.ObjectModel;
using FandomAppSpace;
using ReactiveUI;
using UserInfo;

namespace FandomAppSpace.ViewModels
{
    public class ProfileDisplayViewModel : ViewModelBase
    {
        public Boolean ShowEditButton = false;
        public Profile Profile { get; }
        public ProfileDisplayViewModel(Login UserManager, User chosenUser)
        {
            
            if(chosenUser == UserManager.CurrentUser){
                ShowEditButton = true;
                Profile = UserManager.CurrentUser.UserProfile;
            }
            else{
                Profile = chosenUser.UserProfile;
            }
        }

    
    }
}