using FluentAssertions;
using Xunit;

namespace ReactDrone.Tests
{
    public class Location_Tests
    {
        [Fact]
        public void A_locations_latitude_longitude_and_altitude_are_initialized_correctly()
        {
            const double latitude = 1.0;
            const double longitude = 2.0;
            const double altitude = 3.0;
            var location = new Location(latitude, longitude, altitude);

            location.Latitude.Should().Be(latitude);
            location.Longitude.Should().Be(longitude);
            location.Altitude.Should().Be(altitude);
        }
    }
}
