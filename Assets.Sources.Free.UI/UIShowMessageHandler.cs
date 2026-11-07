using Assets.Sources.Free.Data;
using NetData;

namespace Assets.Sources.Free.UI;

public class UIShowMessageHandler : ISimpleMesssageHandler
{
	public bool CanHandle(int key)
	{
		if (key != 51)
		{
			return key == 52;
		}
		return true;
	}

	public void Handle(SimpleProto simpleUI)
	{
		UIDataManager.Instance.SFreeUIata.SimpleDataChanged(simpleUI);
	}
}
