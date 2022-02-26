using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public interface IIntegralModel
    {
        double lowerLimit { get; set; }
        double upperLimit { get; set; }
        double spliting { get; set; }
        string function { get; set; }


        double CalculateSquireMethod(out double time, out int numberOfPartitions, double offset);
        double CalculateTrapezoidMethod(out double time);
        double CalculateSimpsonMethod(out double time);
        double CalculateFunctionInPoint(double point);
    }
}
