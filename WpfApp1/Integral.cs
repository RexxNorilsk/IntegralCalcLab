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
        public string function { get; set; }


        public Integral(double _lowerLimit, double _upperLimit, double _spliting, string _function) {
            lowerLimit = _lowerLimit;
            upperLimit = _upperLimit;
            spliting = _spliting;
            if (spliting <= 0) throw new ArgumentException("Некорректный шаг интегрирования");
            function = _function;
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
            double area = 0;
            for (int i = 0; i < N; i++)
            {
                double currentX = lowerLimit + spliting * i;
                area += CalculateFunctionInPoint(currentX);
                area += 2*CalculateFunctionInPoint(currentX+ spliting/2);
            }
            area += (CalculateFunctionInPoint(upperLimit) - CalculateFunctionInPoint(lowerLimit)) / 2;
            time = 0;
            return area* spliting/3;
        }

        public double CalculateFunctionInPoint(double point) {
            /*string currentFunction = function;
            currentFunction = currentFunction.Replace("x", point.ToString());
            currentFunction = currentFunction.Replace(',', '.');
            MatchCollection matches = Regex.Matches(currentFunction, @"ln(\((?<lns>.+?)\))");
            Regex regLn = new Regex(@"ln(\((?<lns>.+?)\))");
            foreach (Match match in matches)
            {
                Group g = match.Groups["lns"];
                currentFunction = regLn.Replace(currentFunction, Math.Log(Convert.ToDouble(new DataTable().Compute(g.Value, ""))).ToString(), 1, 0);
            }
            currentFunction = currentFunction.Replace(',', '.');
            return Convert.ToDouble(new DataTable().Compute(currentFunction, ""));
            */
            return 11*point - Math.Log(11* point) - 2;
        }
    }
}
