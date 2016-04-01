using System;
using System.Reactive.Linq;

namespace ReactDrone
{
    public class Drone : IObservable<DroneState>
    {
        readonly IObservable<DroneState> stateSource;

        public Drone(IObservable<DroneState> stateSource)
        {
            this.stateSource = stateSource;
        }

        public IDisposable Subscribe(IObserver<DroneState> observer)
        {
            return stateSource.Subscribe(observer);
        }
    }
}

