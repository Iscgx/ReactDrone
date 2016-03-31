using System;
using System.Reactive.Linq;

namespace ReactDrone
{
    public class GPS : IGPS
    {
        GPS(IObservable<Location> locationSource)
        {
            Location = locationSource;
        }

        public static GPS Create()
        {
            return new GPS(Observable.Repeat(new Location(0, 0, 0)));
        }

        public static GPS Create(IObservable<Location> locationSource)
        {
            return new GPS(locationSource);
        }

        public IObservable<Location> Location { get;}
    }
}