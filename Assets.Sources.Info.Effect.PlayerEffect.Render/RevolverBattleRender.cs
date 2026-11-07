using Assets.Res.Assets.Scripts;
using Assets.Sources.Components.Interface;
using UnityEngine;

namespace Assets.Sources.Info.Effect.PlayerEffect.Render;

public class RevolverBattleRender : AbstractPlayerEffectRender
{
	private const int AIM_FLAG = 1;

	private const int LOCK_FLAG = 2;

	private const int CHOOSE_FLAG = 3;

	private SpriteList _spriteList;

	private SpriteRenderer _spriteRender;

	public override void Init(PlayerEntity player, GameObject effectGameObject)
	{
		base.Init(player, effectGameObject);
		_spriteRender = effectGameObject.GetComponentInChildren<SpriteRenderer>();
		_spriteList = effectGameObject.GetComponentInChildren<SpriteList>();
	}

	public override void Render(int frameTime, PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		if (targetPlayer.deadEye.ShowFlag == 1)
		{
			int num = targetPlayer.deadEye.EffectTime / (_spriteList.Sprites.Length - 2);
			int num2 = targetPlayer.deadEye.ServerTime / num;
			num2 = ((num2 < _spriteList.Sprites.Length - 2) ? num2 : (_spriteList.Sprites.Length - 3));
			if (_spriteRender.sprite != _spriteList.Sprites[num2])
			{
				_spriteRender.sprite = _spriteList.Sprites[num2];
			}
		}
		else if (targetPlayer.deadEye.ShowFlag == 2)
		{
			if (_spriteRender.sprite != _spriteList.Sprites[_spriteList.Sprites.Length - 2])
			{
				_spriteRender.sprite = _spriteList.Sprites[_spriteList.Sprites.Length - 2];
			}
		}
		else if (targetPlayer.deadEye.ShowFlag == 3 && _spriteRender.sprite != _spriteList.Sprites[_spriteList.Sprites.Length - 1])
		{
			_spriteRender.sprite = _spriteList.Sprites[_spriteList.Sprites.Length - 1];
		}
	}

	public override Vector3 GetOffset(PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		return new Vector3(0f, 0f, GetHeight(targetPlayer) * 0.6f);
	}
}
