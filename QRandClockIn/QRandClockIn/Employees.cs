using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QRandClockIn
{
    public class Employees
    {
        private string _name;
        private string _empNumber;
        private string _surname;
        private string _title;
        private string _phoneNo;




        //private variables for address
        private string _street;
        private string _suburb;
        private string _city;
        private string _postalCode;
        private string _province;

        //for the stuff below the mail header
        private string _initials;
        private string _tax;
        private string _maritalStatus;
        private string _department;
        private string _idNumber;
        private string _medicalDependents;
        private string _medicalAid;
        private string _medicalAidNo;
        private string _totalHours;
        private string _bank;
        private string _bankBranch;
        private string _bankAcc;
        private string _bankAccType;
        private string _salary;

        //clocked
        private DateTime _timeIn;
        private DateTime _timeOut;





        public Employees(string nam, string empNum, string surname)
        {
            this._name = nam;
            this._empNumber = empNum;
            this._surname = surname;

        }
        public Employees(string nam, string studentNum)
        {
            this._name = nam;
            this._empNumber = studentNum;
            //this._studentCredit = studentCred;

        }
        public Employees(string totalHours)
        {
            this._totalHours = totalHours;
        }
        public Employees(string nam, string studentNum, string empSur, string street, string suburb, string city, string postalCode, string province, string initials, string tax, string maritalStatus, string department, string id, string dependents, string bank, string branch, string accNumber, string accType, string title, string phoneNo, string medicalAid, string medicalAidNo, string income, DateTime timeIn, DateTime timeOut)
        {
            this._name = nam;
            this._empNumber = studentNum;
            this._surname = empSur;
            this._title = title;
            this._phoneNo = phoneNo;
            this._street = street;
            this._suburb = suburb;
            this._city = city;
            this._postalCode = postalCode;
            this._province = province;

            //for the stuff underneth the mail header
            this._initials = initials;
            this._tax = tax;
            this._maritalStatus = maritalStatus;
            this._department = department;
            this._idNumber = id;
            this._medicalDependents = dependents;
            this._medicalAid = medicalAid;
            this._medicalAidNo = medicalAidNo;

            this._bank = bank;
            this._bankBranch = branch;
            this._bankAcc = accNumber;
            this._bankAccType = accType;

            this._salary = income;

            this._timeIn = timeIn;
            this._timeOut = timeOut;



        }

        public Employees(string nam, string studentNum, string empSur, string street, string suburb, string city, string postalCode, string province, string initials, string tax, string maritalStatus, string department, string id, string dependents, string bank, string branch, string accNumber, string accType, string title, string phoneNo, string medicalAid, string medicalAidNo, string income)
        {
            this._name = nam;
            this._empNumber = studentNum;
            this._surname = empSur;
            this._title = title;
            this._phoneNo = phoneNo;
            this._street = street;
            this._suburb = suburb;
            this._city = city;
            this._postalCode = postalCode;
            this._province = province;

            //for the stuff underneth the mail header
            this._initials = initials;
            this._tax = tax;
            this._maritalStatus = maritalStatus;
            this._department = department;
            this._idNumber = id;
            this._medicalDependents = dependents;
            this._medicalAid = medicalAid;
            this._medicalAidNo = medicalAidNo;

            this._bank = bank;
            this._bankBranch = branch;
            this._bankAcc = accNumber;
            this._bankAccType = accType;

            this._salary = income;


        }

        public Employees(DateTime timeIn)
        {
            this._timeIn = timeIn;

        }
        public Employees(DateTime timeOut, int zero)
        {
            this._timeOut = timeOut;

        }





        public string EmpNumber
        {
            get { return _empNumber; }
            set { _empNumber = value; }
        }
        public string EmpName
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public string PhoneNo
        {
            get { return _phoneNo; }
            set { _phoneNo = value; }
        }



        public override string ToString()
        {
            return EmpNumber + " \t " + EmpName;
        }

        //for the address
        public string Street
        {
            get { return _street; }
            set { _street = value; }
        }
        public string Suburb
        {
            get { return _suburb; }
            set { _suburb = value; }
        }
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }
        public string PostalCode
        {
            get { return _postalCode; }
            set { _postalCode = value; }
        }
        public string Province
        {
            get { return _province; }
            set { _province = value; }
        }

        //for the stuff below the mail header
        public string Initials
        {
            get { return _initials; }
            set { _initials = value; }
        }
        public string Tax
        {
            get { return _tax; }
            set { _tax = value; }
        }
        public string MaritalStatus
        {
            get { return _maritalStatus; }
            set { _maritalStatus = value; }
        }
        public string Department
        {
            get { return _department; }
            set { _department = value; }
        }
        public string IdNumber
        {
            get { return _idNumber; }
            set { _idNumber = value; }
        }
        public string MedicalDependents
        {
            get { return _medicalDependents; }
            set { _medicalDependents = value; }
        }
        public string MedicalAid
        {
            get { return _medicalAid; }
            set { _medicalAid = value; }
        }
        public string MedicalAidNo
        {
            get { return _medicalAidNo; }
            set { _medicalAidNo = value; }
        }
        public string TotalHours
        {
            get { return _totalHours; }
            set { _totalHours = value; }
        }
        public string Bank
        {
            get { return _bank; }
            set { _bank = value; }
        }
        public string BankBranch
        {
            get { return _bankBranch; }
            set { _bankBranch = value; }
        }
        public string BankAcc
        {
            get { return _bankAcc; }
            set { _bankAcc = value; }
        }
        public string BankAccType
        {
            get { return _bankAccType; }
            set { _bankAccType = value; }
        }

        //salary
        public string Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }

        //clocked
        public DateTime TimeIn
        {
            get { return _timeIn; }
            set { _timeIn = value; }
        }

        public DateTime TimeOut
        {
            get { return _timeOut; }
            set { _timeOut = value; }
        }


        public string DatabaseGroupName { get; set; }

    }
}
