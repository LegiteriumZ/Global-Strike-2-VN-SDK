using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Weapon;

[GameUiTest]
public class JusticeFromAboveCrossViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oCenter;

	private GameObject _oBack;

	private Image _oBackImage;

	private GameObject _oLeft;

	private RectTransform _oLeftRectTransform;

	private GameObject _oRight;

	private RectTransform _oRightRectTransform;

	private GameObject _oProgressBack;

	private Image _oProgressBackImage;

	private GameObject _oProgressBackUnactive;

	private Image _oProgressBackUnactiveImage;

	private GameObject _oProgressBar;

	private Image _oProgressBarImage;

	private GameObject _oBulletNum;

	private Text _oBulletNumText;

	private GameObject _oGlobalTime;

	private Text _oGlobalTimeText;

	private GameObject _oLocalTime;

	private Text _oLocalTimeText;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/weapon";

	private string _resourceAssetName = "JusticeFromAboveCross";

	public GameObject CenterObj => _oCenter;

	public bool CenterShow
	{
		get
		{
			if (_oCenter != null)
			{
				return _oCenter.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CenterShow != value && _oCenter != null)
			{
				_oCenter.SetObjectActive(value);
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

	public Vector3 LeftPosition
	{
		get
		{
			if (_oLeftRectTransform != null)
			{
				return _oLeftRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (LeftPosition != value && _oLeftRectTransform != null)
			{
				_oLeftRectTransform.localPosition = value;
			}
		}
	}

	public Vector3 RightPosition
	{
		get
		{
			if (_oRightRectTransform != null)
			{
				return _oRightRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (RightPosition != value && _oRightRectTransform != null)
			{
				_oRightRectTransform.localPosition = value;
			}
		}
	}

	public Sprite ProgressBackSprite
	{
		get
		{
			if (_oProgressBackImage != null)
			{
				return _oProgressBackImage.sprite;
			}
			return null;
		}
		set
		{
			if (ProgressBackSprite != value && _oProgressBackImage != null)
			{
				_oProgressBackImage.sprite = value;
			}
		}
	}

	public Sprite ProgressBackUnactiveSprite
	{
		get
		{
			if (_oProgressBackUnactiveImage != null)
			{
				return _oProgressBackUnactiveImage.sprite;
			}
			return null;
		}
		set
		{
			if (ProgressBackUnactiveSprite != value && _oProgressBackUnactiveImage != null)
			{
				_oProgressBackUnactiveImage.sprite = value;
			}
		}
	}

	public GameObject ProgressBarObj => _oProgressBar;

	public Sprite ProgressBarSprite
	{
		get
		{
			if (_oProgressBarImage != null)
			{
				return _oProgressBarImage.sprite;
			}
			return null;
		}
		set
		{
			if (ProgressBarSprite != value && _oProgressBarImage != null)
			{
				_oProgressBarImage.sprite = value;
			}
		}
	}

	public string BulletNumString
	{
		get
		{
			if (_oBulletNumText != null)
			{
				return _oBulletNumText.text;
			}
			return null;
		}
		set
		{
			if (BulletNumString != value && _oBulletNumText != null)
			{
				_oBulletNumText.text = value;
			}
		}
	}

	public string GlobalTimeString
	{
		get
		{
			if (_oGlobalTimeText != null)
			{
				return _oGlobalTimeText.text;
			}
			return null;
		}
		set
		{
			if (GlobalTimeString != value && _oGlobalTimeText != null)
			{
				_oGlobalTimeText.text = value;
			}
		}
	}

	public string LocalTimeString
	{
		get
		{
			if (_oLocalTimeText != null)
			{
				return _oLocalTimeText.text;
			}
			return null;
		}
		set
		{
			if (LocalTimeString != value && _oLocalTimeText != null)
			{
				_oLocalTimeText.text = value;
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
			case "Center":
				_oCenter = transform.gameObject;
				break;
			case "Back":
				_oBack = transform.gameObject;
				_oBackImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Left":
				_oLeft = transform.gameObject;
				_oLeftRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "Right":
				_oRight = transform.gameObject;
				_oRightRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "ProgressBack":
				_oProgressBack = transform.gameObject;
				_oProgressBackImage = transform.gameObject.GetComponent<Image>();
				break;
			case "ProgressBackUnactive":
				_oProgressBackUnactive = transform.gameObject;
				_oProgressBackUnactiveImage = transform.gameObject.GetComponent<Image>();
				break;
			case "ProgressBar":
				_oProgressBar = transform.gameObject;
				_oProgressBarImage = transform.gameObject.GetComponent<Image>();
				break;
			case "BulletNum":
				_oBulletNum = transform.gameObject;
				_oBulletNumText = transform.gameObject.GetComponent<Text>();
				break;
			case "GlobalTime":
				_oGlobalTime = transform.gameObject;
				_oGlobalTimeText = transform.gameObject.GetComponent<Text>();
				break;
			case "LocalTime":
				_oLocalTime = transform.gameObject;
				_oLocalTimeText = transform.gameObject.GetComponent<Text>();
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

	public List<RectTransform> GetHoldPosIntergeTrans()
	{
		return null;
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
}
