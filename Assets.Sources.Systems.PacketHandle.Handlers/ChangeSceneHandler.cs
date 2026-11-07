using NetData;
using SSJJBase.Logger;
using SSJJBase.Manager;
using SSJJBase.Singleton;
using UnityEngine.SceneManagement;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class ChangeSceneHandler : ApcPacketHandler<IntData>
{
	public ChangeSceneHandler(Contexts contexts)
	{
	}

	public override int MethodId()
	{
		return 201;
	}

	public override void Handle(IntData data)
	{
		Contexts.sharedInstance.battleServer.battleServer.Server.Disconnect(isKill: false);
		BattleSingletonInstance<BattleAssetClear>.Instance.ClearAll();
		MonoBehaviourSingleton<GameExitManager>.Instance.ExitGame();
		UnLoadAssetUtil.UnLoadAsset();
		SceneManager.LoadScene(0);
		this.Info(" ChangeSceneHandler ");
	}
}
