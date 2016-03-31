using System;
using System.Reactive.Linq;

namespace ReactDrone.Tests
{
    public class GPS : IGPS
    {
        public GPS()
        {
            Location = Observable.Repeat(new Location(0, 0, 0));
        }

        public static GPS Create()
        {
            return new GPS();
        }

        public IObservable<Location> Location { get;}
    }
}