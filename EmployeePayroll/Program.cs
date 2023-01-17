using EmployeePayroll.Repository;

namespace EmployeePayroll
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeRepository repository= new EmployeeRepository();
            repository.CreateDatabase();
        }
    }
}