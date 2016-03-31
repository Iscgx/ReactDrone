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
        }

        public IObservable<Location> Location { get; }
    }

    public class Location
    {
    }
}