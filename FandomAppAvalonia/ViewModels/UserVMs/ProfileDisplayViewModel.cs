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

        public ProfileDisplayViewModel(User chosenUser)
        {
            if(chosenUser == ViewModelBase.UserManager.CurrentUser){
                ShowEditButton = true;
                Profile = ViewModelBase.UserManager.CurrentUser.UserProfile;
            }
            else{
                ShowEditButton = false;
                Profile = chosenUser.UserProfile;
            }
        }

    
    }
}