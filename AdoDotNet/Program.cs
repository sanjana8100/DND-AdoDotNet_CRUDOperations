namespace AdoDotNet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source = SANJANA; Database = EmployeeDB; Integrated Security = true";
            EmployeeDBOperations employeeDBOperations = new EmployeeDBOperations(connectionString);

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("******************MENU:******************");
                Console.WriteLine("=> To Add an Employee: PRESS 1");
                Console.WriteLine("=> To Update an Existing Employee Details: PRESS 2");
                Console.WriteLine("=> To Delete an Employee: PRESS 3");
                Console.WriteLine("=> To Display a specific Employee Detail: PRESS 4");
                Console.WriteLine("=> To Display all Employees' Details: PRESS 5");
                Console.WriteLine("=> To EXIT: PRESS 6");

                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("Enter the details to add an employee: ");

                            Console.Write("\nEnter Name: ");
                            string name = Console.ReadLine();

                            Console.Write("Enter Age: ");
                            int age = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Enter E-mail: ");
                            string email = Console.ReadLine();;

                            Employee employee = new Employee(name, age, email);
                            employeeDBOperations.AddEmployee(employee);
                            
                            break;
                        }
                    case 2:
                        {
                            Console.Write("Enter the ID of the employee who's name you want to edit: ");
                            int id = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Enter the new name: ");
                            string newName = Console.ReadLine();

                            Employee employee = new Employee("newName");
                            employeeDBOperations.UpdateEmployee(id, employee);

                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Enter the ID of the employee you want to Delete: ");
                            int id = Convert.ToInt32(Console.ReadLine());

                            employeeDBOperations.GetEmployeeByID(id);

                            Console.WriteLine("Are you sure you want to DELETE the Contact?");
                            Console.WriteLine("1. YES \t 2. NO");
                            int option = Convert.ToInt32(Console.ReadLine());
                            switch (option)
                            {
                                case 1:
                                    employeeDBOperations.DeleteEmployee(id);
                                    break;
                                case 2:
                                    Console.WriteLine("Contact is NOT deleted!!!");
                                    break;
                                default:
                                    Console.WriteLine("Select a valid option!!!");
                                    break;
                            }

                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Enter the ID of the Contact you want to Display: ");
                            int id = Convert.ToInt32(Console.ReadLine());

                            Employee employee = employeeDBOperations.GetEmployeeByID(id);

                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Displaying the details of all the employees: ");
                            List<Employee> list = employeeDBOperations.GetAllEmployee();

                            break;
                        }
                    case 6:
                        {
                            Environment.Exit(0);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid Choice!!! Please make a valid choice.");
                            break;
                        }
                }
            }
        }
    }
}