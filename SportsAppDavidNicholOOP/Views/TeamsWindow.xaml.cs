using SportsAppDavidNicholOOP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SportsAppDavidNicholOOP.Views
{
    /// <summary>
    /// Interaction logic for TeamsWindow.xaml
    /// </summary>
    public partial class TeamsWindow : Window
    {
        TeamAdjustViewModel teamAdjust;
        public TeamsWindow(Mediator mediator, TeamSetupViewModel ts, Repo repository)
        {
            this.Name = "TeamAdjustWindow";
            InitializeComponent();
            teamAdjust = new TeamAdjustViewModel(mediator, ts.match, repository);

            this.DataContext = teamAdjust;
        }
    }
}
