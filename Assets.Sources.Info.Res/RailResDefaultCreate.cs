using SSJJBase.Cache;
using SSJJBase.Logger;

namespace Assets.Sources.Info.Res;

internal class RailResDefaultCreate : ICacheObjectFactory<int, RailResConfig>
{
	private static readonly LoggerAdapter Logger = new LoggerAdapter(typeof(RailResDefaultCreate));

	public RailResConfig CreateObject(int key)
	{
		Logger.ErrorFormat("RailResDefaultCreate Unknown Id:{0}", key);
		return new RailResConfig("effectprefab/rail", "bullet", 0);
	}
}
