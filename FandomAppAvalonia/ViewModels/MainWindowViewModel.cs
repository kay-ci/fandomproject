using System.Reactive.Linq;
using ReactiveUI;
using System.Reactive;
using UserInfo;
namespace FandomAppSpace.ViewModels
{
    class MainWindowViewModel : ViewModelBase
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


        public MainWindowViewModel()
        {
            //Buttons
            Profile = ReactiveCommand.Create(() => {ShowPersonalProfile();});
            MyEvents =  ReactiveCommand.Create(() => {DisplayEventPage();});
            Search  = ReactiveCommand.Create(() => {OpenSearch();});
            CreateMessage = ReactiveCommand.Create(() => {Create_Message();});
            OpenInbox = ReactiveCommand.Create(() => {Open_Inbox(UserManager.CurrentUser.Inbox);});
            OpenOutbox = ReactiveCommand.Create(() => {Open_Outbox(UserManager.CurrentUser.Outbox);});
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
                Content = dispvm;vm.RegisterUser();});
            Content = vm;
            vm.Login.Subscribe(x => {ShowLogin();});
        }
        public void PrepareMainPage(Login u){
            VisibleNavigation = true;
            UserManager = u;
            ShowPersonalProfile();
        }

        //Show profile of logged in user
        private void ShowPersonalProfile()
        {
            DisplayProfile(UserManager.CurrentUser.UserProfile);
        }

        //Show profile of a specified user
        private void DisplayProfile(Profile p)
        {
            Content = new ProfileDisplayViewModel(p);
        }

        //Navigate to edit profile view from profile display view
        public void EditProfile()
        {
            ProfileDisplayViewModel dispvm = (ProfileDisplayViewModel) Content;
            var vm = new ProfileEditViewModel(dispvm.Profile);
            
            vm.Ok.Subscribe(x => {
                Content = dispvm;
                vm.UpdateUser(UserManager);});
            Content = vm;
        }

        //Display an existing event
        private void DisplayEventPage(){
            Content = new EventDisplayViewModel();
        }

        private void View_Message(Message msg){
            Content = new MessageViewModel(msg);
        }

        private void Open_Outbox(List<Message> outbox){
            Content = new OutboxDisplayViewModel(outbox);
        }

        private void Open_Inbox(List<Message> inbox){
            Content = new InboxDisplayViewModel(inbox);
        }

        private void Create_Message(){
            var vm = new CreateMessageViewModel(UserManager);

            vm.Ok.Subscribe(x => {
                vm.CreateMessage(UserManager);
                Open_Outbox(UserManager.CurrentUser.Outbox);
            });
            vm.Cancel.Subscribe(x => {
                Open_Inbox(UserManager.CurrentUser.Inbox);
            });
            Content = vm;
        }

        // private void Create_Message(User chosen_recipient){
        //     var vm = new CreateMessageViewModel(UserManager, chosen_recipient);

        //     vm.Ok.Subscribe(x => {
        //         vm.CreateMessage(UserManager);
        //         Open_Outbox(UserManager.CurrentUser.Outbox);
        //     });
        //     vm.Cancel.Subscribe(x => {
        //         Open_Inbox(UserManager.CurrentUser.Inbox);
        //     });
        //     Content = vm;
        // }

        private void Edit_Message(Message msg){
            var vm = new EditMessageViewModel(msg);

            vm.Ok.Subscribe(x => {
                vm.EditMessage(UserManager);
                Open_Outbox(UserManager.CurrentUser.Outbox);
            });
            vm.Cancel.Subscribe(x => {
                Open_Inbox(UserManager.CurrentUser.Inbox);
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