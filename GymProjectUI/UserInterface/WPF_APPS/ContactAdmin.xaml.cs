using GYMDatabaseProject.DataAccess;
using GYMDatabaseProject.Models;
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
    /// Interaction logic for ContactAdmin.xaml
    /// </summary>
    public partial class ContactAdmin : Window
    {
        public ContactAdmin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainUI main = new MainUI();
            main.Show();
            main.ShowDisplay();
            this.Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TextRange text = new TextRange(body.Document.ContentStart, body.Document.ContentEnd);
            if(title.Text == "")
            {
                MessageBox.Show("Title must be included!");
            }
            else if(text.Text == "")
            {
                MessageBox.Show("Message body must be included!");
            }
            else
            {
                using (var dbContext = new DatabaseGYM())
                {
                    var admin = dbContext.Admins.FirstOrDefault(p => p.User_ID == 211818414);
                    Messages message = new Messages()
                    {
                        Title = title.Text,
                        Body = text.Text,
                        _From_ID = Utilities.Utilities.User.User_ID,
                        _To_ID = 211818414
                    };

                    admin.AdminMessages.Add(message);

                    dbContext.AddRange(message);
                    dbContext.SaveChanges();
                }

                MainUI main = new MainUI();
                main.Show();
                main.ShowDisplay();
                this.Hide();
            }
        }
    }
}
