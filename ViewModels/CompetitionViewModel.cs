using DoJudo.Models.Database;
using DoJudo.Views.Pages;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DoJudo.ViewModels
{
    internal class CompetitionViewModel : INotifyPropertyChanged
    {
        private Competition _competition;
        public Competition Competition
        { 
            get { return _competition; } 
            set
            {
                _competition = value;
                OnPropertyChanged(nameof(Competition));
            }
        }

        public CompetitionViewModel(Competition competititon)
        {
            _competition = competititon;
            AddParticipantsCompetitionCommand = new RelayCommand(GoToAddParticipantsCompetitionPage);
        }
        private void GoToAddParticipantsCompetitionPage()
        {
            AddParticipantsCompetitionPage addParticipantsCompetitionPage = new AddParticipantsCompetitionPage();
            MainWindowViewModel.Instance.CurrentPage = addParticipantsCompetitionPage;
        }
        public ICommand AddParticipantsCompetitionCommand { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
