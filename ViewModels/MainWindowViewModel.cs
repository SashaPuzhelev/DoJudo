using DoJudo.Models;
using DoJudo.Models.Repositories;
using DoJudo.Models.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoJudo.ViewModels
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {

        public string FullNameWithRoleName
        {
            get { return CurrentUser.FullNameWithRoleName; }
        }
        public MainWindowViewModel()
        {

        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged (string propertyName)
        {
            PropertyChanged?.Invoke (this, new PropertyChangedEventArgs (propertyName));
        }
    }
}
