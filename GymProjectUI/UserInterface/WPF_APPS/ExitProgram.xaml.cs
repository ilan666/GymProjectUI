using GymProjectUI.WPF_APPS;
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

namespace GymProjectUI.UserInterface.WPF_APPS
{
    /// <summary>
    /// Interaction logic for ExitProgram.xaml
    /// </summary>
    public partial class ExitProgram : Window
    {
        public ExitProgram()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
            this.Close();
        }
    }
}
