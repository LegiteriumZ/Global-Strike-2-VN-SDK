using Assets.Sources.Components.Interface.Info.GameRule;
using SSJJMath;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Info.Effect.PlayerHpBar.SubRender;

public class HpBarBioShield : BaseHpBar
{
	private RectTransform _bioLevelBackTran;

	private Image _bioShieldBackImage;

	private RectTransform _parentRectTransform;

	private Image _bioShieldUpImage;

	private Vector3 _lastPos;

	private bool _lastActive = true;

	private IGameRule _gameRule;

	private PlayerEntity owerEntity;

	public override void Init(PlayerEntity playerEntity, GameObject effectGameObject, Contexts contexts, PlayerHpBarRender hpBar)
	{
		base.Init(playerEntity, effectGameObject, contexts, hpBar);
		_bioShieldBackImage = Tran.Find("WorldSpace/BioHuDun").GetComponent<Image>();
		_bioLevelBackTran = _bioShieldBackImage.rectTransform;
		_parentRectTransform = Tran.Find("WorldSpace").GetComponent<RectTransform>();
		_bioShieldUpImage = Tran.Find("WorldSpace/BioHuDun/Up").GetComponent<Image>();
		SetActive(_bioShieldBackImage.gameObject, ref _lastActive, newActive: false);
		_bioShieldUpImage.fillAmount = 0f;
		_gameRule = contexts.gameRule.currentRule.Rule;
		owerEntity = contexts.player.cameraOwnerEntity;
	}

	public override void Update(PlayerEntity playerEntity, Vector3 pos)
	{
		base.Update(playerEntity, pos);
		if (!_gameRule.IsBioEvolution() && !playerEntity.basicInfo.IsDead)
		{
			if (playerEntity.hasDunHpShow && playerEntity.dunHpShow.showMinNum > 0f)
			{
				_bioShieldUpImage.fillAmount = playerEntity.dunHpShow.showMinNum / playerEntity.dunHpShow.showMaxNum;
				SetActive(_bioShieldBackImage.gameObject, ref _lastActive, newActive: true);
				Vector3 inv = new Vector3(owerEntity.basicInfo.Current.X - playerEntity.basicInfo.Current.X, owerEntity.basicInfo.Current.Y - playerEntity.basicInfo.Current.Y, owerEntity.basicInfo.Current.Z - playerEntity.basicInfo.Current.Z);
				inv = VectorCoordConverter.SsjjToUnity(inv);
				inv.y = 0f;
				Vector3 vector = Vector3.Normalize(inv);
				HpBar.PosY -= 150;
				SetPos(_bioLevelBackTran, ref _lastPos, new Vector3(0f, (float)HpBar.PosY / _parentRectTransform.localScale.y, 0f - Mathf.Abs(vector.z * 45f / _parentRectTransform.localScale.z)));
				HpBar.PosY -= 150;
			}
			else
			{
				SetActive(_bioShieldBackImage.gameObject, ref _lastActive, newActive: false);
			}
		}
		else
		{
			SetActive(_bioShieldBackImage.gameObject, ref _lastActive, newActive: false);
		}
	}

	public void SetPos(Transform tran, ref Vector3 lastPos, Vector3 newPos)
	{
		if (lastPos != newPos)
		{
			tran.localPosition = newPos;
			lastPos = newPos;
		}
	}
}
