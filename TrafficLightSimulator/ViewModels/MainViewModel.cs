using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TrafficLightSimulator.Helpers;
using TrafficLightSimulator.Model;
using TrafficLightSimulator.ViewModels.Base;

namespace TrafficLightSimulator.ViewModels {
    public class MainViewModel : BaseViewModel {

        #region Private Members
        
        private TrafficLight mTrafficLightObject;

        private ICommand mOpenSettings { get; set; }

        /// <summary>
        /// The Window this view model controls
        /// </summary>
        private Window mWindow;
        
        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        private int mOuterMarginSize = 5;
        
        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        private int mWindowRadius = 0;

        #endregion
        
        #region Window Toolbar

        /// <summary>
        /// The size of the resize border around the window
        /// </summary>
        public int ResizeBorder { get; set; } = 6;

        /// <summary>
        /// The size of the resize border, taking into account the outer margin
        /// </summary>
        public Thickness ResizeBorderThickness {
            get {
                return new Thickness(ResizeBorder + OuterMarginSize);
            }
        }

        /// <summary>
        /// The padding of the inner content of the main window
        /// </summary>
        public Thickness InnerContentPadding {
            get {
                return new Thickness(ResizeBorder);
            }
        }

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        public int OuterMarginSize {
            get {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mOuterMarginSize;
            }
            set {
                mOuterMarginSize = value;
            }
        }

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        public Thickness OuterMarginSizeThickness {
            get {
                return new Thickness(OuterMarginSize);
            }
        }

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        public int WindowRadius {
            get {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mWindowRadius;
            }
            set {
                mWindowRadius = value;
            }
        }

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        public CornerRadius WindowCornerRadius {
            get {
                return new CornerRadius(WindowRadius);
            }
        }

        /// <summary>
        /// The height of the title bar / caption of the window
        /// </summary>
        public int TitleHeight { get; set; } = 35;

        /// <summary>
        /// The height of the title bar / caption of the window
        /// </summary>
        public GridLength TitleHeightGridLength {
            get {
                return new GridLength(TitleHeight + ResizeBorder);
            }
        }
        
        #endregion
        
        #region Commands for Controls
        
        /// <summary>
        /// The command to minimize the window
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        /// The command to maximize the window
        /// </summary>
        public ICommand MaximizeCommand { get; set; }

        /// <summary>
        /// The command to close the window
        /// </summary>
        public ICommand CloseCommand { get; set; }

        #endregion
        
        public TrafficLight TrafficLightObject {
            get {
                return mTrafficLightObject;
            }
            set {
                mTrafficLightObject = value;
                RaisePropertyChanged();
            }
        }
        
        /// <summary>
        /// Default constructor
        /// </summary>
        public MainViewModel(Window window) {
            
            mWindow = window;

            // Listen out for the window resizing
            mWindow.StateChanged += (sender, e) => {
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
            };

            // Create commands for controls
            MinimizeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(CloseWindow);
            
            if(File.Exists("Settings.json")) {
                using (StreamReader file = File.OpenText("Settings.json")) {
                    JsonSerializer serializer = new JsonSerializer();
                    TrafficLightObject = (TrafficLight)serializer.Deserialize(file, typeof(TrafficLight));
                }
                // TrafficLightObject = JsonConvert.DeserializeObject<TrafficLight>(File.ReadAllText("Settings.json"));
            } else {
                TrafficLightObject = new TrafficLight();
            }
            
            TrafficLightObject.RedTimer = new DispatcherTimer(DispatcherPriority.Render);
            TrafficLightObject.RedTimer.Interval = TimeSpan.FromSeconds(1);
            TrafficLightObject.RedTimer.Tick += (sender, args) => {
                if (TrafficLightObject.DurationRed.TimeRemaining > TimeSpan.Zero) {
                    TrafficLightObject.DurationRed.TimeRemaining = TrafficLightObject.DurationRed.TimeRemaining.Subtract(TimeSpan.FromSeconds(1));
                } else {
                    TrafficLightObject.RedTimer.Stop();
                    TrafficLightObject.YellowTimer.Start();
                    TrafficLightObject.SetYellowLight();
                }
            };
            TrafficLightObject.LaunchTimers();

            TrafficLightObject.YellowTimer = new DispatcherTimer(DispatcherPriority.Render);
            TrafficLightObject.YellowTimer.Interval = TimeSpan.FromSeconds(1);
            TrafficLightObject.YellowTimer.Tick += (sender, args) => {
                if (TrafficLightObject.DurationYellow.TimeRemaining > TimeSpan.Zero) {
                    TrafficLightObject.DurationYellow.TimeRemaining = TrafficLightObject.DurationYellow.TimeRemaining.Subtract(TimeSpan.FromSeconds(1));
                } else {
                    TrafficLightObject.YellowTimer.Stop();
                    TrafficLightObject.GreenTimer.Start();
                    TrafficLightObject.SetGreenLight();
                }
            };

            TrafficLightObject.GreenTimer = new DispatcherTimer(DispatcherPriority.Render);
            TrafficLightObject.GreenTimer.Interval = TimeSpan.FromSeconds(1);
            TrafficLightObject.GreenTimer.Tick += (sender, args) => {
                if (TrafficLightObject.DurationGreen.TimeRemaining > TimeSpan.Zero) {
                    TrafficLightObject.DurationGreen.TimeRemaining = TrafficLightObject.DurationGreen.TimeRemaining.Subtract(TimeSpan.FromSeconds(1));
                } else {
                    TrafficLightObject.GreenTimer.Stop();
                    // Restoring initial durations
                    TrafficLightObject.DurationRed.TimeRemaining = TrafficLightObject.DurationRed.Value;
                    TrafficLightObject.DurationYellow.TimeRemaining = TrafficLightObject.DurationYellow.Value;
                    TrafficLightObject.DurationGreen.TimeRemaining = TrafficLightObject.DurationGreen.Value;
                    TrafficLightObject.RedTimer.Start();
                    TrafficLightObject.SetRedLight();
                }
            };
        }

        public ICommand OpenSettings {
            get {
                if (mOpenSettings == null)
                    mOpenSettings = new RelayCommand<TrafficLight>(OpenSettingsWindow);
                return mOpenSettings;
            }
        }

        private void OpenSettingsWindow(TrafficLight trafficLight) {
            var settingsWindow = new SettingsWindow();
            var settingsViewModel = new SettingsViewModel(settingsWindow) {
                TrafficLightInfo = trafficLight,
            };
            settingsWindow.DataContext = settingsViewModel;
            settingsWindow.Show();
        }

        /// <summary>
        /// Handle closing window and saving data
        /// </summary>
        private void CloseWindow() {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;

            using (StreamWriter sw = new StreamWriter("Settings.json")) {
                using (JsonWriter writer = new JsonTextWriter(sw)) {
                    serializer.Serialize(writer, TrafficLightObject);
                }
            }
            // File.WriteAllText("Settings.json", JsonConvert.SerializeObject(TrafficLightObject));
            mWindow.Close();
        }
    }
}
