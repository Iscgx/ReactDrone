using System;
using System.Reactive.Linq;
using MavLinkNet;

namespace ReactDrone.Mavlink
{
    public class UdpMavLinkDroneConnection : IDisposable
    {
        readonly MavLinkUdpTransport mavLinkUdpTransport;

        internal IObservable<MavLinkPacket> MavLinkPacketStream
            => Observable.FromEventPattern<MavLinkPacket>(mavLinkUdpTransport, "OnPacketReceived")
                .Select(evt => evt.EventArgs);

        UdpMavLinkDroneConnection(MavLinkUdpTransport mavLinkUdpTransport)
        {
            this.mavLinkUdpTransport = mavLinkUdpTransport;
        }

        public void Dispose()
        {
            mavLinkUdpTransport.Dispose();
        }

        public static UdpMavLinkDroneConnection Create(int port)
        {
            var mavLinkUdpTransport = new MavLinkUdpTransport
            {
                UdpListeningPort = port
            };
            mavLinkUdpTransport.Initialize();
            return new UdpMavLinkDroneConnection(mavLinkUdpTransport);
        }

        public IObservable<Location> GetLocationStream()
        {
            return
                MavLinkPacketStream
                    .Select(packet => packet.Message as UasGlobalPositionInt)
                    .Where(packet => packet != null)
                    .Select(packet => new Location(packet.Lat / 1E7f, packet.Lon / 1E7f, packet.Alt / 1000.0f));
        }

        public IObservable<Axes> GetAxesStream()
        {
            return
                MavLinkPacketStream
                    .Select(packet => packet.Message as UasAttitude)
                    .Where(packet => packet != null)
                    .Select(packet => new Axes(packet.Roll, packet.Pitch, packet.Yaw));
        }
    }
}
