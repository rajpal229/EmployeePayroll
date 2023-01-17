using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll.Repository
{
    public class Operations
    {
        SqlConnection connection = new SqlConnection("Data Source=I-CHANGE-THE-NA\\SQLEXPRESS;Initial Catalog=EmpPayroll; Integrated Security=true");

        public void Max()
        {
            try
            {
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand("select MAX(Basic_Pay) as MaxSalary from Employee", connection);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        long max = (long)reader[0];
                        Console.WriteLine("Maximum Salary in DataBase: " + max);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Min()
        {
            try
            {
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand("select MIN(Basic_Pay) as MinSalary from Employee", connection);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        long min = (long)reader[0];
                        Console.WriteLine("Minimum Salary in DataBase: " + min);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Avg()
        {
            try
            {
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand("select AVG(Basic_Pay) as AvgSalary from Employee", connection);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        long avg = (long)reader[0];
                        Console.WriteLine("Average Salary in DataBase: " + avg);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Sum()
        {
            try
            {
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand("select SUM(Basic_Pay) as SumOfSalary from Employee", connection);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        long sum = (long)reader[0];
                        Console.WriteLine("Sum of Salaries in DataBase: " + sum);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void CountMale()
        {
            try
            {
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand("select Count(id) as NumberOfMale from Employee where gender = 'M' group by gender", connection);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int count = (int)reader[0];
                        Console.WriteLine("Number of Male in DataBase: " + count);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void CountFeMale()
        {
            try
            {
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand("select Count(id) as NumberOfMale from Employee where gender = 'F' group by gender", connection);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int count = (int)reader[0];
                        Console.WriteLine("Number of Female in DataBase: " + count);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
