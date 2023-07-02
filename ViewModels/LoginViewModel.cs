using GalaSoft.MvvmLight.Command;
using DoJudo.Models;
using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Windows;
using System.Windows.Input;
using DoJudo.Models.Database;
using DoJudo.Models.Repositories;
using DoJudo.Models.Interfaces;

namespace DoJudo.ViewModels
{
    internal class LoginViewModel : INotifyPropertyChanged
    {
        private readonly IUserRepository _userRepository;
        private string _username;
        private string _password;
        private bool _isLoginEnabled;

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
                UpdateLoginEnabled();
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
                UpdateLoginEnabled();
            }
        }
        public bool IsLoginEnabled
        {
            get { return _isLoginEnabled; }
            private set
            {
                _isLoginEnabled = value;
                OnPropertyChanged(nameof(IsLoginEnabled));
            }
        }
        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(Login, CanLogin());
            ShutdownAppCommand = new RelayCommand(ShutdownApp);
            _userRepository = new UserRepository();
        }
        public ICommand LoginCommand { get; private set; }
        public ICommand ShutdownAppCommand { get; private set; }
        private bool CanLogin()
        {
            return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);
        }
        private async void Login()
        {
            if (DbDoJudo.CheckConnection() == false)
            {
                MessageBox.Show("Нет подключения к БД! Обратитесь к админу", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            IsLoginEnabled = false;
            var user = await _userRepository.CheckLogin(Username, Password);
            if (user == null)
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                IsLoginEnabled = true;
            }
            else
            {
                MessageBox.Show("Вы успешно вошли!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                CurrentUser.SetInstance(user);
                CurrentUser.StartHistoryLogin();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                CloseWindow();
            }
        }
        private void ShutdownApp()
        {
            var messageBoxResult =
                MessageBox.Show("Вы действительно хотите выйти?", "Информация", MessageBoxButton.OKCancel, MessageBoxImage.Information);
            if (messageBoxResult == MessageBoxResult.OK)
            {
                Application.Current.Shutdown();
            }
        }
        private void UpdateLoginEnabled()
        {
            IsLoginEnabled = CanLogin();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event EventHandler CloseWindowEvent;
        private void CloseWindow()
        {
            CloseWindowEvent?.Invoke(this, EventArgs.Empty);
        }

    }
}
