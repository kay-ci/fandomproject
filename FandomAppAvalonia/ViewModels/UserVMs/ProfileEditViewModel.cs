using System.Reactive;
using Avalonia.Controls;
using FandomAppSpace;
using ReactiveUI;
using UserInfo;
using System.Collections.ObjectModel;
using System.Reactive.Linq;

namespace FandomAppSpace.ViewModels
{
    public class ProfileEditViewModel : ViewModelBase
    {
        string _categoryText;
        string _fandomName;
        string _fandomCategory;
        string _fandomDescription;
        string _badgesText;
        string _name;
        string _pronouns;
        int _age;
        string _country;
        string _city;
        string _description;
        string _interests;
        string _picture;
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
        public string Name 
        {
            get => _name;
            private set => this.RaiseAndSetIfChanged(ref _name, value);
        }
         public string Pronouns 
        {
            get => _pronouns;
            private set => this.RaiseAndSetIfChanged(ref _pronouns, value);
        }
         public int Age 
        {
            get => _age;
            private set => this.RaiseAndSetIfChanged(ref _age, value);
        }
         public string Country 
        {
            get => _country;
            private set => this.RaiseAndSetIfChanged(ref _country, value);
        }
         public string City 
        {
            get => _city;
            private set => this.RaiseAndSetIfChanged(ref _city, value);
        }
         public string Description 
        {
            get => _description;
            private set => this.RaiseAndSetIfChanged(ref _description, value);
        }
         public string Interests 
        {
            get => _interests;
            private set => this.RaiseAndSetIfChanged(ref _interests, value);
        }
         public string Picture 
        {
            get => _picture;
            private set => this.RaiseAndSetIfChanged(ref _picture, value);
        }
        ObservableCollection<Category> Categories {get; set;}
        ObservableCollection<Fandom> Fandoms {get; set;}
        ObservableCollection<Badge> Badges {get; set;}
        List<Category> CategoriesList;
        List<Fandom> FandomsList;
        List<Badge> BadgesList;
        UserService service = UserService.getInstance();
        public Profile Profile {get; set;}
        public ReactiveCommand<Unit, Unit> Ok { get; }
        public ProfileEditViewModel(Profile p)
        {
            CategoriesList = new List<Category>();
            FandomsList = new List<Fandom>();
            BadgesList = new List<Badge>();
            Profile = p;
            Categories = new ObservableCollection<Category>(CategoriesList);
            Fandoms = new ObservableCollection<Fandom>(FandomsList);
            Badges = new ObservableCollection<Badge>(BadgesList);
            // var editEnabled = this.WhenAnyValue(
            //     x => x.FandomCategory, x=> x.FandomName, x=>x.FandomDescription, x=>x.BadgesText, x=>x.Name, x=>x.Pronouns, x=>x.Country, x=>x.City,x=>x.Description, x=>x.Age, x=>x.Picture, x=>x.Interests,
            //     (fcategory, fname, fdescription, badges, pname, pronouns, country, city, pdescription, age, picture, interests) =>
            //         !string.IsNullOrWhiteSpace(fcategory) &&
            //         !string.IsNullOrWhiteSpace(fname) &&
            //         !string.IsNullOrWhiteSpace(fdescription) &&
            //         !string.IsNullOrWhiteSpace(badges) &&
            //         !string.IsNullOrWhiteSpace(pname) &&
            //         !string.IsNulOrWhiteSpace(pronouns)&&
            //         !string.IsNullOrWhiteSpace(country)&&
            //         !string.IsNullOrWhiteSpace(city)&&
            //         !string.IsNullOrWhiteSpace(picture)&&
            //         age >= 0 && age <= 130)
            // .DistinctUntilChanged();
            Ok = ReactiveCommand.Create(() => { });
        }

        public void UpdateUser(Login userManager){
            Profile = new Profile(Name, Pronouns, Age, Country, City, CategoriesList, FandomsList, BadgesList, Description, Picture, Interests);
            
            uService.UpdateProfile(userManager, Profile);
        }
        public void AddBadge(){
            Badge newBadge = new Badge(BadgesText);
            if (!Badges.Contains(newBadge)){
                BadgesList.Add(newBadge);
                Badges.Add(newBadge);
                uService.AddBadge(newBadge);
            }
        }
        public void RemoveBadge(Badge badgeToRemove){
            Badges.Remove(badgeToRemove);
            BadgesList.Remove(badgeToRemove);
        }
        public void AddCategory(){
            Category newCategory = new Category(CategoryText);
            if (!Categories.Contains(newCategory)){
                Categories.Add(newCategory);
                uService.AddCategory(newCategory);
                CategoriesList.Add(newCategory);
            }
        }
        public void RemoveCategory(Category catToRemove){
            Categories.Remove(catToRemove);
            CategoriesList.Remove(catToRemove);
        }
        public void AddFandom(){
            Fandom newFandom = new Fandom(FandomName, FandomCategory, FandomDescription);
            if (!Fandoms.Contains(newFandom)){
                Fandoms.Add(newFandom);
                uService.AddFandom(newFandom);
                FandomsList.Add(newFandom);
            }
        }
        public void RemoveFandom(Fandom fandomToRemove){
            Fandoms.Remove(fandomToRemove);
            FandomsList.Remove(fandomToRemove);
        }
    }
}
