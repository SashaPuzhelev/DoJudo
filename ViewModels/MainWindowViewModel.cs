using DoJudo.Models;
using DoJudo.UI.Windows;
using GalaSoft.MvvmLight.Command;
using System;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace DoJudo.ViewModels
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        public static MainWindowViewModel Instance { get; private set; }
        private readonly string _pathToPages = "DoJudo.Views.Pages.";
        private Page _currentPage;
        private readonly CurrentUser _currentUser;
        public Page CurrentPage
        {
            get { return _currentPage; }
            set
            {
                _currentPage = value;
                OnPropertyChanged(nameof(CurrentPage));
            }
        }
        public string FullNameWithRoleName
        {
            get { return _currentUser.FullNameWithRoleName; }
        }
        public ICommand NavigateCommand { get; private set; }
        public ICommand ExitCommand { get; private set; }
        public MainWindowViewModel()
        {
            Instance = this;
            _currentUser = CurrentUser.GetInstance();
            NavigateCommand = new RelayCommand<string>((pageName) =>
            {
                CurrentPage = (Page)Activator.CreateInstance(Type.GetType(_pathToPages + pageName));
            });
            ExitCommand = new RelayCommand(ExitCurrentUser);
        }
        private void ExitCurrentUser()
        {
            CurrentUser.SetNullInstance();
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            CloseWindow();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
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
