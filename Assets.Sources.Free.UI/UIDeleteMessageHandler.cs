using NetData;
using SSJJBase.Singleton;

namespace Assets.Sources.Free.UI;

public class UIDeleteMessageHandler : ISimpleMesssageHandler
{
	public bool CanHandle(int key)
	{
		return key == 55;
	}

	public void Handle(SimpleProto simpleUI)
	{
		string key = simpleUI.Ss[0];
		MonoBehaviourSingleton<FreeUiManager>.Instance.RemoveOldUi(key);
	}
}
