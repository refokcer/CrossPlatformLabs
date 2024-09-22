﻿using Xunit;

namespace Lab1.Tests
{
    public class MathTests
    {
        [Theory]
        [InlineData(12, 8, 4)]
        [InlineData(54, 24, 6)]
        [InlineData(7, 13, 1)]
        [InlineData(48, 18, 6)]
        public void Gcd_ReturnsCorrectGcd(long a, long b, long expected)
        {
            // Act
            long result = Math.Gcd(a, b);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(12, 8, 24)]
        [InlineData(3, 5, 15)]
        [InlineData(7, 13, 91)]
        [InlineData(6, 10, 30)]
        public void Lcm_ReturnsCorrectLcm(long a, long b, long expected)
        {
            // Act
            long result = Math.Lcm(a, b);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, 1)]  // Только одно число (1), которое не делится на 2, 3 или 5
        [InlineData(10, 2)] // Числа: 1, 7
        [InlineData(15, 4)] // Числа: 1, 7, 11, 13
        [InlineData(20, 6)] // Числа: 1, 7, 11, 13, 16, 17, 19
        [InlineData(100, 26)]
        public void CountNumbersNotDivisibleBy2_3_5_ReturnsCorrectCount(long N, long expected)
        {
            // Act
            long result = Math.CountNumbersNotDivisibleBy2_3_5(N);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
