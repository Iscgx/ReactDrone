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
            var drone = DroneBuilder.Create().WithLocationStream(Observable.Return(new Location(0, 0, 0))).Build();
            drone.WhenDroneStateChanges.Select(d => d.Location).Wait().Should().NotBeNull();
        }

        [Fact]
        public void The_status_of_a_drone_can_be_observed()
        {
            var drone = DroneBuilder.Create().WithStatusStream(Observable.Return(DroneStatus.Unknown)).Build();
            drone.WhenDroneStateChanges.Select(d => d.Status).Wait().Should().NotBeNull();
        }

        [Fact]
        public void The_axes_of_a_drone_can_be_observed()
        {
            var drone = DroneBuilder.Create().WithAxesStream(Observable.Return(new Axes(0, 0, 0))).Build();
            drone.WhenDroneStateChanges.Select(d => d.Axes).Wait().Should().NotBeNull();
        }
    }
}
