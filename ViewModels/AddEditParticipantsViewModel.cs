using DoJudo.Models.Database;
using DoJudo.Models.Interfaces;
using DoJudo.Models.Repositories;
using DoJudo.Views.Pages;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DoJudo.ViewModels
{
    internal class AddEditParticipantsViewModel : INotifyPropertyChanged
    {
        private IParticipantRepository _participantRepository;
        private Participant _participant;
        private ObservableCollection<City> _cities;
        private ObservableCollection<Club> _clubs;
        private City _selectedCity;
        private Club _selectedClub;
        private bool _isMan;
        private bool _isWoman;

        public Participant Participant
        {
            get { return _participant;}
            set
            {
                _participant = value;
                OnPropertyChanged(nameof(_participant));
            }
        }
        public ObservableCollection<City> Cities
        {
            get { return _cities; }
            set
            {
                _cities = value;
                OnPropertyChanged(nameof(_participant));
            }
        }
        public ObservableCollection<Club> Clubs
        {
            get { return _clubs; }
            set
            {
                _clubs = value;
                OnPropertyChanged(nameof(_participant));
            }
        }
        public City SelectedCity
        {
            get { return _selectedCity; }
            set
            {
                _selectedCity = value;
                OnPropertyChanged(nameof(_selectedCity));
            }
        }
        public Club SelectedClub
        { 
            get { return _selectedClub; }
            set
            {
                _selectedClub = value;
                OnPropertyChanged(nameof(_selectedClub));
            }
        }
        public bool IsMan
        {
            get { return _isMan; }
            set
            {
                _isMan = value;
                OnPropertyChanged(nameof(_isMan));
                if (_isWoman)
                    _isWoman = false;
            }
        }
        public bool IsWoman
        {
            get { return _isWoman; }
            set
            {
                _isWoman = value;
                OnPropertyChanged(nameof(_isWoman));
                if (_isMan)
                    _isMan = false;
            }
        }
        public ICommand CancelCommand;
        public ICommand SaveCommand;
        public AddEditParticipantsViewModel(Participant participant)
        {
            _participant = participant;
            _cities = new ObservableCollection<City>(DbDoJudo.GetInstance().Cities.ToList());
            _clubs = new ObservableCollection<Club>(DbDoJudo.GetInstance().Clubs.ToList());

            if (participant.Id != 0) 
            {
                _selectedClub = participant.Club;
                _selectedCity = participant.Address.City;
            }

            if (participant.Gender == "М")
                _isMan = true;
            if (participant.Gender == "Ж")
                _isWoman = true;

            CancelCommand = new RelayCommand(GoToParticipants);
            SaveCommand = new RelayCommand(SaveParticipant);
        }
        private void GoToParticipants()
        {
            ParticipantsPage participantsPage = new ParticipantsPage();
            MainWindowViewModel.Instance.CurrentPage = participantsPage;
        }
        private void SaveParticipant()
        {
            _participantRepository = new ParticipantRepository();
            if (_participant.Id == 0)
            {
                _participantRepository.Add(_participant);
            }
            if (_participant.Id != 0)
            {
                _participantRepository.Update(_participant);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
