using System.Collections.Generic;
using System.Threading.Tasks;
using Assessment.DbConnect;
using Assessment.Models;
using SQLite;

namespace Assessment.ViewModels
{
    public class SQLiteEmployeeLogs : IEmployeeLog
    {
        #region CONSTRUCTION

        public SQLiteEmployeeLogs(ISQLiteDb db)
        {
            _connection = db.GetConnection();
            _connection.CreateTableAsync<Employee>();
        }

        #endregion

        #region METHODS

        public async Task<IEnumerable<Employee>> GetEmployeesListAsync() //Convert SQLite database to list
        {
            return await _connection.Table<Employee>().ToListAsync();
        }

        public async Task<Employee> FetchEmployeeDetails(int id) //Retreive an employee detail by using Id
        {
            return await _connection.FindAsync<Employee>(id);
        }

        public async Task AddEmployeeDetails(Employee employee) //Add employee details to database
        {
            await _connection.InsertAsync(employee);
        }

        public async Task UpdateEmployeeDetails(Employee employee) //Update the edited employee details in database
        {
            await _connection.UpdateAsync(employee);
        }

        public async Task DeleteEmployeeDetails(Employee employee) //Delete employee from database
        {
            await _connection.DeleteAsync(employee);
        }

        #endregion

        #region PRIVATE METHODS

        private SQLiteAsyncConnection _connection;

        #endregion
    }
}