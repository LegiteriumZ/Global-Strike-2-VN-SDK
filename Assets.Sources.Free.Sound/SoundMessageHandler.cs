using NetData;

namespace Assets.Sources.Free.Sound;

public class SoundMessageHandler : ISimpleMesssageHandler
{
	public bool CanHandle(int key)
	{
		return key == 41;
	}

	public void Handle(SimpleProto data)
	{
	}
}
