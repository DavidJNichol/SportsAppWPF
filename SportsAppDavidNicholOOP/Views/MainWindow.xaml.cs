using SportsAppDavidNicholOOP.Models;
using SportsAppDavidNicholOOP.Models.Sports;
using SportsAppDavidNicholOOP.Models.Team;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SportsAppDavidNicholOOP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TeamSetupViewModel viewModel;
        Mediator mediator;

        public MainWindow()
        {
            InitializeComponent();
            mediator = new Mediator();
            mediator.currentWindow = this;
            viewModel = new TeamSetupViewModel(mediator);
            this.DataContext = viewModel;
        }
    }
}
