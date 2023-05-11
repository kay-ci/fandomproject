using System;
using System.Reactive.Linq;
using ReactiveUI;
using FandomAppSpace;
using System.Reactive;
using UserInfo;
namespace FandomAppSpace.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _content;
        private Boolean _visibleNavigation;
        Login? UserManager;

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
        public ReactiveCommand<Unit, Unit> NewEvent { get; }
        public ReactiveCommand<Unit, Unit> Search { get; }
        public ReactiveCommand<Unit, Unit> CreateMessage { get; }
        public ReactiveCommand<Unit, Unit> OpenInbox { get; }
        public ReactiveCommand<Unit, Unit> OpenOutbox { get; }
        public ReactiveCommand<Unit, Unit> Logout { get; }







        public MainWindowViewModel()
        {
            Profile = ReactiveCommand.Create(() => {DisplayProfile(UserManager.CurrentUser);});
            NewEvent =  ReactiveCommand.Create(() => {CreateEvent();});
            Search  = ReactiveCommand.Create(() => {OpenSearch();});
            CreateMessage = ReactiveCommand.Create(() => {Create_Message();});
            OpenInbox = ReactiveCommand.Create(() => {Open_Inbox(UserManager.CurrentUser.Inbox);});
            OpenOutbox = ReactiveCommand.Create(() => {Open_Outbox(UserManager.CurrentUser.Outbox);});
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
                vm.UpdateUser(UserManager);});
            Content = vm;
        }

        //Create and display a new event
        private void CreateEvent()
        {
        //    DisplayEvent(new Event());
        }

        //Display an existing event
        private void DisplayEvent(Event e){
            Content = new EventDisplayViewModel(e) ;
        }

        //Navigate to edit event view from event display view
        public void EditEvent()
        {
            EventDisplayViewModel dispvm = (EventDisplayViewModel) Content;
            var vm = new EventEditViewModel(dispvm.Event);
            
            vm.Ok.Subscribe(x => {Content = dispvm;});
            Content = vm;
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
            var vm = new CreateMessageViewModel();

            vm.Ok.Subscribe(x => {
                vm.CreateMessage(UserManager);
                Open_Outbox(UserManager.CurrentUser.Outbox);
            });
            vm.Cancel.Subscribe(x => {
                Open_Inbox(UserManager.CurrentUser.Inbox);
            });
            Content = vm;
        }

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

        //Navigate to search view
        private void OpenSearch()
        {
            Content = new SearchViewModel();
        }




    }
}