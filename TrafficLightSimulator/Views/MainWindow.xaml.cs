using System;
using System.Windows;
using TimePickerControlLibrary;
using TrafficLightSimulator.ViewModels;

namespace TrafficLightSimulator {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            this.DataContext = new MainViewModel(this);
        }
    }
}
