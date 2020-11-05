using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLightSimulator.ViewModels.Base;

namespace TrafficLightSimulator.Model {
    public class Mode : BaseViewModel {
        private string mValue;

        public int Id { get; set; }

        public string Value {
            get {
                return mValue;
            }
            set {
                mValue = value;
                RaisePropertyChanged();
            }
        }

        public Mode(int id, string mode) {
            Id = id;
            Value = mode;
        }

        public Mode() { }

        public override string ToString() {
            return Value;
        }

    }
}
