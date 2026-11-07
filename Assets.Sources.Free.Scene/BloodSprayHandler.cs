using NetData;

namespace Assets.Sources.Free.Scene;

public class BloodSprayHandler : ISimpleMesssageHandler
{
	public bool CanHandle(int key)
	{
		return key == 49;
	}

	public void Handle(SimpleProto simpleUI)
	{
		_ = simpleUI.Bs[0];
	}
}
