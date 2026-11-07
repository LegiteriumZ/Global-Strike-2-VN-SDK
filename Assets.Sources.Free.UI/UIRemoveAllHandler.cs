using NetData;
using SSJJBase.Singleton;
using UnityEngine;

namespace Assets.Sources.Free.UI;

public class UIRemoveAllHandler : ISimpleMesssageHandler
{
	public bool CanHandle(int key)
	{
		return key == 56;
	}

	public void Handle(SimpleProto simpleUI)
	{
		Transform freeUiTran = MonoBehaviourSingleton<FreeUiManager>.Instance.GetFreeUiTran();
		if (freeUiTran != null)
		{
			Object.Destroy(freeUiTran.gameObject);
		}
		MonoBehaviourSingleton<FreeUiManager>.Instance.RemoveAllUi();
	}
}
