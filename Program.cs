namespace Lab_7_______OOP_Generic_collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee1 = new Employee(1, "Parman Gitijah", "Man", 10000);
            Employee employee2 = new Employee(3, "Omar Al-Farsi", "Man", 11000);
            Employee employee3 = new Employee(4, "Emily Johansson", "Kvinna", 10500);
            Employee employee4 = new Employee(5, "Rajesh Kumar", "Man", 11500);
            Employee employee5 = new Employee(6, "Sara Martinez", "Kvinna", 10800);


            Stack<Employee> employeeStack = new Stack<Employee>();
            AddEmployeesToStack(employeeStack, employee1, employee2, employee3, employee4, employee5);
            ShowEmployeesInStack(employeeStack);

            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.WriteLine("Nu har alla employees visats. Om några sekunder ska alla employees visas med Pop metoden!");
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Thread.Sleep(3000);

            // Ta bort anställda med Pop() och sparar i en resärvstack
            Stack<Employee> employeesStackReserve = PopEmployees(employeeStack);

            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.WriteLine("Nu har alla employees visats och tagits bort och lagts till i annan stack! Nu ska de läggas tillbaka om några sekunder!");
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Thread.Sleep(3000);

            // Lägger tillbaka alla anställda i den ursprungliga stacken
            PushEmployeesBack(employeeStack, employeesStackReserve);

            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------------------------------------");
            Console.WriteLine("Nu har alla employees lagtstill i tidigare stacken! Nu ska vi se de två översta anställda!");
            Console.WriteLine("------------------------------------------------------------------------------------------");
            Thread.Sleep(3000);

            Console.WriteLine($"Det finns {employeeStack.Count} anställda kvar i stacken.");

            // Första Peek
            var topEmployee1 = employeeStack.Peek();
            Console.WriteLine(topEmployee1);
            Console.WriteLine($"Det finns {employeeStack.Count} anställda kvar i stacken.");

            // Andra Peek
            var topEmployee2 = employeeStack.Peek();
            Console.WriteLine(topEmployee2);
            Console.WriteLine($"Det finns {employeeStack.Count} anställda kvar i stacken.");


            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Nu kontrollerar vi om anställd nummer 3 finns med i stacken!");
            Console.WriteLine("------------------------------------------------------------");
            Thread.Sleep(3000);

            //Funktion för att se om anställd nummer 3 finns med i stacken!
            AvailableInStack(employeeStack, employee2);

            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Nu Ska vi skapa Lista och lägga till anställda i det!");
            Console.WriteLine("-----------------------------------------------------");
            Thread.Sleep(3000);

            List<Employee> employeesList = new List<Employee>();

            employeesList.AddRange(new List<Employee> { employee1, employee2, employee3, employee4, employee5 });

            ListContains(employeesList, employee2);



        }

        // Funktion för Del2 av uppgiften
        static void ListContains(List<Employee> employeeList, Employee employee2)
        {
            bool exist = employeeList.Contains(employee2);

            if (exist == true)
            {
                Console.WriteLine("Employee2 object exists in the list");
                Console.WriteLine($"Employee nummer 2 är: {employee2.EmployeeName}");
            }
            else
            {
                Console.WriteLine("Employee2 object does not exist in the list");
            }
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------");

            Employee employeeFound = employeeList.Find(e => e.EmployeeGender == "Man");

            if (employeeFound != null)
            {
                Console.WriteLine("Första anställda som är Man är: " + employeeFound);
            }
            else
            {
                Console.WriteLine("Ingen anställd hittades!");
            }

            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Nu ska vi se alla anställda som är Man");
            Console.WriteLine("-----------------------------------------------------");
            Thread.Sleep(3000);

            List<Employee> maleEmployees = employeeList.FindAll(e => e.EmployeeGender == "Man");

            if (maleEmployees.Count > 0) // Kontrollera om listan innehåller några objekt
            {
                Console.WriteLine("Alla anställda som är män:");
                foreach (var employee in maleEmployees)
                {
                    Console.WriteLine($"Id: {employee.EmployeeId}, Name: {employee.EmployeeName}, Gender: {employee.EmployeeGender}");
                }
            }
            else
            {
                Console.WriteLine("Ingen anställd hittades!");
            }
        }

        // Funktione för att lägga till employee i stacken med Push();
        static void AddEmployeesToStack(Stack<Employee> stack, params Employee[] employees)
        {
            foreach (var employee in employees)
            {
                stack.Push(employee);
            }
        }

        // Funktion för att visa Employees i stacken! Uppdaterar antalet redovisade efter varje redovisning!
        static void ShowEmployeesInStack(Stack<Employee> stack)
        {
            int totalEmployees = stack.Count;
            Console.WriteLine($"Det finns {totalEmployees}st employees att visa!");

            foreach (var employee in stack)
            {
                Console.WriteLine(employee);
                totalEmployees--;
                Console.WriteLine();
                Console.WriteLine($"Det finns {totalEmployees} anställda att redovisa!");
            }
        }

        // Funktion för att använda Pop() metoden!
        static Stack<Employee> PopEmployees(Stack<Employee> stack)
        {
            Stack<Employee> reserveStack = new Stack<Employee>();

            Console.WriteLine($"Det finns {stack.Count}st employees att visa!");
            while (stack.Count > 0)
            {
                var employee = stack.Pop();
                Console.WriteLine(employee);
                Console.WriteLine();
                Console.WriteLine($"Det finns {stack.Count} anställda kvar i stacken.");
                reserveStack.Push(employee);
            }

            return reserveStack;
        }

        // Funktion för att trycka tillbaka användare i ordinarie stacken från resärvstacken.
        static void PushEmployeesBack(Stack<Employee> stack, Stack<Employee> reserveStack)
        {
            while (reserveStack.Count > 0)
            {
                var employee = reserveStack.Pop();
                stack.Push(employee);
                Console.WriteLine($"Lagts tillbaka: {employee}");
            }
        }

        // Funktion för att se om employee2 finns med i stacken!
        static void AvailableInStack(Stack<Employee>employeeStack, Employee employee2)
        {
            bool exists = employeeStack.Contains(employee2); 
            if (exists)
            {
                Console.WriteLine("Anställd nummer 3 finns i stacken.");
                Console.WriteLine($"Anställd nummer 3 är: \"{employee2}\"");
            }
            else
            {
                Console.WriteLine("Anställd nummer 3 finns inte i stacken.");
            }
        }
    }
}