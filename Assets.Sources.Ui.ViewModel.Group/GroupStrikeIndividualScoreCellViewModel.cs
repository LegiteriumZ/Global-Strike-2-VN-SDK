using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Group;

[GameUiTest]
public class GroupStrikeIndividualScoreCellViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oGroupStrikeIndividualScoreCell;

	private GameObject _oSelfBack;

	private GameObject _oSelfTeamBack;

	private GameObject _oUnityFlag;

	private GameObject _oRankText;

	private Text _oRankTextText;

	private GameObject _oPlayerDead;

	private GameObject _oHero;

	private GameObject _oFirst;

	private GameObject _oGunKing;

	private GameObject _oSecond;

	private GameObject _oThird;

	private GameObject _oKd;

	private GameObject _oMvp;

	private GameObject _oBlaster;

	private GameObject _oC4Holder;

	private GameObject _oSpecialists;

	private GameObject _oPlayerName;

	private Text _oPlayerNameText;

	private GameObject _oPlayerTeam;

	private Text _oPlayerTeamText;

	private GameObject _oPlayerStroke;

	private Text _oPlayerStrokeText;

	private GameObject _oPlayerScore;

	private Text _oPlayerScoreText;

	private GameObject _oPlayerAssistant;

	private Text _oPlayerAssistantText;

	private GameObject _oPlayerPing;

	private Text _oPlayerPingText;

	private GameObject _oVip;

	private Image _oVipImage;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/group";

	private string _resourceAssetName = "GroupStrikeIndividualScoreCell";

	public GameObject GroupStrikeIndividualScoreCellObj => _oGroupStrikeIndividualScoreCell;

	public bool GroupStrikeIndividualScoreCellShow
	{
		get
		{
			if (_oGroupStrikeIndividualScoreCell != null)
			{
				return _oGroupStrikeIndividualScoreCell.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GroupStrikeIndividualScoreCellShow != value && _oGroupStrikeIndividualScoreCell != null)
			{
				_oGroupStrikeIndividualScoreCell.SetObjectActive(value);
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

	public bool HeroShow
	{
		get
		{
			if (_oHero != null)
			{
				return _oHero.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (HeroShow != value && _oHero != null)
			{
				_oHero.SetObjectActive(value);
			}
		}
	}

	public bool FirstShow
	{
		get
		{
			if (_oFirst != null)
			{
				return _oFirst.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (FirstShow != value && _oFirst != null)
			{
				_oFirst.SetObjectActive(value);
			}
		}
	}

	public bool GunKingShow
	{
		get
		{
			if (_oGunKing != null)
			{
				return _oGunKing.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GunKingShow != value && _oGunKing != null)
			{
				_oGunKing.SetObjectActive(value);
			}
		}
	}

	public bool SecondShow
	{
		get
		{
			if (_oSecond != null)
			{
				return _oSecond.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SecondShow != value && _oSecond != null)
			{
				_oSecond.SetObjectActive(value);
			}
		}
	}

	public bool ThirdShow
	{
		get
		{
			if (_oThird != null)
			{
				return _oThird.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ThirdShow != value && _oThird != null)
			{
				_oThird.SetObjectActive(value);
			}
		}
	}

	public bool KdShow
	{
		get
		{
			if (_oKd != null)
			{
				return _oKd.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (KdShow != value && _oKd != null)
			{
				_oKd.SetObjectActive(value);
			}
		}
	}

	public bool MvpShow
	{
		get
		{
			if (_oMvp != null)
			{
				return _oMvp.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MvpShow != value && _oMvp != null)
			{
				_oMvp.SetObjectActive(value);
			}
		}
	}

	public bool BlasterShow
	{
		get
		{
			if (_oBlaster != null)
			{
				return _oBlaster.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BlasterShow != value && _oBlaster != null)
			{
				_oBlaster.SetObjectActive(value);
			}
		}
	}

	public bool C4HolderShow
	{
		get
		{
			if (_oC4Holder != null)
			{
				return _oC4Holder.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (C4HolderShow != value && _oC4Holder != null)
			{
				_oC4Holder.SetObjectActive(value);
			}
		}
	}

	public bool SpecialistsShow
	{
		get
		{
			if (_oSpecialists != null)
			{
				return _oSpecialists.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SpecialistsShow != value && _oSpecialists != null)
			{
				_oSpecialists.SetObjectActive(value);
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

	public string PlayerStrokeString
	{
		get
		{
			if (_oPlayerStrokeText != null)
			{
				return _oPlayerStrokeText.text;
			}
			return null;
		}
		set
		{
			if (PlayerStrokeString != value && _oPlayerStrokeText != null)
			{
				_oPlayerStrokeText.text = value;
			}
		}
	}

	public string PlayerScoreString
	{
		get
		{
			if (_oPlayerScoreText != null)
			{
				return _oPlayerScoreText.text;
			}
			return null;
		}
		set
		{
			if (PlayerScoreString != value && _oPlayerScoreText != null)
			{
				_oPlayerScoreText.text = value;
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
			case "GroupStrikeIndividualScoreCell":
				_oGroupStrikeIndividualScoreCell = transform.gameObject;
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
			case "Hero":
				_oHero = transform.gameObject;
				break;
			case "First":
				_oFirst = transform.gameObject;
				break;
			case "GunKing":
				_oGunKing = transform.gameObject;
				break;
			case "Second":
				_oSecond = transform.gameObject;
				break;
			case "Third":
				_oThird = transform.gameObject;
				break;
			case "Kd":
				_oKd = transform.gameObject;
				break;
			case "Mvp":
				_oMvp = transform.gameObject;
				break;
			case "Blaster":
				_oBlaster = transform.gameObject;
				break;
			case "C4Holder":
				_oC4Holder = transform.gameObject;
				break;
			case "Specialists":
				_oSpecialists = transform.gameObject;
				break;
			case "PlayerName":
				_oPlayerName = transform.gameObject;
				_oPlayerNameText = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerTeam":
				_oPlayerTeam = transform.gameObject;
				_oPlayerTeamText = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerStroke":
				_oPlayerStroke = transform.gameObject;
				_oPlayerStrokeText = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerScore":
				_oPlayerScore = transform.gameObject;
				_oPlayerScoreText = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerAssistant":
				_oPlayerAssistant = transform.gameObject;
				_oPlayerAssistantText = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerPing":
				_oPlayerPing = transform.gameObject;
				_oPlayerPingText = transform.gameObject.GetComponent<Text>();
				break;
			case "Vip":
				_oVip = transform.gameObject;
				_oVipImage = transform.gameObject.GetComponent<Image>();
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
