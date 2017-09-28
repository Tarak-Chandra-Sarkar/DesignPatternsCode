using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace WeatherUndergroundApi.Tests
{
    public class WeatherUndegroundClientTests
    {

        [Fact]
        public void TestGetCurrentConditionsByZipCode()
        {
            WeatherUndergroundClient client = new WeatherUndergroundClient();
            var currentConditions = client.GetCurrentConditions("54911");

            Assert.NotNull(currentConditions);

        }

    }
}
