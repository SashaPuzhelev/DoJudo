using DoJudo.Models.Database;
using DoJudo.Models.Interfaces;
using DoJudo.Models.Repositories;
using System;

namespace DoJudo.Models
{
    internal class CurrentUser
    {
        private static User _user;
        private static CurrentUser instance;
        public int Id => _user.Id;
        public string Name => _user.Name;
        public string Surname => _user.Surname;
        public int IdRole => _user.IdRole;
        public bool IsAdmin => _user.IdRole == 1;
        public HistoryLogin HistoryLogin;
        public string RoleName => _user.Role.Name;
        public string FullName => $"{_user.Name} {_user.Surname}";
        public string FullNameWithRoleName => $"{_user.Role.Name}: {FullName}";
        private CurrentUser(User user)
        {
            _user = user;
            HistoryLogin = new HistoryLogin();
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
        public static void StartHistoryLogin()
        {
            if (instance != null)
            {
                GetInstance().HistoryLogin.IdUser = _user.Id;
                GetInstance().HistoryLogin.DateTimeLogin = DateTime.Now;
            }
        }
        public static void EndHistoryLogin()
        {
            GetInstance().HistoryLogin.DateTimeExit = DateTime.Now;
            IHistoryLoginRepository historyLoginRepository = new  HistoryLoginRepository();
            historyLoginRepository.Add(GetInstance().HistoryLogin);
        }
            
       
    }
}
