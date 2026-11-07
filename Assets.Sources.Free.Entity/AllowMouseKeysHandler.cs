using NetData;

namespace Assets.Sources.Free.Entity;

public class AllowMouseKeysHandler : ISimpleMesssageHandler
{
	public bool CanHandle(int key)
	{
		return key == 44;
	}

	public void Handle(SimpleProto simpleUI)
	{
		_ = simpleUI.Ins[0];
	}
}
