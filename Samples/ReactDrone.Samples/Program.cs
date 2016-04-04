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
                    .WithAxesStream(udpMavLinkDroneConnection.GetAxesStream())
                    .Build();

            drone.WhenDroneStateChanges
                .Subscribe(s =>
                {
                    Console.WriteLine(s.Location);
                    Console.WriteLine(s.Axes);
                });

            Console.ReadLine();
        }
    }
}
