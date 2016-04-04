using System;
using System.Reactive.Linq;

namespace ReactDrone
{
    public class DroneBuilder
    {
        readonly IObservable<Location> whenLocationChanges;

        readonly IObservable<DroneStatus> whenStatusChanges;

        readonly IObservable<Axes> whenAxesChanges;

        public DroneBuilder()
        {
            whenLocationChanges = Observable.Return(default(Location));
            whenStatusChanges = Observable.Return(default(DroneStatus));
            whenAxesChanges = Observable.Return(default(Axes));
        }

        DroneBuilder(IObservable<Location> whenLocationChanges,
            IObservable<DroneStatus> whenStatusChanges,
            IObservable<Axes> whenAxesChanges)
        {
            this.whenLocationChanges = whenLocationChanges;
            this.whenStatusChanges = whenStatusChanges;
            this.whenAxesChanges = whenAxesChanges;
        }

        public DroneBuilder WithLocation(IObservable<Location> newWhenLocationChanges)
        {
            return new DroneBuilder(newWhenLocationChanges, whenStatusChanges, whenAxesChanges);
        }

        public DroneBuilder WithStatus(IObservable<DroneStatus> newWhenStatusChanges)
        {
            return new DroneBuilder(whenLocationChanges, newWhenStatusChanges, whenAxesChanges);
        }

        public DroneBuilder WithAxes(IObservable<Axes> newWhenAxesChanges)
        {
            return new DroneBuilder(whenLocationChanges, whenStatusChanges, newWhenAxesChanges);
        }

        public Drone Build()
        {
            return
                new Drone(whenLocationChanges.CombineLatest(whenStatusChanges,
                    whenAxesChanges,
                    (l, s, a) => new DroneState(l, s, a)));
        }
    }
}
