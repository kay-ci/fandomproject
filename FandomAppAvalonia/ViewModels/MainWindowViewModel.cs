using System.Reactive.Linq;
using ReactiveUI;
using System.Reactive;
using UserInfo;
namespace FandomAppSpace.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _content;
        private Boolean _visibleNavigation;

        public Boolean VisibleNavigation
        {
            get => _visibleNavigation;
            private set => this.RaiseAndSetIfChanged(ref _visibleNavigation, value);
        }

        public ViewModelBase Content
        {
            get => _content;
            private set => this.RaiseAndSetIfChanged(ref _content, value);
        }

        public ReactiveCommand<Unit, Unit> Profile { get; }
        public ReactiveCommand<Unit, Unit> MyEvents { get; }
        public ReactiveCommand<Unit, Unit> Search { get; }
        public ReactiveCommand<Unit, Unit> CreateMessage { get; }
        public ReactiveCommand<Unit, Unit> OpenInbox { get; }
        public ReactiveCommand<Unit, Unit> OpenOutbox { get; }
        public ReactiveCommand<Unit, Unit> ViewUsers {get; }
        public ReactiveCommand<Unit, Unit> Logout { get; }

        public Login? UserManager;
        public MainWindowViewModel()
        {
            //Buttons
            MyEvents =  ReactiveCommand.Create(() => {DisplayEventPage();});
            Profile = ReactiveCommand.Create(() => {DisplayProfile(UserManager.CurrentUser);});
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
            vm.Login.Subscribe(x => {PrepareMainPage(vm.LoginUser());});
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
            UserManager = login;
            DisplayProfile(UserManager.CurrentUser);
        }

        //Show profile of a specified user
        
        private void DisplayProfile(User chosenUser)
        {
            Content = new ProfileDisplayViewModel(UserManager, chosenUser);
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
            Content = new EventDisplayViewModel();
        }

        private void View_Message(Message msg){
            bool showEditButton = false;
            if(msg.Sender.Username.Equals(UserManager.CurrentUser.Username)) showEditButton = true;
            Content = new MessageViewModel(msg, showEditButton);
        }

        private void Open_Outbox(){
            Content = new OutboxDisplayViewModel(UserManager);
        }

        private void Open_Inbox(){
            Content = new InboxDisplayViewModel(UserManager);
        }

        private void Create_Message(User chosen_recipient){
            var vm = new CreateMessageViewModel(UserManager, chosen_recipient);

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
            var vm = new CreateMessageViewModel( UserManager);

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
                vm.EditMessage(UserManager);
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