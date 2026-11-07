using Assets.Libs.ForAce;
using Assets.Sources.Framework;
using SSJJBase.Singleton;

namespace Assets.Sources.Modules.Player.EntityCreate;

public class FakePlayerEntityCreateModule : IEntityCreateSystem
{
	private PlayerContext _playerContext;

	public PlayerEntity fakeplayer;

	public int frame = 1800;

	public FakePlayerEntityCreateModule(Contexts contexts)
	{
		_playerContext = contexts.player;
	}

	public void OnEntityCreate()
	{
		if (!MonoBehaviourSingleton<AceClientManager>.Instance._loginSucc)
		{
			return;
		}
		frame--;
		if (frame < 0)
		{
			if (fakeplayer == null)
			{
				frame = 180;
				fakeplayer = _playerContext.CreateEntity();
				return;
			}
			frame = 3600;
			fakeplayer.isDestroy = true;
			fakeplayer.Destroy();
			fakeplayer = null;
		}
	}
}
