using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QRandClockIn
{
    public class Employers
    {
        private string _employersname;
        private string _employersSurname;
        private string _employersMaidenName;
        private string _employersIdNumber;
        private string _employersEmpNumber;
        private string _employersDateAssigned;
        private string _employersEmail;
        private string _employersPassword;


        public Employers(string employersname, string employersSurname, string maidenName, string employersID, string employersEmpNumber, string employersDateAssigned, string employersEmail, string password)
        {
            this._employersname = employersname;
            this._employersSurname = employersSurname;
            this._employersMaidenName = maidenName;
            this._employersIdNumber = employersID;
            this._employersEmpNumber = employersEmpNumber;
            this._employersDateAssigned = employersDateAssigned;
            this._employersEmail = employersEmail;
            this._employersPassword = password;
        }

     

        public string Employername
        {
            get { return this._employersname; }
            set { this._employersname = value; }
        }
        public string EmployerSurname
        {
            get { return this._employersSurname; }
            set { this._employersSurname = value; }
        }
        public string EmployerMaidenName
        {
            get { return _employersMaidenName; }
            set { _employersMaidenName = value; }
        }
        public string EmployerDateAssigned
        {
            get { return _employersDateAssigned; }
            set { _employersDateAssigned = value; }
        }
        public string EmployerIdNumber
        {
            get { return _employersIdNumber; }
            set { _employersIdNumber = value; }
        }
        public string EmployerPassword
        {
            get { return _employersPassword; }
            set { _employersPassword = value; }
        }
        public string EmployerEmail
        {
            get { return _employersEmail; }
            set { _employersEmail = value; }
        }
        public string EmployerEmpNumber
        {
            get { return _employersEmpNumber; }
            set { _employersEmpNumber = value; }
        }


        public override string ToString()
        {
            return Employername + " \t " + EmployerEmpNumber + " \t " + EmployerPassword;
        }
    }
}
