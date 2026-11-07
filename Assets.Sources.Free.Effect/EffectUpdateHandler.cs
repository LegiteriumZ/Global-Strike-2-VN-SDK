using NetData;

namespace Assets.Sources.Free.Effect;

public class EffectUpdateHandler : ISimpleMesssageHandler
{
	public bool CanHandle(int key)
	{
		return key == 62;
	}

	public void Handle(SimpleProto sp)
	{
		string key = sp.Ss[0];
		FreeRenderObject effect = FreeEffectManager.GetInstance().GetEffect(key);
		if (!(effect != null))
		{
			return;
		}
		for (int i = 0; i < sp.Ks.Count; i++)
		{
			int num = sp.Ks[i];
			int num2 = sp.Ins[i];
			string text = sp.Ss[i + 1];
			if (num == 0)
			{
				effect.ChangeAutoValue(num2, text);
			}
			else
			{
				effect.GetEffect(num - 1)?.SetValue(num2, text);
			}
		}
	}
}
