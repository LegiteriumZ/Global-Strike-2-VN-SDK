using NetData;
using UnityEngine;

namespace Assets.Sources.Free.Effect;

public class EffectDeleteHandler : ISimpleMesssageHandler
{
	private const string DEBUG_ID = "debug_effect";

	public bool CanHandle(int key)
	{
		return key == 65;
	}

	public void Handle(SimpleProto sp)
	{
		string key = sp.Ss[0];
		FreeRenderObject effect = FreeEffectManager.GetInstance().GetEffect(key);
		if (effect != null)
		{
			Object.Destroy(effect.gameObject);
			FreeEffectManager.GetInstance().RemoveEffect(effect);
		}
	}
}
