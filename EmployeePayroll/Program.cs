using EmployeePayroll.Repository;

namespace EmployeePayroll
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeRepository repository= new EmployeeRepository();
            Console.WriteLine("Enter the Value\n1.Get All Data\n2. Update Salary");
            int op = Convert.ToInt32(Console.ReadLine());
            while (true)
            {
                switch (op)
                {
                    case 1:
                        repository.GetAllData();
                        break;
                    case 2:
                        repository.UpdateSalary();
                        break;
                }
                break;
            }
        }
    }
}