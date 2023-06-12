using DevExpress.Internal.WinApi.Windows.UI.Notifications;
using DoJudo.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DoJudo.Models
{
    internal class CurrentUser 
    {
        private static User _user;
        public CurrentUser(User user)
        {
            _user = user;
        }
        public static int Id => _user.Id;
        public static string Name => _user.Name;
        public static string Surname => _user.Surname;
        public static int IdRole => _user.IdRole;
        public static string RoleName => _user.Role.Name;
        public static string FullName => $"{_user.Name} {_user.Surname}";
        public static string FullNameWithRoleName => $"{_user.Role.Name}: {FullName}";

        public static bool CanEdit => _user.IdRole == 1;
    }
}
