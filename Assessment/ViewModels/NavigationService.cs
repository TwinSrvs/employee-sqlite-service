using System.Threading.Tasks;
using Xamarin.Forms;

namespace Assessment.ViewModels
{
    public class NavigationService : INavigationService
    {
        #region METHODS

        public async Task PushAsync(Page page)
        {
            await MainPage.Navigation.PushAsync(page);
        }

        public async Task<Page> PopAsync()
        {
            return await MainPage.Navigation.PopAsync();
        }

        public async Task DisplayAlert(string title, string message, string ok)
        {
            await MainPage.DisplayAlert(title, message, ok);
        }

        public async Task<bool> DisplayAlert(string title, string message, string ok, string cancel)
        {
            return await MainPage.DisplayAlert(title, message, ok, cancel);
        }

        #endregion

        #region PRIVATE METHODS

        private Page MainPage
        {
            get { return Application.Current.MainPage; }
        }

        #endregion
    }
}