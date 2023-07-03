using DoJudo.Models;
using DoJudo.Models.Database;
using DoJudo.Models.Interfaces;
using DoJudo.Models.Repositories;
using DoJudo.Views.Pages;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DoJudo.ViewModels
{
    internal class CompetitionsViewModel : INotifyPropertyChanged
    {
        private ICompetitionRepository _competitionRepository;
        private ObservableCollection<Competition> _competitions;
        private Competition _selectedCompetition;
        public ObservableCollection<Competition> Competitions
        { 
            get { return _competitions; }
            set
            {
                _competitions = value;
                OnPropertyChanged(nameof(Competitions));
            }
        }
        public Competition SelectedCompetition
        {
            get => _selectedCompetition;
            set
            {
                _selectedCompetition = value;
                OnPropertyChanged(nameof(SelectedCompetition));
            }
        }
        public CompetitionsViewModel()
        {
            _competitionRepository = new CompetitionRepository();
            _competitions = new ObservableCollection<Competition>(
                    _competitionRepository.GetAllNoAsync());
            ChooseCommand = new RelayCommand(GoToCompetition);
            AddCommand = new RelayCommand(GoToAddCompetition);
        }
        public ICommand AddCommand { get; private set; }
        public ICommand ChooseCommand { get; private set; }
        private void GoToCompetition()
        {
            if (_selectedCompetition.Id != 0)
            {
                CompetitionPage competitionPage = new CompetitionPage(_selectedCompetition);
                MainWindowViewModel.Instance.CurrentPage = competitionPage;
                return;
            }
            MessageBox.Show("Вы не выбрали соревнование!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void GoToAddCompetition()
        {
            if (CurrentUser.GetInstance().IsAdmin)
            {
                AddCompetitionPageViewModel addCompetitionPage = new AddCompetitionPageViewModel();
                MainWindowViewModel.Instance.CurrentPage = addCompetitionPage;
                return;
            }
            MessageBox.Show("У вас недостаточно прав!", "Ошибка",
                      MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
