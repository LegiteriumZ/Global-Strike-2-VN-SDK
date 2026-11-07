using Assets.Sources.Components.Player;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.Player.Attack;

public class PlayerFovInitSystem : PredicationInitSystemBase<FovComponent>
{
	private readonly PlayerContext _playerContext;

	public override FovComponent CurrentComponent => _playerContext.cameraOwnerEntity.fov;

	public PlayerFovInitSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
	}

	public override void GetComponentFromSnapshot(FovComponent comp)
	{
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		if (cameraOwnerEntity != null)
		{
			comp.Fov = cameraOwnerEntity.basicInfo.Current.Fov;
			comp.LastFov = cameraOwnerEntity.basicInfo.Current.LastFov;
			comp.ResumeZoom = cameraOwnerEntity.basicInfo.Current.ResumeZoom;
		}
	}
}
