using System;
using System.Reactive.Linq;

namespace ReactDrone
{
    public class DroneBuilder
    {
        readonly IObservable<Location> location;

        readonly IObservable<DroneStatus> state;

        readonly IObservable<Axes> axes;

        public DroneBuilder()
        {
            location = Observable.Return(default(Location));
            state = Observable.Return(default(DroneStatus));
            axes = Observable.Return(default(Axes));
        }

        DroneBuilder(IObservable<Location> location, IObservable<DroneStatus> state, IObservable<Axes> axes)
        {
            this.location = location;
            this.state = state;
            this.axes = axes;
        }

        public DroneBuilder WithLocation(IObservable<Location> newLocation)
        {
            return new DroneBuilder(newLocation, state, axes);
        }

        public DroneBuilder WithStatus(IObservable<DroneStatus> newState)
        {
            return new DroneBuilder(location, newState, axes);
        }

        public DroneBuilder WithAxes(IObservable<Axes> newAxes)
        {
            return new DroneBuilder(location, state, newAxes);
        }

        public Drone Build()
        {
            return new Drone(location.CombineLatest(state, axes, (l, s, a) => new DroneState(l, s, a)));
        }
    }
}
