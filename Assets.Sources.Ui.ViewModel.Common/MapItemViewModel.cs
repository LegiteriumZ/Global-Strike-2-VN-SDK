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
public class MapItemViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oMapItem;

	private RectTransform _oMapItemRectTransform;

	private CanvasGroup _oMapItemCanvasGroup;

	private GameObject _oRotation;

	private RectTransform _oRotationRectTransform;

	private GameObject _oImage;

	private RectTransform _oImageRectTransform;

	private Image _oImageImage;

	private GameObject _oTactics;

	private GameObject _oMask;

	private GameObject _oName;

	private Text _oNameText;

	private GameObject _oHp;

	private RectTransform[] _oHealths;

	private Text[] _oHealthTexts;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/common";

	private string _resourceAssetName = "MapItem";

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

	public bool MapItemShow
	{
		get
		{
			if (_oMapItem != null)
			{
				return _oMapItem.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MapItemShow != value && _oMapItem != null)
			{
				_oMapItem.SetObjectActive(value);
			}
		}
	}

	public Vector3 MapItemPosition
	{
		get
		{
			if (_oMapItemRectTransform != null)
			{
				return _oMapItemRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (MapItemPosition != value && _oMapItemRectTransform != null)
			{
				_oMapItemRectTransform.localPosition = value;
			}
		}
	}

	public float MapItemAlpha
	{
		get
		{
			if (_oMapItemCanvasGroup != null)
			{
				return _oMapItemCanvasGroup.alpha;
			}
			return 0f;
		}
		set
		{
			if (MapItemAlpha != value && _oMapItemCanvasGroup != null)
			{
				_oMapItemCanvasGroup.alpha = value;
			}
		}
	}

	public Quaternion RotationRotation
	{
		get
		{
			if (_oRotationRectTransform != null)
			{
				return _oRotationRectTransform.localRotation;
			}
			return Quaternion.Euler(Vector3.zero);
		}
		set
		{
			if (RotationRotation != value && _oRotationRectTransform != null)
			{
				_oRotationRectTransform.localRotation = value;
			}
		}
	}

	public bool ImageShow
	{
		get
		{
			if (_oImage != null)
			{
				return _oImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ImageShow != value && _oImage != null)
			{
				_oImage.SetObjectActive(value);
			}
		}
	}

	public Vector3 ImageScale
	{
		get
		{
			if (_oImageRectTransform != null)
			{
				return _oImageRectTransform.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (ImageScale != value && _oImageRectTransform != null)
			{
				_oImageRectTransform.localScale = value;
			}
		}
	}

	public Vector3 ImageSize
	{
		get
		{
			if (_oImageRectTransform != null)
			{
				return _oImageRectTransform.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (ImageSize != value && _oImageRectTransform != null)
			{
				_oImageRectTransform.sizeDelta = value;
			}
		}
	}

	public Sprite ImageSprite
	{
		get
		{
			if (_oImageImage != null)
			{
				return _oImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (ImageSprite != value && _oImageImage != null)
			{
				_oImageImage.sprite = value;
			}
		}
	}

	public bool TacticsShow
	{
		get
		{
			if (_oTactics != null)
			{
				return _oTactics.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TacticsShow != value && _oTactics != null)
			{
				_oTactics.SetObjectActive(value);
			}
		}
	}

	public bool MaskShow
	{
		get
		{
			if (_oMask != null)
			{
				return _oMask.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MaskShow != value && _oMask != null)
			{
				_oMask.SetObjectActive(value);
			}
		}
	}

	public bool NameShow
	{
		get
		{
			if (_oName != null)
			{
				return _oName.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NameShow != value && _oName != null)
			{
				_oName.SetObjectActive(value);
			}
		}
	}

	public string NameString
	{
		get
		{
			if (_oNameText != null)
			{
				return _oNameText.text;
			}
			return null;
		}
		set
		{
			if (NameString != value && _oNameText != null)
			{
				_oNameText.text = value;
			}
		}
	}

	public bool HpShow
	{
		get
		{
			if (_oHp != null)
			{
				return _oHp.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (HpShow != value && _oHp != null)
			{
				_oHp.SetObjectActive(value);
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
			case "MapItem":
				_oMapItem = transform.gameObject;
				_oMapItemRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oMapItemCanvasGroup = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "Rotation":
				_oRotation = transform.gameObject;
				_oRotationRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "Image":
				_oImage = transform.gameObject;
				_oImageRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oImageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Tactics":
				_oTactics = transform.gameObject;
				break;
			case "Mask":
				_oMask = transform.gameObject;
				break;
			case "Name":
				_oName = transform.gameObject;
				_oNameText = transform.gameObject.GetComponent<Text>();
				break;
			case "Hp":
				_oHp = transform.gameObject;
				break;
			case "Health":
				_oHealths = transform.GetComponentsInChildren<RectTransform>();
				_oHealthTexts = transform.GetComponentsInChildren<Text>();
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

	public void ImageNtvsize()
	{
		if (_oImageImage != null)
		{
			_oImageImage.SetNativeSize();
		}
	}

	public void SetHealthShowLargenumber(bool[] shows)
	{
		if (shows.Length == 4 || _oHealths.Length == 5)
		{
			for (int i = 1; i < _oHealths.Length; i++)
			{
				_oHealths[i].gameObject.SetActive(shows[i - 1]);
			}
		}
	}

	public void SetHealthPosiLargenumber(Vector3[] positions)
	{
		if (positions.Length == 5 || _oHealths.Length == 5)
		{
			for (int i = 0; i < _oHealths.Length; i++)
			{
				_oHealths[i].anchoredPosition = positions[i];
			}
		}
	}

	public void SetHealthTextLargenumber(string wholeStr, string decimalStr)
	{
		if (_oHealthTexts.Length == 2)
		{
			_oHealthTexts[0].text = wholeStr;
			_oHealthTexts[1].text = decimalStr;
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
