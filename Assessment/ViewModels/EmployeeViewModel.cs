using System;
using Assessment.Models;
using Xamarin.Forms;

namespace Assessment.ViewModels
{
    public class EmployeeViewModel : EmployeeBaseViewModel
    {
        #region PROPERTIES

        public int Id { get; set; }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                SetValue(ref _firstName, value);
                OnPropertyChanged(nameof(FullName));
            }
        }
        private string _firstName;

        public string LastName
        {
            get { return _lastName; }
            set
            {
                SetValue(ref _lastName, value);
                OnPropertyChanged(nameof(FullName));
            }
        }
        private string _lastName;

        public string Phone
        {
            get { return _phone; }
            set
            {
                SetValue(ref _phone, value);
            }
        }
        private string _phone;

        public string Email
        {
            get { return _email; }
            set
            {
                SetValue(ref _email, value);
            }
        }
        private string _email;

        public string EmployeeId
        {
            get { return _employeeId; }
            set
            {
                SetValue(ref _employeeId, value);
            }
        }
        private string _employeeId;

        public string Department
        {
            get { return _department; }
            set
            {
                SetValue(ref _department, value);
            }
        }
        private string _department;

        public Uri ProfileImageSource { get; set; }

        #endregion

        #region CONSTRUCTION

        public EmployeeViewModel() { }

        public EmployeeViewModel(Employee employee)
        {
            Id = employee.Id;
            _firstName = employee.FirstName;
            _lastName = employee.LastName;
            Phone = employee.Phone;
            Email = employee.Email;
            Department = employee.Department;
            EmployeeId = employee.EmployeeId;
            //ProfileImageSource = new Uri(employee.Url);

        }

        #endregion

        #region METHODS

        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }

        #endregion
    }
}