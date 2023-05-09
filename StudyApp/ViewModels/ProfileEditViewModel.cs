using System.Reactive;
using StudyApp;
using ReactiveUI;
using UserInfo;

namespace StudyApp.ViewModels
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
