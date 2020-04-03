using Microsoft.AppCenter.Crashes;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppCenter.Xamarin.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IPageDialogService _pageDialogService;
        private readonly IAppCenterLogger _appCenterLogger;

        private DelegateCommand<string> _notImplementedCommand;
        public DelegateCommand<string> NotImplementedCommand =>
            _notImplementedCommand ?? (_notImplementedCommand = new DelegateCommand<string>(ExecuteNotImplementedCommand));

        private void ExecuteNotImplementedCommand(string parameter)
        {
            _pageDialogService.DisplayAlertAsync("情報", $"{parameter}が押されました。", "閉じる");
            _appCenterLogger.NavigatedToPage(parameter);
        }

        private DelegateCommand _crashCommand;
        public DelegateCommand CrashCommand =>
            _crashCommand ?? (_crashCommand = new DelegateCommand(ExecuteCrashCommand));

        private void ExecuteCrashCommand()
        {
            throw new InvalidOperationException("Crash button was clicked");
        }

        private DelegateCommand _errorReportCommand;
        public DelegateCommand ErrorReportCommand =>
            _errorReportCommand ?? (_errorReportCommand = new DelegateCommand(ExecuteErrorReportCommand));

        private void ExecuteErrorReportCommand()
        {
            Crashes.TrackError(new InvalidOperationException("An error occurred."));
        }

        public string AppVersion => VersionTracking.CurrentVersion;
        public MainPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IAppCenterLogger appCenterLogger)
            : base(navigationService)
        {
            Title = "App Center demo app";
            _pageDialogService = pageDialogService;
            _appCenterLogger = appCenterLogger;
        }
    }
}
