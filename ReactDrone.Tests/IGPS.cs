using System;

namespace ReactDrone.Tests
{
    public interface IGPS
    {
        IObservable<Location> Location { get; }
    }
}