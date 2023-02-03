using System.Collections.Generic;
using System.Threading.Tasks;
using Assessment.Models;

namespace Assessment.ViewModels
{
    public interface IEmployeeLog
    {
        #region METHODS

        Task<IEnumerable<Employee>> GetEmployeesListAsync();

        Task<Employee> FetchEmployeeDetails(int id);

        Task AddEmployeeDetails(Employee employee);

        Task UpdateEmployeeDetails(Employee employee);

        Task DeleteEmployeeDetails(Employee employee);

        #endregion
    }
}