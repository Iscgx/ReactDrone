using System.Reactive.Linq;
using FluentAssertions;
using Xunit;

namespace ReactDrone.Tests
{
    public class Drone_Tests
    {
        [Fact]
        public void The_location_of_a_drone_can_be_observed()
        {
            var drone = new DroneBuilder().WithLocationStream(Observable.Return(new Location(0, 0, 0))).Build();
            drone.DroneStateStream.Select(d => d.Location).Wait().Should().NotBeNull();
        }

        [Fact]
        public void The_status_of_a_drone_can_be_observed()
        {
            var drone = new DroneBuilder().WithStatusStream(Observable.Return(DroneStatus.Unknown)).Build();
            drone.DroneStateStream.Select(d => d.Status).Wait().Should().NotBeNull();
        }

        [Fact]
        public void The_axes_of_a_drone_can_be_observed()
        {
            var drone = new DroneBuilder().WithAxesStream(Observable.Return(new Axes(0, 0, 0))).Build();
            drone.DroneStateStream.Select(d => d.Axes).Wait().Should().NotBeNull();
        }
    }
}
