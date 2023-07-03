using DoJudo.Models.Database;
using DoJudo.Models.Interfaces;
using DoJudo.Models.Repositories;
using GalaSoft.MvvmLight.Command;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace DoJudo.ViewModels
{
    internal class AddParticipantCompetitionViewModel : INotifyPropertyChanged
    {
        private readonly IParticipantCompetitionRepository _participantCompetitionRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly IAgeCategoryRepository _ageCategoryRepository;
        private readonly IWeightCategoryRepository _weightCategoryRepository;
        private Participant _participant;
        private Group _group;
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
        public AddParticipantCompetitionViewModel(Participant participant)
        {
            _participant = participant;
            _participantCompetitionRepository = new ParticipantCompetitionRepository();
            _groupRepository = new GroupRepository();
            _ageCategoryRepository = new AgeCategoryRepository();
            _weightCategoryRepository = new WeightCategoryRepository();
            _group = new Group();
            _participantCompetition = new ParticipantCompetition();
            CancelCommand = new RelayCommand(CloseWindow);
            SaveCommand = new RelayCommand(SaveParticipantCompetition);
        }
        public ICommand SaveCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }
        private void SaveParticipantCompetition()
        {
            if (_participantCompetition.Weight != 0)
            {
                FillingInGroup();

                _groupRepository.Add(_group);
                _participantCompetition.Group = _groupRepository.SearchGroup(_group);

                _participantCompetition.IdParticipant = _participant.Id;

                if(_participantCompetitionRepository.Add(_participantCompetition))
                {
                    MessageBox.Show("Участник успешно добавлен!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    CloseWindow();
                    return;
                }
                MessageBox.Show("При добавлении произошла ошибка!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBox.Show("Неверно введен вес!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void FillingInGroup()
        {
            _group.Competition = CompetitionViewModel.Instance.Competition;
            _group.AgeCategory = _ageCategoryRepository.GetAgeCategory(_participant);
            _group.WeightCategory = _weightCategoryRepository.GetWeightCategory(_participantCompetition.Weight);
            _group.GenderCategory = _participant.Gender;
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
