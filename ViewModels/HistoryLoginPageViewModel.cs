using DoJudo.Models.Database;
using DoJudo.Models.Interfaces;
using DoJudo.Models.Repositories;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoJudo.ViewModels
{
    internal class HistoryLoginPageViewModel : INotifyPropertyChanged
    {
        private readonly IHistoryLoginRepository _historyLoginRepository;
        private ObservableCollection<HistoryLogin> _historyLogins;
        public ObservableCollection<HistoryLogin> HistoryLogins
        {
            get { return _historyLogins; }
            set
            {
                _historyLogins = value;
                OnPropertyChanged(nameof(HistoryLogins));
            }
        }
        public HistoryLoginPageViewModel()
        {
            _historyLoginRepository = new HistoryLoginRepository();
            _ = LoadHistoryLoginsAsync();
        }

        private async Task LoadHistoryLoginsAsync()
        {
            var listHistoryLogins = await _historyLoginRepository.GetAll();
            HistoryLogins = new ObservableCollection<HistoryLogin>(listHistoryLogins);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
