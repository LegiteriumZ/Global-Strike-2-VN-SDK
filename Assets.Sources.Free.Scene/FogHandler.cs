using Assets.Scripts.Fog;
using NetData;
using SSJJBase.Logger;
using SSJJBase.Singleton;
using UnityEngine;

namespace Assets.Sources.Free.Scene;

public class FogHandler : ISimpleMesssageHandler
{
	public bool CanHandle(int key)
	{
		return key == 45;
	}

	public void Handle(SimpleProto simpleUI)
	{
		float num = simpleUI.Fs[0];
		float num2 = simpleUI.Fs[1];
		string text = simpleUI.Ss[0];
		float num3 = simpleUI.Fs[2];
		int num4 = simpleUI.Ins[0];
		bool flag = simpleUI.Bs[0];
		ColorUtility.TryParseHtmlString($"#{text}", out var color);
		this.DebugFormat("Fog close  fogId {0} near {1} far {2} colorString {4} density {3}", num4, num, num2, num3, text);
		FreeFog freeFog = MonoBehaviourSingleton<FogManager>.Instance.GetFog(num4);
		if (flag && freeFog != null)
		{
			MonoBehaviourSingleton<FogManager>.Instance.RemoveFog(num4);
		}
		else if (!flag)
		{
			if (freeFog == null)
			{
				freeFog = new FreeFog(num4, new SSJJFog.FogConfig(num4));
				MonoBehaviourSingleton<FogManager>.Instance.AddFog(num4, freeFog);
			}
			freeFog.getFog().Set(num3, color, num, num2);
			freeFog.InitialAuto(simpleUI.Ss[1]);
			freeFog.StartAuto();
		}
	}
}
