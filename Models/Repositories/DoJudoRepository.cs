using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoJudo.Models.Database;

namespace DoJudo.Models.Repositories
{
    internal class DoJudoRepository : DoJudoEntities
    {
        //you need to make constr is PROTECTED in DoJudoEntitites
        private static DoJudoRepository instance;
        public static DoJudoRepository GetInstance() 
        {
            if (instance == null)
                instance = new DoJudoRepository();
            return instance;
        }
    }
}
