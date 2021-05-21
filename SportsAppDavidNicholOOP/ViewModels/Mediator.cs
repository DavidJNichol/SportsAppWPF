using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SportsAppDavidNicholOOP.ViewModels
{
    public class Mediator
    {
        public Window currentWindow;
        public Mediator()
        {

        }

        public void CloseCurrentView()
        {
            this.currentWindow.Close();
        }

        public void CloseView(Window window)
        {
            window.Close();
        }

        public void OpenView(Window window)
        {
            window.Show();
        }
    }
}
