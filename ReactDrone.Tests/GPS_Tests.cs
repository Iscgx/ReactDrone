using System;
using System.Linq;
using System.Reactive.Linq;
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

        [Fact]
        public void The_location_of_a_GPS_can_be_observed()
        {
            GPS.Create().Location.ToEnumerable().Take(1).Should().NotBeNull();
        }

        [Fact]
        public void The_location_source_of_a_GPS_can_be_specified_and_is_called()
        {
            var wasObserved = false;
            GPS.Create(Observable.Defer(() =>
            {
                wasObserved = true;
                return Observable.Never<Location>();
            })).Location.Subscribe();

            wasObserved.Should().BeTrue();
        }
    }
}
