using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoJudo.Models.Database;

namespace DoJudo.Models.Database
{
    internal class DbDoJudo : DoJudoEntities
    {
        private static DbDoJudo instance;
        public static DbDoJudo GetInstance() 
        {
            if (instance == null)
                instance = new DbDoJudo();
            return instance;
        }
        public static bool CheckConnection()
        {
            try
            {
                GetInstance().Database.Connection.Open();
                GetInstance().Database.Connection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
