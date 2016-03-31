using System;

namespace ReactDrone.Tests
{
    public class DroneBuilder
    {
        readonly IObservable<Location> location;

        readonly IObservable<DroneState> state;

        readonly IObservable<Axes> axes;

        public DroneBuilder()
        {
            location = null;
            state = null;
            axes = null;
        }

        DroneBuilder(IObservable<Location> location, IObservable<DroneState> state, IObservable<Axes> axes)
        {
            this.location = location;
            this.state = state;
            this.axes = axes;
        }

        public DroneBuilder WithLocation(IObservable<Location> newLocation)
        {
            return new DroneBuilder(newLocation, state, axes);
        }

        public DroneBuilder WithState(IObservable<DroneState> newState)
        {
            return new DroneBuilder(location, newState, axes);
        }

        public DroneBuilder WithAxes(IObservable<Axes> newAxes)
        {
            return new DroneBuilder(location, state, newAxes);
        }

        public Drone Build()
        {
            return new Drone(location, state, axes);
        }
    }
}
