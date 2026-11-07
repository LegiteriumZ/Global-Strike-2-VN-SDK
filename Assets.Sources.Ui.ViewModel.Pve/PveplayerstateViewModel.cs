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

namespace Assets.Sources.Ui.ViewModel.Pve;

[GameUiTest]
public class PveplayerstateViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _opveplayerstate;

	private GameObject _oBack;

	private RectTransform _oBackRectTransform;

	private Image _oBackImage;

	private GameObject _oplayerCareer;

	private RectTransform _oplayerCareerRectTransform;

	private Image _oplayerCareerImage;

	private GameObject _olvtxt;

	private Text _olvtxtText;

	private GameObject _oplayerHPProgressBar;

	private RectTransform _oplayerHPProgressBarRectTransform;

	private Image _oplayerHPProgressBarImage;

	private GameObject _ohptxt;

	private Text _ohptxtText;

	private GameObject _ogoldtxt;

	private Text _ogoldtxtText;

	private GameObject _oplayerTitle;

	private Image _oplayerTitleImage;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/pve";

	private string _resourceAssetName = "Pveplayerstate";

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

	public GameObject pveplayerstateObj => _opveplayerstate;

	public bool pveplayerstateShow
	{
		get
		{
			if (_opveplayerstate != null)
			{
				return _opveplayerstate.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (pveplayerstateShow != value && _opveplayerstate != null)
			{
				_opveplayerstate.SetObjectActive(value);
			}
		}
	}

	public bool BackShow
	{
		get
		{
			if (_oBack != null)
			{
				return _oBack.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BackShow != value && _oBack != null)
			{
				_oBack.SetObjectActive(value);
			}
		}
	}

	public Vector2 BackAnchoredposition
	{
		get
		{
			if (_oBackRectTransform != null)
			{
				return _oBackRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (BackAnchoredposition != value && _oBackRectTransform != null)
			{
				_oBackRectTransform.anchoredPosition = value;
			}
		}
	}

	public Sprite BackSprite
	{
		get
		{
			if (_oBackImage != null)
			{
				return _oBackImage.sprite;
			}
			return null;
		}
		set
		{
			if (BackSprite != value && _oBackImage != null)
			{
				_oBackImage.sprite = value;
			}
		}
	}

	public float BackFillamount
	{
		get
		{
			if (_oBackImage != null)
			{
				return _oBackImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (BackFillamount != value && _oBackImage != null)
			{
				_oBackImage.fillAmount = value;
			}
		}
	}

	public Color BackColor
	{
		get
		{
			if (_oBackImage != null)
			{
				return _oBackImage.color;
			}
			return Color.white;
		}
		set
		{
			if (BackColor != value && _oBackImage != null)
			{
				_oBackImage.color = value;
			}
		}
	}

	public Image BackImage
	{
		get
		{
			if (_oBackImage != null)
			{
				return _oBackImage;
			}
			return null;
		}
		set
		{
			if (BackImage != value && _oBackImage != null)
			{
				_oBackImage = value;
			}
		}
	}

	public bool playerCareerShow
	{
		get
		{
			if (_oplayerCareer != null)
			{
				return _oplayerCareer.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (playerCareerShow != value && _oplayerCareer != null)
			{
				_oplayerCareer.SetObjectActive(value);
			}
		}
	}

	public Vector2 playerCareerAnchoredposition
	{
		get
		{
			if (_oplayerCareerRectTransform != null)
			{
				return _oplayerCareerRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (playerCareerAnchoredposition != value && _oplayerCareerRectTransform != null)
			{
				_oplayerCareerRectTransform.anchoredPosition = value;
			}
		}
	}

	public Sprite playerCareerSprite
	{
		get
		{
			if (_oplayerCareerImage != null)
			{
				return _oplayerCareerImage.sprite;
			}
			return null;
		}
		set
		{
			if (playerCareerSprite != value && _oplayerCareerImage != null)
			{
				_oplayerCareerImage.sprite = value;
			}
		}
	}

	public float playerCareerFillamount
	{
		get
		{
			if (_oplayerCareerImage != null)
			{
				return _oplayerCareerImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (playerCareerFillamount != value && _oplayerCareerImage != null)
			{
				_oplayerCareerImage.fillAmount = value;
			}
		}
	}

	public Color playerCareerColor
	{
		get
		{
			if (_oplayerCareerImage != null)
			{
				return _oplayerCareerImage.color;
			}
			return Color.white;
		}
		set
		{
			if (playerCareerColor != value && _oplayerCareerImage != null)
			{
				_oplayerCareerImage.color = value;
			}
		}
	}

	public Image playerCareerImage
	{
		get
		{
			if (_oplayerCareerImage != null)
			{
				return _oplayerCareerImage;
			}
			return null;
		}
		set
		{
			if (playerCareerImage != value && _oplayerCareerImage != null)
			{
				_oplayerCareerImage = value;
			}
		}
	}

	public bool lvtxtShow
	{
		get
		{
			if (_olvtxt != null)
			{
				return _olvtxt.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (lvtxtShow != value && _olvtxt != null)
			{
				_olvtxt.SetObjectActive(value);
			}
		}
	}

	public string lvtxtString
	{
		get
		{
			if (_olvtxtText != null)
			{
				return _olvtxtText.text;
			}
			return null;
		}
		set
		{
			if (lvtxtString != value && _olvtxtText != null)
			{
				_olvtxtText.text = value;
			}
		}
	}

	public bool playerHPProgressBarShow
	{
		get
		{
			if (_oplayerHPProgressBar != null)
			{
				return _oplayerHPProgressBar.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (playerHPProgressBarShow != value && _oplayerHPProgressBar != null)
			{
				_oplayerHPProgressBar.SetObjectActive(value);
			}
		}
	}

	public Vector2 playerHPProgressBarAnchoredposition
	{
		get
		{
			if (_oplayerHPProgressBarRectTransform != null)
			{
				return _oplayerHPProgressBarRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (playerHPProgressBarAnchoredposition != value && _oplayerHPProgressBarRectTransform != null)
			{
				_oplayerHPProgressBarRectTransform.anchoredPosition = value;
			}
		}
	}

	public Sprite playerHPProgressBarSprite
	{
		get
		{
			if (_oplayerHPProgressBarImage != null)
			{
				return _oplayerHPProgressBarImage.sprite;
			}
			return null;
		}
		set
		{
			if (playerHPProgressBarSprite != value && _oplayerHPProgressBarImage != null)
			{
				_oplayerHPProgressBarImage.sprite = value;
			}
		}
	}

	public float playerHPProgressBarFillamount
	{
		get
		{
			if (_oplayerHPProgressBarImage != null)
			{
				return _oplayerHPProgressBarImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (playerHPProgressBarFillamount != value && _oplayerHPProgressBarImage != null)
			{
				_oplayerHPProgressBarImage.fillAmount = value;
			}
		}
	}

	public Image playerHPProgressBarImage
	{
		get
		{
			if (_oplayerHPProgressBarImage != null)
			{
				return _oplayerHPProgressBarImage;
			}
			return null;
		}
		set
		{
			if (playerHPProgressBarImage != value && _oplayerHPProgressBarImage != null)
			{
				_oplayerHPProgressBarImage = value;
			}
		}
	}

	public bool hptxtShow
	{
		get
		{
			if (_ohptxt != null)
			{
				return _ohptxt.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (hptxtShow != value && _ohptxt != null)
			{
				_ohptxt.SetObjectActive(value);
			}
		}
	}

	public string hptxtString
	{
		get
		{
			if (_ohptxtText != null)
			{
				return _ohptxtText.text;
			}
			return null;
		}
		set
		{
			if (hptxtString != value && _ohptxtText != null)
			{
				_ohptxtText.text = value;
			}
		}
	}

	public bool goldtxtShow
	{
		get
		{
			if (_ogoldtxt != null)
			{
				return _ogoldtxt.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (goldtxtShow != value && _ogoldtxt != null)
			{
				_ogoldtxt.SetObjectActive(value);
			}
		}
	}

	public string goldtxtString
	{
		get
		{
			if (_ogoldtxtText != null)
			{
				return _ogoldtxtText.text;
			}
			return null;
		}
		set
		{
			if (goldtxtString != value && _ogoldtxtText != null)
			{
				_ogoldtxtText.text = value;
			}
		}
	}

	public bool playerTitleShow
	{
		get
		{
			if (_oplayerTitle != null)
			{
				return _oplayerTitle.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (playerTitleShow != value && _oplayerTitle != null)
			{
				_oplayerTitle.SetObjectActive(value);
			}
		}
	}

	public Sprite playerTitleSprite
	{
		get
		{
			if (_oplayerTitleImage != null)
			{
				return _oplayerTitleImage.sprite;
			}
			return null;
		}
		set
		{
			if (playerTitleSprite != value && _oplayerTitleImage != null)
			{
				_oplayerTitleImage.sprite = value;
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
			case "pveplayerstate":
				_opveplayerstate = transform.gameObject;
				break;
			case "Back":
				_oBack = transform.gameObject;
				_oBackRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oBackImage = transform.gameObject.GetComponent<Image>();
				break;
			case "playerCareer":
				_oplayerCareer = transform.gameObject;
				_oplayerCareerRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oplayerCareerImage = transform.gameObject.GetComponent<Image>();
				break;
			case "lvtxt":
				_olvtxt = transform.gameObject;
				_olvtxtText = transform.gameObject.GetComponent<Text>();
				break;
			case "playerHPProgressBar":
				_oplayerHPProgressBar = transform.gameObject;
				_oplayerHPProgressBarRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oplayerHPProgressBarImage = transform.gameObject.GetComponent<Image>();
				break;
			case "hptxt":
				_ohptxt = transform.gameObject;
				_ohptxtText = transform.gameObject.GetComponent<Text>();
				break;
			case "goldtxt":
				_ogoldtxt = transform.gameObject;
				_ogoldtxtText = transform.gameObject.GetComponent<Text>();
				break;
			case "playerTitle":
				_oplayerTitle = transform.gameObject;
				_oplayerTitleImage = transform.gameObject.GetComponent<Image>();
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

	public void BackNtvsize()
	{
		if (_oBackImage != null)
		{
			_oBackImage.SetNativeSize();
		}
	}

	public void playerCareerNtvsize()
	{
		if (_oplayerCareerImage != null)
		{
			_oplayerCareerImage.SetNativeSize();
		}
	}

	public void playerHPProgressBarNtvsize()
	{
		if (_oplayerHPProgressBarImage != null)
		{
			_oplayerHPProgressBarImage.SetNativeSize();
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
