using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Traveling_Nerds.Models;
using Xunit;

namespace TravelingNerds.Tests
{
    public class LocationTest
    {
        [Fact]
        public void GetNameTest()
        {
            // Arrange
            var location = new Location();
            location.Name = "Croatia"; 

            // Act
            var result = location.Name;

            // Assert
            Assert.Equal("Croatia", result); 
        }
    }
}
