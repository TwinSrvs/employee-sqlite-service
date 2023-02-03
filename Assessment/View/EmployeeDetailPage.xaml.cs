using Assessment.DbConnect;
using Assessment.ViewModels;
using Xamarin.Forms;

namespace Assessment.View
{
    public partial class EmployeeDetailPage : ContentPage
    {
        #region CONSTRUCTION

        public EmployeeDetailPage(EmployeeViewModel viewModel)
        {
            InitializeComponent();
            var employeeStore = new SQLiteEmployeeLogs(DependencyService.Get<ISQLiteDb>());
            var navigationService = new NavigationService();
            Title = (viewModel.EmployeeId == null) ? "New Employee" : "Edit Employee Details";
            BindingContext = new EmployeeDetailViewModel(viewModel ?? new EmployeeViewModel(), employeeStore, navigationService);
        }

        #endregion
    }
}