using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Drone.Create().Location.Take(1).Wait().Should().NotBeNull();
        }

        [Fact]
        public void The_state_of_a_drone_can_be_observed()
        {
            Drone.Create().State.Take(1).Wait().Should().NotBeNull();
        }

        [Fact]
        public void The_axes_of_a_drone_can_be_observed()
        {
            Drone.Create().Axes.Take(1).Wait().Should().NotBeNull();
        }
    }
}
