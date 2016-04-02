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
            var drone = new DroneBuilder().WithLocation(Observable.Return(new Location(0, 0, 0))).Build();
            drone.WhenStateChanges.Select(d => d.Location).Wait().Should().NotBeNull();
        }

        [Fact]
        public void The_status_of_a_drone_can_be_observed()
        {
            var drone = new DroneBuilder().WithStatus(Observable.Return(DroneStatus.Unknown)).Build();
            drone.WhenStateChanges.Select(d => d.State).Wait().Should().NotBeNull();
        }

        [Fact]
        public void The_axes_of_a_drone_can_be_observed()
        {
            var drone = new DroneBuilder().WithAxes(Observable.Return(new Axes(0, 0, 0))).Build();
            drone.WhenStateChanges.Select(d => d.Axes).Wait().Should().NotBeNull();
        }
    }
}
