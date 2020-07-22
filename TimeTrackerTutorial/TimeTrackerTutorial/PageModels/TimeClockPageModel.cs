using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TimeTrackerTutorial.Models;
using TimeTrackerTutorial.PageModels.Base;
using TimeTrackerTutorial.PageModels.Buttons;

namespace TimeTrackerTutorial.PageModels
{
    public class TimeClockPageModel : PageModelBase
    {
        TimeSpan _runningTotal;
        public TimeSpan RunningTotal
        {
            get => _runningTotal;
            set => SetProperty(ref _runningTotal, value);
        }

        DateTime _currentStartTime;
        public DateTime CurrentStartTime
        {
            get => _currentStartTime;
            set => SetProperty(ref _currentStartTime, value);
        }

        ObservableCollection<WorkItem> _workItems;
        public ObservableCollection<WorkItem> workItems
        {
            get => _workItems;
            set => SetProperty(ref _workItems, value);
        }

        Double _todayEarnings;
        public Double TodayEarnings
        {
            get => _todayEarnings;
            set => SetProperty(ref _todayEarnings, value);
        }

        ButtonModel _clockInOutButtonModel;
        public ButtonModel ClockInOutButtonModel
        {
            get => _clockInOutButtonModel;
            set => SetProperty(ref _clockInOutButtonModel, value);
        }

        public TimeClockPageModel()
        {
            workItems = new ObservableCollection<WorkItem>();
            ClockInOutButtonModel = new ButtonModel("Clock In", OnClockInOutAction);
        }

        public override Task InitializeAsync(object navigationData = null)
        {
            RunningTotal = new TimeSpan();
            return base.InitializeAsync(navigationData);
        }

        private void OnClockInOutAction()
        {
            throw new NotImplementedException();
        }
    }
}
