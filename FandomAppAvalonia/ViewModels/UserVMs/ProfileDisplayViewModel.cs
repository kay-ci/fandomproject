using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
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
        public ReactiveCommand<Unit, Unit> DeleteUser { get; }

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
            DeleteUser = ReactiveCommand.Create(() => { });
        }

        public void DeleteCurrentUser(){
            uService.DeleteUser(UserManager);
        }
    }
}