using System.Collections.Generic;
using Assets.Sources.Utils.Ui;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using SSJJBase.Extensions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Jump;

[GameUiTest]
public class JumpplayerscorecellViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _ojumpplayerscorecell;

	private GameObject _oShow;

	private GameObject _oUnityFlag;

	private GameObject _oRankText;

	private Text _oRankTextText;

	private GameObject _oPlayerHonor1;

	private GameObject _oPlayerHonor2;

	private GameObject _oPlayerHonor3;

	private Image _oPlayerHonorImage1;

	private Image _oPlayerHonorImage2;

	private Image _oPlayerHonorImage3;

	private GameObject _oHeroImage;

	private GameObject _oPlayerDead;

	private GameObject _oPlayerName;

	private Text _oPlayerNameText;

	private GameObject _oPlayerTeam;

	private Text _oPlayerTeamText;

	private GameObject _oMinutes;

	private Text _oMinutesText;

	private GameObject _oSeconds;

	private Text _oSecondsText;

	private GameObject _oMilliseconds;

	private Text _oMillisecondsText;

	private GameObject _oAddTime;

	private Text _oAddTimeText;

	private GameObject _oSavePoint;

	private Text _oSavePointText;

	private GameObject _oReadPoint;

	private Text _oReadPointText;

	private GameObject _oWeapon;

	private Text _oWeaponText;

	private GameObject _oPlayerPing;

	private Text _oPlayerPingText;

	private GameObject _viewGameObject;

	private UiReferences uiRef;

	private string _resourceBundleName = "uiprefabs/jump";

	private string _resourceAssetName = "Jumpplayerscorecell";

	public UiReferences UI => uiRef;

	public GameObject jumpplayerscorecellObj => _ojumpplayerscorecell;

	public bool ShowShow
	{
		get
		{
			if (_oShow != null)
			{
				return _oShow.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ShowShow != value && _oShow != null)
			{
				_oShow.SetObjectActive(value);
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

	public bool PlayerHonorShow1
	{
		get
		{
			if (_oPlayerHonor1 != null)
			{
				return _oPlayerHonor1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerHonorShow1 != value && _oPlayerHonor1 != null)
			{
				_oPlayerHonor1.SetObjectActive(value);
			}
		}
	}

	public bool PlayerHonorShow2
	{
		get
		{
			if (_oPlayerHonor2 != null)
			{
				return _oPlayerHonor2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerHonorShow2 != value && _oPlayerHonor2 != null)
			{
				_oPlayerHonor2.SetObjectActive(value);
			}
		}
	}

	public bool PlayerHonorShow3
	{
		get
		{
			if (_oPlayerHonor3 != null)
			{
				return _oPlayerHonor3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerHonorShow3 != value && _oPlayerHonor3 != null)
			{
				_oPlayerHonor3.SetObjectActive(value);
			}
		}
	}

	public Sprite PlayerHonorSprite1
	{
		get
		{
			if (_oPlayerHonorImage1 != null)
			{
				return _oPlayerHonorImage1.sprite;
			}
			return null;
		}
		set
		{
			if (PlayerHonorSprite1 != value && _oPlayerHonorImage1 != null)
			{
				_oPlayerHonorImage1.sprite = value;
			}
		}
	}

	public Sprite PlayerHonorSprite2
	{
		get
		{
			if (_oPlayerHonorImage2 != null)
			{
				return _oPlayerHonorImage2.sprite;
			}
			return null;
		}
		set
		{
			if (PlayerHonorSprite2 != value && _oPlayerHonorImage2 != null)
			{
				_oPlayerHonorImage2.sprite = value;
			}
		}
	}

	public Sprite PlayerHonorSprite3
	{
		get
		{
			if (_oPlayerHonorImage3 != null)
			{
				return _oPlayerHonorImage3.sprite;
			}
			return null;
		}
		set
		{
			if (PlayerHonorSprite3 != value && _oPlayerHonorImage3 != null)
			{
				_oPlayerHonorImage3.sprite = value;
			}
		}
	}

	public bool HeroImageShow
	{
		get
		{
			if (_oHeroImage != null)
			{
				return _oHeroImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (HeroImageShow != value && _oHeroImage != null)
			{
				_oHeroImage.SetObjectActive(value);
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

	public string MinutesString
	{
		get
		{
			if (_oMinutesText != null)
			{
				return _oMinutesText.text;
			}
			return null;
		}
		set
		{
			if (MinutesString != value && _oMinutesText != null)
			{
				_oMinutesText.text = value;
			}
		}
	}

	public string SecondsString
	{
		get
		{
			if (_oSecondsText != null)
			{
				return _oSecondsText.text;
			}
			return null;
		}
		set
		{
			if (SecondsString != value && _oSecondsText != null)
			{
				_oSecondsText.text = value;
			}
		}
	}

	public string MillisecondsString
	{
		get
		{
			if (_oMillisecondsText != null)
			{
				return _oMillisecondsText.text;
			}
			return null;
		}
		set
		{
			if (MillisecondsString != value && _oMillisecondsText != null)
			{
				_oMillisecondsText.text = value;
			}
		}
	}

	public string AddTimeString
	{
		get
		{
			if (_oAddTimeText != null)
			{
				return _oAddTimeText.text;
			}
			return null;
		}
		set
		{
			if (AddTimeString != value && _oAddTimeText != null)
			{
				_oAddTimeText.text = value;
			}
		}
	}

	public string SavePointString
	{
		get
		{
			if (_oSavePointText != null)
			{
				return _oSavePointText.text;
			}
			return null;
		}
		set
		{
			if (SavePointString != value && _oSavePointText != null)
			{
				_oSavePointText.text = value;
			}
		}
	}

	public string ReadPointString
	{
		get
		{
			if (_oReadPointText != null)
			{
				return _oReadPointText.text;
			}
			return null;
		}
		set
		{
			if (ReadPointString != value && _oReadPointText != null)
			{
				_oReadPointText.text = value;
			}
		}
	}

	public string WeaponString
	{
		get
		{
			if (_oWeaponText != null)
			{
				return _oWeaponText.text;
			}
			return null;
		}
		set
		{
			if (WeaponString != value && _oWeaponText != null)
			{
				_oWeaponText.text = value;
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
		uiRef = instance.TryAddComponent<UiReferences>();
		Transform[] componentsInChildren = instance.GetComponentsInChildren<Transform>(includeInactive: true);
		foreach (Transform transform in componentsInChildren)
		{
			switch (transform.name.Replace("(Clone)", ""))
			{
			case "jumpplayerscorecell":
				_ojumpplayerscorecell = transform.gameObject;
				uiRef.Set("jumpplayerscorecell", _ojumpplayerscorecell.transform);
				break;
			case "Show":
				_oShow = transform.gameObject;
				uiRef.Set("Show", _oShow.transform);
				break;
			case "UnityFlag":
				_oUnityFlag = transform.gameObject;
				uiRef.Set("UnityFlag", _oUnityFlag.transform);
				break;
			case "RankText":
				_oRankText = transform.gameObject;
				uiRef.Set("RankText", _oRankText.transform);
				_oRankTextText = transform.gameObject.GetComponent<Text>();
				uiRef.Set("RankTextText", _oRankTextText);
				break;
			case "PlayerHonor1":
				_oPlayerHonor1 = transform.gameObject;
				uiRef.Set("PlayerHonor1", _oPlayerHonor1.transform);
				_oPlayerHonorImage1 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("PlayerHonorImage1", _oPlayerHonorImage1);
				break;
			case "PlayerHonor2":
				_oPlayerHonor2 = transform.gameObject;
				uiRef.Set("PlayerHonor2", _oPlayerHonor2.transform);
				_oPlayerHonorImage2 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("PlayerHonorImage2", _oPlayerHonorImage2);
				break;
			case "PlayerHonor3":
				_oPlayerHonor3 = transform.gameObject;
				uiRef.Set("PlayerHonor3", _oPlayerHonor3.transform);
				_oPlayerHonorImage3 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("PlayerHonorImage3", _oPlayerHonorImage3);
				break;
			case "HeroImage":
				_oHeroImage = transform.gameObject;
				uiRef.Set("HeroImage", _oHeroImage.transform);
				break;
			case "PlayerDead":
				_oPlayerDead = transform.gameObject;
				uiRef.Set("PlayerDead", _oPlayerDead.transform);
				break;
			case "PlayerName":
				_oPlayerName = transform.gameObject;
				uiRef.Set("PlayerName", _oPlayerName.transform);
				_oPlayerNameText = transform.gameObject.GetComponent<Text>();
				uiRef.Set("PlayerNameText", _oPlayerNameText);
				break;
			case "PlayerTeam":
				_oPlayerTeam = transform.gameObject;
				uiRef.Set("PlayerTeam", _oPlayerTeam.transform);
				_oPlayerTeamText = transform.gameObject.GetComponent<Text>();
				uiRef.Set("PlayerTeamText", _oPlayerTeamText);
				break;
			case "Minutes":
				_oMinutes = transform.gameObject;
				uiRef.Set("Minutes", _oMinutes.transform);
				_oMinutesText = transform.gameObject.GetComponent<Text>();
				uiRef.Set("MinutesText", _oMinutesText);
				break;
			case "Seconds":
				_oSeconds = transform.gameObject;
				uiRef.Set("Seconds", _oSeconds.transform);
				_oSecondsText = transform.gameObject.GetComponent<Text>();
				uiRef.Set("SecondsText", _oSecondsText);
				break;
			case "Milliseconds":
				_oMilliseconds = transform.gameObject;
				uiRef.Set("Milliseconds", _oMilliseconds.transform);
				_oMillisecondsText = transform.gameObject.GetComponent<Text>();
				uiRef.Set("MillisecondsText", _oMillisecondsText);
				break;
			case "AddTime":
				_oAddTime = transform.gameObject;
				uiRef.Set("AddTime", _oAddTime.transform);
				_oAddTimeText = transform.gameObject.GetComponent<Text>();
				uiRef.Set("AddTimeText", _oAddTimeText);
				break;
			case "SavePoint":
				_oSavePoint = transform.gameObject;
				uiRef.Set("SavePoint", _oSavePoint.transform);
				_oSavePointText = transform.gameObject.GetComponent<Text>();
				uiRef.Set("SavePointText", _oSavePointText);
				break;
			case "ReadPoint":
				_oReadPoint = transform.gameObject;
				uiRef.Set("ReadPoint", _oReadPoint.transform);
				_oReadPointText = transform.gameObject.GetComponent<Text>();
				uiRef.Set("ReadPointText", _oReadPointText);
				break;
			case "Weapon":
				_oWeapon = transform.gameObject;
				uiRef.Set("Weapon", _oWeapon.transform);
				_oWeaponText = transform.gameObject.GetComponent<Text>();
				uiRef.Set("WeaponText", _oWeaponText);
				break;
			case "PlayerPing":
				_oPlayerPing = transform.gameObject;
				uiRef.Set("PlayerPing", _oPlayerPing.transform);
				_oPlayerPingText = transform.gameObject.GetComponent<Text>();
				uiRef.Set("PlayerPingText", _oPlayerPingText);
				break;
			}
		}
	}

	public bool GetPlayerHonorShow(int index)
	{
		return index switch
		{
			1 => PlayerHonorShow1, 
			2 => PlayerHonorShow2, 
			3 => PlayerHonorShow3, 
			_ => false, 
		};
	}

	public void SetPlayerHonorShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			PlayerHonorShow1 = value;
			break;
		case 2:
			PlayerHonorShow2 = value;
			break;
		case 3:
			PlayerHonorShow3 = value;
			break;
		}
	}

	public Sprite GetPlayerHonorSprite(int index)
	{
		return index switch
		{
			1 => PlayerHonorSprite1, 
			2 => PlayerHonorSprite2, 
			3 => PlayerHonorSprite3, 
			_ => null, 
		};
	}

	public void SetPlayerHonorSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			PlayerHonorSprite1 = value;
			break;
		case 2:
			PlayerHonorSprite2 = value;
			break;
		case 3:
			PlayerHonorSprite3 = value;
			break;
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
