using System;
using System.Reactive.Linq;

namespace ReactDrone
{
    public class Drone
    {
        public Drone(IObservable<Location> location, IObservable<DroneStatus> state, IObservable<Axes> axes)
        {
            this.Location = location;
            this.State = state;
            this.Axes = axes;
        }

        public IObservable<Location> Location { get; }

        public IObservable<DroneStatus> State { get; }

        public IObservable<Axes> Axes { get; }
    }
}

