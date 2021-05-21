using SportsAppDavidNicholOOP.Models;
using SportsAppDavidNicholOOP.Models.Interfaces;
using SportsAppDavidNicholOOP.Models.Sports;
using SportsAppDavidNicholOOP.Models.Team;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SportsAppDavidNicholOOP.Views;
using System.Collections.ObjectModel;
namespace SportsAppDavidNicholOOP.ViewModels
{
    public class TeamAdjustViewModel : INotifyPropertyChanged
    {
        public IMatch match;

        public ICommand RemovePlayerTeamOne { get; set; }
        public ICommand RemovePlayerTeamTwo {get ; set;}

        public ICommand ScheduleMatch { get; set; }

        public string SelectedPlayerOne { get; set; }
        public string SelectedPlayerTwo { get; set; }

        public ICommand Save { get; set; }
        public ICommand Load { get; set; }

        private Repo repository;

        public ObservableCollection<string> PlayerListOne { get; set; }
        public ObservableCollection<string> PlayerListTwo { get; set; }

        public static ObservableCollection<Match> page;

        Mediator mediator;

        string playerRemovedMessage;

        public ObservableCollection<Match> Page
        {
            get
            {
                return page;
            }
            set
            {
                if (value != page)
                {
                    page = value;
                }
            }
        }

        public string MatchAbout
        {
            get
            {
                return match.About;
            }
            set
            {
                this.match.About = value;
                RaisePropertyChanged("MatchAbout");
            }
        }

        public string PlayerRemovedMessage
        {
            get
            {
                return playerRemovedMessage;
            }
            set
            {
                this.playerRemovedMessage = value;
                RaisePropertyChanged("PlayerRemovedMessage");
            }
        }

        public string Date
        {
            get
            {
                return match.Date;
            }
            set
            {
                this.match.Date = value;
                RaisePropertyChanged("Date");
            }
        }

        public string Time
        {
            get
            {
                return match.Time;
            }
            set
            {
                this.match.Time = value;
                RaisePropertyChanged("Time");
            }
        }

        public TeamAdjustViewModel(Mediator mediator, IMatch match, Repo repo)
        {
            this.match = match;

            PlayerListOne = new ObservableCollection<string>();
            PlayerListTwo = new ObservableCollection<string>();

            Save = new ViewModelCommand(SelectSave, CanSelectSave);
            Load = new ViewModelCommand(SelectLoad, CanSelectLoad);

            Page = new ObservableCollection<Match>();
            Page.Add((Match)match);

            foreach (IPlayer p in match.TeamOne.PlayerList)
            {
                PlayerListOne.Add(p.Name);
            }    

            foreach(IPlayer p in match.TeamTwo.PlayerList)
            {
                PlayerListTwo.Add(p.Name);
            }

            this.mediator = mediator;

            this.repository = repo;

            RemovePlayerTeamOne = new ViewModelCommand(RemovePlayerOne, CanRemovePlayer);
            RemovePlayerTeamTwo = new ViewModelCommand(RemovePlayerTwo, CanRemovePlayer);

            ScheduleMatch = new ViewModelCommand(SelectSchedule, CanSelectSchedule);
        }

        public bool CanSelectSave(object parameter)
        {
            return true;
        }

        public void SelectSave(object parameter)
        {
            Page.RemoveAt(0);
            Page.Add((Match)match);
            if (repository.Match != Page[0])
            {
                repository.Match = Page[0];
            }
            repository.Save("Match");
        }

        public bool CanSelectLoad(object parameter)
        {
            return true;
        }

        public void SelectLoad(object parameter)
        {
            Match Match = repository.LoadMatch();

            this.match = Match;

            RaisePropertyChanged("Time");
            RaisePropertyChanged("Date");
            RaisePropertyChanged("PlayerRemovedMessage");
            RaisePropertyChanged("MatchAbout");
        }

        public bool CanRemovePlayer(object parameter)
        {
            return true;
        }

        public void RemovePlayerOne(object parameter)
        {
            IPlayer playerToRemove = this.match.TeamOne.PlayerList.First(p => p.Name == SelectedPlayerOne); 
            match.TeamOne.PlayerList.Remove(playerToRemove);
            playerRemovedMessage = $"{SelectedPlayerOne} has been removed!";
            RaisePropertyChanged("PlayerRemovedMessage");
        }

        public void RemovePlayerTwo(object parameter)
        {
            IPlayer playerToRemove = this.match.TeamTwo.PlayerList.First(p => p.Name == SelectedPlayerTwo);
            match.TeamOne.PlayerList.Remove(playerToRemove);
            playerRemovedMessage = $"{SelectedPlayerTwo} has been removed!";
            RaisePropertyChanged("PlayerRemovedMessage");
        }

        public bool CanSelectSchedule(object parameter)
        {
            return true;
        }

        public void SelectSchedule(object parameter)
        {
            MatchWindow mw = new MatchWindow(this.mediator, this, this.repository);
            mediator.OpenView(mw);
            mediator.CloseCurrentView();
            mediator.currentWindow = mw;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
