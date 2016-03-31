using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace ReactDrone.Tests
{
    public class GPS_Tests
    {
        [Fact]
        public void A_GPS_can_be_created()
        {
            GPS.Create().Should().NotBeNull();
        }
    }

    public class GPS
    {
        public static GPS Create()
        {
            return new GPS();
        }
    }
}
