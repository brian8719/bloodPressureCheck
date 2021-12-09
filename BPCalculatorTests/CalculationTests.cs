using Microsoft.VisualStudio.TestTools.UnitTesting;
using BPCalculator;
using System;

namespace BPCalculatorTests
{
    [TestClass]
    public class CalculationTests
    {
        [TestMethod]
        public void InHighRange()
        {
            // Arrange
            BloodPressure pressure = new BloodPressure();

            // Act
            pressure.Systolic = 170;
            pressure.Diastolic = 40;

            // Assert
            Assert.AreEqual(BPCategory.High, pressure.Category);
        }

        [TestMethod]
        public void InIdealRange()
        {
            // Arrange
            BloodPressure pressure = new BloodPressure();

            // Act
            pressure.Systolic = 105;
            pressure.Diastolic = 70;

            // Assert
            Assert.AreEqual(BPCategory.Ideal, pressure.Category);
        }
        [TestMethod]
        public void InLowRange()
        {
            // Arrange
            BloodPressure pressure = new BloodPressure();

            // Act
            pressure.Systolic = 80;
            pressure.Diastolic = 50;

            // Assert
            Assert.AreEqual(BPCategory.Low, pressure.Category);
        }
        //[TestMethod]
        //[ExpectedException(typeof(ArgumentException))]
        //public void SystolicOverRange()
        //{
        //    // Arrange
        //    BloodPressure pressure = new BloodPressure();

        //    // Act
        //    pressure.Systolic = 200;
        //}
    }
}
