using System.Threading.Tasks;
using TimeTrackerTutorial.PageModels.Base;

namespace TimeTrackerTutorial.Services
{
    public interface INavigationService
    {
        /// <summary>
        /// Navigation method to push onto the Navigation Stack
        /// </summary>
        /// <typeparam name="TPageModel"></typeparam>
        /// <param name="navigationData"></param>
        /// <param name="setRoot"></param>
        /// <returns></returns>

        Task NavigateToAsync<TPageModel>(object navigationData = null, bool setRoot = false)
            where TPageModel: PageModelBase;

        /// <summary>
        /// Navigation method to pop off the Navigation Stack
        /// </summary>
        /// <returns></returns>
        /// 
        Task GoBackAsync();
    }
}
