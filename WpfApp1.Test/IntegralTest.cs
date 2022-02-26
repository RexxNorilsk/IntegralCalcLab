using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WpfApp1;

namespace WpfApp1.Test
{
    [TestClass]
    public class IntegralTest
    {
        [TestMethod]
        public void Integral_Trap_XX_Correct()
        {
            //Arrange
            IIntegralModel integral = new Integral(0, 1000, 0.1, "x*x");
            double expected = 333333333.333333;

            //Act
            double time;
            double actual = integral.CalculateTrapezoidMethod(out time);

            //Assert
            Assert.AreEqual(expected, actual, 0.001);
        }

        [TestMethod]
        public void Integral_Simp_XX_Correct()
        {
            //Arrange
            IIntegralModel integral = new Integral(0, 1000, 0.1, "x*x");
            double expected = 333333333.333333;

            //Act
            double time;
            double actual = integral.CalculateSimpsonMethod(out time);

            //Assert
            Assert.AreEqual(expected, actual, 0.001);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Integral_Simp_XX_Step_Zero()
        {
            //Arrange
            IIntegralModel integral = new Integral(0, 1000, 0, "x*x");
            double expected = 333333333.333333;

            //Act
            double time;
            double actual = integral.CalculateSimpsonMethod(out time);

            //Assert
            //Assert.AreEqual(expected, actual, 0.001);
        }

    }
}
