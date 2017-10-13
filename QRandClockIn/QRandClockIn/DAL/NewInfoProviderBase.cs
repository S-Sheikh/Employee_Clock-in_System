using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QRandClockIn.DAL
{
    public abstract class NewInfoProviderBase
    {
        //for employers and employees
        public abstract List<Employers> selectAllEmployerInfo();//formerly Employers
        public abstract List<Employees> SelectAllEmployees();

        public abstract int Insert2(object member2);
        public abstract int Update2(object member2);
        public abstract int Update3(object member3);
        public abstract int Delete2(string member2);
    }
}
