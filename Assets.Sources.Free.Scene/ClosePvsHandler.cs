using NetData;

namespace Assets.Sources.Free.Scene;

public class ClosePvsHandler : ISimpleMesssageHandler
{
	public bool CanHandle(int key)
	{
		return key == 48;
	}

	public void Handle(SimpleProto simpleUI)
	{
		_ = simpleUI.Bs[0];
	}
}
