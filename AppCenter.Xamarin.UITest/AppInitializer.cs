using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace AppCenter.Xamarin.UITest
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
#if !ENABLE_TEST_CLOUD
            System.IO.Directory.SetCurrentDirectory(
                System.IO.Path.GetDirectoryName(typeof(AppInitializer).Assembly.Location));
#endif
            if (platform == Platform.Android)
            {
                return ConfigureApp.Android
#if !ENABLE_TEST_CLOUD
                    .InstalledApp("jp.okazuki.appcenter.xamarin")
#endif
                    .StartApp();
            }

            return ConfigureApp.iOS.StartApp();
        }
    }
}