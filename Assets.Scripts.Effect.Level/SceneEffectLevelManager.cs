using Assets.Sources.Utils.Effect;
using SSJJBase.Singleton;

namespace Assets.Scripts.Effect.Level;

public class SceneEffectLevelManager : SingletonInstance<SceneEffectLevelManager>
{
	public int GetSceneLevel(string effectName)
	{
		return SingletonInstance<ParticleEffectVisibleConfig>.Instance.GetLevel(effectName);
	}
}
