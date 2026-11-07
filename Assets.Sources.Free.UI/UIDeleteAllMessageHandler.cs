using NetData;
using SSJJBase.Singleton;

namespace Assets.Sources.Free.UI;

public class UIDeleteAllMessageHandler : ISimpleMesssageHandler
{
	public bool CanHandle(int key)
	{
		return key == 57;
	}

	public void Handle(SimpleProto simpleUI)
	{
		string key = simpleUI.Ss[0];
		foreach (SimpleFreeUI item in MonoBehaviourSingleton<FreeUiManager>.Instance.GetUiWithPrefix(key))
		{
			if (item != null)
			{
				MonoBehaviourSingleton<FreeUiManager>.Instance.RemoveOldUi(item.Key);
			}
		}
		MonoBehaviourSingleton<FreeUiManager>.Instance.RemoveOldUi(key);
	}
}
