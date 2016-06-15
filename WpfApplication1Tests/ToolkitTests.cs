using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows;

namespace WpfApplication1.Tests
{
    [TestClass()]
    public class ToolkitTests
    {
        private const int LENGTH = 6;
        private const String NUMBER = "123456";
        private const String PATTERN_BY_2 = "([0-9]{2}\\s)+";
        private const String PATTERN_BY_3 = "([0-9]{3}\\s)+";

        Toolkit toolkit = new Toolkit();

        [TestMethod()]
        public void shouldGenerateNumbersOfGivenLength()
        {
            String number = toolkit.getNewNumbers(LENGTH);

            Assert.AreEqual(LENGTH, number.Length);
        }

        [TestMethod()]
        public void shouldGenerateDifferentNumbers()
        {
            String number1 = toolkit.getNewNumbers(LENGTH);
            String number2 = toolkit.getNewNumbers(LENGTH);

            Assert.AreNotEqual(number1, number2);
        }

        [TestMethod()]
        public void shouldGenerateZeroNumber()
        {
            String number = toolkit.getNewNumbers(0);

            Assert.AreEqual(number.Length, 0);
        }

        [TestMethod()]
        public void shouldNotDivideByZero()
        {
            String number = toolkit.divideBy(0, NUMBER);

            Assert.AreEqual(NUMBER, number);
        }

        [TestMethod()]
        public void shouldDividedByTwo()
        {
            String number = toolkit.divideBy(2, NUMBER);
            Regex regex = new Regex(PATTERN_BY_2);

            Assert.IsTrue(regex.IsMatch(number));
        }

        [TestMethod()]
        public void shouldDividedByThree()
        {
            String number = toolkit.divideBy(3, NUMBER);
            Regex regex = new Regex(PATTERN_BY_3);
            
            Assert.IsTrue(regex.IsMatch(number));
        }
    }
}