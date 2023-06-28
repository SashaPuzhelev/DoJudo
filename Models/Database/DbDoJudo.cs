﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoJudo.Models.Database;

namespace DoJudo.Models.Database
{
    internal class DbDoJudo : DoJudoEntitiesV4
    {
        //you need to make constr is PROTECTED in DoJudoEntitites
        private static DbDoJudo instance;
        public static DbDoJudo GetInstance() 
        {
            if (instance == null)
                instance = new DbDoJudo();
            return instance;
        }
    }
}
