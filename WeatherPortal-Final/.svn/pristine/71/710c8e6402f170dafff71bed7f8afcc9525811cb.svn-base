using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ZipCodeService
{

    /// <summary>
    /// Implementation of a service that will look up information on US Zip Codes from a list of zip codes 
    /// it holds in memory
    /// </summary>
    /// <remarks>
    /// This class is instantiated with a list of UsZipCode objects that it will store in memory, and then 
    /// look up any requests it receives against that in memory list
    /// </remarks>
    public class InMemoryZipCodeService : IZipCodeService
    {


        public InMemoryZipCodeService(List<ZipCodeInfo> zipCodes)
        {
            this.zipCodeTable = new Dictionary<string, ZipCodeInfo>();

            zipCodes.ForEach(x => this.zipCodeTable.Add(x.ZipCode, x));
        }


        #region Member Variables

        private Dictionary<String, ZipCodeInfo> zipCodeTable;

        #endregion



        /// <summary>
        /// Looks up a zip code and returns information about it
        /// </summary>
        /// <param name="zipCode">A String of the 5 digit us zip code</param>
        /// <returns>A UsZipCode object or null if the zip code is not found</returns>
        public ZipCodeInfo GetZipCode(String zipCode)
        {
            // Make sure we have valid input
            if (!Regex.IsMatch(zipCode, "^\\d{5}$"))
                throw new ArgumentException("The zip code must be exactly 5 digits");

            if (!this.zipCodeTable.ContainsKey(zipCode))
                return null;

            return this.zipCodeTable[zipCode];
        }



    }
}
