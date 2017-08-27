using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherWidget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherWidget.Models.Tests
{
    [TestClass()]
    public class WeatherTests
    {
        [TestMethod()]
        public void ValidateZipTest()
        {
            // Test: Success
            bool isValid = Weather.ValidateZip("30909");
            Assert.AreEqual(true,isValid);

            // Test: Fail - Too many numbers
            isValid = Weather.ValidateZip("309090");
            Assert.AreEqual(false, isValid);

            // Test: Fail - Too few numbers
            isValid = Weather.ValidateZip("3090");
            Assert.AreEqual(false, isValid);

            // Test: Fail - Leading extra character
            isValid = Weather.ValidateZip("m309090");
            Assert.AreEqual(false, isValid);

            // Test: Fail - Trailing extra character
            isValid = Weather.ValidateZip("309090a");
            Assert.AreEqual(false, isValid);

            // Test: Fail - Correct number of characters
            isValid = Weather.ValidateZip("seven");
            Assert.AreEqual(false, isValid);
            
        }
    }
}