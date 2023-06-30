using DoJudo.Models.Database;
using DoJudo.Models.Interfaces;
using DoJudo.Models.Repositories;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DoJudo.ViewModels
{
    internal class AddParticipantCompetitionWindowViewModel : INotifyPropertyChanged
    {
        private IParticipantCompetitionRepository _participantCompetitionRepository;
        private Participant _participant;
        private ParticipantCompetition _participantCompetition;
        public Participant Participant
        {
            get { return _participant; }
            set
            {
                if (_participant != value)
                {
                    _participant = value;
                    OnPropertyChanged(nameof(Participant));
                }
            }
        }
        public ParticipantCompetition ParticipantCompetition
        {
            get { return _participantCompetition; }
            set
            {
                _participantCompetition = value;
                OnPropertyChanged(nameof(ParticipantCompetition));
            }
        }
        public AddParticipantCompetitionWindowViewModel(Participant participant)
        {
            _participant = participant;
            _participantCompetitionRepository = new ParticipantCompetitionRepository();
            _participantCompetition = new ParticipantCompetition();
            CancelCommand = new RelayCommand(CloseWindow);
            SaveCommand = new RelayCommand(SaveParticipantCompetition);
        }
        public ICommand SaveCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }
        private void SaveParticipantCompetition()
        {
            _participantCompetition.IdParticipant = _participant.Id;
        }
        private void CloseWindow()
        {
            CloseWindowEvent?.Invoke(this, EventArgs.Empty);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public event EventHandler CloseWindowEvent;
    }
}
