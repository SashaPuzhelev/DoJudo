using DoJudo.Models.Database;
using DoJudo.Models.Interfaces;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DoJudo.ViewModels
{
    internal class AddCompetitionPageViewModel : INotifyPropertyChanged
    {
        private readonly ICompetitionRepository _competitionRepository;
        private Competition _competition;
        public Competition Competition
        { 
            get { return _competition; } 
            set
            {
                _competition = value;
                OnPropertyChanged(nameof(Competition));
            }
        }
        public AddCompetitionPageViewModel()
        {
            Competition = new Competition();
            CancelCommand = new RelayCommand(GoToBack);
            SaveCommand = new RelayCommand(AddCompetition);
        }

        public ICommand SaveCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }
        private void AddCompetition()
        {
            if (_competitionRepository.Add(_competition))
            {
                MessageBox.Show("Соревнование успешно добавлено!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                GoToBack();
                return;
            }
            MessageBox.Show("Не получилось добавить соревнование!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void GoToBack()
        {
            MainWindowViewModel.Instance.CurrentPage.NavigationService.GoBack();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
