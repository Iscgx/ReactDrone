using System;
using System.Reactive.Linq;

namespace ReactDrone
{
    public class DroneBuilder
    {
        readonly IObservable<Location> locationStream;

        readonly IObservable<DroneStatus> droneStatusStream;

        readonly IObservable<Axes> axesStream;

        public DroneBuilder()
        {
            locationStream = Observable.Return(default(Location));
            droneStatusStream = Observable.Return(default(DroneStatus));
            axesStream = Observable.Return(default(Axes));
        }

        DroneBuilder(IObservable<Location> locationStream,
            IObservable<DroneStatus> droneStatusStream,
            IObservable<Axes> axesStream)
        {
            this.locationStream = locationStream;
            this.droneStatusStream = droneStatusStream;
            this.axesStream = axesStream;
        }

        public DroneBuilder WithLocationStream(IObservable<Location> newWhenLocationChanges)
        {
            return new DroneBuilder(newWhenLocationChanges, droneStatusStream, axesStream);
        }

        public DroneBuilder WithStatusStream(IObservable<DroneStatus> newWhenStatusChanges)
        {
            return new DroneBuilder(locationStream, newWhenStatusChanges, axesStream);
        }

        public DroneBuilder WithAxesStream(IObservable<Axes> newWhenAxesChanges)
        {
            return new DroneBuilder(locationStream, droneStatusStream, newWhenAxesChanges);
        }

        public Drone Build()
        {
            return
                new Drone(locationStream.CombineLatest(droneStatusStream,
                    axesStream,
                    (l, s, a) => new DroneState(l, s, a)));
        }
    }
}
