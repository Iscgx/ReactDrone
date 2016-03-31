using System;
using System.Reactive.Linq;

namespace ReactDrone
{
    public class Drone : IDrone
    {
        public static Drone Create()
        {
            return new Drone();
        }

        Drone()
        {
            Location = Observable.Repeat(new Location(0, 0, 0));
            State = Observable.Repeat(DroneState.Unknown);
            Axes = Observable.Repeat(new Axes());
        }

        public IObservable<Location> Location { get; }

        public IObservable<DroneState> State { get; }

        public IObservable<Axes> Axes { get; set; }
    }
}