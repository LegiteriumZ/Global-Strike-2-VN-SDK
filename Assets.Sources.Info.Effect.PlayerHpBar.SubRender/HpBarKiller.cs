using Assets.Sources.Modules.Ui.UiEventCondition;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Info.Effect.PlayerHpBar.SubRender;

public class HpBarKiller : BaseHpBar
{
	private Image _killerImage;

	private GameObject _killerImageObj;

	private RectTransform _killerImageTran;

	private Vector3 _lastKillerPos;

	private bool _lastKillerActive = true;

	private bool _killerLoaded;

	public override void Init(PlayerEntity playerEntity, GameObject effectGameObject, Contexts contexts, PlayerHpBarRender hpBar)
	{
		base.Init(playerEntity, effectGameObject, contexts, hpBar);
		_killerImage = Tran.Find("WorldSpace/KillerImage").GetComponent<Image>();
		_killerImageObj = _killerImage.gameObject;
		_killerImageTran = _killerImage.rectTransform;
		SetActive(_killerImageObj, ref _lastKillerActive, newActive: false);
	}

	public override void Update(PlayerEntity playerEntity, Vector3 pos)
	{
		base.Update(playerEntity, pos);
		bool flag = !string.IsNullOrEmpty(PlayerData.PlayerName) && PlayerData.PlayerName == UiIEventCondition.Get_killPlayerInfo_KillerName();
		SetActive(_killerImageObj, ref _lastKillerActive, flag);
		if (!flag)
		{
			return;
		}
		if (!_killerLoaded)
		{
			_killerLoaded = true;
			Loader.RetriveSprite("effect/common", "Assets/Res/Assets/effect/common/killplayer/kill.png", delegate(Sprite sprite)
			{
				_killerImage.sprite = sprite;
			});
		}
		HpBar.PosY += 14;
		SetPosition(_killerImageTran, ref _lastKillerPos, new Vector3(0f, HpBar.PosY));
		HpBar.PosY += 14;
	}
}
