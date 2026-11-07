using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Pve;

[GameUiTest]
public class EnergydevicetowardViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oenergydevicetoward;

	private GameObject _oenergyDeviceHintImage;

	private RectTransform _oenergyDeviceHintImageRectTransform;

	private Image _oenergyDeviceHintImageImage;

	private GameObject _oenergyDeviceDistancetxt;

	private RectTransform _oenergyDeviceDistancetxtRectTransform;

	private Text _oenergyDeviceDistancetxtText;

	private GameObject _otoward;

	private RectTransform _otowardRectTransform;

	private GameObject _oenergyDeviceTowardImage;

	private RectTransform _oenergyDeviceTowardImageRectTransform;

	private Image _oenergyDeviceTowardImageImage;

	private GameObject _oenergyDeviceIconImage;

	private RectTransform _oenergyDeviceIconImageRectTransform;

	private Image _oenergyDeviceIconImageImage;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/pve";

	private string _resourceAssetName = "Energydevicetoward";

	public GameObject energydevicetowardObj => _oenergydevicetoward;

	public bool energydevicetowardShow
	{
		get
		{
			if (_oenergydevicetoward != null)
			{
				return _oenergydevicetoward.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (energydevicetowardShow != value && _oenergydevicetoward != null)
			{
				_oenergydevicetoward.SetObjectActive(value);
			}
		}
	}

	public bool energyDeviceHintImageShow
	{
		get
		{
			if (_oenergyDeviceHintImage != null)
			{
				return _oenergyDeviceHintImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (energyDeviceHintImageShow != value && _oenergyDeviceHintImage != null)
			{
				_oenergyDeviceHintImage.SetObjectActive(value);
			}
		}
	}

	public Vector2 energyDeviceHintImageAnchoredposition
	{
		get
		{
			if (_oenergyDeviceHintImageRectTransform != null)
			{
				return _oenergyDeviceHintImageRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (energyDeviceHintImageAnchoredposition != value && _oenergyDeviceHintImageRectTransform != null)
			{
				_oenergyDeviceHintImageRectTransform.anchoredPosition = value;
			}
		}
	}

	public Quaternion energyDeviceHintImageRotation
	{
		get
		{
			if (_oenergyDeviceHintImageRectTransform != null)
			{
				return _oenergyDeviceHintImageRectTransform.localRotation;
			}
			return Quaternion.Euler(Vector3.zero);
		}
		set
		{
			if (energyDeviceHintImageRotation != value && _oenergyDeviceHintImageRectTransform != null)
			{
				_oenergyDeviceHintImageRectTransform.localRotation = value;
			}
		}
	}

	public Vector3 energyDeviceHintImageSize
	{
		get
		{
			if (_oenergyDeviceHintImageRectTransform != null)
			{
				return _oenergyDeviceHintImageRectTransform.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (energyDeviceHintImageSize != value && _oenergyDeviceHintImageRectTransform != null)
			{
				_oenergyDeviceHintImageRectTransform.sizeDelta = value;
			}
		}
	}

	public Sprite energyDeviceHintImageSprite
	{
		get
		{
			if (_oenergyDeviceHintImageImage != null)
			{
				return _oenergyDeviceHintImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (energyDeviceHintImageSprite != value && _oenergyDeviceHintImageImage != null)
			{
				_oenergyDeviceHintImageImage.sprite = value;
			}
		}
	}

	public bool energyDeviceDistancetxtShow
	{
		get
		{
			if (_oenergyDeviceDistancetxt != null)
			{
				return _oenergyDeviceDistancetxt.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (energyDeviceDistancetxtShow != value && _oenergyDeviceDistancetxt != null)
			{
				_oenergyDeviceDistancetxt.SetObjectActive(value);
			}
		}
	}

	public Vector2 energyDeviceDistancetxtAnchoredposition
	{
		get
		{
			if (_oenergyDeviceDistancetxtRectTransform != null)
			{
				return _oenergyDeviceDistancetxtRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (energyDeviceDistancetxtAnchoredposition != value && _oenergyDeviceDistancetxtRectTransform != null)
			{
				_oenergyDeviceDistancetxtRectTransform.anchoredPosition = value;
			}
		}
	}

	public string energyDeviceDistancetxtString
	{
		get
		{
			if (_oenergyDeviceDistancetxtText != null)
			{
				return _oenergyDeviceDistancetxtText.text;
			}
			return null;
		}
		set
		{
			if (energyDeviceDistancetxtString != value && _oenergyDeviceDistancetxtText != null)
			{
				_oenergyDeviceDistancetxtText.text = value;
			}
		}
	}

	public bool towardShow
	{
		get
		{
			if (_otoward != null)
			{
				return _otoward.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (towardShow != value && _otoward != null)
			{
				_otoward.SetObjectActive(value);
			}
		}
	}

	public Vector2 towardAnchoredposition
	{
		get
		{
			if (_otowardRectTransform != null)
			{
				return _otowardRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (towardAnchoredposition != value && _otowardRectTransform != null)
			{
				_otowardRectTransform.anchoredPosition = value;
			}
		}
	}

	public Quaternion towardRotation
	{
		get
		{
			if (_otowardRectTransform != null)
			{
				return _otowardRectTransform.localRotation;
			}
			return Quaternion.Euler(Vector3.zero);
		}
		set
		{
			if (towardRotation != value && _otowardRectTransform != null)
			{
				_otowardRectTransform.localRotation = value;
			}
		}
	}

	public bool energyDeviceTowardImageShow
	{
		get
		{
			if (_oenergyDeviceTowardImage != null)
			{
				return _oenergyDeviceTowardImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (energyDeviceTowardImageShow != value && _oenergyDeviceTowardImage != null)
			{
				_oenergyDeviceTowardImage.SetObjectActive(value);
			}
		}
	}

	public Vector2 energyDeviceTowardImageAnchoredposition
	{
		get
		{
			if (_oenergyDeviceTowardImageRectTransform != null)
			{
				return _oenergyDeviceTowardImageRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (energyDeviceTowardImageAnchoredposition != value && _oenergyDeviceTowardImageRectTransform != null)
			{
				_oenergyDeviceTowardImageRectTransform.anchoredPosition = value;
			}
		}
	}

	public Quaternion energyDeviceTowardImageRotation
	{
		get
		{
			if (_oenergyDeviceTowardImageRectTransform != null)
			{
				return _oenergyDeviceTowardImageRectTransform.localRotation;
			}
			return Quaternion.Euler(Vector3.zero);
		}
		set
		{
			if (energyDeviceTowardImageRotation != value && _oenergyDeviceTowardImageRectTransform != null)
			{
				_oenergyDeviceTowardImageRectTransform.localRotation = value;
			}
		}
	}

	public Sprite energyDeviceTowardImageSprite
	{
		get
		{
			if (_oenergyDeviceTowardImageImage != null)
			{
				return _oenergyDeviceTowardImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (energyDeviceTowardImageSprite != value && _oenergyDeviceTowardImageImage != null)
			{
				_oenergyDeviceTowardImageImage.sprite = value;
			}
		}
	}

	public bool energyDeviceIconImageShow
	{
		get
		{
			if (_oenergyDeviceIconImage != null)
			{
				return _oenergyDeviceIconImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (energyDeviceIconImageShow != value && _oenergyDeviceIconImage != null)
			{
				_oenergyDeviceIconImage.SetObjectActive(value);
			}
		}
	}

	public Vector2 energyDeviceIconImageAnchoredposition
	{
		get
		{
			if (_oenergyDeviceIconImageRectTransform != null)
			{
				return _oenergyDeviceIconImageRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (energyDeviceIconImageAnchoredposition != value && _oenergyDeviceIconImageRectTransform != null)
			{
				_oenergyDeviceIconImageRectTransform.anchoredPosition = value;
			}
		}
	}

	public Quaternion energyDeviceIconImageRotation
	{
		get
		{
			if (_oenergyDeviceIconImageRectTransform != null)
			{
				return _oenergyDeviceIconImageRectTransform.localRotation;
			}
			return Quaternion.Euler(Vector3.zero);
		}
		set
		{
			if (energyDeviceIconImageRotation != value && _oenergyDeviceIconImageRectTransform != null)
			{
				_oenergyDeviceIconImageRectTransform.localRotation = value;
			}
		}
	}

	public Vector3 energyDeviceIconImageSize
	{
		get
		{
			if (_oenergyDeviceIconImageRectTransform != null)
			{
				return _oenergyDeviceIconImageRectTransform.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (energyDeviceIconImageSize != value && _oenergyDeviceIconImageRectTransform != null)
			{
				_oenergyDeviceIconImageRectTransform.sizeDelta = value;
			}
		}
	}

	public Sprite energyDeviceIconImageSprite
	{
		get
		{
			if (_oenergyDeviceIconImageImage != null)
			{
				return _oenergyDeviceIconImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (energyDeviceIconImageSprite != value && _oenergyDeviceIconImageImage != null)
			{
				_oenergyDeviceIconImageImage.sprite = value;
			}
		}
	}

	public Color energyDeviceIconImageColor
	{
		get
		{
			if (_oenergyDeviceIconImageImage != null)
			{
				return _oenergyDeviceIconImageImage.color;
			}
			return Color.white;
		}
		set
		{
			if (energyDeviceIconImageColor != value && _oenergyDeviceIconImageImage != null)
			{
				_oenergyDeviceIconImageImage.color = value;
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
			case "energydevicetoward":
				_oenergydevicetoward = transform.gameObject;
				break;
			case "energyDeviceHintImage":
				_oenergyDeviceHintImage = transform.gameObject;
				_oenergyDeviceHintImageRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oenergyDeviceHintImageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "energyDeviceDistancetxt":
				_oenergyDeviceDistancetxt = transform.gameObject;
				_oenergyDeviceDistancetxtRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oenergyDeviceDistancetxtText = transform.gameObject.GetComponent<Text>();
				break;
			case "toward":
				_otoward = transform.gameObject;
				_otowardRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "energyDeviceTowardImage":
				_oenergyDeviceTowardImage = transform.gameObject;
				_oenergyDeviceTowardImageRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oenergyDeviceTowardImageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "energyDeviceIconImage":
				_oenergyDeviceIconImage = transform.gameObject;
				_oenergyDeviceIconImageRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oenergyDeviceIconImageImage = transform.gameObject.GetComponent<Image>();
				break;
			}
		}
	}

	public void energyDeviceHintImageNtvsize()
	{
		if (_oenergyDeviceHintImageImage != null)
		{
			_oenergyDeviceHintImageImage.SetNativeSize();
		}
	}

	public void energyDeviceTowardImageNtvsize()
	{
		if (_oenergyDeviceTowardImageImage != null)
		{
			_oenergyDeviceTowardImageImage.SetNativeSize();
		}
	}

	public void energyDeviceIconImageNtvsize()
	{
		if (_oenergyDeviceIconImageImage != null)
		{
			_oenergyDeviceIconImageImage.SetNativeSize();
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
