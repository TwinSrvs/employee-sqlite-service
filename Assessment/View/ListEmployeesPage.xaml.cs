using Assessment.DbConnect;
using Assessment.ViewModels;
using Xamarin.Forms;

namespace Assessment.View
{
    public partial class ListEmployeesPage : ContentPage
    {
        #region PROPERTIES

        public ListEmployeeViewModel ViewModel
        {
            get { return BindingContext as ListEmployeeViewModel; }
            set { BindingContext = value; }
        }

        #endregion

        #region CONSTRUCTION

        public ListEmployeesPage()
        {
            var employeeStore = new SQLiteEmployeeLogs(DependencyService.Get<ISQLiteDb>());
            var navigationService = new NavigationService();
            ViewModel = new ListEmployeeViewModel(employeeStore, navigationService);
            InitializeComponent();
        }

        #endregion

        #region OVERRIDES

        protected override void OnAppearing()
        {
            ViewModel.LoadDataCommand.Execute(null);
            base.OnAppearing();
        }

        #endregion

        #region EVENT HANDLER

        void OnEmployeeSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.SelectEmployeeCommand.Execute(e.SelectedItem);
        }

        #endregion
    }
}