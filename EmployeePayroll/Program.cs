using EmployeePayroll.Model;
using EmployeePayroll.Repository;

namespace EmployeePayroll
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeRepository repository= new EmployeeRepository();
            Console.WriteLine("Enter the Value\n1. Insert Data Into Table\n2. Get All Data\n3. Update Salary\n4. Update salary using Stored Procedure\n5. Get Data By Name\n6. Get Data Between Date");
            int op = Convert.ToInt32(Console.ReadLine());
            while (true)
            {
                switch (op)
                {
                    case 1:
                        EmployeeModel model = new EmployeeModel();
                        Console.WriteLine("Enter Name");
                        model.Name = Console.ReadLine();
                        Console.WriteLine("Enter Phone Number");
                        model.PhoneNumber = Convert.ToInt64(Console.ReadLine());
                        Console.WriteLine("Enter Address");
                        model.Address = Console.ReadLine();
                        Console.WriteLine("Enter Department");
                        model.Department = Console.ReadLine();
                        Console.WriteLine("Enter Gender");
                        model.Gender = Convert.ToChar(Console.ReadLine());
                        Console.WriteLine("Enter Basic_Pay");
                        model.Basic_Pay = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Enter Deductions");
                        model.Deductions = Convert.ToDouble(Console.ReadLine());
                        if (model.Basic_Pay > 500000)
                        {
                            model.Taxable_Pay = model.Basic_Pay - model.Deductions - 500000;
                        }
                        else
                        {
                            model.Taxable_Pay = 0;
                        }
                        Console.WriteLine("Taxable_Pay " + model.Taxable_Pay);
                        if (model.Basic_Pay <= 500000)
                        {
                            model.Tax = 0;
                        }
                        if (model.Basic_Pay > 500000 && model.Basic_Pay <= 1000000)
                        {
                            model.Tax = model.Taxable_Pay * 0.10;
                        }
                        if (model.Basic_Pay > 1000000 && model.Basic_Pay <= 2000000)
                        {
                            model.Tax = model.Taxable_Pay * 0.20;
                        }
                        if (model.Basic_Pay > 2000000)
                        {
                            model.Tax = model.Taxable_Pay * 0.30;
                        }
                        Console.WriteLine("Tax " + model.Tax);
                        model.Net_Pay = model.Basic_Pay - model.Deductions - model.Tax;
                        Console.WriteLine("Net_Pay " + model.Net_Pay);
                        Console.WriteLine("Enter Date MM/DD/YYYY");
                        var startdate = Convert.ToDateTime(Console.ReadLine());
                        model.Start_Date = startdate;
                        repository.InsertIntoTable(model.Name, model.PhoneNumber, model.Address, model.Department, model.Gender, model.Basic_Pay, model.Deductions, model.Taxable_Pay, model.Tax, model.Net_Pay, model.Start_Date);
                        break;
                    case 2:
                        repository.GetAllData();
                        break;
                    case 3:
                        repository.UpdateSalary();
                        break;
                    case 4:
                        EmployeeModel model1 = new EmployeeModel();
                        Console.WriteLine("Enter Basic_Pay");
                        model1.Basic_Pay = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Enter Deductions");
                        model1.Deductions = Convert.ToDouble(Console.ReadLine());
                        if (model1.Basic_Pay > 500000)
                        {
                            model1.Taxable_Pay = model1.Basic_Pay - model1.Deductions - 500000;
                        }
                        else
                        {
                            model1.Taxable_Pay = 0;
                        }
                        Console.WriteLine("Taxable_Pay " + model1.Taxable_Pay);
                        if (model1.Basic_Pay <= 500000)
                        {
                            model1.Tax = 0;
                        }
                        if (model1.Basic_Pay > 500000 && model1.Basic_Pay <= 1000000)
                        {
                            model1.Tax = model1.Taxable_Pay * 0.10;
                        }
                        if (model1.Basic_Pay > 1000000 && model1.Basic_Pay <= 2000000)
                        {
                            model1.Tax = model1.Taxable_Pay * 0.20;
                        }
                        if (model1.Basic_Pay > 2000000)
                        {
                            model1.Tax = model1.Taxable_Pay * 0.30;
                        }
                        Console.WriteLine("Tax " + model1.Tax);
                        model1.Net_Pay = model1.Basic_Pay - model1.Deductions - model1.Tax;
                        Console.WriteLine("Net_Pay " + model1.Net_Pay);
                        Console.WriteLine("Enter id");
                        model1.id = Convert.ToInt32(Console.ReadLine());
                        repository.UpdateSalaryStoredProcedure(model1.Basic_Pay, model1.Deductions, model1.Taxable_Pay, model1.Tax, model1.Net_Pay,model1.id);
                        break;
                    case 5:
                        EmployeeModel model2 = new EmployeeModel();
                        Console.WriteLine("Enter the Name");
                        model2.Name = Console.ReadLine();
                        repository.GetDataByName(model2.Name);
                        break;
                    case 6:
                        Console.WriteLine("Enter Starting date");
                        string startdate1 = Console.ReadLine();
                        Console.WriteLine("Enter End date");
                        string enddate = Console.ReadLine();
                        repository.JoinedBetweenDate(startdate1, enddate);
                        break;
                }
                break;
            }
        }
    }
}