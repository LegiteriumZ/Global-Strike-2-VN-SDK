using System;
using Assets.Sources.Components.Interface;
using Assets.Sources.Constant.Career;
using UnityEngine;

namespace Assets.Sources.Info.Effect.PlayerEffect.Render;

public class RemoteVariantGunFireRender : AbstractPlayerEffectRender
{
	private GameObject _sprite;

	private int _time;

	private static bool[] _show = new bool[15]
	{
		true, true, false, true, true, false, true, true, false, true,
		true, false, true, true, false
	};

	private int _minDis = 3000;

	private int _maxDis = 10000;

	private PlayerEntity _myPlayer;

	public override void Init(PlayerEntity player, GameObject effectGameObject)
	{
		_sprite = effectGameObject.transform.Find("1").gameObject;
		_time = -1;
		_sprite.SetObjectActive(isactive: false);
		_minDis = (Contexts.sharedInstance.gameRule.currentRule.Rule.IsGeneralPve() ? 2000 : 3000);
	}

	public override void Render(int frameTime, PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		if (_time > -1)
		{
			_time += frameTime;
			int num = _time / 50;
			if (num < _show.Length)
			{
				if (_sprite.IsActiveSelf() != _show[num])
				{
					_sprite.SetObjectActive(_show[num]);
				}
				return;
			}
			if (_sprite.IsActiveSelf())
			{
				_sprite.SetObjectActive(isactive: false);
			}
			_time = -1;
		}
		else if (targetPlayer.GetTorseAnimation() == 15 || targetPlayer.GetLegAnimation() == 45 || targetPlayer.GetLegAnimation() == 52)
		{
			if (_myPlayer == null)
			{
				_myPlayer = Contexts.sharedInstance.player.myPlayerEntity;
			}
			float num2 = Vector3.Distance(_myPlayer.GetCompenstatePos(_myPlayer.fpos.Change.GetPosIndex()), targetPlayer.GetCompenstatePos(targetPlayer.fpos.Change.GetPosIndex()));
			if (num2 > (float)_minDis && num2 < (float)_maxDis)
			{
				_time = 0;
			}
		}
	}

	public override Vector3 GetOffset(PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		return new Vector3(Mathf.Cos(targetPlayer.GetViewYaw() * ((float)Math.PI / 180f)) * 100f, Mathf.Sin(targetPlayer.GetViewYaw() * ((float)Math.PI / 180f)) * 100f, (float)PlayerCareerConstantUtility.GetHeight(targetPlayer.GetCareer()) * 0.75f);
	}
}
