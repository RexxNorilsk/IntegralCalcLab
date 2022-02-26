using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using OxyPlot;
using OxyPlot.Series;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    using OxyPlot;
    using OxyPlot.Axes;
    using OxyPlot.Series;

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            Integral integ = new Integral(double.Parse(LowerLimitEditBox.Text), double.Parse(UpperLimitEditBox.Text), double.Parse(SplitterEditBox.Text), FunctionEditBox.Text);
            double time = 0;
            int numberOfPartitions;
            if (ModeComboBox.SelectedIndex == 0) MessageBox.Show(integ.CalculateSquireMethod(out time, out numberOfPartitions).ToString());
            else if (ModeComboBox.SelectedIndex == 1) MessageBox.Show(integ.CalculateTrapezoidMethod(out time).ToString());
            else if (ModeComboBox.SelectedIndex == 2) MessageBox.Show(integ.CalculateSimpsonMethod(out time).ToString());
        }
        //public IList<DataPoint> Points { get; private set; }
        
        private void StartGraphicBtn_Click(object sender, RoutedEventArgs e)
        {
            PlotModel model = new PlotModel();
            LineSeries line = new LineSeries();
            model.Title = "11x-ln(11x)-2";
            double counter = double.Parse(SplitterEditBox_grapMax.Text);
            while (counter >= double.Parse(SplitterEditBox_grapMin.Text))
            {
                Integral integ = new Integral(double.Parse(LowerLimitEditBox.Text), double.Parse(UpperLimitEditBox.Text), counter, FunctionEditBox.Text);
                double time = 0;
                int numberOfPartitions;
                integ.CalculateSquireMethod(out time, out numberOfPartitions);
                line.Points.Add(new DataPoint(numberOfPartitions, time));
                counter -= double.Parse(SplitterEditBox.Text);
            }
            model.Series.Add(line);
            Graf.Model = model;

        }


    }
}
