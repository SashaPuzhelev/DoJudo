using DoJudo.Models;
using DoJudo.Models.Database;
using DoJudo.Views.Pages;
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
    internal class CompetitionViewModel : INotifyPropertyChanged
    {
        public static CompetitionViewModel Instance { get; private set; }
        private Competition _competition;
        public Competition Competition
        { 
            get { return _competition; } 
            private set
            {
                _competition = value;
                OnPropertyChanged(nameof(Competition));
            }
        }

        public CompetitionViewModel(Competition competititon)
        {
            Instance = this;
            _competition = competititon;
            AddParticipantsCompetitionCommand = new RelayCommand(GoToAddParticipantsCompetitionPage);
            ParticipantsCompetitionCommand = new RelayCommand(GoToParticipantsCompetitionPage);
            DrawGridCommand = new RelayCommand(DrawGrid);
        }
        private void GoToAddParticipantsCompetitionPage()
        {
            AddParticipantsCompetitionPage addParticipantsCompetitionPage = new AddParticipantsCompetitionPage();
            MainWindowViewModel.Instance.CurrentPage = addParticipantsCompetitionPage;
        }
        private void GoToParticipantsCompetitionPage()
        {
            ParticipantsCompetitionPage participantsCompetitionPage = new ParticipantsCompetitionPage();
            MainWindowViewModel.Instance.CurrentPage = participantsCompetitionPage;
        }
        private  void DrawGrid()
        {
            MessageBoxResult messageBoxResult =
               MessageBox.Show("Вы точно хотите провести жеребьевку? Добавление участников будет невозможным!", "Информация",
                   MessageBoxButton.OKCancel, MessageBoxImage.Information);
            if (messageBoxResult == MessageBoxResult.OK)
            {
                CompetitionGridsGeneration competitionGrid = new CompetitionGridsGeneration();
                competitionGrid.DrawCompetitionGrids(_competition);
                MessageBox.Show("Жеребьевка успешно проведена!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        public ICommand AddParticipantsCompetitionCommand { get; private set; }
        public ICommand ParticipantsCompetitionCommand { get; private set; }
        public ICommand DrawGridCommand { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
