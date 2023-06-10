using DevExpress.Mvvm;
using DoJudo.Models.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;

namespace DoJudo.Model
{
    internal class LoginViewModel : INotifyPropertyChanged

    {
        private string _username;
        private string _password;
        private bool _isLoginEnabled;

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnProperyChanged(nameof(Username));
                UpdateLoginEnabled();
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnProperyChanged(nameof(Password));
                UpdateLoginEnabled();
            }
        }
        public bool IsLoginEnabled
        {
            get { return _isLoginEnabled; }
            set
            {
                _isLoginEnabled = value;
                OnProperyChanged(nameof(IsLoginEnabled));
            }
        }
        public LoginViewModel()
        {
        }
        public ICommand LoginCommand { get; }

        private bool CanLogin(object parameter)
        {
            return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);
        }
        private async void Login()
        {
            var user = await DoJudoRepository.GetInstance().Users.
                FirstOrDefaultAsync(x => x.Username == Username && x.Password == Password);
            if (user == null)
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }
        }
        private void UpdateLoginEnabled()
        {
            IsLoginEnabled = CanLogin(null);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnProperyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
