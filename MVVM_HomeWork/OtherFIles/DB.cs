using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_HomeWork.OtherFIles
{
    public static class DB
    {
        static HomeworkdatabaseContext dataBase;

        public static HomeworkdatabaseContext instance { get
            {
                if(dataBase == null)
                    dataBase = new HomeworkdatabaseContext();
                return dataBase;
            } }
    }
}
