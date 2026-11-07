using NetData;

namespace Assets.Sources.Free.Entity;

internal class PlayerStateHandler : ISimpleMesssageHandler
{
	public const int INVISIBLE = 1;

	public const int INTERCEPT = 2;

	public const int MEMORY = 3;

	public const int DRAW_COUNT = 4;

	public bool CanHandle(int key)
	{
		return key == 42;
	}

	public void Handle(SimpleProto data)
	{
		int num = data.Ins[0];
		float num2 = data.Fs[0];
		switch (num)
		{
		case 2:
			Contexts.sharedInstance.userCommand.commands.State = (int)num2;
			break;
		case 1:
		case 3:
		case 4:
			break;
		}
	}
}
