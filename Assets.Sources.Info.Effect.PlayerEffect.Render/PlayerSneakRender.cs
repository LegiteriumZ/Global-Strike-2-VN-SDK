using Assets.Res.Assets.Scripts;
using Assets.Sources.Components.Interface;
using UnityEngine;
using share.constant;

namespace Assets.Sources.Info.Effect.PlayerEffect.Render;

public class PlayerSneakRender : AbstractPlayerEffectRender
{
	private SpriteList _spriteList;

	private GameObject _spriteObj;

	public override void Init(PlayerEntity player, GameObject effectGameObject)
	{
		base.Init(player, effectGameObject);
		_spriteObj = effectGameObject.transform.Find("GameObject/1/sprite1").gameObject;
		_spriteList = _spriteObj.GetComponent<SpriteList>();
	}

	public override void Render(int frameTime, PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		if (targetPlayer.skill.Status.ContainsKey(PlayerInfoStatusConstant.RPG_qianxing_idle.ID))
		{
			_spriteObj.GetComponent<SpriteRenderer>().sprite = _spriteList.Sprites[0];
		}
		else if (targetPlayer.skill.Status.ContainsKey(PlayerInfoStatusConstant.RPG_qianxing_chakan.ID))
		{
			_spriteObj.GetComponent<SpriteRenderer>().sprite = _spriteList.Sprites[2];
		}
		else if (targetPlayer.skill.Status.ContainsKey(PlayerInfoStatusConstant.RPG_qianxing_faxian.ID))
		{
			_spriteObj.GetComponent<SpriteRenderer>().sprite = _spriteList.Sprites[1];
		}
	}

	public override Vector3 GetOffset(PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		return new Vector3(0f, 0f, GetHeight(targetPlayer) + 50f);
	}
}
