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
                    .Select(evt => evt.Message as UasGlobalPositionInt)
                    .Where(evt => evt != null)
                    .Select(evt => new Location(evt.Lat / 1E7f, evt.Lon / 1E7f, evt.Alt / 1000.0f));
        }
    }
}
