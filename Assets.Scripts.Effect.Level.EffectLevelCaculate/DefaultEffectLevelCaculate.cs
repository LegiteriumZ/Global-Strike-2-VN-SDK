using Assets.Scripts.Utility.ParticleSize;
using UnityEngine;

namespace Assets.Scripts.Effect.Level.EffectLevelCaculate;

public class DefaultEffectLevelCaculate : IEffectLevelCaculate
{
	protected long[] BaseSizeArray = new long[4];

	public DefaultEffectLevelCaculate()
	{
		BaseSizeArray[0] = 900L;
		BaseSizeArray[1] = 9000L;
		BaseSizeArray[2] = 40000L;
		BaseSizeArray[3] = 100000L;
	}

	public int GetEffectLevel(GameObject particleGameObject)
	{
		ParticleSizeUnit component = particleGameObject.GetComponent<ParticleSizeUnit>();
		if (component == null)
		{
			return -1;
		}
		float size = component.Size;
		int result = 0;
		if (size >= (float)BaseSizeArray[3])
		{
			result = 4;
		}
		else if (size >= (float)BaseSizeArray[2])
		{
			result = 3;
		}
		else if (size >= (float)BaseSizeArray[1])
		{
			result = 2;
		}
		else if (size >= (float)BaseSizeArray[0])
		{
			result = 1;
		}
		return result;
	}
}
