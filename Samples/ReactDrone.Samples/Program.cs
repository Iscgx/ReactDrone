using System;
using System.Reactive.Linq;
using ReactDrone.Mavlink;

namespace ReactDrone.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            var udpMavLinkDroneConnection = UdpMavLinkDroneConnection.Create(8888);

            var drone =
                DroneBuilder.Create()
                    .WithLocationStream(udpMavLinkDroneConnection.GetLocationStream())
                    .Build();

            drone.DroneStateStream.Select(d => d.Location).Sample(TimeSpan.FromSeconds(1))
                .Subscribe(l => Console.WriteLine($"({l.Latitude:000.000},{l.Longitude:000.000},{l.Altitude:000.000})"));

            Console.ReadLine();
        }
    }
}
