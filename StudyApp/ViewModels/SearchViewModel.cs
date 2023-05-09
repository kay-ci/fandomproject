using System;
using System.Collections.Generic;
using ReactiveUI;
using System.Collections.ObjectModel;
using StudyApp;
using System.Reactive;
using UserInfo;

namespace StudyApp.ViewModels
{
    public class SearchViewModel : ViewModelBase
    {
        private Boolean _showEventResults;
        private Boolean _showProfileResults;
        private List<Event> _eventResults;
        private List<Profile> _profileResults;
        private string _keyword;

        public string Keyword
        {
            get => _keyword;
            private set => this.RaiseAndSetIfChanged(ref _keyword, value);
        }

        public Boolean ShowEventResults
        {
            get => _showEventResults;
            private set => this.RaiseAndSetIfChanged(ref _showEventResults, value);
        }

        public Boolean ShowProfileResults
        {
            get => _showProfileResults;
            private set => this.RaiseAndSetIfChanged(ref _showProfileResults, value);
        }

        public List<Event> EventResults         
        {
            get => _eventResults;
            private set => this.RaiseAndSetIfChanged(ref _eventResults, value);
        }
        public List<Profile> ProfileResults         {
            get => _profileResults;
            private set => this.RaiseAndSetIfChanged(ref _profileResults, value);
        }

        public ReactiveCommand<Unit, Unit> EventSearch { get; }

        public ReactiveCommand<Unit, Unit> ProfileSearch { get; }

        public SearchViewModel()
        {
            ShowEventResults = false;
            ShowProfileResults = false;
            EventResults = new List<Event>();
            ProfileResults = new List<Profile>();
            
            ProfileSearch = ReactiveCommand.Create(() => {DisplayProfileResults();});
            EventSearch = ReactiveCommand.Create(() => {DisplayEventResults();});
        }

        private void DisplayProfileResults()
        {
           ShowEventResults = false;
           ShowProfileResults = true;
        //    ProfileResults = ProfileSearcher.SearchProfiles("");
        }

        private void DisplayEventResults()
        {
            ShowProfileResults = false;
            ShowEventResults = true;
            // EventResults = EventSearcher.SearchEvents("");
        }
    }
}