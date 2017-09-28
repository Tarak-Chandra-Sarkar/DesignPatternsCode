using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace WeatherUndergroundAdapter.Tests
{
    public class WeatherUndergroundDriverTests
    {

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("NA")]
        public void TestWindchillConversionWithBadValues(String value)
        {
            // Arrange
            WeatherUndergroundDriver wuDriver = new WeatherUndergroundDriver();

            // Act
            double? windchill = wuDriver.ConvertWindchillString(value);

            // Assert
            Assert.Null(windchill);
        }


        [Theory]
        [InlineData("-37")]
        [InlineData("0")]
        [InlineData("24")]
        public void TestWindchillConversionWithGoodValues(String value)
        {
            // Arrange
            WeatherUndergroundDriver wuDriver = new WeatherUndergroundDriver();

            // Act
            double? windchill = wuDriver.ConvertWindchillString(value);

            // Assert
            Assert.NotNull(windchill);
            Assert.Equal(Convert.ToDouble(value), windchill);
        }




    }
}
