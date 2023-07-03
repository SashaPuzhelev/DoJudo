using DoJudo.Models.Database;
using DoJudo.Models.Interfaces;
using DoJudo.Models.Repositories;
using DoJudo.Views.Pages;
using DoJudo.Views.Windows;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DoJudo.ViewModels
{
    internal class AddParticipantsCompetitionViewModel : INotifyPropertyChanged
    {
        private readonly IParticipantRepository _participantRepository;
        private ObservableCollection<Participant> _participants;
        private Participant _selectedParticipant;
        public ObservableCollection<Participant> Participants
        {
            get { return _participants; }
            private set
            {
                _participants = value;
                OnPropertyChanged(nameof(Participants));
            }
        }
        public Participant SelectedParticipant
        {
            get { return _selectedParticipant; }
            set
            {
                if (_selectedParticipant != value)
                {
                    _selectedParticipant = value;
                    OnPropertyChanged(nameof(SelectedParticipant));
                }
            }
        }
        public AddParticipantsCompetitionViewModel()
        {
            _participantRepository = new ParticipantRepository();
            _ = LoadParticipantsAsync();
            SelectedParticipant = new Participant();
            AddParticipantCommand = new RelayCommand(GoToAddParticipant);
            AddParticipantCompetitionCommand = new RelayCommand(GoToAddParticipantCompetition);
            BackCommand = new RelayCommand(GoToBack);
        }
        private async Task LoadParticipantsAsync()
        {
            var participantsList = await _participantRepository.GetAll();
            Participants = new ObservableCollection<Participant>(participantsList);
        }
        public ICommand AddParticipantCommand { get; private set; }
        public ICommand AddParticipantCompetitionCommand { get; private set; }
        public ICommand BackCommand { get; private set; }
        private  void GoToAddParticipantCompetition()
        {
            if (_selectedParticipant.Id != 0)
            {
                if (_participantRepository.IsParticipantCompetition(_selectedParticipant, CompetitionViewModel.Instance.Competition))
                {
                    AddPartitcipantCompetitionWindow addPartitcipantCompetitionWindow = new AddPartitcipantCompetitionWindow(_selectedParticipant);
                    addPartitcipantCompetitionWindow.Show();
                    return;
                }
                MessageBox.Show("Этот спортсмен уже участвует в этих соревнованиях!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;            }
            MessageBox.Show("Вы не выбрали!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void GoToAddParticipant()
        {
            Participant participant = new Participant();
            AddEditParticipantsPage addEditParticipantsPage = new AddEditParticipantsPage(participant);
            MainWindowViewModel.Instance.CurrentPage = addEditParticipantsPage;

        }
        private void GoToBack()
        {
            MainWindowViewModel.Instance.CurrentPage.NavigationService.GoBack();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
