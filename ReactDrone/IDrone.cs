using System;

namespace ReactDrone
{
    public interface IDrone
    {
        IObservable<Location> Location { get; }
        IObservable<DroneState> State { get; }
    }
}