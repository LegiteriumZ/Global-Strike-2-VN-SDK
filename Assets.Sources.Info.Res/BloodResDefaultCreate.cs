using SSJJBase.Cache;
using SSJJBase.Logger;

namespace Assets.Sources.Info.Res;

internal class BloodResDefaultCreate : ICacheObjectFactory<int, BloodResConfig>
{
	private static readonly LoggerAdapter Logger = new LoggerAdapter(typeof(BloodResDefaultCreate));

	public BloodResConfig CreateObject(int key)
	{
		Logger.ErrorFormat("BloodResDefaultCreate Unknown Id:{0}", key);
		return new BloodResConfig("effect/common", "Assets/Res/Assets/effectprefab/wallblood/common/blood.prefab", 3, -1);
	}
}
