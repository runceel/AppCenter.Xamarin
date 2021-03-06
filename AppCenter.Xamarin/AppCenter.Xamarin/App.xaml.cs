﻿using Prism;
using Prism.Ioc;
using AppCenter.Xamarin.ViewModels;
using AppCenter.Xamarin.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Logging;
using Microsoft.AppCenter.Distribute;
using Xamarin.Essentials;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AppCenter.Xamarin
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            VersionTracking.Track();
            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterRequiredTypes(IContainerRegistry containerRegistry)
        {
            base.RegisterRequiredTypes(containerRegistry);
            containerRegistry.RegisterSingleton<ILoggerFacade, DebugLogger>();
            containerRegistry.RegisterSingleton<IAppCenterLogger, AppCenterLogger>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
        }
    }
}
