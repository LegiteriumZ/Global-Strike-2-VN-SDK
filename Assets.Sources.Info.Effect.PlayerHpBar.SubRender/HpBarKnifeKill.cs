using Assets.Sources.Components.Interface.Info.GameRule;
using Assets.Sources.Constant.Career;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Info.Effect.PlayerHpBar.SubRender;

public class HpBarKnifeKill : BaseHpBar
{
	private GameObject _knifeKillObj;

	private RectTransform _knifeKillTran;

	private Image _knifeKillImage;

	private Vector3 _lastPos;

	private bool _lastActive = true;

	private IGameRule _gameRule;

	public override void Init(PlayerEntity playerEntity, GameObject effectGameObject, Contexts contexts, PlayerHpBarRender hpBar)
	{
		base.Init(playerEntity, effectGameObject, contexts, hpBar);
		_knifeKillImage = Tran.Find("WorldSpace/KnifeKill").GetComponent<Image>();
		_knifeKillTran = _knifeKillImage.rectTransform;
		_knifeKillObj = _knifeKillImage.gameObject;
		SetActive(_knifeKillObj, ref _lastActive, newActive: false);
		_gameRule = contexts.gameRule.currentRule.Rule;
		Loader.RetriveSprite("effect/bio3mode", "Assets/Res/Assets/effect/bio3Mode/suggest/knifeKill.png", delegate(Sprite sprite)
		{
			_knifeKillImage.sprite = sprite;
		});
	}

	public override void Update(PlayerEntity playerEntity, Vector3 pos)
	{
		base.Update(playerEntity, pos);
		if (playerEntity.IsDead() || playerEntity.basicInfo.Current.Hp > 500 || PlayerCareerConstantUtility.IsHumanity(PlayerData.Career) || (!_gameRule.IsBio3() && !_gameRule.IsBioEvolution()))
		{
			SetActive(_knifeKillObj, ref _lastActive, newActive: false);
			return;
		}
		SetActive(_knifeKillObj, ref _lastActive, newActive: true);
		HpBar.PosY += 30;
		SetPosition(_knifeKillTran, ref _lastPos, new Vector3(0f, HpBar.PosY));
		HpBar.PosY += 30;
	}
}
