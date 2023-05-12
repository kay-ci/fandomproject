using System.Collections.ObjectModel;
using System.Reactive;
using FandomAppSpace;
using ReactiveUI;
using UserInfo;

namespace FandomAppSpace.ViewModels
{
    public class EventEditViewModel : EventDisplayViewModel
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

        public Event? new_event;
        public Event old_event;
        public ReactiveCommand<Unit, Unit> Cancel { get; }
        public ReactiveCommand<Unit, Unit> EditBtn { get; }

        public EventEditViewModel(Event e){
            old_event = e;
            if(e.Categories==null)CategoriesList= new List<Category>();
            else CategoriesList=e.Categories;
            if(e.Fandoms==null)FandomsList= new List<Fandom>();
            else FandomsList=e.Fandoms;
            Categories = new ObservableCollection<Category>(CategoriesList);
            Fandoms = new ObservableCollection<Fandom>(FandomsList);
            EditBtn = ReactiveCommand.Create(() => { });
            Cancel = ReactiveCommand.Create(() => { });
        }

        public void UpdateEvent(){
            Event new_event = new Event(Title, new DateTime(2030,12,12), Location, MinAge, ViewModelBase.UserManager.CurrentUser , Categories.ToList(), FandomsList.ToList());
            evService.EditEvent(ViewModelBase.UserManager, new_event, old_event.Title);
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
