using Microsoft.AppCenter.Analytics;
using Prism.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AppCenter.Xamarin
{
    public interface IAppCenterLogger
    {
        void NavigatedToPage(string pageName);
    }

    public class AppCenterLogger : IAppCenterLogger
    {
        public void NavigatedToPage(string pageName)
        {
            TrackEvent(MakeParams((nameof(pageName), pageName)));
        }

        private static void TrackEvent(Dictionary<string, string> parameters, [CallerMemberName]string eventName = null) => 
            Analytics.TrackEvent(eventName, parameters);

        private static Dictionary<string, string> MakeParams(params (string key, string value)[] parameters) => 
            parameters?.ToDictionary(x => x.key, x => x.value);
    }
}
