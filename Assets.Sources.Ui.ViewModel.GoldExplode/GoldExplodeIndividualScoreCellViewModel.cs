using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.GoldExplode;

[GameUiTest]
public class GoldExplodeIndividualScoreCellViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oGoldExplodeIndividualScoreCell;

	private GameObject _oSelfBack;

	private GameObject _oSelfTeamBack;

	private GameObject _oUnityFlag;

	private GameObject _oRankText;

	private Text _oRankTextText;

	private GameObject _oPlayerDead;

	private GameObject _oHeroWeapon;

	private GameObject _oPlayerFirst;

	private GameObject _oPlayerSecond;

	private GameObject _oPlayerThird;

	private GameObject _oPlayerKd;

	private GameObject _oPlayerMvp;

	private GameObject _oPlayerBlaster;

	private GameObject _oPlayerSpecialists;

	private GameObject _oPlayerCc;

	private GameObject _oPlayerGoldHunter;

	private GameObject _oPlayerName;

	private Text _oPlayerNameText;

	private GameObject _oVip;

	private Image _oVipImage;

	private GameObject _oPlayerTeam;

	private Text _oPlayerTeamText;

	private GameObject _oPlayerKill;

	private Text _oPlayerKillText;

	private GameObject _oPlayerDeath;

	private Text _oPlayerDeathText;

	private GameObject _oPlayerAssistant;

	private Text _oPlayerAssistantText;

	private GameObject _oPlayerPing;

	private Text _oPlayerPingText;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/goldexplode";

	private string _resourceAssetName = "GoldExplodeIndividualScoreCell";

	public GameObject GoldExplodeIndividualScoreCellObj => _oGoldExplodeIndividualScoreCell;

	public bool GoldExplodeIndividualScoreCellShow
	{
		get
		{
			if (_oGoldExplodeIndividualScoreCell != null)
			{
				return _oGoldExplodeIndividualScoreCell.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GoldExplodeIndividualScoreCellShow != value && _oGoldExplodeIndividualScoreCell != null)
			{
				_oGoldExplodeIndividualScoreCell.SetObjectActive(value);
			}
		}
	}

	public bool SelfBackShow
	{
		get
		{
			if (_oSelfBack != null)
			{
				return _oSelfBack.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelfBackShow != value && _oSelfBack != null)
			{
				_oSelfBack.SetObjectActive(value);
			}
		}
	}

	public bool SelfTeamBackShow
	{
		get
		{
			if (_oSelfTeamBack != null)
			{
				return _oSelfTeamBack.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelfTeamBackShow != value && _oSelfTeamBack != null)
			{
				_oSelfTeamBack.SetObjectActive(value);
			}
		}
	}

	public bool UnityFlagShow
	{
		get
		{
			if (_oUnityFlag != null)
			{
				return _oUnityFlag.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (UnityFlagShow != value && _oUnityFlag != null)
			{
				_oUnityFlag.SetObjectActive(value);
			}
		}
	}

	public string RankTextString
	{
		get
		{
			if (_oRankTextText != null)
			{
				return _oRankTextText.text;
			}
			return null;
		}
		set
		{
			if (RankTextString != value && _oRankTextText != null)
			{
				_oRankTextText.text = value;
			}
		}
	}

	public bool PlayerDeadShow
	{
		get
		{
			if (_oPlayerDead != null)
			{
				return _oPlayerDead.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerDeadShow != value && _oPlayerDead != null)
			{
				_oPlayerDead.SetObjectActive(value);
			}
		}
	}

	public bool HeroWeaponShow
	{
		get
		{
			if (_oHeroWeapon != null)
			{
				return _oHeroWeapon.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (HeroWeaponShow != value && _oHeroWeapon != null)
			{
				_oHeroWeapon.SetObjectActive(value);
			}
		}
	}

	public bool PlayerFirstShow
	{
		get
		{
			if (_oPlayerFirst != null)
			{
				return _oPlayerFirst.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerFirstShow != value && _oPlayerFirst != null)
			{
				_oPlayerFirst.SetObjectActive(value);
			}
		}
	}

	public bool PlayerSecondShow
	{
		get
		{
			if (_oPlayerSecond != null)
			{
				return _oPlayerSecond.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerSecondShow != value && _oPlayerSecond != null)
			{
				_oPlayerSecond.SetObjectActive(value);
			}
		}
	}

	public bool PlayerThirdShow
	{
		get
		{
			if (_oPlayerThird != null)
			{
				return _oPlayerThird.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerThirdShow != value && _oPlayerThird != null)
			{
				_oPlayerThird.SetObjectActive(value);
			}
		}
	}

	public bool PlayerKdShow
	{
		get
		{
			if (_oPlayerKd != null)
			{
				return _oPlayerKd.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerKdShow != value && _oPlayerKd != null)
			{
				_oPlayerKd.SetObjectActive(value);
			}
		}
	}

	public bool PlayerMvpShow
	{
		get
		{
			if (_oPlayerMvp != null)
			{
				return _oPlayerMvp.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerMvpShow != value && _oPlayerMvp != null)
			{
				_oPlayerMvp.SetObjectActive(value);
			}
		}
	}

	public bool PlayerBlasterShow
	{
		get
		{
			if (_oPlayerBlaster != null)
			{
				return _oPlayerBlaster.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerBlasterShow != value && _oPlayerBlaster != null)
			{
				_oPlayerBlaster.SetObjectActive(value);
			}
		}
	}

	public bool PlayerSpecialistsShow
	{
		get
		{
			if (_oPlayerSpecialists != null)
			{
				return _oPlayerSpecialists.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerSpecialistsShow != value && _oPlayerSpecialists != null)
			{
				_oPlayerSpecialists.SetObjectActive(value);
			}
		}
	}

	public bool PlayerCcShow
	{
		get
		{
			if (_oPlayerCc != null)
			{
				return _oPlayerCc.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerCcShow != value && _oPlayerCc != null)
			{
				_oPlayerCc.SetObjectActive(value);
			}
		}
	}

	public bool PlayerGoldHunterShow
	{
		get
		{
			if (_oPlayerGoldHunter != null)
			{
				return _oPlayerGoldHunter.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerGoldHunterShow != value && _oPlayerGoldHunter != null)
			{
				_oPlayerGoldHunter.SetObjectActive(value);
			}
		}
	}

	public string PlayerNameString
	{
		get
		{
			if (_oPlayerNameText != null)
			{
				return _oPlayerNameText.text;
			}
			return null;
		}
		set
		{
			if (PlayerNameString != value && _oPlayerNameText != null)
			{
				_oPlayerNameText.text = value;
			}
		}
	}

	public bool VipShow
	{
		get
		{
			if (_oVip != null)
			{
				return _oVip.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (VipShow != value && _oVip != null)
			{
				_oVip.SetObjectActive(value);
			}
		}
	}

	public Sprite VipSprite
	{
		get
		{
			if (_oVipImage != null)
			{
				return _oVipImage.sprite;
			}
			return null;
		}
		set
		{
			if (VipSprite != value && _oVipImage != null)
			{
				_oVipImage.sprite = value;
			}
		}
	}

	public string PlayerTeamString
	{
		get
		{
			if (_oPlayerTeamText != null)
			{
				return _oPlayerTeamText.text;
			}
			return null;
		}
		set
		{
			if (PlayerTeamString != value && _oPlayerTeamText != null)
			{
				_oPlayerTeamText.text = value;
			}
		}
	}

	public string PlayerKillString
	{
		get
		{
			if (_oPlayerKillText != null)
			{
				return _oPlayerKillText.text;
			}
			return null;
		}
		set
		{
			if (PlayerKillString != value && _oPlayerKillText != null)
			{
				_oPlayerKillText.text = value;
			}
		}
	}

	public string PlayerDeathString
	{
		get
		{
			if (_oPlayerDeathText != null)
			{
				return _oPlayerDeathText.text;
			}
			return null;
		}
		set
		{
			if (PlayerDeathString != value && _oPlayerDeathText != null)
			{
				_oPlayerDeathText.text = value;
			}
		}
	}

	public string PlayerAssistantString
	{
		get
		{
			if (_oPlayerAssistantText != null)
			{
				return _oPlayerAssistantText.text;
			}
			return null;
		}
		set
		{
			if (PlayerAssistantString != value && _oPlayerAssistantText != null)
			{
				_oPlayerAssistantText.text = value;
			}
		}
	}

	public string PlayerPingString
	{
		get
		{
			if (_oPlayerPingText != null)
			{
				return _oPlayerPingText.text;
			}
			return null;
		}
		set
		{
			if (PlayerPingString != value && _oPlayerPingText != null)
			{
				_oPlayerPingText.text = value;
			}
		}
	}

	public string ResourceBundleName
	{
		get
		{
			return _resourceBundleName;
		}
		set
		{
			_resourceBundleName = value;
		}
	}

	public string ResourceAssetName
	{
		get
		{
			return _resourceAssetName;
		}
		set
		{
			_resourceAssetName = value;
		}
	}

	public string ConfigBundleName => "";

	public string ConfigAssetName => "";

	public bool IsInited => _viewGameObject != null;

	public void CreateBinding(GameObject instance)
	{
		_viewGameObject = instance;
		Transform[] componentsInChildren = instance.GetComponentsInChildren<Transform>(includeInactive: true);
		foreach (Transform transform in componentsInChildren)
		{
			switch (transform.name.Replace("(Clone)", ""))
			{
			case "GoldExplodeIndividualScoreCell":
				_oGoldExplodeIndividualScoreCell = transform.gameObject;
				break;
			case "SelfBack":
				_oSelfBack = transform.gameObject;
				break;
			case "SelfTeamBack":
				_oSelfTeamBack = transform.gameObject;
				break;
			case "UnityFlag":
				_oUnityFlag = transform.gameObject;
				break;
			case "RankText":
				_oRankText = transform.gameObject;
				_oRankTextText = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerDead":
				_oPlayerDead = transform.gameObject;
				break;
			case "HeroWeapon":
				_oHeroWeapon = transform.gameObject;
				break;
			case "PlayerFirst":
				_oPlayerFirst = transform.gameObject;
				break;
			case "PlayerSecond":
				_oPlayerSecond = transform.gameObject;
				break;
			case "PlayerThird":
				_oPlayerThird = transform.gameObject;
				break;
			case "PlayerKd":
				_oPlayerKd = transform.gameObject;
				break;
			case "PlayerMvp":
				_oPlayerMvp = transform.gameObject;
				break;
			case "PlayerBlaster":
				_oPlayerBlaster = transform.gameObject;
				break;
			case "PlayerSpecialists":
				_oPlayerSpecialists = transform.gameObject;
				break;
			case "PlayerCc":
				_oPlayerCc = transform.gameObject;
				break;
			case "PlayerGoldHunter":
				_oPlayerGoldHunter = transform.gameObject;
				break;
			case "PlayerName":
				_oPlayerName = transform.gameObject;
				_oPlayerNameText = transform.gameObject.GetComponent<Text>();
				break;
			case "Vip":
				_oVip = transform.gameObject;
				_oVipImage = transform.gameObject.GetComponent<Image>();
				break;
			case "PlayerTeam":
				_oPlayerTeam = transform.gameObject;
				_oPlayerTeamText = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerKill":
				_oPlayerKill = transform.gameObject;
				_oPlayerKillText = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerDeath":
				_oPlayerDeath = transform.gameObject;
				_oPlayerDeathText = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerAssistant":
				_oPlayerAssistant = transform.gameObject;
				_oPlayerAssistantText = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerPing":
				_oPlayerPing = transform.gameObject;
				_oPlayerPingText = transform.gameObject.GetComponent<Text>();
				break;
			}
		}
	}

	public bool IsPropertyExist(string name)
	{
		return true;
	}

	public Transform GetParentLinkNode()
	{
		return null;
	}

	public Transform GetChildLinkNode()
	{
		return null;
	}

	public void Destory()
	{
		if (_viewGameObject != null)
		{
			Object.Destroy(_viewGameObject);
		}
	}

	public void Visible(bool isVisible)
	{
		if (_viewGameObject != null)
		{
			_viewGameObject.SetObjectActive(isVisible);
		}
	}

	public EventTrigger.Entry CreateTriggerEntry(List<EventTrigger.Entry> triggers, EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		EventTrigger.Entry entry = new EventTrigger.Entry
		{
			callback = new EventTrigger.TriggerEvent(),
			eventID = eventId
		};
		entry.callback.AddListener(callback);
		triggers?.Add(entry);
		return entry;
	}

	public List<RectTransform> GetHoldPosIntergeTrans()
	{
		return null;
	}
}
