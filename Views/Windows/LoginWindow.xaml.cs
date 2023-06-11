using System;
using System.Windows;
using System.Windows.Controls;
using DoJudo.ViewModels;

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
            (DataContext as LoginViewModel).CloseWindowEvent += CloseWindowEventHandler;
        }

        private void CloseWindowEventHandler(object sender, EventArgs e)
        {
            Close();
        }
        private void CheckBoxPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            PasswordBox.Password = TextBoxPassword.Text;
        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            TextBoxPassword.Text = PasswordBox.Password;
        }
    }
}
