using SSJJBase.Logger;

namespace Assets.Sources.Snapshots;

public class UdpSnapshotParser : AbstractSnapshotParser
{
	public UdpSnapshotParser()
	{
		Logger = new LoggerAdapter(typeof(UdpSnapshotParser));
		Offset = 5;
	}
}
