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
            var editEnabled = this.WhenAnyValue(
                x => x.FandomCategory, x=> x.FandomName, x=>x.FandomCategory, x=>x.FandomDescription, x=>x.BadgesText, x=>x.Profile.Name, x=>x.Profile.Pronouns, x=>x.Profile.Country, x=>x.Profile.City,x=>x.Profile.Description, x=>x.Profile.Age,x=>x.Profile.Picture, x=>x.Profile,
                (user_name, pass_word, country, city, name, age, pronouns) =>
                    !string.IsNullOrWhiteSpace(user_name) &&
                    !string.IsNullOrWhiteSpace(pass_word) &&
                    !string.IsNullOrWhiteSpace(country) &&
                    !string.IsNullOrWhiteSpace(city) &&
                    !string.IsNullOrWhiteSpace(name) &&
                    !string.IsNullOrWhiteSpace(pronouns))
                .DistinctUntilChanged();
            Ok = ReactiveCommand.Create(() => { });
        }

        public void UpdateUser(Login userManager){
            Profile = new Profile(Profile.Name, Profile.Pronouns, Profile.Age, Profile.Country, Profile.City, Categories.ToList(), Fandoms.ToList(), Badges.ToList(), Profile.Description, Profile.Picture, Profile.Interests);
            service.UpdateProfile(userManager, Profile);
        }
        public void AddBadge(){
            Badge newBadge = new Badge(BadgesText);
            if (!Badges.Contains(newBadge)){
                Badges.Add(newBadge);
            }
        }
        public void RemoveBadge(Badge badgeToRemove){
            Badges.Remove(badgeToRemove);
        }
        public void AddCategory(){
            Category newCategory = new Category(CategoryText);
            if (!Categories.Contains(newCategory)){
                Categories.Add(newCategory);
            }
        }
        public void RemoveCategory(Category catToRemove){
            Categories.Remove(catToRemove);
        }
        public void AddFandom(){
            Fandom newFandom = new Fandom(FandomName, FandomCategory, FandomDescription);
            if (!Fandoms.Contains(newFandom)){
                Fandoms.Add(newFandom);
            }
        }
        public void RemoveFandom(Fandom fandomToRemove){
            Fandoms.Remove(fandomToRemove);
        }
    }
}
