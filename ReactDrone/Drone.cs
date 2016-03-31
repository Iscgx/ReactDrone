using System;
using System.Reactive.Linq;

namespace ReactDrone
{
    public class Drone : IDrone
    {
        public Drone(IObservable<Location> location, IObservable<DroneState> state, IObservable<Axes> axes)
        {
            this.Location = location;
            this.State = state;
            this.Axes = axes;
        }

        public IObservable<Location> Location { get; }

        public IObservable<DroneState> State { get; }

        public IObservable<Axes> Axes { get; }
    }
}

