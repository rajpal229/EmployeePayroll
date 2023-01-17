using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EmployeePayroll.Repository
{
    public class EmployeeRepository
    {
        SqlConnection connection = new SqlConnection("Data Source=I-CHANGE-THE-NA\\SQLEXPRESS;Initial Catalog=master; Integrated Security=true");
        public void CreateDatabase()
        {
            SqlCommand cmd = new SqlCommand("Create Database EmpPayroll;", connection);
            connection.Open();
            Console.WriteLine("Connection Established");
            cmd.ExecuteNonQuery();
            Console.WriteLine("Database Created");
        }
    }
}
