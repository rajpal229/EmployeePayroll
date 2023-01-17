using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EmployeePayroll.Model;

namespace EmployeePayroll.Repository
{
    public class EmployeeRepository
    {
        SqlConnection connection = new SqlConnection("Data Source=I-CHANGE-THE-NA\\SQLEXPRESS;Initial Catalog=EmpPayroll; Integrated Security=true");
        public void CreateDatabase()
        {
            SqlCommand cmd = new SqlCommand("Create Database EmpPayroll;", connection);
            connection.Open();
            Console.WriteLine("Connection Established");
            cmd.ExecuteNonQuery();
            Console.WriteLine("Database Created");
        }
        public void CreateTable()
        {
            SqlCommand cmd = new SqlCommand("Create Table Employee(id int primary key identity(1,1), Name varchar(200), PhoneNumber bigint, Address varchar(200), Department varchar(200), Gender char, Basic_Pay bigint, Deductions bigint, Taxable_Pay bigint, Tax bigint, Net_Pay bigint, Start_date date);", connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            Console.WriteLine("Table Created");
            connection.Close();
        }
        public void GetAllData()
        {
            EmployeeModel empmodel = new EmployeeModel();
            try
            {
                using (connection)
                {
                    string Query = @"Select * from Employee";
                    SqlCommand cmd = new SqlCommand(Query, connection);
                    connection.Open();
                    Console.WriteLine("Connection Established");
                    SqlDataReader datareader = cmd.ExecuteReader();
                    if (datareader.HasRows)
                    {
                        while (datareader.Read())
                        {
                            empmodel.id = datareader.GetInt32(0);
                            empmodel.Name = datareader.GetString(1);
                            empmodel.PhoneNumber = datareader.GetInt64(2);
                            empmodel.Address = datareader.GetString(3);
                            empmodel.Department = datareader.GetString(4);
                            empmodel.Gender = Convert.ToChar(datareader.GetValue(5));
                            empmodel.Basic_Pay = datareader.GetInt64(6);
                            empmodel.Deductions = datareader.GetInt64(7);
                            empmodel.Taxable_Pay = datareader.GetInt64(8);
                            empmodel.Tax = datareader.GetInt64(9);
                            empmodel.Net_Pay = datareader.GetInt64(10);
                            empmodel.Start_Date= datareader.GetDateTime(11);
                            Console.WriteLine(empmodel.id + " " + empmodel.Name + " " + empmodel.PhoneNumber + " " + empmodel.Address + " " + empmodel.Department + " " + empmodel.Gender + " " + empmodel.Basic_Pay + " " + empmodel.Deductions + " " + empmodel.Taxable_Pay + " " + empmodel.Tax + " " + empmodel.Net_Pay + " " + empmodel.Start_Date.ToShortDateString()); 
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
                Console.WriteLine("Connection Closed");
            }
        }
    }
}
