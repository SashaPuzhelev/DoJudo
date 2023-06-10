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

namespace DoJudo.UI.Windows
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void CheckBoxPassword_Checked(object sender, RoutedEventArgs e)
        {
            TextBoxPassword.Text = PasswordBox.Password;
        }

        private void CheckBoxPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            PasswordBox.Password = TextBoxPassword.Text;
        }
    }
}
