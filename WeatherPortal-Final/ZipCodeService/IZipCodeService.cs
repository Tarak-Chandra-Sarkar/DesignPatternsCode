using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZipCodeService
{


    /// <summary>
    /// Simple interface for a service that will look up a US Zip code and return information about that zip code
    /// </summary>
    public interface IZipCodeService
    {

        /// <summary>
        /// Gets information about the given zip code.  If the zip code is not found, then null is returned
        /// </summary>
        /// <param name="zipCode">A String of the zip code</param>
        /// <returns>A UsZipCode object that contains information about the zip code or null if the zip code is not found</returns>
        ZipCodeInfo GetZipCode(String zipCode);
    }
}
