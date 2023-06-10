using DevExpress.Mvvm;
using DoJudo.Models.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace DoJudo.Model
{
    internal class LoginViewModel : ViewModelBase

    {
        private User _user;
        public User User
        {
            get{ return _user; }
            set
            {
                _user = value;
                RaisePropertiesChanged();
            }
        }
    }
}
