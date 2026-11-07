using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Common;

[GameUiTest]
public class CommonkillbroadViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _ocommonkillbroad;

	private GameObject _oPanel;

	private GameObject _oKillBack;

	private Image _oKillBackImage;

	private GameObject _oKillType;

	private RectTransform _oKillTypeRectTransform;

	private Image _oKillTypeImage;

	private GameObject _oKillNumber;

	private Image _oKillNumberImage;

	private GameObject _oPlayerName;

	private RectTransform _oPlayerNameRectTransform;

	private Text _oPlayerNameText;

	private GameObject _ohintImage;

	private Image _ohintImageImage;

	private GameObject _oweaponImage;

	private Image _oweaponImageImage;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/common";

	private string _resourceAssetName = "Commonkillbroad";

	public bool commonkillbroadShow
	{
		get
		{
			if (_ocommonkillbroad != null)
			{
				return _ocommonkillbroad.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (commonkillbroadShow != value && _ocommonkillbroad != null)
			{
				_ocommonkillbroad.SetObjectActive(value);
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

	public bool KillBackShow
	{
		get
		{
			if (_oKillBack != null)
			{
				return _oKillBack.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (KillBackShow != value && _oKillBack != null)
			{
				_oKillBack.SetObjectActive(value);
			}
		}
	}

	public Image KillBackImage
	{
		get
		{
			if (_oKillBackImage != null)
			{
				return _oKillBackImage;
			}
			return null;
		}
		set
		{
			if (KillBackImage != value && _oKillBackImage != null)
			{
				_oKillBackImage = value;
			}
		}
	}

	public bool KillTypeShow
	{
		get
		{
			if (_oKillType != null)
			{
				return _oKillType.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (KillTypeShow != value && _oKillType != null)
			{
				_oKillType.SetObjectActive(value);
			}
		}
	}

	public Vector2 KillTypeAnchoredposition
	{
		get
		{
			if (_oKillTypeRectTransform != null)
			{
				return _oKillTypeRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (KillTypeAnchoredposition != value && _oKillTypeRectTransform != null)
			{
				_oKillTypeRectTransform.anchoredPosition = value;
			}
		}
	}

	public Sprite KillTypeSprite
	{
		get
		{
			if (_oKillTypeImage != null)
			{
				return _oKillTypeImage.sprite;
			}
			return null;
		}
		set
		{
			if (KillTypeSprite != value && _oKillTypeImage != null)
			{
				_oKillTypeImage.sprite = value;
			}
		}
	}

	public Image KillTypeImage
	{
		get
		{
			if (_oKillTypeImage != null)
			{
				return _oKillTypeImage;
			}
			return null;
		}
		set
		{
			if (KillTypeImage != value && _oKillTypeImage != null)
			{
				_oKillTypeImage = value;
			}
		}
	}

	public bool KillNumberShow
	{
		get
		{
			if (_oKillNumber != null)
			{
				return _oKillNumber.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (KillNumberShow != value && _oKillNumber != null)
			{
				_oKillNumber.SetObjectActive(value);
			}
		}
	}

	public Sprite KillNumberSprite
	{
		get
		{
			if (_oKillNumberImage != null)
			{
				return _oKillNumberImage.sprite;
			}
			return null;
		}
		set
		{
			if (KillNumberSprite != value && _oKillNumberImage != null)
			{
				_oKillNumberImage.sprite = value;
			}
		}
	}

	public Image KillNumberImage
	{
		get
		{
			if (_oKillNumberImage != null)
			{
				return _oKillNumberImage;
			}
			return null;
		}
		set
		{
			if (KillNumberImage != value && _oKillNumberImage != null)
			{
				_oKillNumberImage = value;
			}
		}
	}

	public bool PlayerNameShow
	{
		get
		{
			if (_oPlayerName != null)
			{
				return _oPlayerName.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerNameShow != value && _oPlayerName != null)
			{
				_oPlayerName.SetObjectActive(value);
			}
		}
	}

	public Vector2 PlayerNameAnchoredposition
	{
		get
		{
			if (_oPlayerNameRectTransform != null)
			{
				return _oPlayerNameRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (PlayerNameAnchoredposition != value && _oPlayerNameRectTransform != null)
			{
				_oPlayerNameRectTransform.anchoredPosition = value;
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

	public Color PlayerNameTextcolor
	{
		get
		{
			if (_oPlayerNameText != null)
			{
				return _oPlayerNameText.color;
			}
			return Color.white;
		}
		set
		{
			if (PlayerNameTextcolor != value && _oPlayerNameText != null)
			{
				_oPlayerNameText.color = value;
			}
		}
	}

	public bool hintImageShow
	{
		get
		{
			if (_ohintImage != null)
			{
				return _ohintImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (hintImageShow != value && _ohintImage != null)
			{
				_ohintImage.SetObjectActive(value);
			}
		}
	}

	public Sprite hintImageSprite
	{
		get
		{
			if (_ohintImageImage != null)
			{
				return _ohintImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (hintImageSprite != value && _ohintImageImage != null)
			{
				_ohintImageImage.sprite = value;
			}
		}
	}

	public Image hintImageImage
	{
		get
		{
			if (_ohintImageImage != null)
			{
				return _ohintImageImage;
			}
			return null;
		}
		set
		{
			if (hintImageImage != value && _ohintImageImage != null)
			{
				_ohintImageImage = value;
			}
		}
	}

	public bool weaponImageShow
	{
		get
		{
			if (_oweaponImage != null)
			{
				return _oweaponImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (weaponImageShow != value && _oweaponImage != null)
			{
				_oweaponImage.SetObjectActive(value);
			}
		}
	}

	public Sprite weaponImageSprite
	{
		get
		{
			if (_oweaponImageImage != null)
			{
				return _oweaponImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (weaponImageSprite != value && _oweaponImageImage != null)
			{
				_oweaponImageImage.sprite = value;
			}
		}
	}

	public Image weaponImageImage
	{
		get
		{
			if (_oweaponImageImage != null)
			{
				return _oweaponImageImage;
			}
			return null;
		}
		set
		{
			if (weaponImageImage != value && _oweaponImageImage != null)
			{
				_oweaponImageImage = value;
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
			case "commonkillbroad":
				_ocommonkillbroad = transform.gameObject;
				break;
			case "Panel":
				_oPanel = transform.gameObject;
				break;
			case "KillBack":
				_oKillBack = transform.gameObject;
				_oKillBackImage = transform.gameObject.GetComponent<Image>();
				break;
			case "KillType":
				_oKillType = transform.gameObject;
				_oKillTypeRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oKillTypeImage = transform.gameObject.GetComponent<Image>();
				break;
			case "KillNumber":
				_oKillNumber = transform.gameObject;
				_oKillNumberImage = transform.gameObject.GetComponent<Image>();
				break;
			case "PlayerName":
				_oPlayerName = transform.gameObject;
				_oPlayerNameRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oPlayerNameText = transform.gameObject.GetComponent<Text>();
				break;
			case "hintImage":
				_ohintImage = transform.gameObject;
				_ohintImageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "weaponImage":
				_oweaponImage = transform.gameObject;
				_oweaponImageImage = transform.gameObject.GetComponent<Image>();
				break;
			}
		}
	}

	public void KillNumberNtvsize()
	{
		if (_oKillNumberImage != null)
		{
			_oKillNumberImage.SetNativeSize();
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
