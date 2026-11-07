using SSJJBase.Logger;

namespace Assets.Sources.Snapshots;

public class TcpSnapshotParser : AbstractSnapshotParser
{
	public TcpSnapshotParser()
	{
		Logger = new LoggerAdapter(typeof(TcpSnapshotParser));
		Offset = 0;
	}
}
