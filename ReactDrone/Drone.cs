using System;
using System.Reactive.Linq;

namespace ReactDrone
{
    public class Drone
    {
        public static Drone Create()
        {
            return new Drone();
        }

        Drone()
        {
            Location = Observable.Repeat(new Location());
            State = Observable.Repeat(DroneState.Unknown);
        }

        public IObservable<Location> Location { get; }

        public IObservable<DroneState> State { get; }
    }
}