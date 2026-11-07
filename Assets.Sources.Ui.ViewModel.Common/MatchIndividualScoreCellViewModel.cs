using System;
using System.Collections.Generic;
using Assets.Res.Assets.Scripts.Refrenceless;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Common;

[GameUiTest]
public class MatchIndividualScoreCellViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oMatchIndividualScoreCell;

	private GameObject _oSelfBack;

	private GameObject _oSelfTeamBack;

	private GameObject _oUnityFlag;

	private GameObject _oRankText;

	private Text _oRankTextText;

	private GameObject _oCareerImage;

	private Image _oCareerImageImage;

	private GameObject _oPlayerDead;

	private GameObject _oPlayerRankHonor;

	private Image _oPlayerRankHonorImage;

	private GameObject _oPlayerName;

	private Text _oPlayerNameText;

	private GameObject _oPlayerTeam;

	private Text _oPlayerTeamText;

	private GameObject _oPlayerPing;

	private Text _oPlayerPingText;

	private GameObject _oVip;

	private Image _oVipImage;

	private GameObject _oPlayerScore1;

	private GameObject _oPlayerScore2;

	private GameObject _oPlayerScore3;

	private GameObject _oPlayerScore4;

	private GameObject _oPlayerScore5;

	private GameObject _oPlayerScore6;

	private Text _oPlayerScoreText1;

	private Text _oPlayerScoreText2;

	private Text _oPlayerScoreText3;

	private Text _oPlayerScoreText4;

	private Text _oPlayerScoreText5;

	private Text _oPlayerScoreText6;

	private GameObject _oWeapon;

	private Text _oWeaponText;

	private GameObject _oPlayerDuiwu;

	private Text _oPlayerDuiwuText;

	private GameObject _oPlayerLevel;

	private Text _oPlayerLevelText;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/common";

	private string _resourceAssetName = "MatchIndividualScoreCell";

	private List<RectTransform> _holdPosTrans;

	public GameObject ViewGameObject => _viewGameObject;

	public bool ViewGameObjectShow
	{
		get
		{
			if (_viewGameObject != null)
			{
				return _viewGameObject.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ViewGameObjectShow != value && _viewGameObject != null)
			{
				_viewGameObject.SetObjectActive(value);
			}
		}
	}

	public GameObject MatchIndividualScoreCellObj => _oMatchIndividualScoreCell;

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

	public Sprite PlayerRankHonorSprite
	{
		get
		{
			if (_oPlayerRankHonorImage != null)
			{
				return _oPlayerRankHonorImage.sprite;
			}
			return null;
		}
		set
		{
			if (PlayerRankHonorSprite != value && _oPlayerRankHonorImage != null)
			{
				_oPlayerRankHonorImage.sprite = value;
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
			case "MatchIndividualScoreCell":
				_oMatchIndividualScoreCell = transform.gameObject;
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
			case "CareerImage":
				_oCareerImage = transform.gameObject;
				_oCareerImageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "PlayerDead":
				_oPlayerDead = transform.gameObject;
				break;
			case "PlayerRankHonor":
				_oPlayerRankHonor = transform.gameObject;
				_oPlayerRankHonorImage = transform.gameObject.GetComponent<Image>();
				break;
			case "PlayerName":
				_oPlayerName = transform.gameObject;
				_oPlayerNameText = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerTeam":
				_oPlayerTeam = transform.gameObject;
				_oPlayerTeamText = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerPing":
				_oPlayerPing = transform.gameObject;
				_oPlayerPingText = transform.gameObject.GetComponent<Text>();
				break;
			case "Vip":
				_oVip = transform.gameObject;
				_oVipImage = transform.gameObject.GetComponent<Image>();
				break;
			case "PlayerScore1":
				_oPlayerScore1 = transform.gameObject;
				_oPlayerScoreText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerScore2":
				_oPlayerScore2 = transform.gameObject;
				_oPlayerScoreText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerScore3":
				_oPlayerScore3 = transform.gameObject;
				_oPlayerScoreText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerScore4":
				_oPlayerScore4 = transform.gameObject;
				_oPlayerScoreText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerScore5":
				_oPlayerScore5 = transform.gameObject;
				_oPlayerScoreText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerScore6":
				_oPlayerScore6 = transform.gameObject;
				_oPlayerScoreText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "Weapon":
				_oWeapon = transform.gameObject;
				_oWeaponText = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerDuiwu":
				_oPlayerDuiwu = transform.gameObject;
				_oPlayerDuiwuText = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerLevel":
				_oPlayerLevel = transform.gameObject;
				_oPlayerLevelText = transform.gameObject.GetComponent<Text>();
				break;
			}
		}
	}

	public void LoadRefrenceless(IUiResourcesLoader loader)
	{
		if (_refrencelessLoaded)
		{
			return;
		}
		_refrencelessLoaded = true;
		RefrencelessHelper component = _viewGameObject.GetComponent<RefrencelessHelper>();
		if (!(component != null))
		{
			return;
		}
		for (int i = 0; i < component.SpritePaths.Count; i++)
		{
			try
			{
				if (i < component.AutoLoad.Count && !component.AutoLoad[i])
				{
					continue;
				}
				string[] array = component.SpritePaths[i].Split(':');
				Image image = component.transform.Find(component.Images[i]).GetComponent<Image>();
				if (!string.IsNullOrEmpty(array[0]))
				{
					loader.RetriveSprite(array[0], array[1], delegate(Sprite sprite)
					{
						image.sprite = sprite;
					});
				}
			}
			catch (Exception message)
			{
				Debug.LogError(message);
			}
		}
	}

	public void PlayerRankHonorNtvsize()
	{
		if (_oPlayerRankHonorImage != null)
		{
			_oPlayerRankHonorImage.SetNativeSize();
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
			UnityEngine.Object.Destroy(_viewGameObject);
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

	public void RemoveTriggerEntry(List<EventTrigger.Entry> triggers, EventTriggerType eventId)
	{
		foreach (EventTrigger.Entry trigger in triggers)
		{
			if (trigger.eventID == eventId)
			{
				triggers.Remove(trigger);
				break;
			}
		}
	}

	public List<RectTransform> GetHoldPosIntergeTrans()
	{
		if (_holdPosTrans != null)
		{
			return _holdPosTrans;
		}
		_holdPosTrans = new List<RectTransform>();
		if (_oRankTextText != null)
		{
			_holdPosTrans.Add(_oRankTextText.GetComponent<RectTransform>());
		}
		if (_oPlayerNameText != null)
		{
			_holdPosTrans.Add(_oPlayerNameText.GetComponent<RectTransform>());
		}
		if (_oPlayerTeamText != null)
		{
			_holdPosTrans.Add(_oPlayerTeamText.GetComponent<RectTransform>());
		}
		if (_oPlayerPingText != null)
		{
			_holdPosTrans.Add(_oPlayerPingText.GetComponent<RectTransform>());
		}
		if (_oPlayerScoreText1 != null)
		{
			_holdPosTrans.Add(_oPlayerScoreText1.GetComponent<RectTransform>());
		}
		if (_oPlayerScoreText2 != null)
		{
			_holdPosTrans.Add(_oPlayerScoreText2.GetComponent<RectTransform>());
		}
		if (_oPlayerScoreText3 != null)
		{
			_holdPosTrans.Add(_oPlayerScoreText3.GetComponent<RectTransform>());
		}
		if (_oPlayerScoreText4 != null)
		{
			_holdPosTrans.Add(_oPlayerScoreText4.GetComponent<RectTransform>());
		}
		if (_oPlayerScoreText5 != null)
		{
			_holdPosTrans.Add(_oPlayerScoreText5.GetComponent<RectTransform>());
		}
		if (_oPlayerScoreText6 != null)
		{
			_holdPosTrans.Add(_oPlayerScoreText6.GetComponent<RectTransform>());
		}
		if (_oWeaponText != null)
		{
			_holdPosTrans.Add(_oWeaponText.GetComponent<RectTransform>());
		}
		if (_oPlayerDuiwuText != null)
		{
			_holdPosTrans.Add(_oPlayerDuiwuText.GetComponent<RectTransform>());
		}
		if (_oPlayerLevelText != null)
		{
			_holdPosTrans.Add(_oPlayerLevelText.GetComponent<RectTransform>());
		}
		return _holdPosTrans;
	}
}
