using Assets.Res.Assets.Scripts;
using Assets.Sources.Components.Interface;
using Assets.Sources.Utils.SceneObject;
using UnityEngine;

namespace Assets.Sources.Info.Effect.SceneBufferEffect.Render;

public class JumpStartEndEffectRender : AbstractSceneBuffEffectRender
{
	private Transform _suggest;

	private PlayerContext _playerContext;

	public override void Init(ISceneObjectEntity entity, GameObject effectGameObject)
	{
		base.Init(entity, effectGameObject);
		_playerContext = Contexts.sharedInstance.player;
		if (entity.HasSceneBuff)
		{
			_suggest = effectGameObject.transform.Find("GameObject/Suggest");
			effectGameObject.transform.Find("GameObject/2/sprite").localScale = Vector3.one * entity.SceneBuff.Data.Radius / 500f * 3f * 2f;
			if (entity.SceneBuff.Data.BufName == "jump_start")
			{
				_suggest.GetComponent<SpriteRenderer>().sprite = _suggest.GetComponent<SpriteList>().Sprites[0];
			}
			else if (entity.SceneBuff.Data.BufName == "jump_stop")
			{
				_suggest.GetComponent<SpriteRenderer>().sprite = _suggest.GetComponent<SpriteList>().Sprites[1];
			}
			if (!entity.SceneBuff.Data.Show)
			{
				effectGameObject.SetActive(value: false);
			}
		}
	}

	public override bool JumpStart()
	{
		if (Entity.SceneBuff.Data.BufName == "jump_start")
		{
			return SceneObjectEntityUtility.CanPickWeapon(_playerContext.myPlayerEntity, Entity);
		}
		return false;
	}

	public override bool JumpStop()
	{
		if (Entity.SceneBuff.Data.BufName == "jump_stop")
		{
			return SceneObjectEntityUtility.CanPickWeapon(_playerContext.myPlayerEntity, Entity);
		}
		return false;
	}
}
