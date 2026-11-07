using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Utils.Weapon;

namespace Assets.Sources.Modules.Ui.Cross;

public class AwpCrossUpdateSystem : IPlaybackSystem
{
	private CrossContext _crossContext;

	private PlayerContext _playerContext;

	private PlayerEntity _cameraOwner;

	public AwpCrossUpdateSystem(Contexts contexts)
	{
		_crossContext = contexts.cross;
		_playerContext = contexts.player;
	}

	public void OnPlayback()
	{
		if (_playerContext.isCameraOwner)
		{
			_cameraOwner = _playerContext.cameraOwnerEntity;
			_crossContext.isAwpCross = _cameraOwner.fov.Fov == 40 || _cameraOwner.fov.Fov == 10 || _cameraOwner.fov.Fov == 55;
			if (WeaponUtility.GetWeaponSuperCross(UiIEventCondition.Get_uiCross_WeaponName()))
			{
				_crossContext.isAwpCross = false;
			}
		}
	}
}
