using SSJJBase.Cache;
using SSJJBase.Logger;

namespace Assets.Sources.Info.Res;

internal class HitResDefaultCreate : ICacheObjectFactory<int, HitResConfig>
{
	public HitResConfig CreateObject(int key)
	{
		this.LogErrorFormat("HitResDefaultCreate Unknown Id:{0}", key);
		return new HitResConfig("effect/common", "Assets/Res/Assets/effect/common/particle/event_95.prefab", 1, -1, 1100);
	}
}
