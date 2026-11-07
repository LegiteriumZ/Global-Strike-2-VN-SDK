using SSJJNetworking.Packet;
using SSJJNetworking.Server;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class P2PDataParser : IPacketBodyParser<P2PData>
{
	public P2PData Parse(byte[] data, int len)
	{
		return new P2PData
		{
			UdpSnapshotSpliced = UdpPacketFactory.ReadBool(data, 0),
			UdpSnapshotCompressed = UdpPacketFactory.ReadBool(data, 1),
			UdpSize = UdpPacketFactory.ReadInt(data, 2, 4)
		};
	}
}
