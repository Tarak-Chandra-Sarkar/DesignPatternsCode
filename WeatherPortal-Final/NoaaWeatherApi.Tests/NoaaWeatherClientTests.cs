using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NoaaWeatherApi.Tests
{
    public class NoaaWeatherClientTests
    {

        [Fact]
        public void TestGetCurrentConditionsFromNoaa()
        {
            // Arrange
            double latitude = 44.261917;
            double longitude = -88.414525;

            // Act
            NoaaWeatherClient client = new NoaaWeatherClient();
            NoaaResponse response = client.GetWeatherConditions(latitude, longitude);


            // Assert
            Assert.NotNull(response);
        }

    }
}
