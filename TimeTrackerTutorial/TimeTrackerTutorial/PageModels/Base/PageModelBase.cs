﻿using System.Threading.Tasks;

namespace TimeTrackerTutorial.PageModels.Base
{
    public class PageModelBase : ExtendedBindableObject
    {
        string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.CompletedTask;
        }

    }

}
