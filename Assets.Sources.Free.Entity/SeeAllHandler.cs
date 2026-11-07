using NetData;

namespace Assets.Sources.Free.Entity;

public class SeeAllHandler : ISimpleMesssageHandler
{
	public const int INVISIBLE = 1;

	public bool CanHandle(int key)
	{
		return key == 43;
	}

	public void Handle(SimpleProto simpleUI)
	{
		bool isSeeAllPlayer = simpleUI.Bs[0];
		Contexts.sharedInstance.battleRoom.gameStateEntity.isSeeAllPlayer = isSeeAllPlayer;
	}
}
