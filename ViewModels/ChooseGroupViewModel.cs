using DoJudo.Models.Interfaces;
using DoJudo.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using DoJudo.Models.Database;
using System.Windows.Input;
using DoJudo.Views.Pages;
using GalaSoft.MvvmLight.Command;

namespace DoJudo.ViewModels
{
    internal class ChooseGroupViewModel : INotifyPropertyChanged
    {
        private readonly IGroupRepository _groupRepository;
        private ObservableCollection<Models.Database.Group> _groups;
        private Models.Database.Group _selectedGroup;
        public ObservableCollection<Models.Database.Group> Groups
        {
            get { return _groups; }
            set
            {
                _groups = value;
                OnPropertyChanged(nameof(Groups));
            }
        }
        public Models.Database.Group SelectedGroup
        {
            get { return _selectedGroup; }
            set
            {
                _selectedGroup = value;
                OnPropertyChanged(nameof(SelectedGroup));
            }
        }
        public ChooseGroupViewModel()
        {
            _groupRepository = new GroupRepository();
            SelectedGroup = new Models.Database.Group();
            _ = LoadGroupsAsync();
            ChooseCommand = new RelayCommand(GoToCompetitionGrid);
        }
        private async Task LoadGroupsAsync()
        {
            var groupList = await _groupRepository.GetAllByCompetition(CompetitionViewModel.Instance.Competition);
            Groups = new ObservableCollection<Models.Database.Group>(groupList);
        }
        public ICommand ChooseCommand { get; private set; }
        private void  GoToCompetitionGrid()
        {
            CompetitionGridPage page = new CompetitionGridPage(_selectedGroup);
            MainWindowViewModel.Instance.CurrentPage = page;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
