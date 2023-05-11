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
        string _fandomName;
        string _fandomCategory;
        string _fandomDescription;
        string _badgesText;
        public string CategoryText 
        {
            get => _categoryText;
            private set => this.RaiseAndSetIfChanged(ref _categoryText, value);
        }
        public string FandomName 
        {
            get => _fandomName;
            private set => this.RaiseAndSetIfChanged(ref _fandomName, value);
        }
        public string FandomCategory 
        {
            get => _fandomCategory;
            private set => this.RaiseAndSetIfChanged(ref _fandomCategory, value);
        }
        public string FandomDescription 
        {
            get => _fandomDescription;
            private set => this.RaiseAndSetIfChanged(ref _fandomDescription, value);
        }
        public string BadgesText 
        {
            get => _badgesText;
            private set => this.RaiseAndSetIfChanged(ref _badgesText, value);
        }
        List<Category> Categories = new List<Category>{new Category("Gaming"), new Category("Sports")};
        List<Fandom> Fandoms;
        List<Badge> Badges;
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
            foreach(string category in categories) Categories.Add(new Category(category));

            string[] badges = BadgesText.Split(",");
            foreach(string badge in badges) Badges.Add(new Badge(badge));

            service.UpdateProfile(userManager, Profile);
        }
        public void AddBadge(){
            Badges.Add(new Badge(BadgesText));
        }
    }
}
