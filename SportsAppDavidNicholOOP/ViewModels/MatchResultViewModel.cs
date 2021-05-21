using SportsAppDavidNicholOOP.Models;
using SportsAppDavidNicholOOP.Models.Interfaces;
using SportsAppDavidNicholOOP.Models.Sports;
using SportsAppDavidNicholOOP.Models.Team;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using SportsAppDavidNicholOOP.Views;

namespace SportsAppDavidNicholOOP.ViewModels
{
    public class MatchResultViewModel : INotifyPropertyChanged
    {
        private IMatch match;
        private MatchResult matchResult;

        TeamAdjustViewModel ts;

        string matchOutput;

        string resultString;

        private Repo repository;

        public ICommand Save { get; set; }

        public ICommand Load { get; set; }

        public ICommand StartOver { get; set; }

        private Mediator mediator;

        public string TeamStatsOne { get; set; }
        public string TeamStatsTwo { get; set; }

        public static ObservableCollection<MatchResult> page;

        public ObservableCollection<MatchResult> Page
        {
            get
            {
                return page;
            }
            set
            {
                if(value != page)
                {
                    page = value;
                }
            }
        }

        public MatchResultViewModel(Mediator mediator, TeamAdjustViewModel teamAdjust, Repo repo)
        {
            this.ts = teamAdjust;
            this.match = ts.match;
            matchResult = new MatchResult(this.match);
            matchOutput = matchResult.PrintMatchEvents();

            this.repository = repo;

            this.mediator = mediator;

            mediator = new Mediator();

            Save = new ViewModelCommand(SelectSave, CanSelectSave);
            Load = new ViewModelCommand(SelectLoad, CanSelectLoad);
            StartOver = new ViewModelCommand(SelectNewGame, CanSelectNewGame);

            Page = new ObservableCollection<MatchResult>();
            Page.Add((MatchResult)matchResult);

            TeamStatsOne = $"{match.TeamOne.Name} Stats: ";
            TeamStatsTwo = $"{match.TeamTwo.Name} Stats: ";

            for (int i = 0; i < match.TeamOne.StatList.Count; i++) // both teams have same stat list size
            {
                TeamStatsOne += match.TeamOne.StatList[i].AboutMessage();
                TeamStatsTwo += match.TeamTwo.StatList[i].AboutMessage();
            }
        }

        public string TeamOneName
        {
            get 
            {
                if (match == null)
                    return "Default";

                return match.TeamOne.Name; 
            }
            set
            {
                this.match.TeamOne.Name = value;
                RaisePropertyChanged("TeamOneName");
            }
        }

        public string TeamTwoName
        {
            get 
            {
                if (match == null)
                    return "Default";

                return match.TeamTwo.Name; 
            }
            set
            {
                this.match.TeamTwo.Name = value;
                RaisePropertyChanged("TeamTwoName");
            }
        }

        public string TeamOneScore
        {
            get { return match.TeamOne.Score.ToString(); }
            set
            {
                RaisePropertyChanged("TeamOneScore");
            }
        }

        public string TeamTwoScore
        {
            get { return match.TeamTwo.Score.ToString(); }
            set
            {
                RaisePropertyChanged("TeamTwoScore");
            }
        }

        public string MatchResults
        {
            get
            {
                return matchOutput;
            }
            set
            {
                matchOutput = value;
                RaisePropertyChanged("MatchResults");
            }
        }

        public string MatchResultAbout
        {
            get
            {
                resultString = matchResult.DeclareWinner();
                return resultString;
            }
            set
            {
                resultString = value;
                RaisePropertyChanged("MatchResultsAbout");
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

        public bool CanSelectSave(object parameter)
        {
            return true;
        }

        public void SelectSave(object parameter)
        {
            Page.RemoveAt(0);
            Page.Add((MatchResult)matchResult);
            if(repository.MatchResults != Page[0])
            {
                repository.MatchResults = Page[0];
            }
            repository.MatchOutput = this.matchOutput;
            repository.Save("MatchResult");
        }

        public bool CanSelectLoad(object parameter)
        {
            return true;
        }

        public void SelectLoad(object parameter)
        {
            MatchResult matchResults = repository.LoadMatchResults();

            this.matchResult = matchResults;

            this.match = matchResults.Match;

            for (int i = 0; i < match.TeamOne.StatList.Count; i++) // both teams have same stat list size
            {
                TeamStatsOne += match.TeamOne.StatList[i].AboutMessage();
                TeamStatsTwo += match.TeamTwo.StatList[i].AboutMessage();
            }

            RaisePropertyChanged("TeamOneName");
            RaisePropertyChanged("TeamTwoName");
            RaisePropertyChanged("TeamOneScore");
            RaisePropertyChanged("TeamTwoScore");
            RaisePropertyChanged("MatchResults");
            RaisePropertyChanged("MatchResultAbout");
            RaisePropertyChanged("MatchAbout");
        }

        public bool CanSelectNewGame(object parameter)
        {
            return true;
        }

        public void SelectNewGame(object parameter)
        {
            mediator.OpenView(new MainWindow());
            mediator.CloseCurrentView();
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

