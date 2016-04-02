using System;
using System.Reactive.Linq;

namespace ReactDrone
{
    public class Drone
    {
        public Drone(IObservable<DroneState> whenStateChanges)
        {
            WhenStateChanges = whenStateChanges;
        }

        public IObservable<DroneState> WhenStateChanges { get; }
    }
}

