using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Personal;

[GameUiTest]
public class PersonalplayerscorecellViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _opersonalplayerscorecell;

	private GameObject _oShow;

	private GameObject _oSelfBack;

	private GameObject _oSelfTeamBack;

	private GameObject _oPlayerHonor1;

	private GameObject _oPlayerHonor2;

	private GameObject _oPlayerHonor3;

	private Image _oPlayerHonorImage1;

	private Image _oPlayerHonorImage2;

	private Image _oPlayerHonorImage3;

	private GameObject _oHeroImage;

	private GameObject _oUnityFlag;

	private GameObject _oRankText;

	private Text _oRankTextText;

	private GameObject _oPlayerDead;

	private GameObject _oPlayerName;

	private Text _oPlayerNameText;

	private GameObject _oPlayerTeam;

	private Text _oPlayerTeamText;

	private GameObject _oPlayerKill;

	private Text _oPlayerKillText;

	private GameObject _oPlayerLive;

	private Text _oPlayerLiveText;

	private GameObject _oPlayerPing;

	private Text _oPlayerPingText;

	private GameObject _oCareerImage;

	private Image _oCareerImageImage;

	private GameObject _oVip;

	private Image _oVipImage;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/personal";

	private string _resourceAssetName = "Personalplayerscorecell";

	public GameObject personalplayerscorecellObj => _opersonalplayerscorecell;

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

	public string PlayerLiveString
	{
		get
		{
			if (_oPlayerLiveText != null)
			{
				return _oPlayerLiveText.text;
			}
			return null;
		}
		set
		{
			if (PlayerLiveString != value && _oPlayerLiveText != null)
			{
				_oPlayerLiveText.text = value;
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

	public bool CareerImageShow
	{
		get
		{
			if (_oCareerImage != null)
			{
				return _oCareerImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CareerImageShow != value && _oCareerImage != null)
			{
				_oCareerImage.SetObjectActive(value);
			}
		}
	}

	public Sprite CareerImageSprite
	{
		get
		{
			if (_oCareerImageImage != null)
			{
				return _oCareerImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (CareerImageSprite != value && _oCareerImageImage != null)
			{
				_oCareerImageImage.sprite = value;
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
			case "personalplayerscorecell":
				_opersonalplayerscorecell = transform.gameObject;
				break;
			case "Show":
				_oShow = transform.gameObject;
				break;
			case "SelfBack":
				_oSelfBack = transform.gameObject;
				break;
			case "SelfTeamBack":
				_oSelfTeamBack = transform.gameObject;
				break;
			case "PlayerHonor1":
				_oPlayerHonor1 = transform.gameObject;
				_oPlayerHonorImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "PlayerHonor2":
				_oPlayerHonor2 = transform.gameObject;
				_oPlayerHonorImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "PlayerHonor3":
				_oPlayerHonor3 = transform.gameObject;
				_oPlayerHonorImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "HeroImage":
				_oHeroImage = transform.gameObject;
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
			case "PlayerName":
				_oPlayerName = transform.gameObject;
				_oPlayerNameText = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerTeam":
				_oPlayerTeam = transform.gameObject;
				_oPlayerTeamText = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerKill":
				_oPlayerKill = transform.gameObject;
				_oPlayerKillText = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerLive":
				_oPlayerLive = transform.gameObject;
				_oPlayerLiveText = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerPing":
				_oPlayerPing = transform.gameObject;
				_oPlayerPingText = transform.gameObject.GetComponent<Text>();
				break;
			case "CareerImage":
				_oCareerImage = transform.gameObject;
				_oCareerImageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Vip":
				_oVip = transform.gameObject;
				_oVipImage = transform.gameObject.GetComponent<Image>();
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
