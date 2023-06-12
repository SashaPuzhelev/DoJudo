using DoJudo.Models.Database;
using DoJudo.Models.Interfaces;
using DoJudo.Models.Repositories;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace DoJudo.ViewModels
{
    internal class ParticipantsViewModel : INotifyPropertyChanged
    {
        private readonly IParticipantRepository _participantRepository;
        private ObservableCollection<Participant> _participants;
        private readonly string _nameCollectionParticipants = "Participants";
        public ObservableCollection<Participant> Participants
        {
            get { return _participants; }
            set
            {
                _participants = value;
                OnPropertyChanged(_nameCollectionParticipants);
            }
        }
        public ParticipantsViewModel()
        {
            _participantRepository = new ParticipantRepository();
            Participants = new ObservableCollection<Participant>(_participantRepository.GetAll());
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
