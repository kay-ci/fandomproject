using System.Collections.Generic;
using System.Collections.ObjectModel;
using FandomAppSpace;
using UserInfo;

namespace FandomAppSpace.ViewModels
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