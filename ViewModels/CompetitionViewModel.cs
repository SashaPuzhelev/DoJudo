using DoJudo.Models;
using DoJudo.Models.Database;
using DoJudo.Models.Interfaces;
using DoJudo.Models.Repositories;
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
        private readonly ICompetitionRepository _competitionRepository;
        private Competition _competition;
        private CompetitionGridsGenerator _competitionGridsGenerator;
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
            _competitionGridsGenerator = new CompetitionGridsGenerator();
            _competitionRepository = new CompetitionRepository();

            AddParticipantsCompetitionCommand = new RelayCommand(GoToAddParticipantsCompetitionPage);
            ParticipantsCompetitionCommand = new RelayCommand(GoToParticipantsCompetitionPage);
            DrawGridsCommand = new RelayCommand(DrawGrids);
            CompetitionGridsCommand = new RelayCommand(GoToChooseGroup);
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
        private  void DrawGrids()
        {
            MessageBoxResult messageBoxResult =
               MessageBox.Show("Вы точно хотите провести жеребьевку? Добавление участников будет невозможным!", "Информация",
                   MessageBoxButton.OKCancel, MessageBoxImage.Information);
            if (messageBoxResult == MessageBoxResult.OK)
            {
                _competitionGridsGenerator.DrawCompetitionGrids(_competition);
                _competition.IsNoStarted = false;
                _competitionRepository.Update(_competition);
                MessageBox.Show("Жеребьевка успешно проведена!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void GoToChooseGroup()
        {
            if (_competition.IsNoStarted)
            {
                MessageBox.Show("Вы еще не провели жеребьевку!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            ChooseGroupPage page = new ChooseGroupPage();
            MainWindowViewModel.Instance.CurrentPage = page;
        }
        public ICommand AddParticipantsCompetitionCommand { get; private set; }
        public ICommand ParticipantsCompetitionCommand { get; private set; }
        public ICommand DrawGridsCommand { get; private set; }
        public ICommand CompetitionGridsCommand { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
