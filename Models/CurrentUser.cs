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
        public CurrentUser(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Surname = user.Surname;
            IdRole = user.IdRole;
            RoleName = user.Role.Name;
        }
        public static int Id { get; private set; }
        public static string Name { get; private set; }
        public static string Surname { get; private set; }
        public static int IdRole { get; private set; }
        public static string RoleName { get; private set; }
        public static string FullName => $"{Name} {Surname}";
        public static string FullNameWithRoleName => $"{RoleName}: {FullName}";

        public static bool CanEdit => IdRole == 1;
    }
}
