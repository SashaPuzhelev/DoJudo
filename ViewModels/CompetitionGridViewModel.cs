using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoJudo.ViewModels
{
    internal class CompetitionGridViewModel : INotifyPropertyChanged
    {
        public CompetitionGridViewModel(Models.Database.Group group)
        {
            
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
