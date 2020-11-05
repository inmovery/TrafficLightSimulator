using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLightSimulator.ViewModels.Base;

namespace TrafficLightSimulator.Model {
    public class DurationColor : BaseViewModel {

        private TimeSpan mValue;
        private TimeSpan mTimeRemaining;

        public TimeSpan Value {
            get {
                return mValue;
            }
            set {
                mValue = value;
                RaisePropertyChanged();
            }
        }

        public TimeSpan TimeRemaining {
            get {
                return mTimeRemaining;
            }
            set {
                mTimeRemaining = value;
                RaisePropertyChanged();
            }
        }

        public DurationColor(TimeSpan timeValue) {
            Value = timeValue;
            TimeRemaining = timeValue;
        }

        public DurationColor() {
            Value = new TimeSpan();
            TimeRemaining = new TimeSpan();
        }
        
        public override string ToString() {
            return Value.ToString();
        }

    }
}
