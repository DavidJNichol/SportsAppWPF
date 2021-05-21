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
    public class TeamSetupViewModel : INotifyPropertyChanged
    {
        public ICommand ChooseFootball { get; set; }
        public ICommand ChooseBaseball { get; set; }
        public ICommand ChooseHockey { get; set; }
        public ICommand ChooseBasketball { get; set; }
        public ICommand Commence { get; set; }

        public ICommand AddPlayerTeamOne { get; set; }
        public ICommand AddPlayerTeamTwo { get; set; }

        Mediator mediator;
        ITeam teamOne;
        ITeam teamTwo;
        public IMatch match;

        private Repo repository;

        public string TeamOneName
        {
            get { return teamOne.Name; }
            set
            {
                teamOne.Name = value;
                RaisePropertyChanged("TeamOneName");
            }
        }

        public string TeamTwoName
        {
            get { return teamTwo.Name; }
            set
            {
                teamTwo.Name = value;
                RaisePropertyChanged("TeamTwoName");
            }
        }

        private string teamOnePlayerName;
        private string teamTwoPlayerName;

       public string TeamOnePlayerName
        {
            get
            {
                return teamOnePlayerName;
            }
            set
            {
                teamOnePlayerName = value;               
                RaisePropertyChanged("TeamOnePlayerName");
            }
        }

        public string TeamTwoPlayerName
        {
            get
            {
                return teamTwoPlayerName;
            }
            set
            {
                teamTwoPlayerName = value;
                RaisePropertyChanged("TeamTwoPlayerName");
            }
        }

        public TeamSetupViewModel(Mediator mediator)
        {
            this.ChooseFootball = new ViewModelCommand(SelectFootball, CanSelectFootball);
            this.ChooseBaseball = new ViewModelCommand(SelectBaseball, CanSelectBaseball);
            this.ChooseHockey = new ViewModelCommand(SelectHockey, CanSelectHockey);
            this.ChooseBasketball = new ViewModelCommand(SelectBasketball, CanSelectBasketball);
            this.Commence = new ViewModelCommand(SelectCommence, CanSelectCommence);
            this.AddPlayerTeamOne = new ViewModelCommand(SelectAddPlayerTeamOne, CanSelectAddPlayer);
            this.AddPlayerTeamTwo = new ViewModelCommand(SelectAddPlayerTeamTwo, CanSelectAddPlayer);

            this.teamOne = new Team("Default Team One Name"); 
            this.teamTwo = new Team("Default Team Two Name"); // dont forget to init stats

            this.mediator = mediator;

            repository = new Repo(match);

            match = new Match(teamOne, teamTwo, DateTime.Today.ToString(), "", teamOne.SportPlayed);
        }

        private bool CanSelectFootball(object parameter)
        {
            return true;
        }

        public void SelectFootball(object parameter)
        {
            teamOne.SportPlayed = new Football();
            teamTwo.SportPlayed = new Football();
        }

        private bool CanSelectBaseball(object parameter)
        {
            return true;
        }

        public void SelectBaseball(object parameter)
        {
            teamOne.SportPlayed = new Baseball();
            teamTwo.SportPlayed = new Baseball();
        }

        private bool CanSelectHockey(object parameter)
        {
            return true;
        }

        public void SelectHockey(object parameter)
        {
            teamOne.SportPlayed = new Hockey();
            teamTwo.SportPlayed = new Hockey();
        }

        private bool CanSelectBasketball(object parameter)
        {
            return true;
        }

        public void SelectBasketball(object parameter)
        {
            teamOne.SportPlayed = new Basketball();
            teamTwo.SportPlayed = new Basketball();

        }

        public bool CanSelectCommence(object parameter)
        {
            return true; // if user has selected a sport, commence can activate
        }

        public void SelectCommence(object parameter)
        {
            teamOne.InitializeStats();
            teamTwo.InitializeStats();
            string time = DateTime.Now.ToString("h:mm:ss tt");
            string date = DateTime.Now.ToString("M/dd/y");
            match = new Match(teamOne, teamTwo, date, time, teamOne.SportPlayed);
            TeamsWindow tw = new TeamsWindow(this.mediator, this, repository);
            mediator.OpenView(tw);
            mediator.CloseCurrentView();
            mediator.currentWindow = tw;
        }

        public bool CanSelectAddPlayer(object parameter)
        {
            return true;
        }

        public void SelectAddPlayerTeamOne(object parameter)
        {
            IPlayer newPlayer = new Player(this.teamOnePlayerName);

            this.teamOne.AddPlayer(newPlayer);
        }

        public void SelectAddPlayerTeamTwo(object parameter)
        {
            IPlayer newPlayer = new Player(this.teamTwoPlayerName);

            this.teamTwo.AddPlayer(newPlayer);
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

    public class ViewModelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public delegate void ICommandOnExecute(object parameter);

        public delegate bool ICommandOnCanExecute(object parameter);

        private ICommandOnExecute _execute;
        private ICommandOnCanExecute _canExecute;

        public ViewModelCommand(ICommandOnExecute onExecuteMethod, ICommandOnCanExecute onCanExecuteMethod)
        {
            _execute = onExecuteMethod;
            _canExecute = onCanExecuteMethod;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute.Invoke(parameter);
        }

        public void Execute(object parameter)
        {
            _execute.Invoke(parameter);
        }
    }
}
