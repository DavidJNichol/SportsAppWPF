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
    /// Interaction logic for MatchWindow.xaml
    /// </summary>
    public partial class MatchWindow : Window
    {
        MatchResultViewModel viewModel; 
        public MatchWindow(Mediator mediator, TeamAdjustViewModel ta, Repo repository)
        {
            this.Name = "MatchWindow";
            InitializeComponent();
            viewModel = new MatchResultViewModel(mediator, ta, repository);
            this.DataContext = viewModel;
        }
    }
}
