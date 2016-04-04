using System;
using System.Reactive.Linq;

namespace ReactDrone
{
    public class Drone
    {
        public Drone(IObservable<DroneState> droneStateStream)
        {
            DroneStateStream = droneStateStream;
        }

        public IObservable<DroneState> DroneStateStream { get; }
    }
}

