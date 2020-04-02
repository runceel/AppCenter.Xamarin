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

        public string AppVersion => VersionTracking.CurrentVersion;

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

        public MainPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IAppCenterLogger appCenterLogger)
            : base(navigationService)
        {
            Title = "App Center demo app";
            _pageDialogService = pageDialogService;
            _appCenterLogger = appCenterLogger;
        }
    }
}
