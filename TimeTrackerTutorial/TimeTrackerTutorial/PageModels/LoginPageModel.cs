using System.Windows.Input;
using TimeTrackerTutorial.PageModels.Base;
using TimeTrackerTutorial.Services;
using TimeTrackerTutorial.Services.Account;
using Xamarin.Forms;

namespace TimeTrackerTutorial.PageModels
{
    public class LoginPageModel : PageModelBase
    {
        private ICommand _loginCommand;
        public ICommand LoginCommand
        {
            get => _loginCommand;
            set => SetProperty(ref _loginCommand, value);
        }
        private string _username;
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }
        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        private INavigationService _navigationService;
        private readonly IAccountService _accountservice;

        public LoginPageModel(INavigationService navigationService, IAccountService accountservice)
        {
            _navigationService = navigationService;
            _accountservice = accountservice;

            LoginCommand = new Command(DoLoginAction);
        }

        private async void DoLoginAction(object obj)
        {
            var loginAttempt = await _accountservice.LoginAsync(Username, Password);
            if (loginAttempt)
            {
                // navigate to the Dahboard
                await _navigationService.NavigateToAsync<DashboardPageModel>();
            }
            else
            {
                // TODO: Display an Alert for Failure
            }
        }
    }
}
