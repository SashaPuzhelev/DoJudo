﻿using DoJudo.Models.Repositories;
using GalaSoft.MvvmLight.Command;
using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Windows;
using System.Windows.Input;

namespace DoJudo.ViewModels
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
            LoginCommand = new RelayCommand(Login, CanLogin());
            ShutdownAppCommand = new RelayCommand(ShutdownApp);
        }
        public ICommand LoginCommand { get; private set; }
        public ICommand ShutdownAppCommand { get; private set; }
        private bool CanLogin()
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
                CloseWindow();
            }
        }
        private void ShutdownApp()
        {
            Application.Current.Shutdown();
        }
        private void UpdateLoginEnabled()
        {
            IsLoginEnabled = CanLogin();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnProperyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event EventHandler CloseWindowEvent;
        public void CloseWindow()
        {
            CloseWindowEvent?.Invoke(this, EventArgs.Empty);
        }

    }
}
