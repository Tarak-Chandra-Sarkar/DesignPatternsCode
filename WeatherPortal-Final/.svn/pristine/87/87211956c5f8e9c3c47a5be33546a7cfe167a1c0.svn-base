using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZipCodeService
{
    public class ZipCodeProviderFactory
    {


        private static Lazy<InMemoryZipCodeService> zipCodeProvider = new Lazy<InMemoryZipCodeService>(CreateZipCodeProvider);



        public static InMemoryZipCodeService ZipCodeProvider
        {
            get { return zipCodeProvider.Value;  }
        }



        private static InMemoryZipCodeService CreateZipCodeProvider()
        {
            ZipCodeReader reader = new ZipCodeReader();
            List<ZipCodeInfo> zipCodes = reader.LoadZipCodes("ZipCodes.csv");

            InMemoryZipCodeService provider = new InMemoryZipCodeService(zipCodes);
            return provider;
        }
    }
}
