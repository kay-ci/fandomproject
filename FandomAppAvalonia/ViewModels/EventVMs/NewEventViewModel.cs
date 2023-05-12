using System.ComponentModel.DataAnnotations;
using System.Reactive;
using System.Reactive.Linq;
using Avalonia.Data;
using FandomAppSpace;
using ReactiveUI;
using UserInfo;

namespace FandomAppSpace.ViewModels
{
    public class NewEventViewModel : ViewModelBase
    {
         private int _minAge;
        private string _title;
        private DateTime _date;
        private string _location;

        string _categoryText;
        string _fandomName;
        string _fandomCategory;
        string _fandomDescription;

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

        ObservableCollection<Category> Categories {get; set;}
        ObservableCollection<Fandom> Fandoms {get; set;}

        List<Category> CategoriesList = new();
        List<Fandom> FandomsList = new();
        List<Badge> BadgesList = new();

        public string Title 
        {
            get => _title;
            private set { 
                this.RaiseAndSetIfChanged(ref _title, value);
            }
        }

        public DateTime Date {
            get => _date;
            private set { 
                this.RaiseAndSetIfChanged(ref _date, value);
            }
        }
        public string Location 
        {
            get => _location;
            private set { 
                this.RaiseAndSetIfChanged(ref _location, value);
            }
        }
        public int MinAge {
            get => _minAge;
            private set { 
                this.RaiseAndSetIfChanged(ref _minAge, value);
            }
        }

        public ReactiveCommand<Unit, Unit> AddEvent { get; }
       
        public NewEventViewModel()
        {
            Categories = new ObservableCollection<Category>(CategoriesList);
            Fandoms = new ObservableCollection<Fandom>(FandomsList);
            Ok = ReactiveCommand.Create(() => { });
        }

        public void AddNewEvent(){
            Profile = new Profile(Name,Pronouns,Age,Country, City);
            User newUser = service.CreateUser(Username, Password, Profile);
            this.UserManager = new Login(newUser);
            return this.UserManager;
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