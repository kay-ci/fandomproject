using System.Reactive;
using Avalonia.Controls;
using FandomAppSpace;
using ReactiveUI;
using UserInfo;

namespace FandomAppSpace.ViewModels
{
    public class ProfileEditViewModel : ViewModelBase
    {
        string _categoryText;
        string _fandomText;
        string _badgesText;
        public string CategoryText 
        {
            get => _categoryText;
            private set => this.RaiseAndSetIfChanged(ref _categoryText, value);
        }
        public string FandomText 
        {
            get => _fandomText;
            private set => this.RaiseAndSetIfChanged(ref _fandomText, value);
        }
        public string BadgesText 
        {
            get => _badgesText;
            private set => this.RaiseAndSetIfChanged(ref _badgesText, value);
        }
        List<Category> AllCategories = new List<Category>{new Category("Gaming"), new Category("Sports")};
        List<Fandom> AllFandoms;
        List<Badge> AllBadges;
        UserService service = UserService.getInstance();
        public Profile Profile {get; set;}
        public ReactiveCommand<Unit, Unit> Ok { get; }
        public ProfileEditViewModel(Profile p)
        {
            Profile = p;
            Ok = ReactiveCommand.Create(() => { });
        }

        public void UpdateUser(Login userManager){
            string[] categories = CategoryText.Split(",");
            foreach(string category in categories) AllCategories.Add(new Category(category));

            string[] fandoms = _fandomText.Split(",");
            foreach(string category in categories) AllCategories.Add(new Category(category));

            string[] categories = CategoryText.Split(",");
            foreach(string category in categories) AllCategories.Add(new Category(category));

            service.UpdateProfile(userManager, Profile);
        }
    }
}
