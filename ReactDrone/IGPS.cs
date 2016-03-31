using System;

namespace ReactDrone
{
    public interface IGPS
    {
        IObservable<Location> Location { get; }
    }
}