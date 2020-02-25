using System;
using Xunit;

namespace StringCalculator
{
    public class StringCalculatorTest
    {
        
        [Fact]
        public void GivenEmptyStringReturnZero()
        {
            string.Empty.CalculateTo(0);

        }

        [Fact]
        public void GivenSingleNumberReturnNumber()
        {
            "1".CalculateTo(1);
        }

        [Fact]
        public void GivenTwoNumbersReturnSumOfBothNumbers()
        {
            "1,2".CalculateTo(3);
        }

        [Fact]
        public void GivenMultipleNumbersReturnSum()
        {
            "1,2,3".CalculateTo(6);
        }

        [Fact]
        public void GivenNewLineDelimReturnSum()
        {
            "1\n2\n3".CalculateTo(6);
        }

        [Fact]
        public void GivenConsecutiveDelimsThrowException()
        {
            Assert.Throws<ArgumentException>(() => StringCalculator.Add(",,"));
        }

        [Fact]
        public void GivenCustomDelimReturnSum()
        {
            "//;\n1;2".CalculateTo(3);
        }

        [Fact]
        public void GivenNegNumberThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => StringCalculator.Add("-1,2"));
        }

        [Fact]
        public void GivenNegNumberErrorMessageShouldContainNegNumber()
        {
            var error = Assert.Throws<ArgumentOutOfRangeException>(() => StringCalculator.Add("-1,2"));
            Assert.Contains("-1", error.Message);
        }

        [Fact]
        public void IgnoreNumbersGreaterThan1000()
        {
            "1001,2".CalculateTo(2);
            
        }


    }

    internal static class TestHelper
    {
        public static void CalculateTo(this string input, int expected)
        {
            var item = new StringCalculator();
            Assert.Equal(expected,StringCalculator.Add(input));
            
        }
    }
}