using DoJudo.Models.Database;
using DoJudo.Models.Repositories;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace DoJudo.ViewModels
{
    internal class ParticipantsViewModel : INotifyPropertyChanged
    {
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
            var participantsList = DoJudoRepository.GetInstance().Participants.ToList();
            Participants = new ObservableCollection<Participant>(participantsList);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
