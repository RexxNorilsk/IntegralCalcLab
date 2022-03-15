using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace WpfApp1
{
    public class Integral : IIntegralModel
    {
        public double lowerLimit { get; set; }
        public double upperLimit { get; set; }
        public double spliting { get; set; }


        public Integral(double _lowerLimit, double _upperLimit, double _spliting) {
            lowerLimit = _lowerLimit;
            upperLimit = _upperLimit;
            spliting = _spliting;
            if (spliting <= 0) throw new ArgumentException("Некорректный шаг интегрирования");
        }
        public double CalculateSquireMethod(out double time, out int numberOfPartitions, double offset = 0.5) {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            
            int N = (int)((upperLimit - lowerLimit) / spliting);
            lowerLimit += spliting * offset;
            double area = 0;
            for (int i = 0; i < N; i++) {
                double currentX = lowerLimit + spliting * i;
                area += CalculateFunctionInPoint(currentX);
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            time = ts.TotalSeconds;
            numberOfPartitions = N;
            return spliting * area;
        }

        public double CalculateTrapezoidMethod(out double time) {
            int N = (int)((upperLimit - lowerLimit) / spliting);
            double area = 0;
            for (int i = 0; i < N; i++)
            {
                double currentX = lowerLimit + spliting * i;
                area += CalculateFunctionInPoint(currentX);
            }
            area += (CalculateFunctionInPoint(lowerLimit) + CalculateFunctionInPoint(upperLimit)) / 2;
            time = 0;
            return spliting * area;
        }

        public double CalculateSimpsonMethod(out double time) {
            int N = (int)((upperLimit - lowerLimit) / spliting);
            double area = CalculateFunctionInPoint(lowerLimit) + CalculateFunctionInPoint(upperLimit);
            int k = 4;
            for (int i = 0; i < N; i++)
            {
                double currentX = lowerLimit + spliting * i;
                area += k*CalculateFunctionInPoint(currentX);
                k = 6-k;
            }
            area *= spliting / 3;
            time = 0;
            return area;
        }

        public double CalculateFunctionInPoint(double point) {
            return 11*point - Math.Log(11* point) - 2;
        }
    }
}
