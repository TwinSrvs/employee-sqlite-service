using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Assessment.Models;
using Xamarin.Forms;

namespace Assessment.ViewModels
{
    public class EmployeeDetailViewModel
    {
        #region PROPERTIES

        public Employee Employee { get; private set; }

        #endregion

        #region COMMAND

        public ICommand SaveCommand { get; private set; }

        #endregion

        #region CONSTRUCTION

        public EmployeeDetailViewModel(EmployeeViewModel viewModel, IEmployeeLog employeeLog, INavigationService navigationService)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            _navigationService = navigationService;
            _employeeLog = employeeLog;

            SaveCommand = new Command(async () => await Save());

            Employee = new Employee
            {
                Id = viewModel.Id,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Phone = viewModel.Phone,
                Email = viewModel.Email,
                Department = viewModel.Department,
                EmployeeId = viewModel.EmployeeId
            };
        }

        #endregion

        #region METHODS

        async Task Save()
        {
            if (string.IsNullOrWhiteSpace(Employee.FirstName) && string.IsNullOrWhiteSpace(Employee.LastName))
            {
                await _navigationService.DisplayAlert("Error", "Please enter the name.", "OK");
                return;
            }

            if (Employee.Id == 0)
            {
                await _employeeLog.AddEmployeeDetails(Employee);
                MessagingCenter.Send(this, ActionPerformed.EmployeeAdded, Employee);
            }
            else
            {
                await _employeeLog.UpdateEmployeeDetails(Employee);
                MessagingCenter.Send(this, ActionPerformed.EmployeeUpdated, Employee);
            }
            await _navigationService.PopAsync();
        }

        #endregion

        #region FIELDS

        private readonly IEmployeeLog _employeeLog;

        private readonly INavigationService _navigationService;

        #endregion
    }
}