namespace Artists
{
    public class EmployeeService
    {

        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void AddEmployee(Employee employee)
        {
            if (employee != null)
            {

                _employeeRepository.AddEmployee(employee);
                _employeeRepository.SaveChanges();
            }
        }

        public IList<Employee> GetAllEmployees()
        {
            return _employeeRepository.GetAllEmployees().ToList();
        }

        public Employee GetEmployeeByLastName(string name)
        {
            Employee employeeResult = null;
            if (!String.IsNullOrWhiteSpace(name))
            {
                employeeResult = _employeeRepository.GetEmployeeByLastName(name);
            }

            return employeeResult;
        }
    }
}