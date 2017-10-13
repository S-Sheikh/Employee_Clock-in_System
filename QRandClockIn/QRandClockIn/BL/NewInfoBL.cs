using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QRandClockIn.DAL;

namespace QRandClockIn.BL
{
    public class NewInfoBL
    {

        private NewInfoProviderBase providerBase;

        public NewInfoBL(string Provider)
        {
            _SetupProviderBase(Provider);
        }
   
        //about the employers and emps
        public List<Employers> selectAllClerkInfo()
        {
            return providerBase.selectAllEmployerInfo();
        }

        public List<Employees> SelectAllEmployees()
        {
            return providerBase.SelectAllEmployees();
        }

        public int Insert2(object member2)
        {
            return providerBase.Insert2(member2);
        }
        public int Update2(Object member2)
        {
            return providerBase.Update2(member2);
        }
        public int Update3(Object member3)
        {
            return providerBase.Update3(member3);
        }
        public int Delete2(string member2)
        {
            return providerBase.Delete2(member2);
        }





        private void _SetupProviderBase(string Provider)
        {
            if (Provider == "DataBase")
            {
                providerBase = new DataBase();

            }
        }


    }
}
