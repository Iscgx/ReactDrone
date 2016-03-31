using System.Reactive.Linq;
using FluentAssertions;
using Xunit;

namespace ReactDrone.Tests
{
    public class Drone_Tests
    {
        [Fact]
        public void A_drone_can_be_created()
        {
            Drone.Create().Should().NotBeNull();
        }

        [Fact]
        public void The_location_of_a_drone_can_be_observed()
        {
            var drone = new DroneBuilder().WithLocation(Observable.Return(new Location(0, 0, 0))).Build();
            drone.Location.Wait().Should().NotBeNull();
        }

        [Fact]
        public void The_state_of_a_drone_can_be_observed()
        {
            var drone = new DroneBuilder().WithState(Observable.Return(DroneState.Unknown)).Build();
            drone.State.Wait().Should().NotBeNull();
        }

        [Fact]
        public void The_axes_of_a_drone_can_be_observed()
        {
            var drone = new DroneBuilder().WithAxes(Observable.Return(new Axes(0, 0, 0))).Build();
            drone.Axes.Wait().Should().NotBeNull();
        }
    }
}
