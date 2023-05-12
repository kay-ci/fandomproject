using System.Collections.Generic;
using System.Collections.ObjectModel;
using FandomAppSpace;
using ReactiveUI;
using UserInfo;

namespace FandomAppSpace.ViewModels
{
    public class ProfileDisplayViewModel : ViewModelBase

    {

        public Profile Profile { get; }
        private Boolean _showEditButton;
        public Boolean ShowEditButton
        {
            get => _showEditButton;
            private set => this.RaiseAndSetIfChanged(ref _showEditButton, value);
        }

        public ProfileDisplayViewModel(Login UserManager, User chosenUser)
        {
            if(chosenUser == UserManager.CurrentUser){
                ShowEditButton = true;
                Profile = UserManager.CurrentUser.UserProfile;
            }
            else{
                ShowEditButton = false;
                Profile = chosenUser.UserProfile;
            }
        }

    
    }
}