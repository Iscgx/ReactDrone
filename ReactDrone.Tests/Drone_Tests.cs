using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
