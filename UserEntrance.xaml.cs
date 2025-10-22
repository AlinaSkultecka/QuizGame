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

namespace QuizGame
{
    /// <summary>
    /// Interaction logic for UserEntrance.xaml
    /// </summary>
    public partial class UserEntrance : Window
    {
        public UserEntrance()
        {
            InitializeComponent();

                //private void Confirm_Click(object sender, RoutedEventArgs e)
                //{
                //    string userName = NameInput.Text;
                //    if (!string.IsNullOrWhiteSpace(userName))
                //        GreetingText.Text = $"Welcome, {userName}!";
                //    else
                //        GreetingText.Text = "Please enter your name first.";
                //}

                //private void NameInput_TextChanged(object sender, TextChangedEventArgs e)
                //{
                //    PlaceholderText.Visibility =
                //        string.IsNullOrEmpty(NameInput.Text) ? Visibility.Visible : Visibility.Hidden;
                //}
        }
    }
}
