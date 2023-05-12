using FandomAppSpace;
using ReactiveUI;
using System.Reactive;
using System.Reactive.Linq;
using UserInfo;

namespace FandomAppSpace.ViewModels
{
    public class PasswordEditViewModel : ViewModelBase
    {

        public string _oldPassword;
        public string _newPassword;
        public string _confirm;
        public string OldPassword
        {
            get => _oldPassword;
            private set => this.RaiseAndSetIfChanged(ref _oldPassword, value);
        }
        public string NewPassword 
        {
            get => _newPassword;
            private set => this.RaiseAndSetIfChanged(ref _newPassword, value);
        }
        public string Confirm 
        {
            get => _confirm;
            private set => this.RaiseAndSetIfChanged(ref _confirm, value);
        }

        public ReactiveCommand<Unit, Unit> ChangePassword { get; }


        public PasswordEditViewModel()
        {
            //Enable the register button only when the user has entered a valid username
            var loginEnabled = this.WhenAnyValue(
                x => x.OldPassword, x => x.NewPassword,
                (oldPass, newPass) =>
                !string.IsNullOrWhiteSpace(oldPass)&&
                !string.IsNullOrWhiteSpace(newPass))
                .DistinctUntilChanged();
            
            //Create the command to bind to the login and register buttons. Enable it only when loginEnabled is set to true.
            ChangePassword = ReactiveCommand.Create(() => { }, loginEnabled);
        }


        public void UpdatePassword(){
            if (uService.validPassword(ViewModelBase.UserManager.CurrentUser, OldPassword)){
                if(NewPassword.Equals(Confirm)){
                    uService.CreatePassword(ViewModelBase.UserManager.CurrentUser, NewPassword);
                }
            }
        }
    }
}