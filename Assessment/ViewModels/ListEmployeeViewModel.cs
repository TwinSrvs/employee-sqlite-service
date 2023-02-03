using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Assessment.Models;
using Assessment.View;
using Xamarin.Forms;

namespace Assessment.ViewModels
{
    public class ListEmployeeViewModel : EmployeeBaseViewModel
    {
        #region PROPERTIES

        public EmployeeViewModel SelectedEmployee
        {
            get { return _selectedEmployee; }
            set { SetValue(ref _selectedEmployee, value); }
        }
        private EmployeeViewModel _selectedEmployee;

        public ObservableCollection<EmployeeViewModel> Employees { get; private set; }
            = new ObservableCollection<EmployeeViewModel>();

        #endregion

        #region COMMANDS

        public ICommand LoadDataCommand { get; private set; }

        public ICommand AddEmployeeDetailCommand { get; private set; }

        public ICommand SelectEmployeeCommand { get; private set; }

        public ICommand DeleteEmployeeCommand { get; private set; }

        #endregion

        #region CONSTRUCTION

        public ListEmployeeViewModel(IEmployeeLog employeeLog, INavigationService navigationService)
        {
            _employeeLog = employeeLog;
            _navigationService = navigationService;

            LoadDataCommand = new Command(async () => await LoadData());
            AddEmployeeDetailCommand = new Command(async () => await AddEmployeeDetails());
            SelectEmployeeCommand = new Command<EmployeeViewModel>(async emp => await SelectEmployee(emp));
            DeleteEmployeeCommand = new Command<EmployeeViewModel>(async emp => await DeleteEmployee(emp));


            MessagingCenter.Subscribe<EmployeeDetailViewModel, Employee>(this, ActionPerformed.EmployeeAdded, OnEmployeeAdded);

            MessagingCenter.Subscribe<EmployeeDetailViewModel, Employee>(this, ActionPerformed.EmployeeUpdated, OnEmployeeUpdated);
        }

        #endregion

        #region PRIVATE METHODS

        private async Task LoadData()
        {
            if (_isDataLoaded)
                return;

            _isDataLoaded = true;
            var employees = await _employeeLog.GetEmployeesListAsync();
            foreach (var employee in employees)
            {
                await employee.PopulateFromResponse();

                Employees.Add(new EmployeeViewModel(employee));
               
            }
        }

        private async Task AddEmployeeDetails()
        {
            await _navigationService.PushAsync(new EmployeeDetailPage(new EmployeeViewModel()));
        }

        private async Task SelectEmployee(EmployeeViewModel employee)
        {
            if (employee == null)
                return;

            SelectedEmployee = null;
            await _navigationService.PushAsync(new EmployeeDetailPage(employee));
        }

        private async Task DeleteEmployee(EmployeeViewModel employeeViewModel)
        {
            if (await _navigationService.DisplayAlert("Warning", $"Are you sure you want to delete {employeeViewModel.FullName}?", "Yes", "No"))
            {
                Employees.Remove(employeeViewModel);

                var employee = await _employeeLog.FetchEmployeeDetails(employeeViewModel.Id);
                await _employeeLog.DeleteEmployeeDetails(employee);
            }
        }

        private void OnEmployeeAdded(EmployeeDetailViewModel viewModel, Employee employee)
        {
            Employees.Add(new EmployeeViewModel(employee));
        }

        private void OnEmployeeUpdated(EmployeeDetailViewModel viewModel, Employee employee)
        {
            var employeeInList = Employees.Single(emp => emp.Id == employee.Id);

            employeeInList.Id = employee.Id;
            employeeInList.FirstName = employee.FirstName;
            employeeInList.LastName = employee.LastName;
            employeeInList.Phone = employee.Phone;
            employeeInList.Email = employee.Email;
            employeeInList.Department = employee.Department;
            employeeInList.EmployeeId = employee.EmployeeId;
        }

        #endregion

        #region FIELDS

        private IEmployeeLog _employeeLog;

        private INavigationService _navigationService;

        private bool _isDataLoaded;

        #endregion
    }
}