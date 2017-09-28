using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ZipCodeService.Tests
{
    public class ZipCodeReaderTests
    {

        [Fact]
        public void TestReadingZipCodeFile()
        {
            // Arrange
            ZipCodeReader reader = new ZipCodeReader();

            // Act
            List<ZipCodeInfo> zipCodes = reader.LoadZipCodes("ZipCodes.csv");

            // Assert
            Assert.NotEmpty(zipCodes);
        }
    }
}
