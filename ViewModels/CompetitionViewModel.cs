using DoJudo.Models.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
