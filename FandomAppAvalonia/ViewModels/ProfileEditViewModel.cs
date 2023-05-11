using System.Reactive;
using Avalonia.Controls;
using FandomAppSpace;
using ReactiveUI;
using UserInfo;
using System.Collections.ObjectModel;
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
        ObservableCollection<Category> Categories {get; set;}
        ObservableCollection<Fandom> Fandoms {get; set;}
        ObservableCollection<Badge> Badges {get; set;}
        List<Category> CategoriesList = new();
        List<Fandom> FandomsList = new();
        List<Badge> BadgesList = new();
        UserService service = UserService.getInstance();
        public Profile Profile {get; set;}
        public ReactiveCommand<Unit, Unit> Ok { get; }
        public ProfileEditViewModel(Profile p)
        {
            Profile = p;
            Categories = new ObservableCollection<Category>(CategoriesList);
            Fandoms = new ObservableCollection<Fandom>(FandomsList);
            Badges = new ObservableCollection<Badge>(BadgesList);
            Ok = ReactiveCommand.Create(() => { });
        }

        public void UpdateUser(Login userManager){
            Profile = new Profile(Profile.Name, Profile.Pronouns, Profile.Age, Profile.Country, Profile.City, Categories.ToList(), Fandoms.ToList(), Badges.ToList(), Profile.Description, Profile.Picture, Profile.Interests);
            service.UpdateProfile(userManager, Profile);
        }
        public void AddBadge(){
            Badges.Add(new Badge(BadgesText));
        }
        public void RemoveBadge(Badge badgeToRemove){
            Badges.Remove(badgeToRemove);
        }
        public void AddCategory(){
            Categories.Add(new Category(CategoryText));
        }
        public void RemoveCategory(Category catToRemove){
            Categories.Remove(catToRemove);
        }
        public void AddFandom(){
            Fandoms.Add(new Fandom(FandomName, FandomCategory, FandomDescription));
        }
        public void RemoveFandom(Fandom fandomToRemove){
            Fandoms.Remove(fandomToRemove);
        }
    }
}
