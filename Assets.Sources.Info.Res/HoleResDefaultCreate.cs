using SSJJBase.Cache;
using SSJJBase.Logger;

namespace Assets.Sources.Info.Res;

internal class HoleResDefaultCreate : ICacheObjectFactory<int, HoleResConfig>
{
	private static readonly LoggerAdapter Logger = new LoggerAdapter(typeof(HoleResDefaultCreate));

	public HoleResConfig CreateObject(int key)
	{
		Logger.ErrorFormat("RailResDefaultCreate Unknown Id:{0}", key);
		return new HoleResConfig("effectprefab/hole", "bullet", 0);
	}
}
