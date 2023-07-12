using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotNet
{
    internal class EmployeeDBOperations
    {
        private SqlConnection sqlConnection;

        public EmployeeDBOperations(string connectionString)
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public bool AddEmployee(Employee employee)
        {
            try
            {
                sqlConnection.Open();

                string insertQuery = $"Insert into Employees Values ('{employee.Name}',{employee.Age},'{employee.Email}')";
                SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);

                int result = insertCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine($"{result} number of rows affected.");
                }
                else
                {
                    Console.WriteLine("Error!!! Invalid Query.");
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public bool UpdateEmployee(int id, Employee employee)
        {
            try
            {
                sqlConnection.Open();

                string query = $"UPDATE Employees SET Name = '{employee.Name}' WHERE Id={id}";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                int result = sqlCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine($"{result} number of rows affected");
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
        }


        public bool DeleteEmployee(int id)
        {
            try
            {
                sqlConnection.Open();

                string query = $"DELETE FROM Employees WHERE Id = {id}";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                int result = sqlCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine($"{result} number of rows affected.");
                }
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public Employee GetEmployeeByID(int id)
        {
            sqlConnection.Open();

            string query = $"select * from Employees where Id = {id}";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.HasRows)
            {
                Employee employee = new()
                {
                    Id = (int)reader["Id"],
                    Name = (string)reader["Name"],
                    Age = (int)reader["Age"],
                    Email = (string)reader["Email"]
                };

                Console.WriteLine($"Id: {employee.Id}\t Name: {employee.Name}\t Age: {employee.Age}\t Email: {employee.Email}");
                sqlConnection.Close();
                return employee;
            }
            sqlConnection.Close();
            return null;
        }

        public List<Employee> GetAllEmployee()
        {
            sqlConnection.Open();

            List<Employee> list = new List<Employee>();
            
            string query = $"SELECT * From Employees";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                Employee emp = new Employee()
                {
                    Id = (int)reader["Id"],
                    Name = (string)reader["Name"],
                    Age = (int)reader["Age"],
                    Email = (string)reader["Email"]
                };
                list.Add(emp);
            }

            foreach(Employee employee in list)
            {
                Console.WriteLine($"Id: {employee.Id}\t Name: {employee.Name}\t Age: {employee.Age}\t Email: {employee.Email}");
            }
            sqlConnection.Close();
            return list;
        }

    }
}
