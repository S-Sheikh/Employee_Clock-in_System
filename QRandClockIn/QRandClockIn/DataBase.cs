using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QRandClockIn.DAL;
using System.Data.SQLite;
using System.Data;

namespace QRandClockIn
{
    public class DataBase : NewInfoProviderBase
    {

        SQLiteConnection connection = null;
        SQLiteCommand command = null;
        SQLiteDataReader dataRead = null;

        string connectionString = "Data Source=c:\\DataStores\\PIO42\\PIO42DB.s3db;Version=3";

        //About the employees and employers

        public override List<Employers> selectAllEmployerInfo()
        {
            List<Employers> groupInfo = new List<Employers>();


            connection = new SQLiteConnection(connectionString);

            try
            {
                connection.Open();

                command = connection.CreateCommand();

                command.CommandText = "select * from clerk_Credentials";

                dataRead = command.ExecuteReader();

                while (dataRead.Read())
                {
                    groupInfo.Add(new Employers(Convert.ToString(dataRead[0]), Convert.ToString(dataRead[2])
                        , Convert.ToString(dataRead[4])
                        , Convert.ToString(dataRead[5])
                        , Convert.ToString(dataRead[1])
                        , Convert.ToString(dataRead[6])
                        , Convert.ToString(dataRead[7])
                        , Convert.ToString(dataRead[2])

                        ));
                }

                dataRead.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("Problem in the select all from group information method: selectAllGroupInfo " + ex);
            }
            finally
            {
                connection.Close();
            }

            return groupInfo;
        }//you know

        public override List<Employees> SelectAllEmployees()
        {
            List<Employees> students = new List<Employees>();


            connection = new SQLiteConnection(connectionString);
            try
            {

                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = "select * from emp_Credentials";
                dataRead = command.ExecuteReader();
                while (dataRead.Read())
                {
                    students.Add(new Employees(
                        Convert.ToString(dataRead[0]),
                        Convert.ToString(dataRead[16]),
                        Convert.ToString(dataRead[1])

                        , Convert.ToString(dataRead[17])
                        , Convert.ToString(dataRead[18])
                        , Convert.ToString(dataRead[19])
                        , Convert.ToString(dataRead[20])
                        , Convert.ToString(dataRead[21])
                        //for the stuff below the mail header
                        , Convert.ToString(dataRead[22])
                        , Convert.ToString(dataRead[13])
                        , Convert.ToString(dataRead[23])
                        , Convert.ToString(dataRead[5])
                        , Convert.ToString(dataRead[2])
                        , Convert.ToString(dataRead[10])
                        , Convert.ToString(dataRead[6])
                        , Convert.ToString(dataRead[8])
                        , Convert.ToString(dataRead[7])
                        , Convert.ToString(dataRead[9])
                        , Convert.ToString(dataRead[3])
                        , Convert.ToString(dataRead[4])
                        , Convert.ToString(dataRead[11])

                        //the salary
                         , Convert.ToString(dataRead[12])
                         , Convert.ToString(dataRead[15])
                        //clocked
                          , Convert.ToDateTime(dataRead[24])
                          , Convert.ToDateTime(dataRead[25])


                        ));


                }

                dataRead.Close();

            }
            catch 
            {
                // MessageBox.Show(ex.ToString());
                throw new Exception("Problem in the select all from group information method: selectallStudents");
            }
            finally
            {
                connection.Close();
            }

            return students;
        }

        public override int Insert2(object member2)
        {

            int rc = 0;
            try
            {
                int rowsAffected = 0;
                connection = new SQLiteConnection(connectionString); // new connection
                connection.Open(); // open connection

                //MessageBox.Show(((Employees)member2).Salary);
                if (member2 is Employees)
                {

                    string insertQuery = "INSERT INTO emp_Credentials([emp_name], [emp_surname], [emp_idNo], [emp_title], [emp_phoneNo], [emp_dept], [emp_bank], [emp_bankAcc], [emp_bankBranch], [emp_accType], [emp_dependents], [emp_medicalAid], [emp_medicalAidNo], [emp_taxNo], [NetSalary], [emp_Number], [Street], [Suburb], [City], [PostalCode], [Province], [emp_Initials], [emp_MaritalStatus], [TimeCIn],[TimeCOut] ) VALUES(" + "@emp_name, @emp_surname, @emp_idNo, @emp_title, @emp_phoneNo, @emp_dept, @emp_bank, @emp_bankAcc, @emp_bankBranch, @emp_accType, @emp_dependents, @emp_medicalAid, @emp_medicalAidNo, @emp_taxNo, @NetSalary, @emp_Number, @Street, @Suburb, @City, @PostalCode, @Province, @emp_Initials, @emp_MaritalStatus, @TimeCIn, @TimeCOut)";
                    SQLiteCommand sqlCommand = new SQLiteCommand(insertQuery, connection);
                    SQLiteParameter[] sqlParams = new SQLiteParameter[] // setup parameters
                    {
                        new SQLiteParameter("@emp_name",DbType.String),
                        new SQLiteParameter("@emp_surname",DbType.String),
                        new SQLiteParameter("@emp_idNo",DbType.String),
                        new SQLiteParameter("@emp_title", DbType.String),
                        new SQLiteParameter("@emp_phoneNo", DbType.String),
                        new SQLiteParameter("@emp_dept",DbType.String),
                        new SQLiteParameter("@emp_bank",DbType.String),
                        new SQLiteParameter("@emp_bankAcc",DbType.String),
                        new SQLiteParameter("@emp_bankBranch",DbType.String),
                        new SQLiteParameter("@emp_accType",DbType.String),
                        new SQLiteParameter("@emp_dependents",DbType.String),
                        new SQLiteParameter("@emp_medicalAid",DbType.String),
                        new SQLiteParameter("@emp_medicalAidNo",DbType.String),
                        new SQLiteParameter("@emp_taxNo",DbType.String),
                        new SQLiteParameter("@NetSalary",DbType.String),
                        new SQLiteParameter("@emp_Number",DbType.String),
                        new SQLiteParameter("@Street",DbType.String),
                        new SQLiteParameter("@Suburb",DbType.String),
                        new SQLiteParameter("@City",DbType.String),
                        new SQLiteParameter("@PostalCode",DbType.String),
                        new SQLiteParameter("@Province",DbType.String),
                        new SQLiteParameter("@emp_Initials",DbType.String),
                        new SQLiteParameter("@emp_MaritalStatus",DbType.String),
                        new SQLiteParameter("@TimeCIn",DbType.DateTime),
                        new SQLiteParameter("@TimeCOut",DbType.DateTime),
                         

                    };
                    sqlParams[0].Value = ((Employees)member2).EmpName;
                    sqlParams[1].Value = ((Employees)member2).Surname;
                    sqlParams[2].Value = ((Employees)member2).IdNumber;
                    sqlParams[3].Value = ((Employees)member2).Title;
                    sqlParams[4].Value = ((Employees)member2).PhoneNo;
                    sqlParams[5].Value = ((Employees)member2).Department;
                    sqlParams[6].Value = ((Employees)member2).Bank;
                    sqlParams[7].Value = ((Employees)member2).BankAcc;
                    sqlParams[8].Value = ((Employees)member2).BankBranch;
                    sqlParams[9].Value = ((Employees)member2).BankAccType;
                    sqlParams[10].Value = ((Employees)member2).MedicalDependents;
                    sqlParams[11].Value = ((Employees)member2).MedicalAid;
                    sqlParams[12].Value = ((Employees)member2).MedicalAidNo;
                    sqlParams[13].Value = ((Employees)member2).Tax;
                    sqlParams[14].Value = ((Employees)member2).Salary;
                    sqlParams[15].Value = ((Employees)member2).EmpNumber;
                    sqlParams[16].Value = ((Employees)member2).Street;
                    sqlParams[17].Value = ((Employees)member2).Suburb;
                    sqlParams[18].Value = ((Employees)member2).City;
                    sqlParams[19].Value = ((Employees)member2).PostalCode;
                    sqlParams[20].Value = ((Employees)member2).Province;
                    sqlParams[21].Value = ((Employees)member2).Initials;
                    sqlParams[22].Value = ((Employees)member2).MaritalStatus;

                    sqlParams[23].Value = ((Employees)member2).TimeIn;
                    sqlParams[24].Value = ((Employees)member2).TimeOut;




                    sqlCommand.Parameters.AddRange(sqlParams);
                    rowsAffected = sqlCommand.ExecuteNonQuery();

                }//emps




                else if (member2 is Employers)
                {
                    int rowsAffected2 = 0;
                    string insertQuery2 = "INSERT INTO employers_Credentials([employers_name], [employers_empNo], [employers_surname], [employers_maidenName], [employers_idNo], [employers_dateAssigned], [employers_email], [employers_password] ) VALUES(" + "@employers_name, @employers_empNo, @employers_surname, @employers_maidenName, @employers_idNo, @employers_dateAssigned, @employers_email, @employers_password)";
                    SQLiteCommand sqlCommand2 = new SQLiteCommand(insertQuery2, connection);
                    SQLiteParameter[] sqlParams2 = new SQLiteParameter[] // setup parameters
                    {
                        new SQLiteParameter("@employers_name",DbType.String),
                        new SQLiteParameter("@employers_empNo",DbType.String),
                        new SQLiteParameter("@employers_surname",DbType.String),
                        new SQLiteParameter("@employers_maidenName",DbType.String),
                        new SQLiteParameter("@employers_idNo",DbType.String),
                        new SQLiteParameter("@employers_dateAssigned",DbType.String),
                        new SQLiteParameter("@employers_email",DbType.String),
                        new SQLiteParameter("@employers_password",DbType.String),
                    
                    };
                    sqlParams2[0].Value = ((Employers)member2).Employername;
                    sqlParams2[1].Value = ((Employers)member2).EmployerEmpNumber;
                    sqlParams2[2].Value = ((Employers)member2).EmployerSurname;
                    sqlParams2[3].Value = ((Employers)member2).EmployerMaidenName;
                    sqlParams2[4].Value = ((Employers)member2).EmployerIdNumber;
                    sqlParams2[5].Value = ((Employers)member2).EmployerDateAssigned;
                    sqlParams2[6].Value = ((Employers)member2).EmployerEmail;
                    sqlParams2[7].Value = ((Employers)member2).EmployerPassword;


                    sqlCommand2.Parameters.AddRange(sqlParams2);
                    rowsAffected2 = sqlCommand2.ExecuteNonQuery();
                    if (rowsAffected2 == 1) // Test rowsAffected
                    {
                        // 1 row affected, thus 1 row added to datastore, thus success
                        rc = 0;
                    } // end if
                }//employers

            } // end try
            catch (SQLiteException ex) // Catch SQLiteException
            {
                if (ex.ErrorCode == SQLiteErrorCode.Constraint) // Constraint: thus duplicate, thus failure
                {
                    rc = -1;
                } // end if
            } // end catch
            catch (Exception ex)
            {
                throw ex;
            } // end catch
            finally
            {
                connection.Close();  // Close connection
            } // end finally
            return rc; // Single return
        } // end method

        public override int Update2(Object member2)
        {
            int rc = 0;

            try
            {
                int rowsAffected = 0;
                connection = new SQLiteConnection(connectionString); // New connection
                connection.Open(); // open connection

                if (member2 is Employees)
                {
                    string updateQuery = string.Format("UPDATE emp_Credentials SET [TimeCIn]=@TimeCIn WHERE [emp_Number] = '{0}'", ((Employees)member2).EmpNumber);
                    // MessageBox.Show(((Employees)member2).EmpNumber);
                    SQLiteCommand sqlCommand = new SQLiteCommand(updateQuery, connection); // setup command
                    SQLiteParameter[] sqlParams = new SQLiteParameter[] // setup parameters
                    {
                   
                        new SQLiteParameter("@emp_Number", DbType.String),
                        new SQLiteParameter("@TimeCIn", DbType.DateTime),
                        //new SQLiteParameter("@TimeCOut", DbType.DateTime),
                    
                    };

                    sqlParams[0].Value = ((Employees)member2).EmpNumber;
                    sqlParams[1].Value = ((Employees)member2).TimeIn;
                    //  sqlParams[2].Value = ((Employees)member2).TimeOut;


                    sqlCommand.Parameters.AddRange(sqlParams);
                    rowsAffected = sqlCommand.ExecuteNonQuery();


                }//emps


                if (member2 is Employers)
                {
                    string updateQuery = string.Format("UPDATE employers_Credentials SET [employers_name]=@employers_name, [employers_surname]=@employers_surname, [employers_maidenName]=@employers_maidenName, [employers_idNo]=@employers_idNo, [employers_dateAssigned]=@employers_dateAssigned, [employers_email]=@employers_email, [employers_passoword]=@employers_passoword WHERE [employers_empNo] = '{0}'", ((Employers)member2).EmployerEmpNumber);
                    SQLiteCommand sqlCommand = new SQLiteCommand(updateQuery, connection); // setup command
                    SQLiteParameter[] sqlParams = new SQLiteParameter[] // setup parameters
                    {
                        new SQLiteParameter("@employers_name",DbType.String),
                        new SQLiteParameter("@employers_surname",DbType.String),
                        new SQLiteParameter("@employers_maidenName",DbType.String),
                        new SQLiteParameter("@employers_idNo",DbType.String),
                        new SQLiteParameter("@employers_empNo",DbType.String),
                        new SQLiteParameter("@employers_dateAssigned",DbType.String),
                        new SQLiteParameter("@employers_email",DbType.String),
                        new SQLiteParameter("@employers_passoword",DbType.String),
                    };

                    sqlParams[0].Value = ((Employers)member2).Employername;
                    sqlParams[3].Value = ((Employers)member2).EmployerSurname;
                    sqlParams[4].Value = ((Employers)member2).EmployerMaidenName;
                    sqlParams[5].Value = ((Employers)member2).EmployerIdNumber;
                    sqlParams[1].Value = ((Employers)member2).EmployerEmpNumber;
                    sqlParams[6].Value = ((Employers)member2).EmployerDateAssigned;
                    sqlParams[7].Value = ((Employers)member2).EmployerEmail;
                    sqlParams[2].Value = ((Employers)member2).EmployerPassword;


                    sqlCommand.Parameters.AddRange(sqlParams);
                    rowsAffected = sqlCommand.ExecuteNonQuery();


                    string updateQuery2 = string.Format("UPDATE GroupInformation SET [GroupName]=@GroupName WHERE [GroupName] = '{0}'", ((Employers)member2).EmployerEmpNumber);
                    SQLiteCommand sqlCommand2 = new SQLiteCommand(updateQuery2, connection); // setup command
                    SQLiteParameter[] sqlParams2 = new SQLiteParameter[] // setup parameters
                    {
                        new SQLiteParameter("@GroupName", DbType.String),
                    };

                    sqlParams2[0].Value = ((Employers)member2).Employername;

                    sqlCommand2.Parameters.AddRange(sqlParams2);
                    rowsAffected = sqlCommand2.ExecuteNonQuery();

                }//employers

                if (rowsAffected == 0) // Test rowsAffected
                {
                    // 0 rows affected, thus NO row updated in datastore, thus not found, thus failure
                    rc = -1;
                } // end if
                else
                {
                    // 1 row affected, thus 1 row updated in datastore, thus success
                    rc = 0;
                } // end else
            } // end try
            catch (Exception ex)
            {
                throw ex;
            } // end catch
            finally
            {
                connection.Close();  // Close connection
            } // end finally
            return rc; // single return
        } // end method
        public override int Update3(Object member3)
        {
            int rc = 0;

            try
            {
                int rowsAffected = 0;
                connection = new SQLiteConnection(connectionString); // New connection
                connection.Open(); // open connection

                if (member3 is Employees)
                {

                    string updateQuery = string.Format("UPDATE emp_Credentials SET [TimeCOut]=@TimeCOut WHERE [emp_Number] = '{0}'", ((Employees)member3).EmpNumber);

                    // MessageBox.Show(((Employees)member3).TimeOut.ToString());

                    SQLiteCommand sqlCommand = new SQLiteCommand(updateQuery, connection); // setup command
                    SQLiteParameter[] sqlParams = new SQLiteParameter[] // setup parameters
                    {
                   
                        new SQLiteParameter("@emp_Number", DbType.String),
                        new SQLiteParameter("@TimeCOut", DbType.DateTime),
                    
                    };

                    sqlParams[0].Value = ((Employees)member3).EmpNumber;
                    sqlParams[1].Value = ((Employees)member3).TimeOut;


                    sqlCommand.Parameters.AddRange(sqlParams);
                    rowsAffected = sqlCommand.ExecuteNonQuery();


                }//emps

                if (rowsAffected == 0) // Test rowsAffected
                {
                    // 0 rows affected, thus NO row updated in datastore, thus not found, thus failure
                    rc = -1;
                } // end if
                else
                {
                    // 1 row affected, thus 1 row updated in datastore, thus success
                    rc = 0;
                } // end else
            } // end try
            catch (Exception ex)
            {
                throw ex;
            } // end catch
            finally
            {
                connection.Close();  // Close connection
            } // end finally
            return rc; // single return
        } // end method

        public override int Delete2(string member2)
        {

            int rc = 0;

            try
            {
                int rowsAffected = 0;

                connection = new SQLiteConnection(connectionString); // New connection
                connection.Open(); // Open connection
                string deleteQuery = string.Format("DELETE FROM GroupInformation WHERE [GroupMembers] = '{0}'", member2);

                SQLiteCommand sqlCommand = new SQLiteCommand(deleteQuery, connection); // setup command



                rowsAffected = sqlCommand.ExecuteNonQuery();


                if (rowsAffected == 0) // Test rowsAffected
                {
                    rc = -1;
                } // end if
                else
                {

                    rc = 0;
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return rc;
        }


    }
}
