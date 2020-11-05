using System;
using TrafficLightSimulator.ViewModels.Base;
using System.Windows.Threading;
using Newtonsoft.Json;

namespace TrafficLightSimulator.Model {
    public class TrafficLight : BaseViewModel {

        private Mode mModeOperation;

        private bool mRedOn;
        private bool mYellowOn;
        private bool mGreenOn;

        private DurationColor mDurationRed;
        private DurationColor mDurationYellow;
        private DurationColor mDurationGreen;

        private DispatcherTimer mRedTimer;
        private DispatcherTimer mYellowTimer;
        private DispatcherTimer mGreenTimer;

        public Mode ModeOperation {
            get {
                return mModeOperation;
            }
            set {
                mModeOperation = value;
                if (mModeOperation.Value == "Manual") RefreshTimers();
                RaisePropertyChanged();
            }
        }

        public int ModeIndex {
            get {
                return ModeOperation.Id - 1;
            }
            set {}
        }

        public bool RedOn {
            get {
                return mRedOn;
            }
            set {
                mRedOn = value;
                RaisePropertyChanged();
            }
        }

        public bool YellowOn {
            get {
                return mYellowOn;
            }
            set {
                mYellowOn = value;
                RaisePropertyChanged();
            }
        }


        public bool GreenOn {
            get {
                return mGreenOn;
            }
            set {
                mGreenOn = value;
                RaisePropertyChanged();
            }
        }

        public DurationColor DurationRed {
            get {
                return mDurationRed;
            }
            set {
                mDurationRed = value;
                RaisePropertyChanged();
            }
        }

        public DurationColor DurationYellow {
            get {
                return mDurationYellow;
            }
            set {
                mDurationYellow = value;
                RaisePropertyChanged();
            }
        }

        public DurationColor DurationGreen {
            get {
                return mDurationGreen;
            }
            set {
                mDurationGreen = value;
                RaisePropertyChanged();
            }
        }

        [JsonIgnore]
        public DispatcherTimer RedTimer {
            get {
                return mRedTimer;
            }
            set {
                mRedTimer = value;
                RaisePropertyChanged();
            }
        }

        [JsonIgnore]
        public DispatcherTimer YellowTimer {
            get {
                return mYellowTimer;
            }
            set {
                mYellowTimer = value;
                RaisePropertyChanged();
            }
        }
        
        [JsonIgnore]
        public DispatcherTimer GreenTimer {
            get {
                return mGreenTimer;
            }
            set {
                mGreenTimer = value;
                RaisePropertyChanged();
            }
        }

        public TrafficLight() {
            RedOn = false;
            YellowOn = false;
            GreenOn = false;
            DurationRed = new DurationColor(new TimeSpan(0, 0, 10));
            DurationYellow = new DurationColor(new TimeSpan(0, 0, 5));
            DurationGreen = new DurationColor(new TimeSpan(0, 0, 10));
            ModeOperation = new Mode(1, "Automatic");
        }
        
        public TrafficLight(DurationColor durationRed, DurationColor durationYellow, DurationColor durationGreen, Mode mode) {
            RedOn = false;
            YellowOn = false;
            GreenOn = false;
            DurationRed = durationRed;
            DurationYellow = durationYellow;
            DurationGreen = durationGreen;
            ModeOperation = mode;
        }

        public void LaunchTimers() {
            RedTimer.Start();
            SetRedLight();
        }

        public void RefreshTimers() {
            if(RedTimer.IsEnabled)
                RedTimer.Stop();
            
            if(YellowTimer.IsEnabled)
                YellowTimer.Stop();
            
            if(GreenTimer.IsEnabled)
                GreenTimer.Stop();
            
            RedOn = false;
            YellowOn = false;
            GreenOn = false;
            
            DurationRed.TimeRemaining = DurationRed.Value;
            DurationYellow.TimeRemaining = DurationYellow.Value;
            DurationGreen.TimeRemaining = DurationGreen.Value;
        }

        public void SetRedLight() {
            RedOn = true;
            YellowOn = false;
            GreenOn = false;
        }

        public void SetYellowLight() {
            RedOn = false;
            YellowOn = true;
            GreenOn = false;
        }

        public void SetGreenLight() {
            RedOn = false;
            YellowOn = false;
            GreenOn = true;
        }

    }
}
