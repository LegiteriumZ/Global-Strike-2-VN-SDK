using Assets.Sources.Components.Interface;
using Assets.Sources.Constant.Career;
using Assets.Sources.Utils.SceneObject;
using UnityEngine;

namespace Assets.Sources.Info.Effect.SceneBufferEffect.Render;

public class WeaponBuffEffectRender : AbstractSceneBuffEffectRender
{
	private PlayerContext _playerContext;

	public override void Init(ISceneObjectEntity entity, GameObject effectGameObject)
	{
		base.Init(entity, effectGameObject);
		_playerContext = Contexts.sharedInstance.player;
	}

	public override bool CanPickWeapon()
	{
		if (PlayerCareerConstantUtility.IsHumanity(_playerContext.myPlayerEntity.GetCareer()))
		{
			return SceneObjectEntityUtility.CanPickWeapon(_playerContext.myPlayerEntity, Entity);
		}
		return false;
	}
}
