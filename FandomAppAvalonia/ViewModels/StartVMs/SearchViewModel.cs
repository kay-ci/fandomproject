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
        private List<Profile> _profileResults;
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
        public List<Profile> ProfileResults{
            get => _profileResults;
            private set => this.RaiseAndSetIfChanged(ref _profileResults, value);
        }

        public ReactiveCommand<Unit, Unit> EventSearch { get; }

        public ReactiveCommand<Unit, Unit> ProfileSearch { get; }

        public SearchViewModel(){
            ShowEventResults = false;
            ShowProfileResults = false;
            EventResults = new List<Event>();
            ProfileResults = new List<Profile>();
            
            ProfileSearch = ReactiveCommand.Create(() => {DisplayProfileResults();});
            EventSearch = ReactiveCommand.Create(() => {DisplayEventResults();});
        }

        private void DisplayProfileResults(){
           ShowEventResults = false;
           ShowProfileResults = true;
           ProfileResults = SearchProfiles();
        }

        private void DisplayEventResults(){
            ShowProfileResults = false;
            ShowEventResults = true;
            // EventResults = SearchEvents(_keyword);
        }

        private List<Profile> SearchProfiles(){
            List<Profile> profiles = service.GetProfiles();
            if(string.IsNullOrWhiteSpace(_keyword)) return profiles;
            List<Profile> filtered_prof = new List<Profile>();
            foreach(Profile prof in profiles){
                if(prof.Name.Contains(_keyword)) filtered_prof.Add(prof);
                else if(prof.Country.Contains(_keyword)) filtered_prof.Add(prof);
                else if(prof.City.Contains(_keyword)) filtered_prof.Add(prof);
                try {
                    if(prof.Age == Int32.Parse(_keyword)) filtered_prof.Add(prof);
                }catch{}
                foreach(Fandom fandom in prof.Fandoms){
                    if(fandom.Name.Contains(_keyword)) filtered_prof.Add(prof);
                }
                foreach(Category cat in prof.Categories){
                    if(cat.Name.Contains(_keyword)) filtered_prof.Add(prof);
                }
            }
            
            return filtered_prof;
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