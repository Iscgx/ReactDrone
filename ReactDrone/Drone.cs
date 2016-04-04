using System;
using System.Reactive.Linq;

namespace ReactDrone
{
    public class Drone
    {
        public Drone(IObservable<DroneState> droneStateStream)
        {
            WhenDroneStateChanges = droneStateStream;
        }

        public IObservable<DroneState> WhenDroneStateChanges { get; }
    }
}

