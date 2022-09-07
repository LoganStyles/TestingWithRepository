using System.Collections.Generic;
using System.Linq;
using Moq;
using Xunit;

namespace Artists.Test
{
    public class EmployeeServiceTests
    {
        [Fact]
        public void GetEmployeeByLastName_WhenCalled_ReturnsAnEmployee()
        {

            //Arrange
            var employee = new Employee { FirstName = "Campbell", LastName = "Akpan", Age = 36 };

            var repositoryMock = new Mock<IEmployeeRepository>();
            repositoryMock.Setup(repo => repo.GetEmployeeByLastName("Akpan"))
            .Returns(employee);

            var service = new EmployeeService(repositoryMock.Object);

            //Act
            var selectedEmployee = service.GetEmployeeByLastName("Akpan");

            //Assert
            repositoryMock.Verify(repo => repo.GetEmployeeByLastName("Akpan"));
            Assert.Equal("Campbell", selectedEmployee.FirstName);
        }

        [Fact]
        public void GetAllEmployees_WhenCalled_ReturnsAllEmployees()
        {

            //Arrange
            var employees = new List<Employee> {
            new Employee { FirstName = "Joe", LastName = "Rock", Age = 36 },
            new Employee { FirstName = "Martha", LastName = "Lucas", Age = 40 },
            new Employee { FirstName = "Jules", LastName = "Abrams", Age = 19 }
        };

            var repositoryMock = new Mock<IEmployeeRepository>();
            repositoryMock.Setup(repo => repo.GetAllEmployees()).Returns(employees);

            var service = new EmployeeService(repositoryMock.Object);

            //Act
            var selectedEmployees = service.GetAllEmployees();

            //Assert
            repositoryMock.Verify(repo => repo.GetAllEmployees());
            Assert.Equal(3, selectedEmployees.Count());
            Assert.Equal("Joe", selectedEmployees[0].FirstName);
            Assert.Equal("Martha", selectedEmployees[1].FirstName);
            Assert.Equal("Jules", selectedEmployees[2].FirstName);
        }

        [Fact]
        public void AddEmployee_WhenCalled_InsertsAnEmployee()
        {

            //Arrange
            var employee = new Employee { FirstName = "Connelly", LastName = "Brandy", Age = 19 };

            var repositoryMock = new Mock<IEmployeeRepository>();

            var service = new EmployeeService(repositoryMock.Object);

            //Act
            service.AddEmployee(employee);

            //Assert
            repositoryMock.Verify(repo => repo.AddEmployee(It.IsAny<Employee>()));
            repositoryMock.Verify(repo => repo.SaveChanges());
        }
    }
}