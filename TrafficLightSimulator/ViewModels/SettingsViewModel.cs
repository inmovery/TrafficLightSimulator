using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Newtonsoft.Json.Converters;
using TrafficLightSimulator.Model;
using TrafficLightSimulator.ViewModels.Base;

namespace TrafficLightSimulator.ViewModels {
    public class SettingsViewModel : BaseViewModel {

        #region Private Members
        
        private ICommand mApplyChanges { get; set; }
        
        private ICommand mEnableRedLight { get; set; }
        
        private ICommand mEnableYellowLight { get; set; }
        
        private ICommand mEnableGreenLight { get; set; }
        
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
        
        public TrafficLight TrafficLightInfo { get; set; }

        /// <summary>
        /// The collection of modes for live updating items
        /// </summary>
        public ObservableCollection<Mode> Modes { get; set; }

        /// <summary>
        /// The colletcion of modes to display items for
        /// </summary>
        public ICollectionView ModesView { get; set; }

        public Mode Mode { get; set; }
        
        public SettingsViewModel(Window window) {
            
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
            
            List<Mode> modes = new List<Mode>();
            modes.Add(new Mode(1, "Automatic"));
            modes.Add(new Mode(2, "Manual"));

            Modes = new ObservableCollection<Mode>(modes);
            BindingOperations.EnableCollectionSynchronization(Modes, new object());
            ModesView = CollectionViewSource.GetDefaultView(Modes);
        }
        
        public ICommand ApplyChanges {
            get {
                if (mApplyChanges == null)
                    mApplyChanges = new RelayCommand(DoApplyChanges);
                return mApplyChanges;
            }
        }
        
        public ICommand EnableRedLight {
            get {
                if (mEnableRedLight == null)
                    mEnableRedLight = new RelayCommand(DoEnableRedLight);
                return mEnableRedLight;
            }
        }
        
        public ICommand EnableYellowLight {
            get {
                if (mEnableYellowLight == null)
                    mEnableYellowLight = new RelayCommand(DoEnableYellowLight);
                return mEnableYellowLight;
            }
        }
        
        public ICommand EnableGreenLight {
            get {
                if (mEnableGreenLight == null)
                    mEnableGreenLight = new RelayCommand(DoEnableGreenLight);
                return mEnableGreenLight;
            }
        }
        
        private void DoApplyChanges() {
            if(TrafficLightInfo.RedTimer.IsEnabled)
                TrafficLightInfo.RedTimer.Stop();
            
            if(TrafficLightInfo.YellowTimer.IsEnabled)
                TrafficLightInfo.YellowTimer.Stop();
            
            if(TrafficLightInfo.GreenTimer.IsEnabled)
                TrafficLightInfo.GreenTimer.Stop();
            
            TrafficLightInfo.RedOn = false;
            TrafficLightInfo.YellowOn = false;
            TrafficLightInfo.GreenOn = false;
            
            TrafficLightInfo.DurationRed.TimeRemaining = TrafficLightInfo.DurationRed.Value;
            TrafficLightInfo.DurationYellow.TimeRemaining = TrafficLightInfo.DurationYellow.Value;
            TrafficLightInfo.DurationGreen.TimeRemaining = TrafficLightInfo.DurationGreen.Value;
            
            TrafficLightInfo.LaunchTimers();
        }

        private void DoEnableRedLight() {
            TrafficLightInfo.RedOn = true;
            TrafficLightInfo.YellowOn = false;
            TrafficLightInfo.GreenOn = false;
        }

        private void DoEnableYellowLight() {
            TrafficLightInfo.RedOn = false;
            TrafficLightInfo.YellowOn = true;
            TrafficLightInfo.GreenOn = false;
        }

        private void DoEnableGreenLight() {
            TrafficLightInfo.RedOn = false;
            TrafficLightInfo.YellowOn = false;
            TrafficLightInfo.GreenOn = true;
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
                    serializer.Serialize(writer, TrafficLightInfo);
                }
            }
            // File.WriteAllText("Settings.json", JsonConvert.SerializeObject(TrafficLightObject));
            mWindow.Close();
        }

    }
}
