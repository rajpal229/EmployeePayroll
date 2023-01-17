using EmployeePayroll.Model;
using EmployeePayroll.Repository;

namespace EmployeePayrollTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            EmployeeRepository employee = new EmployeeRepository();
            string actual = employee.UpdateSalary();
            string Excepted = "Data Updated";
            Assert.AreEqual(Excepted, actual);
        }
        [TestMethod]
        public void TestMethod2()
        {
            EmployeeRepository employee = new EmployeeRepository();
            EmployeeModel model = new EmployeeModel();
            model.Basic_Pay = 350000;
            model.id = 4;
            model.Deductions = 0;
            if (model.Basic_Pay > 500000)
            {
                model.Taxable_Pay = model.Basic_Pay - model.Deductions - 500000;
            }
            else
            {
                model.Taxable_Pay = 0;
            }
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
            model.Net_Pay = model.Basic_Pay - model.Deductions - model.Tax;
            string actual = employee.UpdateSalaryStoredProcedure(model.Basic_Pay, model.Deductions, model.Taxable_Pay, model.Tax, model.Net_Pay, model.id);
            string Excepted = "Data Updated";
            Assert.AreEqual(Excepted, actual);
        }
    }
}