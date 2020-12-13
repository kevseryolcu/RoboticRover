using System;
using Xunit;
using HepsiBuradaApp;

namespace HepsiBuradaAppTest
{
    public class PlateauTest
    {
        [Fact]
        public void IsInsidePlateau_InputXMinus1YMinus2_ReturnsFalse()
        {
            var plateau = new Plateau(5, 5);
            var result = plateau.IsInsidePlateau(-1, -2);
            Assert.False(result, "If upper right corner is (5, 5), (-1, -2) should be outside of the triangle");
        }

        [Fact]
        public void IsInsidePlateau_InputX1Y2_ReturnsFalse()
        {
            var plateau = new Plateau(5, 5);
            var result = plateau.IsInsidePlateau(1, 2);
            Assert.False(result, "If upper right corner is (5, 5), (1, 2) should be outside of the triangle");
        }

        [Fact]
        public void IsInsidePlateau_InputX3Y3_ReturnsTrue()
        {
            var plateau = new Plateau(5, 5);
            var result = plateau.IsInsidePlateau(3, 3);
            Assert.False(!result, "If upper right corner is (5, 5), (3, 3) should be inside of the triangle");
        }

        [Fact]
        public void IsInsidePlateau_InputX4Y1_ReturnsTrue()
        {
            var plateau = new Plateau(5, 5);
            var result = plateau.IsInsidePlateau(4, 1);
            Assert.False(!result, "If upper right corner is (5, 5), (4, 1) should be inside of the triangle");
        }

        [Fact]
        public void IsInsidePlateau_InputX5Y0_ReturnsTrue()
        {
            var plateau = new Plateau(5, 5);
            var result = plateau.IsInsidePlateau(5, 0);
            Assert.False(!result, "If upper right corner is (5, 5), (5, 0) should be inside of the triangle");
        }

        [Fact]
        public void IsInsidePlateau_InputX0Y5_ReturnsFalse()
        {
            var plateau = new Plateau(5, 5);
            var result = plateau.IsInsidePlateau(0, 5);
            Assert.False(result, "If upper right corner is (5, 5), (0, 5) should be outside of the triangle");
        }
    }
}
