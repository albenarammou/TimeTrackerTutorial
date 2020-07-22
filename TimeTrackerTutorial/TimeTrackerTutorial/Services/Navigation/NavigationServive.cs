using System.Threading.Tasks;
using TimeTrackerTutorial.PageModels.Base;
using Xamarin.Forms;

namespace TimeTrackerTutorial.Services
{
    public class NavigationServive : INavigationService
    {
        public Task GoBackAsync()
        {
            return App.Current.MainPage.Navigation.PopAsync();
        }

        public async Task NavigateToAsync<TPageModel>(object navigationData = null, bool setRoot = false)
            where TPageModel : PageModelBase
        {
            Page page = PageModelLocator.CreatePageFor(typeof(TPageModel));

            if (setRoot)
            {
                if (page is TabbedPage tabbedPage)
                {
                    App.Current.MainPage = tabbedPage;
                }
                else
                {
                    App.Current.MainPage = new NavigationPage(page);
                }
            }
            else
            {
                if (page is TabbedPage tabPage)
                {
                    App.Current.MainPage = tabPage;
                }
                else if (App.Current.MainPage is NavigationPage navPage)
                {
                    await navPage.PushAsync(page);
                }
                else if (App.Current.MainPage is TabbedPage tabbedPage)
                {
                    if (tabbedPage.CurrentPage is NavigationPage nPage)
                    {
                        await nPage.PushAsync(page);
                    }
                }
                else
                {
                    App.Current.MainPage = new NavigationPage(page);
                }
            }
            if (page.BindingContext is PageModelBase pmBase)
            {
                await pmBase.InitializeAsync(navigationData);
            }
        }
    }
}
