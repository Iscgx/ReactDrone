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

            drone.WhenDroneStateChanges.Select(d => d.Location).Sample(TimeSpan.FromSeconds(1))
                .Subscribe(Console.WriteLine);

            Console.ReadLine();
        }
    }
}
