using System.Collections.Generic;
using System.Collections.ObjectModel;
using StudyApp;
using UserInfo;

namespace StudyApp.ViewModels
{
    public class ProfileDisplayViewModel : ViewModelBase
    {
        public ProfileDisplayViewModel(Profile p)
        {
            Profile = p;
        }

        public Profile Profile { get; }
    }
}