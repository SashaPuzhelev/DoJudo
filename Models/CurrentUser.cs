using DevExpress.Internal.WinApi.Windows.UI.Notifications;
using DoJudo.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DoJudo.Models
{
    internal class CurrentUser 
    {
        private static User _user;
        private static CurrentUser instance;
        private CurrentUser(User user)
        {
            _user = user;
        }
        public static CurrentUser SetInstance(User user)
        {
            if (instance == null)
            {
                instance = new CurrentUser(user);
            }
            return instance;
        }
        public static CurrentUser GetInstance()
        {
            return instance;
        }
        public static void SetNullInstance()
        {
            instance = null;
        }
        public int Id => _user.Id;
        public string Name => _user.Name;
        public string Surname => _user.Surname;
        public int IdRole => _user.IdRole;
        public string RoleName => _user.Role.Name;
        public string FullName => $"{_user.Name} {_user.Surname}";
        public string FullNameWithRoleName => $"{_user.Role.Name}: {FullName}";

        public bool CanEdit => _user.IdRole == 1;
    }
}
