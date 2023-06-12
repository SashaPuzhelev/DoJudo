using DoJudo.Models.Database;
using DoJudo.Models.Interfaces;
using DoJudo.Models.Repositories;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DoJudo.ViewModels
{
    internal class ParticipantsViewModel : INotifyPropertyChanged
    {
        private readonly IParticipantRepository _participantRepository;
        private ObservableCollection<Participant> _participants;
        private ObservableCollection<Participant> _selectedParticipant;
        public ObservableCollection<Participant> Participants
        {
            get { return _participants; }
            private set
            {
                _participants = value;
                OnPropertyChanged(nameof(Participants));
            }
        }
        public ObservableCollection<Participant> SelectedParticipants
        { 
            get { return _selectedParticipant; }
            set
            {
                if (_selectedParticipant != value)
                {
                    _selectedParticipant = value;
                    OnPropertyChanged(nameof(SelectedParticipants));
                }
            }
        }
        public ParticipantsViewModel()
        {
            _participantRepository = new ParticipantRepository();
            _ = LoadParticipantsAsync();
            SelectedParticipants = new ObservableCollection<Participant>();
            DeleteCommand = new RelayCommand(DeleteParticipants, CanDeleteParticipants);
        }
        private async Task LoadParticipantsAsync()
        {
            var participantsList = await _participantRepository.GetAll();
            Participants = new ObservableCollection<Participant>(participantsList);
        }
        private void DeleteParticipants()
        {
            if (_participantRepository.DeleteItems(_selectedParticipant))
            {
                MessageBox.Show("Удаление прошло успешно!","Информация",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                _ = LoadParticipantsAsync();
                SelectedParticipants.Clear();
                return;
            }
            MessageBox.Show("Удаление провалено!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private bool CanDeleteParticipants()
        {
            return SelectedParticipants != null && SelectedParticipants.Any();
        }
        public ICommand AddCommand { get; private set; }
        public ICommand UpdateCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
