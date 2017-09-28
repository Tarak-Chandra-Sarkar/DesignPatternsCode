using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ZipCodeService.Tests
{
    public class ZipCodeFactoryTests
    {

        [Fact]
        public void TestZipCodeFactoryWorks()
        {            
            // Act
            InMemoryZipCodeService provider = ZipCodeProviderFactory.ZipCodeProvider;

            // assert
            Assert.NotNull(provider);

            ZipCodeInfo appletonZip = provider.GetZipCode("54911");

            Assert.NotNull(appletonZip);
            Assert.Equal("APPLETON", appletonZip.City);

        }

    }
}
