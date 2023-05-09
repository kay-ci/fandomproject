using System.Reactive;
using FandomAppSpace;
using ReactiveUI;
using UserInfo;

namespace FandomAppSpace.ViewModels
{
    public class ProfileEditViewModel : ViewModelBase
    {
        
        public Profile Profile {get; set;}
        public ReactiveCommand<Unit, Unit> Ok { get; }
        public ProfileEditViewModel(Profile p)
        {
            Profile = p;

            Ok = ReactiveCommand.Create(() => { });

        }


        
    }
}
