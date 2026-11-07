using Assets.Sources.Framework;
using SSJJMath;

namespace Assets.Sources.Modules.Player.Position;

public class SingleUpdateSelfPositionSystem : IRenderSystem
{
	private readonly PlayerContext _playerContext;

	public SingleUpdateSelfPositionSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
	}

	public void OnRender()
	{
		if (_playerContext.myPlayerEntity != null && _playerContext.myPlayerEntity.hasFpos && _playerContext.myPlayerEntity.hasThirdPersonUnityObjects)
		{
			UpdateLocation(_playerContext.myPlayerEntity);
		}
	}

	private static void UpdateLocation(PlayerEntity entity)
	{
		VectorCoordConverter.SsjjToUnity(entity.GetCompenstatePos(entity.fpos.Change.GetPosIndex()), out var dest);
		entity.thirdPersonUnityObjects.ThirdTran.RootContainer.transform.position = dest;
	}
}
