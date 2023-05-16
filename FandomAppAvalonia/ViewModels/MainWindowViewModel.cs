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
        public MainWindowViewModel()
        {
            //Buttons
            MyEvents =  ReactiveCommand.Create(() => {DisplayAllEventsPage();});
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
                vm.RegisterUser();});
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
            var vm = new ProfileEditViewModel(ViewModelBase.UserManager.CurrentUser.UserProfile);
            Content = vm;
            vm.Ok.Subscribe(x => {
            vm.UpdateUser();
            DisplayProfile(ViewModelBase.UserManager.CurrentUser);
            });
        }

        public void DeleteUser(){
            var vm = new ProfileDisplayViewModel( ViewModelBase.UserManager.CurrentUser);
            vm.DeleteUser.Subscribe(x => {
                ShowLogin();
                
            });
        }
        public void ChangePassword(){
            var vm = new PasswordEditViewModel();
            Content = vm;
            vm.ChangePassword.Subscribe(x => {
            vm.UpdatePassword();
            DisplayProfile(ViewModelBase.UserManager.CurrentUser);
            });
        }

        //EVENTS
        private void DisplayAllEventsPage()
        {
            var vm = new EventDisplayViewModel();
            Content=vm;

            vm.CreateEventPageBtn.Subscribe(x => {
                DisplayCreateEventPage();
            });

        }

        public void DisplayEventPage(Event e)
        {
            var vm = new EventPageViewModel(e);
            Content = vm;
            vm.AttendEventBtn.Subscribe(x => {
                vm.AttendEvent();
                DisplayAllEventsPage();
                });

            vm.DeleteEventBtn.Subscribe(x => {
                DisplayAllEventsPage();
                });
        }
        public void DisplayCreateEventPage()
        {   
            var vm = new NewEventViewModel();
            Content = vm;

            vm.Ok.Subscribe(x => {
                vm.AddNewEvent();
                DisplayAllEventsPage();
                });

            vm.Cancel.Subscribe(x => {
                DisplayAllEventsPage();
                });
        }
        
        public void EditEventView(Event e)
        {
            var vm = new EventEditViewModel(e);;
            Content = vm;
            vm.Ok.Subscribe(x => {
                vm.UpdateEvent();
                DisplayAllEventsPage();
                });

            vm.Cancel.Subscribe(x => {
                DisplayAllEventsPage();
                });
        }

        //MESSAGES

        private void View_Message_Edit(Message msg){
            Content = new MessageViewModel(msg, true);
        }
        private void View_Message(Message msg){
            Content = new MessageViewModel(msg, false);
        }

        private void Open_Outbox(){
            Content = new OutboxDisplayViewModel();
        }

        private void Open_Inbox(){
            Content = new InboxDisplayViewModel();
        }

        private void Create_Message(User chosen_recipient){
            var vm = new CreateMessageViewModel(chosen_recipient);

            vm.Ok.Subscribe(x => {
                vm.CreateMessage();
                Open_Outbox();
            });
            vm.Cancel.Subscribe(x => {
                Open_Inbox();
            });
            Content = vm;
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

        private void Edit_Message(Message msg){
            var vm = new EditMessageViewModel(msg);

            vm.Ok.Subscribe(x => {
                vm.EditMessage();
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