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

namespace Assets.Sources.Ui.ViewModel.Rpg;

[GameUiTest]
public class RpgPlayerStateViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oPanel;

	private GameObject _oPlayerTitle;

	private Image _oPlayerTitleImage;

	private GameObject _oPlayerCareer;

	private Image _oPlayerCareerImage;

	private GameObject _oBhImage;

	private Image _oBhImageImage;

	private GameObject _oBvImage;

	private Image _oBvImageImage;

	private GameObject _oHpProgressBar;

	private Image _oHpProgressBarImage;

	private GameObject _oHpWarnning;

	private CanvasGroup _oHpWarnningCanvasGroup;

	private GameObject _oMpProgressBar;

	private Image _oMpProgressBarImage;

	private GameObject _oSuperMpProgressBar;

	private Image _oSuperMpProgressBarImage;

	private GameObject _oMpWarnning;

	private CanvasGroup _oMpWarnningCanvasGroup;

	private RectTransform[] _oMpCounts;

	private Text[] _oMpCountTexts;

	private RectTransform[] _oHpCounts;

	private Text[] _oHpCountTexts;

	private GameObject _oVipImage;

	private Image _oVipImageImage;

	private GameObject _oNameTxt;

	private Text _oNameTxtText;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/rpg";

	private string _resourceAssetName = "RpgPlayerState";

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

	public bool PanelShow
	{
		get
		{
			if (_oPanel != null)
			{
				return _oPanel.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PanelShow != value && _oPanel != null)
			{
				_oPanel.SetObjectActive(value);
			}
		}
	}

	public bool PlayerTitleShow
	{
		get
		{
			if (_oPlayerTitle != null)
			{
				return _oPlayerTitle.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerTitleShow != value && _oPlayerTitle != null)
			{
				_oPlayerTitle.SetObjectActive(value);
			}
		}
	}

	public Sprite PlayerTitleSprite
	{
		get
		{
			if (_oPlayerTitleImage != null)
			{
				return _oPlayerTitleImage.sprite;
			}
			return null;
		}
		set
		{
			if (PlayerTitleSprite != value && _oPlayerTitleImage != null)
			{
				_oPlayerTitleImage.sprite = value;
			}
		}
	}

	public Sprite PlayerCareerSprite
	{
		get
		{
			if (_oPlayerCareerImage != null)
			{
				return _oPlayerCareerImage.sprite;
			}
			return null;
		}
		set
		{
			if (PlayerCareerSprite != value && _oPlayerCareerImage != null)
			{
				_oPlayerCareerImage.sprite = value;
			}
		}
	}

	public bool BhImageShow
	{
		get
		{
			if (_oBhImage != null)
			{
				return _oBhImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BhImageShow != value && _oBhImage != null)
			{
				_oBhImage.SetObjectActive(value);
			}
		}
	}

	public Sprite BhImageSprite
	{
		get
		{
			if (_oBhImageImage != null)
			{
				return _oBhImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (BhImageSprite != value && _oBhImageImage != null)
			{
				_oBhImageImage.sprite = value;
			}
		}
	}

	public bool BvImageShow
	{
		get
		{
			if (_oBvImage != null)
			{
				return _oBvImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BvImageShow != value && _oBvImage != null)
			{
				_oBvImage.SetObjectActive(value);
			}
		}
	}

	public Sprite BvImageSprite
	{
		get
		{
			if (_oBvImageImage != null)
			{
				return _oBvImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (BvImageSprite != value && _oBvImageImage != null)
			{
				_oBvImageImage.sprite = value;
			}
		}
	}

	public float HpProgressBarFillamount
	{
		get
		{
			if (_oHpProgressBarImage != null)
			{
				return _oHpProgressBarImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (HpProgressBarFillamount != value && _oHpProgressBarImage != null)
			{
				_oHpProgressBarImage.fillAmount = value;
			}
		}
	}

	public bool HpWarnningShow
	{
		get
		{
			if (_oHpWarnning != null)
			{
				return _oHpWarnning.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (HpWarnningShow != value && _oHpWarnning != null)
			{
				_oHpWarnning.SetObjectActive(value);
			}
		}
	}

	public float HpWarnningAlpha
	{
		get
		{
			if (_oHpWarnningCanvasGroup != null)
			{
				return _oHpWarnningCanvasGroup.alpha;
			}
			return 0f;
		}
		set
		{
			if (HpWarnningAlpha != value && _oHpWarnningCanvasGroup != null)
			{
				_oHpWarnningCanvasGroup.alpha = value;
			}
		}
	}

	public float MpProgressBarFillamount
	{
		get
		{
			if (_oMpProgressBarImage != null)
			{
				return _oMpProgressBarImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (MpProgressBarFillamount != value && _oMpProgressBarImage != null)
			{
				_oMpProgressBarImage.fillAmount = value;
			}
		}
	}

	public float SuperMpProgressBarFillamount
	{
		get
		{
			if (_oSuperMpProgressBarImage != null)
			{
				return _oSuperMpProgressBarImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (SuperMpProgressBarFillamount != value && _oSuperMpProgressBarImage != null)
			{
				_oSuperMpProgressBarImage.fillAmount = value;
			}
		}
	}

	public bool MpWarnningShow
	{
		get
		{
			if (_oMpWarnning != null)
			{
				return _oMpWarnning.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MpWarnningShow != value && _oMpWarnning != null)
			{
				_oMpWarnning.SetObjectActive(value);
			}
		}
	}

	public float MpWarnningAlpha
	{
		get
		{
			if (_oMpWarnningCanvasGroup != null)
			{
				return _oMpWarnningCanvasGroup.alpha;
			}
			return 0f;
		}
		set
		{
			if (MpWarnningAlpha != value && _oMpWarnningCanvasGroup != null)
			{
				_oMpWarnningCanvasGroup.alpha = value;
			}
		}
	}

	public bool VipImageShow
	{
		get
		{
			if (_oVipImage != null)
			{
				return _oVipImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (VipImageShow != value && _oVipImage != null)
			{
				_oVipImage.SetObjectActive(value);
			}
		}
	}

	public Sprite VipImageSprite
	{
		get
		{
			if (_oVipImageImage != null)
			{
				return _oVipImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (VipImageSprite != value && _oVipImageImage != null)
			{
				_oVipImageImage.sprite = value;
			}
		}
	}

	public string NameTxtString
	{
		get
		{
			if (_oNameTxtText != null)
			{
				return _oNameTxtText.text;
			}
			return null;
		}
		set
		{
			if (NameTxtString != value && _oNameTxtText != null)
			{
				_oNameTxtText.text = value;
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
			case "Panel":
				_oPanel = transform.gameObject;
				break;
			case "PlayerTitle":
				_oPlayerTitle = transform.gameObject;
				_oPlayerTitleImage = transform.gameObject.GetComponent<Image>();
				break;
			case "PlayerCareer":
				_oPlayerCareer = transform.gameObject;
				_oPlayerCareerImage = transform.gameObject.GetComponent<Image>();
				break;
			case "BhImage":
				_oBhImage = transform.gameObject;
				_oBhImageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "BvImage":
				_oBvImage = transform.gameObject;
				_oBvImageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "HpProgressBar":
				_oHpProgressBar = transform.gameObject;
				_oHpProgressBarImage = transform.gameObject.GetComponent<Image>();
				break;
			case "HpWarnning":
				_oHpWarnning = transform.gameObject;
				_oHpWarnningCanvasGroup = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "MpProgressBar":
				_oMpProgressBar = transform.gameObject;
				_oMpProgressBarImage = transform.gameObject.GetComponent<Image>();
				break;
			case "SuperMpProgressBar":
				_oSuperMpProgressBar = transform.gameObject;
				_oSuperMpProgressBarImage = transform.gameObject.GetComponent<Image>();
				break;
			case "MpWarnning":
				_oMpWarnning = transform.gameObject;
				_oMpWarnningCanvasGroup = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "MpCount":
				_oMpCounts = transform.GetComponentsInChildren<RectTransform>();
				_oMpCountTexts = transform.GetComponentsInChildren<Text>();
				break;
			case "HpCount":
				_oHpCounts = transform.GetComponentsInChildren<RectTransform>();
				_oHpCountTexts = transform.GetComponentsInChildren<Text>();
				break;
			case "VipImage":
				_oVipImage = transform.gameObject;
				_oVipImageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "NameTxt":
				_oNameTxt = transform.gameObject;
				_oNameTxtText = transform.gameObject.GetComponent<Text>();
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

	public void PlayerCareerNtvsize()
	{
		if (_oPlayerCareerImage != null)
		{
			_oPlayerCareerImage.SetNativeSize();
		}
	}

	public void SetMpCountShowLargenumber(bool[] shows)
	{
		if (shows.Length == 4 || _oMpCounts.Length == 5)
		{
			for (int i = 1; i < _oMpCounts.Length; i++)
			{
				_oMpCounts[i].gameObject.SetActive(shows[i - 1]);
			}
		}
	}

	public void SetMpCountPosiLargenumber(Vector3[] positions)
	{
		if (positions.Length == 5 || _oMpCounts.Length == 5)
		{
			for (int i = 0; i < _oMpCounts.Length; i++)
			{
				_oMpCounts[i].anchoredPosition = positions[i];
			}
		}
	}

	public void SetMpCountTextLargenumber(string wholeStr, string decimalStr)
	{
		if (_oMpCountTexts.Length == 2)
		{
			_oMpCountTexts[0].text = wholeStr;
			_oMpCountTexts[1].text = decimalStr;
		}
	}

	public void SetHpCountShowLargenumber(bool[] shows)
	{
		if (shows.Length == 4 || _oHpCounts.Length == 5)
		{
			for (int i = 1; i < _oHpCounts.Length; i++)
			{
				_oHpCounts[i].gameObject.SetActive(shows[i - 1]);
			}
		}
	}

	public void SetHpCountPosiLargenumber(Vector3[] positions)
	{
		if (positions.Length == 5 || _oHpCounts.Length == 5)
		{
			for (int i = 0; i < _oHpCounts.Length; i++)
			{
				_oHpCounts[i].anchoredPosition = positions[i];
			}
		}
	}

	public void SetHpCountTextLargenumber(string wholeStr, string decimalStr)
	{
		if (_oHpCountTexts.Length == 2)
		{
			_oHpCountTexts[0].text = wholeStr;
			_oHpCountTexts[1].text = decimalStr;
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
}
