namespace Artists
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly ArtistsContext _context;
        public EmployeeRepository(ArtistsContext context)
        {
            _context = context;
        }
        public void AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _context.Employees;
        }

        public Employee GetEmployeeByLastName(string name)
        {
            return _context.Employees
                    .FirstOrDefault(emp => emp.LastName == name);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}