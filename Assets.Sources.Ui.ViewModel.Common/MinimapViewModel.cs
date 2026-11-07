using System;
using System.Collections.Generic;
using Assets.Res.Assets.Scripts.Refrenceless;
using Assets.Scripts.ResScripts.Refrenceless.DyVersion;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Common;

[GameUiTest]
public class MinimapViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oImageBack;

	private RectTransform _oImageBackRectTransform;

	private Image _oImageBackImage;

	private EventTrigger _oImageBackEventTrigger;

	private GameObject _oMapImage;

	private Image _oMapImageImage;

	private GameObject _oHelpInfo;

	private RectTransform _oHelpInfoRectTransform;

	private GameObject _oDuwuMask;

	private RectTransform _oDuwuMaskRectTransform;

	private Image _oDuwuMaskImage;

	private GameObject _oDuwu;

	private RectTransform _oDuwuRectTransform;

	private Image _oDuwuImage;

	private GameObject _oSafe;

	private RectTransform _oSafeRectTransform;

	private GameObject _oItems;

	private RectTransform _oItemsRectTransform;

	private GameObject _oSelfPosition;

	private RectTransform _oSelfPositionRectTransform;

	private GameObject _oSelfDead;

	private Image _oSelfDeadImage;

	private GameObject _oSelfAlive;

	private GameObject _oSelfRotation;

	private RectTransform _oSelfRotationRectTransform;

	private GameObject _oSelfSound;

	private Image _oSelfSoundImage;

	private GameObject _oSelfName;

	private Text _oSelfNameText;

	private RectTransform[] _oSelfHealths;

	private Text[] _oSelfHealthTexts;

	private GameObject _oCommonItems;

	private GameObject _oMapGray;

	private Image _oMapGrayImage;

	private GameObject _oPaths;

	private RectTransform _oPathsRectTransform;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/common";

	private string _resourceAssetName = "minimap";

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

	public Vector3 ImageBackPosition
	{
		get
		{
			if (_oImageBackRectTransform != null)
			{
				return _oImageBackRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (ImageBackPosition != value && _oImageBackRectTransform != null)
			{
				_oImageBackRectTransform.localPosition = value;
			}
		}
	}

	public bool ImageBackEnabled
	{
		get
		{
			if (_oImageBackImage != null)
			{
				return _oImageBackImage.enabled;
			}
			return false;
		}
		set
		{
			if (ImageBackEnabled != value && _oImageBackImage != null)
			{
				_oImageBackImage.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public Sprite ImageBackSprite
	{
		get
		{
			if (_oImageBackImage != null)
			{
				return _oImageBackImage.sprite;
			}
			return null;
		}
		set
		{
			if (ImageBackSprite != value && _oImageBackImage != null)
			{
				_oImageBackImage.sprite = value;
			}
		}
	}

	public List<EventTrigger.Entry> ImageBackTriggers
	{
		get
		{
			if (_oImageBackEventTrigger != null)
			{
				return _oImageBackEventTrigger.triggers;
			}
			return null;
		}
		set
		{
			if (ImageBackTriggers != value && _oImageBackEventTrigger != null)
			{
				_oImageBackEventTrigger.triggers = value;
			}
		}
	}

	public Sprite MapImageSprite
	{
		get
		{
			if (_oMapImageImage != null)
			{
				return _oMapImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (MapImageSprite != value && _oMapImageImage != null)
			{
				_oMapImageImage.sprite = value;
			}
		}
	}

	public bool HelpInfoShow
	{
		get
		{
			if (_oHelpInfo != null)
			{
				return _oHelpInfo.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (HelpInfoShow != value && _oHelpInfo != null)
			{
				_oHelpInfo.SetObjectActive(value);
			}
		}
	}

	public Vector3 HelpInfoPosition
	{
		get
		{
			if (_oHelpInfoRectTransform != null)
			{
				return _oHelpInfoRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (HelpInfoPosition != value && _oHelpInfoRectTransform != null)
			{
				_oHelpInfoRectTransform.localPosition = value;
			}
		}
	}

	public bool DuwuMaskShow
	{
		get
		{
			if (_oDuwuMask != null)
			{
				return _oDuwuMask.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DuwuMaskShow != value && _oDuwuMask != null)
			{
				_oDuwuMask.SetObjectActive(value);
			}
		}
	}

	public Vector3 DuwuMaskPosition
	{
		get
		{
			if (_oDuwuMaskRectTransform != null)
			{
				return _oDuwuMaskRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (DuwuMaskPosition != value && _oDuwuMaskRectTransform != null)
			{
				_oDuwuMaskRectTransform.localPosition = value;
			}
		}
	}

	public Sprite DuwuMaskSprite
	{
		get
		{
			if (_oDuwuMaskImage != null)
			{
				return _oDuwuMaskImage.sprite;
			}
			return null;
		}
		set
		{
			if (DuwuMaskSprite != value && _oDuwuMaskImage != null)
			{
				_oDuwuMaskImage.sprite = value;
			}
		}
	}

	public GameObject DuwuObj => _oDuwu;

	public Vector3 DuwuPosition
	{
		get
		{
			if (_oDuwuRectTransform != null)
			{
				return _oDuwuRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (DuwuPosition != value && _oDuwuRectTransform != null)
			{
				_oDuwuRectTransform.localPosition = value;
			}
		}
	}

	public Sprite DuwuSprite
	{
		get
		{
			if (_oDuwuImage != null)
			{
				return _oDuwuImage.sprite;
			}
			return null;
		}
		set
		{
			if (DuwuSprite != value && _oDuwuImage != null)
			{
				_oDuwuImage.sprite = value;
			}
		}
	}

	public Vector3 SafePosition
	{
		get
		{
			if (_oSafeRectTransform != null)
			{
				return _oSafeRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (SafePosition != value && _oSafeRectTransform != null)
			{
				_oSafeRectTransform.localPosition = value;
			}
		}
	}

	public Vector3 SafeSize
	{
		get
		{
			if (_oSafeRectTransform != null)
			{
				return _oSafeRectTransform.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (SafeSize != value && _oSafeRectTransform != null)
			{
				_oSafeRectTransform.sizeDelta = value;
			}
		}
	}

	public Vector3 ItemsPosition
	{
		get
		{
			if (_oItemsRectTransform != null)
			{
				return _oItemsRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (ItemsPosition != value && _oItemsRectTransform != null)
			{
				_oItemsRectTransform.localPosition = value;
			}
		}
	}

	public bool SelfPositionShow
	{
		get
		{
			if (_oSelfPosition != null)
			{
				return _oSelfPosition.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelfPositionShow != value && _oSelfPosition != null)
			{
				_oSelfPosition.SetObjectActive(value);
			}
		}
	}

	public Vector3 SelfPositionPosition
	{
		get
		{
			if (_oSelfPositionRectTransform != null)
			{
				return _oSelfPositionRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (SelfPositionPosition != value && _oSelfPositionRectTransform != null)
			{
				_oSelfPositionRectTransform.localPosition = value;
			}
		}
	}

	public bool SelfDeadEnabled
	{
		get
		{
			if (_oSelfDeadImage != null)
			{
				return _oSelfDeadImage.enabled;
			}
			return false;
		}
		set
		{
			if (SelfDeadEnabled != value && _oSelfDeadImage != null)
			{
				_oSelfDeadImage.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool SelfAliveShow
	{
		get
		{
			if (_oSelfAlive != null)
			{
				return _oSelfAlive.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelfAliveShow != value && _oSelfAlive != null)
			{
				_oSelfAlive.SetObjectActive(value);
			}
		}
	}

	public Quaternion SelfRotationRotation
	{
		get
		{
			if (_oSelfRotationRectTransform != null)
			{
				return _oSelfRotationRectTransform.localRotation;
			}
			return Quaternion.Euler(Vector3.zero);
		}
		set
		{
			if (SelfRotationRotation != value && _oSelfRotationRectTransform != null)
			{
				_oSelfRotationRectTransform.localRotation = value;
			}
		}
	}

	public bool SelfSoundEnabled
	{
		get
		{
			if (_oSelfSoundImage != null)
			{
				return _oSelfSoundImage.enabled;
			}
			return false;
		}
		set
		{
			if (SelfSoundEnabled != value && _oSelfSoundImage != null)
			{
				_oSelfSoundImage.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public string SelfNameString
	{
		get
		{
			if (_oSelfNameText != null)
			{
				return _oSelfNameText.text;
			}
			return null;
		}
		set
		{
			if (SelfNameString != value && _oSelfNameText != null)
			{
				_oSelfNameText.text = value;
			}
		}
	}

	public GameObject CommonItemsObj => _oCommonItems;

	public bool MapGrayShow
	{
		get
		{
			if (_oMapGray != null)
			{
				return _oMapGray.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MapGrayShow != value && _oMapGray != null)
			{
				_oMapGray.SetObjectActive(value);
			}
		}
	}

	public GameObject PathsObj => _oPaths;

	public Vector3 PathsPosition
	{
		get
		{
			if (_oPathsRectTransform != null)
			{
				return _oPathsRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (PathsPosition != value && _oPathsRectTransform != null)
			{
				_oPathsRectTransform.localPosition = value;
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
			case "Show":
				_oShow = transform.gameObject;
				break;
			case "ImageBack":
				_oImageBack = transform.gameObject;
				_oImageBackRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oImageBackImage = transform.gameObject.GetComponent<Image>();
				_oImageBackEventTrigger = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "MapImage":
				_oMapImage = transform.gameObject;
				_oMapImageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "HelpInfo":
				_oHelpInfo = transform.gameObject;
				_oHelpInfoRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "DuwuMask":
				_oDuwuMask = transform.gameObject;
				_oDuwuMaskRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oDuwuMaskImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Duwu":
				_oDuwu = transform.gameObject;
				_oDuwuRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oDuwuImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Safe":
				_oSafe = transform.gameObject;
				_oSafeRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "Items":
				_oItems = transform.gameObject;
				_oItemsRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "SelfPosition":
				_oSelfPosition = transform.gameObject;
				_oSelfPositionRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "SelfDead":
				_oSelfDead = transform.gameObject;
				_oSelfDeadImage = transform.gameObject.GetComponent<Image>();
				break;
			case "SelfAlive":
				_oSelfAlive = transform.gameObject;
				break;
			case "SelfRotation":
				_oSelfRotation = transform.gameObject;
				_oSelfRotationRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "SelfSound":
				_oSelfSound = transform.gameObject;
				_oSelfSoundImage = transform.gameObject.GetComponent<Image>();
				break;
			case "SelfName":
				_oSelfName = transform.gameObject;
				_oSelfNameText = transform.gameObject.GetComponent<Text>();
				break;
			case "SelfHealth":
				_oSelfHealths = transform.GetComponentsInChildren<RectTransform>();
				_oSelfHealthTexts = transform.GetComponentsInChildren<Text>();
				break;
			case "CommonItems":
				_oCommonItems = transform.gameObject;
				break;
			case "MapGray":
				_oMapGray = transform.gameObject;
				_oMapGrayImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Paths":
				_oPaths = transform.gameObject;
				_oPathsRectTransform = transform.gameObject.GetComponent<RectTransform>();
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

	private void CreateImageBackTriggersEntry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(ImageBackTriggers, eventId, callback);
	}

	private void RemoveImageBackTriggersEntry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(ImageBackTriggers, eventId);
	}

	public void SetSelfHealthShowLargenumber(bool[] shows)
	{
		if (shows.Length == 4 || _oSelfHealths.Length == 5)
		{
			for (int i = 1; i < _oSelfHealths.Length; i++)
			{
				_oSelfHealths[i].gameObject.SetActive(shows[i - 1]);
			}
		}
	}

	public void SetSelfHealthPosiLargenumber(Vector3[] positions)
	{
		if (positions.Length == 5 || _oSelfHealths.Length == 5)
		{
			for (int i = 0; i < _oSelfHealths.Length; i++)
			{
				_oSelfHealths[i].anchoredPosition = positions[i];
			}
		}
	}

	public void SetSelfHealthTextLargenumber(string wholeStr, string decimalStr)
	{
		if (_oSelfHealthTexts.Length == 2)
		{
			_oSelfHealthTexts[0].text = wholeStr;
			_oSelfHealthTexts[1].text = decimalStr;
		}
	}

	public void MapGrayNtvsize()
	{
		if (_oMapGrayImage != null)
		{
			_oMapGrayImage.SetNativeSize();
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
