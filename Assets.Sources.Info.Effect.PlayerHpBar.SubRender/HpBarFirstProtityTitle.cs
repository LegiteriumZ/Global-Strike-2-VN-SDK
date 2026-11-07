using UnityEngine;
using UnityEngine.UI;
using share.constant;

namespace Assets.Sources.Info.Effect.PlayerHpBar.SubRender;

public class HpBarFirstProtityTitle : BaseHpBar
{
	private GameObject _firstProtityBackObj;

	private RectTransform _firstProtityBackTran;

	private Image _firstProtityBackImage;

	private Vector3 _lastPos;

	private bool _lastActive = true;

	public override void Init(PlayerEntity playerEntity, GameObject effectGameObject, Contexts contexts, PlayerHpBarRender hpBar)
	{
		base.Init(playerEntity, effectGameObject, contexts, hpBar);
		_firstProtityBackImage = Tran.Find("ScreenSpace/FirstProtityTitle").GetComponent<Image>();
		_firstProtityBackTran = _firstProtityBackImage.rectTransform;
		_firstProtityBackObj = _firstProtityBackImage.gameObject;
		SetActive(_firstProtityBackObj, ref _lastActive, newActive: false);
		Loader.RetriveSprite("effect/common", "Assets/Res/Assets/effect/common/honorary/cheating.png", delegate(Sprite sprite)
		{
			_firstProtityBackImage.sprite = sprite;
			_firstProtityBackImage.SetNativeSize();
		});
	}

	public override void Update(PlayerEntity playerEntity, Vector3 pos)
	{
		base.Update(playerEntity, pos);
		if (playerEntity.IsDead())
		{
			SetActive(_firstProtityBackObj, ref _lastActive, newActive: false);
		}
		else if (playerEntity.HasStatus(PlayerInfoStatusConstant.PLAYER_USING_CHEATING_FLAG.ID))
		{
			SetActive(_firstProtityBackObj, ref _lastActive, newActive: true);
			SetPosition(_firstProtityBackTran, ref _lastPos, HpBar.TitlePos);
		}
	}
}
