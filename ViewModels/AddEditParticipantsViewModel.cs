using DoJudo.Models.Database;
using DoJudo.Models.Interfaces;
using DoJudo.Models.Repositories;
using DoJudo.Views.Pages;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace DoJudo.ViewModels
{
    internal class AddEditParticipantsViewModel : INotifyPropertyChanged
    {
        private IParticipantRepository _participantRepository;
        private IAddressRepository _addressRepository;
        private Participant _participant;
        private ObservableCollection<City> _cities;
        private ObservableCollection<Club> _clubs;
        private bool _isMan;
        private bool _isWoman;
        private Address _address;

        public Participant Participant
        {
            get { return _participant; }
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
        public bool IsMan
        {
            get { return _isMan; }
            set
            {
                _isMan = value;
                SetGender();
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
                SetGender();
                OnPropertyChanged(nameof(_isWoman));
                if (_isMan)
                    _isMan = false;
            }
        }
        public Address Address
        {
            get { return _address; }
            set
            {
                _address = value;
                SetGender();
                OnPropertyChanged(nameof(_address));
            }
        }

        public ICommand CancelCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public AddEditParticipantsViewModel(Participant participant)
        {
            _participant = participant;
            _cities = new ObservableCollection<City>(DbDoJudo.GetInstance().Cities.ToList());
            _clubs = new ObservableCollection<Club>(DbDoJudo.GetInstance().Clubs.ToList());
            _participantRepository = new ParticipantRepository();
            _addressRepository = new AddressRepository();

            if (_participant.Id != 0)
            {
                _address = _participant.Address;
            }
            if (_participant.Id == 0)
            {
                _participant = new Participant();
                _address = new Address();
            }

            if (_participant.Gender == "М")
                _isMan = true;
            if (_participant.Gender == "Ж")
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
            if (_participant.Id != 0)
            {
                if (_participantRepository.Update(_participant))
                {
                    _addressRepository.Update(_address);
                    MessageBox.Show("Редактирование прошло успешно!","Информация",
                        MessageBoxButton.OKCancel, MessageBoxImage.Information);
                }
                MessageBox.Show("Не удалось сохранить изменения!","Ошибка",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (_participant.Id == 0)
            {
                _participant.IdAddress = _addressRepository.AddWithReturnIdAddress(_address);
                if (_participantRepository.Add(_participant))
                {
                    MessageBox.Show("Добавление прошло успешно!", "Информация",
                        MessageBoxButton.OKCancel, MessageBoxImage.Information);
                    return;
                }
                MessageBox.Show("Не удалось добавить участника!", "Ошибка",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void SetGender()
        {
            if(_isMan)
                _participant.Gender = "М";
            if (_isWoman)
                _participant.Gender = "Ж";
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
