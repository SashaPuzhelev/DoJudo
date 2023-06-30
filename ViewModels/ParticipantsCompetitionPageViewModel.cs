using DoJudo.Models.Database;
using DoJudo.Models.Interfaces;
using DoJudo.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoJudo.ViewModels
{
    internal class ParticipantsCompetitionPageViewModel : INotifyPropertyChanged
    {
        private readonly IParticipantCompetitionRepository _participantCompetitionRepository;
        private ObservableCollection<ParticipantCompetition> _participantsCompetition;
        public ObservableCollection<ParticipantCompetition> ParticipantsCompetition
        {
            get { return _participantsCompetition; }
            set
            {
                _participantsCompetition = value;
                OnPropertyChanged(nameof(ParticipantsCompetition));
            }
        }
        public ParticipantsCompetitionPageViewModel()
        {
            _participantCompetitionRepository = new ParticipantCompetitionRepository();
            _ = LoadParticipantCompetitionsAsync();
        }
        private async Task LoadParticipantCompetitionsAsync()
        {
            var participantsCompetitionList = await _participantCompetitionRepository.GetAll();
            ParticipantsCompetition = new ObservableCollection<ParticipantCompetition>(participantsCompetitionList);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
