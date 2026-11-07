using System.Collections.Generic;
using Assets.Sources.Config;
using Assets.Sources.Constant.Career;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Info.Effect.PlayerHpBar.SubRender;

public class HpBarName : BaseHpBar
{
	private static readonly HashSet<string> CareerNoName = new HashSet<string>
	{
		"rpg_tank1", "rpg_jetpack", "rpg_10800002", "rpg_10800003", "rpg_empty_1", "rpg_10300307", "rpg_10003101", "rpg_10200701", "rpg_10100401", "rpg_10003125",
		"rpg_10003106", "rpg_10004001", "rpg_10005111", "rpg_10005112", "rpg_10005113", "rpg_10005114", "rpg_10005115", "rpg_10005116", "rpg_10005119", "rpg_10005120"
	};

	private Text _nameText;

	private RectTransform _nameTextTran;

	private GameObject _nameTextObj;

	private bool _isFriendly;

	private int _nameColor;

	private Vector3 _lastNamePos;

	private bool _lastNameTextActive = true;

	private bool _isShowNameCareer;

	private string _originName;

	public override void Init(PlayerEntity playerEntity, GameObject effectGameObject, Contexts contexts, PlayerHpBarRender hpBar)
	{
		base.Init(playerEntity, effectGameObject, contexts, hpBar);
		_nameText = Tran.Find("ScreenSpace/NameText").GetComponent<Text>();
		_nameTextTran = _nameText.rectTransform;
		_nameTextObj = _nameText.gameObject;
		SetActive(_nameTextObj, ref _lastNameTextActive, newActive: false);
		_isShowNameCareer = !CareerNoName.Contains(playerEntity.GetCareer());
		_isFriendly = playerEntity.IsFriendly();
		_nameText.text = PlayerData.PlayerName;
		_originName = PlayerData.PlayerName;
	}

	public override void Update(PlayerEntity playerEntity, Vector3 pos)
	{
		base.Update(playerEntity, pos);
		if (playerEntity.hasBasicInfo && playerEntity.basicInfo.Current != null)
		{
			string playerName = playerEntity.basicInfo.Current.PlayerName;
			if (!playerName.Equals(_originName))
			{
				_originName = playerName;
				_nameText.text = _originName;
			}
		}
		if (!_isShowNameCareer)
		{
			SetActive(_nameTextObj, ref _lastNameTextActive, newActive: false);
			return;
		}
		if (GameSetting.Config.SuggestFlag == 2)
		{
			SetActive(_nameTextObj, ref _lastNameTextActive, newActive: false);
			return;
		}
		if (!SameCameraTeam && !GameRule.IsBattleRoyaleMode())
		{
			if (GameRule.IsBio3())
			{
				if (!PlayerCareerConstantUtility.IsDoun(PlayerData.Career) && !PlayerCareerConstantUtility.IsEmpress(PlayerData.Career))
				{
					SetActive(_nameTextObj, ref _lastNameTextActive, newActive: false);
					return;
				}
				if (!PlayerEntity.hasBeAttack || playerEntity.beAttack.ShowTime <= 0)
				{
					SetActive(_nameTextObj, ref _lastNameTextActive, newActive: false);
					return;
				}
			}
			else if (GameRule.IsBio() && !GameRule.IsBio2() && !GameRule.IsBioEvolution())
			{
				if (!PlayerCareerConstantUtility.IsHero(PlayerData.Career) && !PlayerCareerConstantUtility.IsEmpress(PlayerData.Career))
				{
					SetActive(_nameTextObj, ref _lastNameTextActive, newActive: false);
					return;
				}
			}
			else
			{
				if (!GameRule.IsBioEvolution())
				{
					SetActive(_nameTextObj, ref _lastNameTextActive, newActive: false);
					return;
				}
				SetActive(_nameTextObj, ref _lastNameTextActive, newActive: false);
			}
		}
		if (PlayerData.IsDead)
		{
			if (_nameColor != 1)
			{
				_nameColor = 1;
				_nameText.color = new Color(0.816f, 0.816f, 0.816f);
				_nameText.GetComponent<Outline>().effectColor = new Color(0.278f, 0.278f, 0.278f, 0.745f);
			}
		}
		else if (PlayerData.TeamId == BaseHpBar.MyTeam && BaseHpBar.MyTeam != 0)
		{
			if (_nameColor != 2)
			{
				_nameColor = 2;
				_nameText.color = new Color(0f, 0.398f, 1f);
				_nameText.GetComponent<Outline>().effectColor = new Color(0.278f, 0.278f, 0.278f, 0.745f);
			}
		}
		else if (_isFriendly)
		{
			if (_nameColor != 3)
			{
				_nameColor = 3;
				_nameText.color = new Color(0f, 0.797f, 1f);
				_nameText.GetComponent<Outline>().effectColor = new Color(0.278f, 0.278f, 0.278f, 0.745f);
			}
		}
		else if (_nameColor != 4)
		{
			_nameColor = 4;
			_nameText.color = Color.green;
			_nameText.GetComponent<Outline>().effectColor = new Color(3f / 85f, 0.4862745f, 0f, 38f / 51f);
		}
		if (GameRule.IsBioEvolution())
		{
			if (SameCameraTeam)
			{
				if (Vector3.Distance(Contexts.sharedInstance.player.cameraOwnerEntity.GetCompenstatePos(Contexts.sharedInstance.player.cameraOwnerEntity.fpos.Change.GetPosIndex()), playerEntity.GetCompenstatePos(playerEntity.fpos.Change.GetPosIndex())) * 0.01f > 30f || PlayerCareerConstantUtility.IsDoun(PlayerData.Career) || PlayerCareerConstantUtility.IsEmpress(PlayerData.Career))
				{
					SetActive(_nameTextObj, ref _lastNameTextActive, newActive: false);
				}
				else
				{
					SetActive(_nameTextObj, ref _lastNameTextActive, newActive: true);
				}
			}
		}
		else if (GameRule.IsBattleRoyaleMode())
		{
			if (!SameCameraTeam)
			{
				if (PlayerCareerConstantUtility.IsNoHuMan(PlayerData.Career))
				{
					SetActive(_nameTextObj, ref _lastNameTextActive, newActive: false);
				}
				else
				{
					SetActive(_nameTextObj, ref _lastNameTextActive, newActive: true);
				}
			}
			else
			{
				SetActive(_nameTextObj, ref _lastNameTextActive, newActive: true);
			}
		}
		else
		{
			SetActive(_nameTextObj, ref _lastNameTextActive, newActive: true);
		}
		pos += new Vector3(0f, HpBar.CareerHeight, 0f);
		Vector3 vector = (Vector3)RectTransformUtility.WorldToScreenPoint(MainCamera, pos) - new Vector3(Screen.width, Screen.height) / 2f;
		HpBar.PosY += 15;
		SetPosition(newPos: new Vector3((int)vector.x, (float)(int)vector.y + (float)HpBar.PosY * ScreenScale, (int)vector.z) / ScreenScale, tran: _nameTextTran, lastPos: ref _lastNamePos);
		HpBar.NamePosY = HpBar.PosY;
		HpBar.NameTextPos = _nameTextTran.localPosition;
		HpBar.NameWidth = _nameText.preferredWidth;
		HpBar.PosY += 10;
	}
}
