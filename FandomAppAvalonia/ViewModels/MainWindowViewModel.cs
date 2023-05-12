using System.Reactive.Linq;
using ReactiveUI;
using System.Reactive;
using UserInfo;
namespace FandomAppSpace.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private static ViewModelBase _content;
        private Boolean _visibleNavigation;

        public Boolean VisibleNavigation
        {
            get => _visibleNavigation;
            private set => this.RaiseAndSetIfChanged(ref _visibleNavigation, value);
        }

        public ViewModelBase Content
        {
            get => _content;
            protected set => this.RaiseAndSetIfChanged(ref _content, value);
        }

        public ReactiveCommand<Unit, Unit> Profile { get; }
        public ReactiveCommand<Unit, Unit> MyEvents { get; }
        public ReactiveCommand<Unit, Unit> Search { get; }
        public ReactiveCommand<Unit, Unit> CreateMessage { get; }
        public ReactiveCommand<Unit, Unit> OpenInbox { get; }
        public ReactiveCommand<Unit, Unit> OpenOutbox { get; }
        public ReactiveCommand<Unit, Unit> ViewUsers {get; }
        public ReactiveCommand<Unit, Unit> Logout { get; }

        //public Login? UserManager;
        public MainWindowViewModel()
        {
            //Buttons
            MyEvents =  ReactiveCommand.Create(() => {DisplayEventPage();});
            Profile = ReactiveCommand.Create(() => {DisplayProfile(ViewModelBase.UserManager.CurrentUser);});
            Search  = ReactiveCommand.Create(() => {OpenSearch();});
            CreateMessage = ReactiveCommand.Create(() => {Create_Message();});
            OpenInbox = ReactiveCommand.Create(() => {Open_Inbox();});
            OpenOutbox = ReactiveCommand.Create(() => {Open_Outbox();});
            ViewUsers = ReactiveCommand.Create(() => {View_Users();});
            Logout = ReactiveCommand.Create(() => {ShowLogin();});
            
            ShowLogin();
        }

        private void ShowLogin(){
            VisibleNavigation = false;

            LogInViewModel vm = new LogInViewModel();
            vm.Login.Subscribe(x => {PrepareMainPage(vm.LoginUser()); });
            vm.Register.Subscribe(x => {RegisterPage();});
            Content = vm;
        }

        public void RegisterPage(){
            LogInViewModel dispvm = (LogInViewModel) Content;
            var vm = new RegisterViewModel();
            
            vm.Register.Subscribe(x => {
                Content = dispvm;
                vm.RegisterUser();
            });
            Content = vm;
            vm.Login.Subscribe(x => {ShowLogin();});
        }
        public void PrepareMainPage(Login login){
            VisibleNavigation = true;
            ViewModelBase.UserManager = login;
            DisplayProfile(ViewModelBase.UserManager.CurrentUser);
        }

        //Show profile of a specified user
        
        private void DisplayProfile(User chosenUser)
        {
            Content = new ProfileDisplayViewModel( chosenUser);
        }

        //Navigate to edit profile view from profile display view
        public void EditProfile()
        {
            ProfileDisplayViewModel dispvm = (ProfileDisplayViewModel) Content;
            var vm = new ProfileEditViewModel(dispvm.Profile);
            
            vm.Ok.Subscribe(x => {
               Content = dispvm;
                vm.UpdateUser();});
            Content = vm;
        }

        //Display an existing event
        private void DisplayEventPage(){
            var vm = new EventDisplayViewModel();
            Content=vm;
            vm.CreateEventPageBtn.Subscribe(x => {
                var new_vm = vm.AddEventPage();
                Content=new_vm;
                    new_vm.AddEventBtn.Subscribe(x => {
                        new_vm.AddNewEvent();
                        DisplayEventPage();
                    });
            });

            vm.EditEventPageBtn.Subscribe(x => {
                var new_vm = vm.EditEventPage();
                Content=new_vm;
                    new_vm.EditBtn.Subscribe(x => {
                        new_vm.UpdateEvent();
                        DisplayEventPage();
                    });

            });

            //Content=vm;

            //vm.EventPageBtn.Subscribe(x => {
            //    var new_vm = vm.EventPage();
            //    Content = new_vm;
            //    
            //        new_vm.EditEventBtn.Subscribe(x => {
            //            new_vm.EditEventPage();
            //            DisplayEventPage();
            //        });
            //        new_vm.DeleteEventBtn.Subscribe(x => {
            //            new_vm.DeleteEvent();
            //            DisplayEventPage();
            //        });
//
            //});
        }

        public void DisplaySingleEventPage(Event e)
        {
            var dpvm = new EventDisplayViewModel();
            
            var vm = new EventPageViewModel(e);
            vm.EditEventBtn.Subscribe(x => {
                    var new_vm = vm.EditEventPage();
                    Content=new_vm;
                        new_vm.EditBtn.Subscribe(x => {
                        new_vm.UpdateEvent();
                        DisplayEventPage();
                    });
                    });
                    vm.DeleteEventBtn.Subscribe(x => {
                        vm.DeleteEvent();
                        DisplayEventPage();
                    });
            Content=vm;
        }


        private void View_Message(Message msg){
            Content = new MessageViewModel(msg);
        }

        private void Open_Outbox(){
            Content = new OutboxDisplayViewModel();
        }

        private void Open_Inbox(){
            Content = new InboxDisplayViewModel();
        }

        private void Create_Message(){
            var vm = new CreateMessageViewModel();

            vm.Ok.Subscribe(x => {
                vm.CreateMessage();
                Open_Outbox();
            });
            vm.Cancel.Subscribe(x => {
                Open_Inbox();
            });
            Content = vm;
        }

        public void View_Users(){
            Content = new AllUsersViewModel();
        }

        //Navigate to search view
        private void OpenSearch()
        {
            Content = new SearchViewModel();
        }

    }
}