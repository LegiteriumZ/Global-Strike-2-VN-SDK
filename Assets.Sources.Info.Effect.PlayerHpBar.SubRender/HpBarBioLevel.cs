using Assets.Sources.Components.Interface.Info.GameRule;
using Assets.Sources.Constant.Career;
using SSJJBase.String;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Info.Effect.PlayerHpBar.SubRender;

public class HpBarBioLevel : BaseHpBar
{
	private GameObject _bioLevelBackObj;

	private RectTransform _bioLevelBackTran;

	private Image _bioLevelBackImage;

	private Text _bioLevelText;

	private Vector3 _lastPos;

	private bool _lastActive = true;

	private IGameRule _gameRule;

	public override void Init(PlayerEntity playerEntity, GameObject effectGameObject, Contexts contexts, PlayerHpBarRender hpBar)
	{
		base.Init(playerEntity, effectGameObject, contexts, hpBar);
		_bioLevelBackImage = Tran.Find("ScreenSpace/BioLevelBack").GetComponent<Image>();
		_bioLevelBackTran = _bioLevelBackImage.rectTransform;
		_bioLevelBackObj = _bioLevelBackImage.gameObject;
		_bioLevelText = Tran.Find("ScreenSpace/BioLevelBack/BioLevel").GetComponent<Text>();
		SetActive(_bioLevelBackObj, ref _lastActive, newActive: false);
		_gameRule = contexts.gameRule.currentRule.Rule;
		Loader.RetriveSprite("effect/bio3mode", "Assets/Res/Assets/effect/bio3Mode/suggest/lvBack.png", delegate(Sprite sprite)
		{
			_bioLevelBackImage.sprite = sprite;
		});
	}

	public override void Update(PlayerEntity playerEntity, Vector3 pos)
	{
		base.Update(playerEntity, pos);
		if (PlayerCareerConstantUtility.IsHumanity(PlayerData.Career) || (!_gameRule.IsBio3() && !_gameRule.IsBioEvolution()))
		{
			SetActive(_bioLevelBackObj, ref _lastActive, newActive: false);
			return;
		}
		if (SameCameraTeam && (Vector3.Distance(Contexts.sharedInstance.player.cameraOwnerEntity.GetCompenstatePos(Contexts.sharedInstance.player.cameraOwnerEntity.fpos.Change.GetPosIndex()), playerEntity.GetCompenstatePos(playerEntity.fpos.Change.GetPosIndex())) * 0.01f > 30f || PlayerCareerConstantUtility.IsEmpress(PlayerData.Career)))
		{
			SetActive(_bioLevelBackObj, ref _lastActive, newActive: false);
			return;
		}
		if (!SameCameraTeam)
		{
			if (GameRule.IsBio3())
			{
				if (!PlayerCareerConstantUtility.IsDoun(PlayerData.Career) && !PlayerCareerConstantUtility.IsEmpress(PlayerData.Career))
				{
					SetActive(_bioLevelBackObj, ref _lastActive, newActive: false);
					return;
				}
				if (!PlayerEntity.hasBeAttack || playerEntity.beAttack.ShowTime <= 0)
				{
					SetActive(_bioLevelBackObj, ref _lastActive, newActive: false);
					return;
				}
			}
			if (_gameRule.IsBioEvolution() && PlayerCareerConstantUtility.IsEmpress(PlayerData.Career))
			{
				SetActive(_bioLevelBackObj, ref _lastActive, newActive: false);
				return;
			}
		}
		SetActive(_bioLevelBackObj, ref _lastActive, newActive: true);
		_bioLevelText.text = StringCache.IntToString(PlayerEntity.basicInfo.Current.GeneLv);
		if (!_gameRule.IsBioEvolution())
		{
			SetPosition(_bioLevelBackTran, ref _lastPos, new Vector3((0f - HpBar.NameWidth) / 2f, 0f) + HpBar.NameTextPos);
		}
		else
		{
			SetPosition(_bioLevelBackTran, ref _lastPos, HpBar.NameTextPos);
		}
	}
}
