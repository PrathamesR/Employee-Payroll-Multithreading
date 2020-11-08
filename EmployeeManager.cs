using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollMultiThreading
{
    class EmployeeManager
    {
        public static SqlConnection getConnect()
        {
            SqlConnection connection = new SqlConnection(@"Data Source='(LocalDB)\MSSQL Server';Initial Catalog = Payroll; Integrated Security = True");
            return connection;
        }
        public bool AddNewEmployee(string name, decimal basicPay, DateTime date, string department, string phoneNo, string address, char gender)
        {
            SqlConnection connection = null;
            try
            {
                connection = getConnect();
                using (connection)
                {
                    connection.Open();
                    Employee employee = new Employee();
                    SqlCommand command = new SqlCommand("AddNewEmployee", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@basicPay", basicPay);
                    command.Parameters.AddWithValue("@startDate", date.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@phoneNo", decimal.Parse(phoneNo));
                    command.Parameters.AddWithValue("@department", department);
                    command.Parameters.AddWithValue("@address", address);
                    command.Parameters.AddWithValue("@gender", gender);
                    command.Parameters.AddWithValue("@deductions", basicPay / 20);
                    command.Parameters.AddWithValue("@taxable_pay", basicPay - basicPay / 20);
                    command.Parameters.AddWithValue("@income_Tax", (basicPay - basicPay / 20) / 10);
                    command.Parameters.AddWithValue("@net_pay", basicPay - ((basicPay - basicPay / 20) / 10));

                    SqlDataReader dr = command.ExecuteReader();
                }
                return true;
            }
            catch (Exception e)
            {
                Console.Write(e.Message+e.StackTrace);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool AddNewEmployee(List<Employee> employees)
        {
            foreach (Employee x in employees)
            {
                Console.WriteLine("Employee being Added: " + x.EmployeeName);
                this.AddNewEmployee(x.EmployeeName, x.BasicPay, x.StartDate.Value, x.Department, x.PhoneNumber, x.Address, x.Gender);
                Console.WriteLine("Employee added: " + x.EmployeeName);
            }
            return true;
        }
    }
}
