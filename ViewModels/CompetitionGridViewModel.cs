using DoJudo.Models.Database;
using DoJudo.Models.Interfaces;
using DoJudo.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace DoJudo.ViewModels
{
    internal class CompetitionGridViewModel : INotifyPropertyChanged
    {
        private readonly IParticipantCompetitionRepository _participantCompetitionRepository;
        private ObservableCollection<ParticipantCompetition> _participantCompetitions;
        private Models.Database.Group _group;
        public Models.Database.Group Group
        {
            get { return _group; }
            set
            {
                _group = value;
                OnPropertyChanged(nameof(Group));
            }
        }
        public ObservableCollection<ParticipantCompetition> ParticipantCompetitions
        {
            get { return _participantCompetitions; }
            set
            {
                _participantCompetitions = value;
                OnPropertyChanged(nameof(ParticipantCompetitions));
            }
        }

        public CompetitionGridViewModel(Models.Database.Group group)
        {
            _group = group;
            _participantCompetitionRepository = new ParticipantCompetitionRepository();
            LoadParticipantCompetitions();
        }
        private async void LoadParticipantCompetitions()
        {
            var list = await _participantCompetitionRepository.GetByGroup(_group);
            _participantCompetitions = new ObservableCollection<ParticipantCompetition>(list);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
