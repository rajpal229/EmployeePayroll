using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EmployeePayroll.Model;
using System.Numerics;
using System.Reflection;
using System.Xml.Linq;

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
        public void InsertIntoTable(string name, long phone, string emp_address, string dept, char gender, double basic, double dedc, double taxable, double tax, double net, DateTime startdate)
        {
            try
            {
                EmployeeModel empmodel = new EmployeeModel();
                using (connection)
                {
                    int value = 0;
                    string Query = @"InsertTable";
                    SqlCommand cmd = new SqlCommand(Query, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@address", emp_address);
                    cmd.Parameters.AddWithValue("@department", dept);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@basic", basic);
                    cmd.Parameters.AddWithValue("@deductions", dedc);
                    cmd.Parameters.AddWithValue("@Taxable_Income", taxable);
                    cmd.Parameters.AddWithValue("@tax", tax);
                    cmd.Parameters.AddWithValue("@net", net);
                    cmd.Parameters.AddWithValue("@Startdate", startdate);
                    connection.Open();
                    Console.WriteLine("Connection Established");
                    value = cmd.ExecuteNonQuery();
                    if (value >= 1)
                    {
                        Console.WriteLine("Employee Data Inserted");
                    }
                    else
                    {
                        Console.WriteLine("Not Updated");
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
                            empmodel.Start_Date = datareader.GetDateTime(11);
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
        public string UpdateSalary()
        {
            try
            {
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand(@"Update Employee set Basic_Pay=300000 where id=3", connection);
                    connection.Open();
                    Console.WriteLine("Connection Established");
                    var objreader = cmd.ExecuteNonQuery();
                    if (objreader >= 1)
                    {
                        Console.WriteLine("Data Updated");
                        return "Data Updated";
                    }
                    else
                    {
                        Console.WriteLine("Data not updated");
                        return "Data not Updated";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                connection.Close();
                Console.WriteLine("Connection Closed");
            }
        }
        public string UpdateSalaryStoredProcedure(double basic, double dedc, double taxable, double tax, double net, int id)
        {
            try
            {
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand(@"UpdateSalary", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@basic", basic);
                    cmd.Parameters.AddWithValue("@dedc", dedc);
                    cmd.Parameters.AddWithValue("@taxable", taxable);
                    cmd.Parameters.AddWithValue("@tax", tax);
                    cmd.Parameters.AddWithValue("@net", net);
                    cmd.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    Console.WriteLine("Connection Established");
                    var objreader = cmd.ExecuteNonQuery();
                    if (objreader >= 1)
                    {
                        Console.WriteLine("Data Updated");
                        return "Data Updated";
                    }
                    else
                    {
                        Console.WriteLine("Data not updated");
                        return "Data not Updated";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                connection.Close(); 
                Console.WriteLine("Connection Closed");
            }
        }
        public void GetDataByName(string name)
        {
            EmployeeModel empmodel = new EmployeeModel();
            try
            {
                using (connection)
                {
                    string Query = @"DataByName";
                    SqlCommand cmd = new SqlCommand(Query, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", name);
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
                            empmodel.Start_Date = datareader.GetDateTime(11);
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
