using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactDrone
{
    public class Program
    {
        public static void Main()
        {
            var fakeDrone = new CirclingDrone();
            fakeDrone.Location.Subscribe(l => Console.WriteLine($"({l.Latitude},{l.Longitude},{l.Altitude})"));
            Console.ReadLine();
        }

        internal class CirclingDrone : IDrone
        {
            public IObservable<Location> Location { get; }
            public IObservable<DroneState> State { get; }

            public CirclingDrone()
            {
                State = Observable.Return(DroneState.Starting).Concat(Observable.Repeat(DroneState.Running));
                Location =
                    Observable.Generate(0, i => i < 360, i => i + 1, i => i, _ => TimeSpan.FromSeconds(1.0/5.0))
                        .Select(i => Math.PI/180.0*i)
                        .Select(angle => new Location(5*Math.Sin(angle), 5*Math.Cos(angle), 2))
                        .Repeat();
            }
        }
    }
}
