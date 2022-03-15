using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WpfApp1;

namespace WpfApp1.Test
{
    [TestClass]
    public class IntegralTest
    {
        [TestMethod]
        public void Integral_Squire_XX_Correct()
        {
            //Arrange
            IIntegralModel integral = new Integral(1, 1000, 0.1);
            double expected = 5489143.14356348;

            //Act
            double time;
            int countParts;
            double actual = integral.CalculateSquireMethod(out time, out countParts, 0.0);

            //Assert
            Assert.AreEqual(expected, actual, 0.0001);
        }
        [TestMethod]
        public void Integral_Trap_XX_Correct()
        {
            //Arrange
            IIntegralModel integral = new Integral(1, 1000, 0.1);
            double expected = 5489692.90838619;

            //Act
            double time;
            double actual = integral.CalculateTrapezoidMethod(out time);

            //Assert
            Assert.AreEqual(expected, actual, 0.0001);
        }

        [TestMethod]
        public void Integral_Simp_XX_Correct()
        {
            //Arrange
            IIntegralModel integral = new Integral(1, 1000, 0.1);
            double expected = 5489326.61940567;

            //Act
            double time;
            double actual = integral.CalculateSimpsonMethod(out time);

            //Assert
            Assert.AreEqual(expected, actual, 0.0001);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Integral_Simp_XX_Step_Zero()
        {
            //Arrange
            IIntegralModel integral = new Integral(1, 1000, 0);
            double expected = 5489694.34944822;

            //Act
            double time;
            double actual = integral.CalculateSimpsonMethod(out time);

            //Assert
            Assert.AreEqual(expected, actual, 0.0001);
        }

    }
}
