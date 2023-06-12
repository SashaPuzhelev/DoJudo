using DoJudo.Models;
using GalaSoft.MvvmLight.Command;
using System;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace DoJudo.ViewModels
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly string _pathToPages = "DoJudo.Views.Pages.";
        private Page _currentPage;
        public Page CurrentPage
        {
            get { return _currentPage; }
            private set
            {
                _currentPage = value;
                OnPropertyChanged(nameof(CurrentPage));
            }
        }
        public string FullNameWithRoleName
        {
            get { return CurrentUser.FullNameWithRoleName; }
        }
        public ICommand NavigateCommand { get; set; }
        public MainWindowViewModel()
        {
            NavigateCommand = new RelayCommand<string>((pageName) =>
            {
                CurrentPage = (Page)Activator.CreateInstance(Type.GetType(_pathToPages + pageName));
            });
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
