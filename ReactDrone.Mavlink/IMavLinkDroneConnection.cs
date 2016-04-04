using System;
using MavLinkNet;

namespace ReactDrone.Mavlink
{
    internal interface IMavLinkDroneConnection
    {
        IObservable<MavLinkPacket> MavLinkPacketSource { get; }
    }
}