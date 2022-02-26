namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using OxyPlot;
    using OxyPlot.Series;

    public class MainViewModel
    {
        public MainViewModel()
        {
            this.MyModel = new PlotModel { Title = "График" };
            this.Points = new ObservableCollection<DataPoint>{};

        }
        public ObservableCollection<DataPoint> Points { get; set; }
        public PlotModel MyModel { get; private set; }
    }
}
