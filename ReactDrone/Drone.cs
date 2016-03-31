using System;
using System.Reactive.Linq;

namespace ReactDrone
{
    public class Drone : IDrone
    {
        public static Drone Create()
        {
            return new Drone(Observable.Repeat(new Location(0, 0, 0)),
                Observable.Repeat(DroneState.Unknown),
                Observable.Repeat(new Axes(0, 0, 0)));
        }

        Drone(IObservable<Location> location, IObservable<DroneState> state, IObservable<Axes> axes)
        {
            Location = location;
            State = state;
            Axes = axes;
        }

        public IObservable<Location> Location { get; }

        public IObservable<DroneState> State { get; }

        public IObservable<Axes> Axes { get; set; }
    }
}