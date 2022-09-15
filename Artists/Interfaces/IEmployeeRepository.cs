namespace Artists
{
    public interface IEmployeeRepository
    {

        Employee GetEmployeeByLastName(string name);
        IEnumerable<Employee> GetAllEmployees();
        void AddEmployee(Employee employee);
        void SaveChanges();
    }
}