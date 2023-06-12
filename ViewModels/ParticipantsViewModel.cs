using DoJudo.Models.Database;
using DoJudo.Models.Interfaces;
using DoJudo.Models.Repositories;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

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
            private set
            {
                _participants = value;
                OnPropertyChanged(_nameCollectionParticipants);
            }
        }
        public ParticipantsViewModel()
        {
            _participantRepository = new ParticipantRepository();
            _ = LoadParticipantsAsync();
        }
        private async Task LoadParticipantsAsync()
        {
            var participantsList = await _participantRepository.GetAll();
            Participants = new ObservableCollection<Participant>(participantsList);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
