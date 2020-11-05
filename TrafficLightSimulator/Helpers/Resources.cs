using System.Windows;

namespace TrafficLightSimulator.Helpers {
    public class Resources {
        public static T Get<T>(string resourceName) where T : class {
            return Application.Current.TryFindResource(resourceName) as T;
        }
    }
}