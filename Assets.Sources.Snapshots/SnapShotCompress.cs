using SSJJNetworking.BattleServer;
using SSJJNetworking.Packet;

namespace Assets.Sources.Snapshots;

public class SnapShotCompress : ISnapShotCompress
{
	public void SnapShotDeCompress(PacketBase packetBase, bool isUdp, bool snapshotCompressed, byte[] outputBuffer)
	{
		SnapshotUtility.SnapShotDeCompress(packetBase, isUdp, snapshotCompressed, outputBuffer);
	}
}
