using DoJudo.Models.Database;
using DoJudo.Views.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoJudo.ViewModels
{
    internal class AddEditParticipantsViewModel : INotifyPropertyChanged
    {
        private Participant participant;
        public Participant Participant
        {
            get { return participant;}
            set
            {
                participant = value;
                OnPropertyChanged(nameof(participant));
            }
        }
        public AddEditParticipantsViewModel(Participant participant)
        {
            this.participant = participant;

        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
