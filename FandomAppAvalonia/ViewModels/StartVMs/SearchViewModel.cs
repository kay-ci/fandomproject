using System;
using System.Collections.Generic;
using ReactiveUI;
using System.Collections.ObjectModel;
using FandomAppSpace;
using System.Reactive;
using UserInfo;

namespace FandomAppSpace.ViewModels{
    public class SearchViewModel : ViewModelBase{
        private Boolean _showEventResults;
        private Boolean _showProfileResults;
        private List<Event> _eventResults;
        private List<User> _userResults;
        private string _keyword;

        FanAppContext Context = new FanAppContext();
        UserService service = UserService.getInstance();
        // EventService evService = EventService.();

        public string Keyword{
            get => _keyword;
            private set => this.RaiseAndSetIfChanged(ref _keyword, value);
        }

        public Boolean ShowEventResults{
            get => _showEventResults;
            private set => this.RaiseAndSetIfChanged(ref _showEventResults, value);
        }

        public Boolean ShowProfileResults{
            get => _showProfileResults;
            private set => this.RaiseAndSetIfChanged(ref _showProfileResults, value);
        }

        public List<Event> EventResults{
            get => _eventResults;
            private set => this.RaiseAndSetIfChanged(ref _eventResults, value);
        }
        public List<User> UserResults{
            get => _userResults;
            private set => this.RaiseAndSetIfChanged(ref _userResults, value);
        }

        public ReactiveCommand<Unit, Unit> EventSearch { get; }

        public ReactiveCommand<Unit, Unit> ProfileSearch { get; }

        public SearchViewModel(){
            ShowEventResults = false;
            ShowProfileResults = false;
            EventResults = new List<Event>();
            UserResults = new List<User>();
            
            ProfileSearch = ReactiveCommand.Create(() => {DisplayProfileResults();});
            EventSearch = ReactiveCommand.Create(() => {DisplayEventResults();});
        }

        private void DisplayProfileResults(){
           ShowEventResults = false;
           ShowProfileResults = true;
           UserResults = SearchUsers(_keyword);
        }

        private void DisplayEventResults(){
            ShowProfileResults = false;
            ShowEventResults = true;
            // EventResults = SearchEvents(_keyword);
        }

        private List<User> SearchUsers(string keyword){
            List<User> users = service.GetUsers();
            if(string.IsNullOrWhiteSpace(_keyword)) return users;
            List<User> filteredUsers = new List<User>();
            foreach(User user in users){
                if(user.UserProfile.Name.Contains(_keyword)) filteredUsers.Add(user);
                else if(user.UserProfile.Country.Contains(_keyword)) filteredUsers.Add(user);
                else if(user.UserProfile.City.Contains(_keyword)) filteredUsers.Add(user);
            }
            
            return filteredUsers;
        }

        // private List<Event> SearchEvents(string keyword){
        //     List<Event> profiles = service.GetProfiles();
        //     if(string.IsNullOrWhiteSpace(_keyword)) return profiles;
        //     List<Event> filtered_prof = new List<Event>();
        //     foreach(Event prof in profiles){
        //         if(prof.Name.Contains(_keyword)) filtered_prof.Add(prof);
        //         else if(prof.Country.Contains(_keyword)) filtered_prof.Add(prof);
        //         else if(prof.City.Contains(_keyword)) filtered_prof.Add(prof);
        //     }
        //     return filtered_prof;
        // }
    }
}