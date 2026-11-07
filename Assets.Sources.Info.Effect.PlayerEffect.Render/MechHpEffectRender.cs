using Assets.Sources.Components.Interface;
using UnityEngine;
using UnityEngine.UI;
using share.constant;

namespace Assets.Sources.Info.Effect.PlayerEffect.Render;

public class MechHpEffectRender : AbstractPlayerEffectRender
{
	private Image _hpImage;

	private GameObject _attack;

	private Image _repleImage;

	private GameObject _huoyan;

	public override void Init(PlayerEntity player, GameObject effectGameObject)
	{
		base.Init(player, effectGameObject);
		_hpImage = EffectObject.transform.Find("Pivot/Hp").GetComponent<Image>();
		_attack = EffectObject.transform.Find("Pivot/Attack").gameObject;
		_repleImage = EffectObject.transform.Find("Pivot/Bottom").GetComponent<Image>();
		_huoyan = EffectObject.transform.Find("Pivot/Huoyan").gameObject;
		_attack.SetObjectActive(isactive: false);
		_huoyan.SetObjectActive(isactive: false);
	}

	public override Vector3 GetOffset(PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		return new Vector3(0f, 0f, GetHeight(targetPlayer));
	}

	public override void Render(int frameTime, PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		_repleImage.fillAmount = targetPlayer.GetRepelPercent();
		_hpImage.fillAmount = (float)(0.9800000190734863 * targetPlayer.GetHpPercent() + 0.004999999888241291);
		bool flag = targetPlayer.skill.Status.ContainsKey(PlayerInfoStatusConstant.MECH_E_ATTACK.ID);
		if (_attack.IsActiveSelf() != flag)
		{
			_attack.SetObjectActive(flag);
		}
		flag = targetPlayer.skill.Status.ContainsKey(PlayerInfoStatusConstant.MECHBOMBERMAN2_HUOYAN_TARGET_BUFF.ID);
		if (_huoyan.IsActiveSelf() != flag)
		{
			_huoyan.SetObjectActive(flag);
		}
	}
}
