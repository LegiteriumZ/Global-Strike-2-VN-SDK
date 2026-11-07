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
public class PvetdbothpViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _opvetdbothp;

	private GameObject _obotHPBackImage;

	private GameObject _obotName;

	private Text _obotNameText;

	private GameObject _ohpProgressEffectImage;

	private Image _ohpProgressEffectImageImage;

	private GameObject _ohpProgressImage;

	private Image _ohpProgressImageImage;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/pve";

	private string _resourceAssetName = "Pvetdbothp";

	public GameObject pvetdbothpObj => _opvetdbothp;

	public bool pvetdbothpShow
	{
		get
		{
			if (_opvetdbothp != null)
			{
				return _opvetdbothp.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (pvetdbothpShow != value && _opvetdbothp != null)
			{
				_opvetdbothp.SetObjectActive(value);
			}
		}
	}

	public bool botHPBackImageShow
	{
		get
		{
			if (_obotHPBackImage != null)
			{
				return _obotHPBackImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (botHPBackImageShow != value && _obotHPBackImage != null)
			{
				_obotHPBackImage.SetObjectActive(value);
			}
		}
	}

	public bool botNameShow
	{
		get
		{
			if (_obotName != null)
			{
				return _obotName.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (botNameShow != value && _obotName != null)
			{
				_obotName.SetObjectActive(value);
			}
		}
	}

	public string botNameString
	{
		get
		{
			if (_obotNameText != null)
			{
				return _obotNameText.text;
			}
			return null;
		}
		set
		{
			if (botNameString != value && _obotNameText != null)
			{
				_obotNameText.text = value;
			}
		}
	}

	public bool hpProgressEffectImageShow
	{
		get
		{
			if (_ohpProgressEffectImage != null)
			{
				return _ohpProgressEffectImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (hpProgressEffectImageShow != value && _ohpProgressEffectImage != null)
			{
				_ohpProgressEffectImage.SetObjectActive(value);
			}
		}
	}

	public Sprite hpProgressEffectImageSprite
	{
		get
		{
			if (_ohpProgressEffectImageImage != null)
			{
				return _ohpProgressEffectImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (hpProgressEffectImageSprite != value && _ohpProgressEffectImageImage != null)
			{
				_ohpProgressEffectImageImage.sprite = value;
			}
		}
	}

	public float hpProgressEffectImageFillamount
	{
		get
		{
			if (_ohpProgressEffectImageImage != null)
			{
				return _ohpProgressEffectImageImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (hpProgressEffectImageFillamount != value && _ohpProgressEffectImageImage != null)
			{
				_ohpProgressEffectImageImage.fillAmount = value;
			}
		}
	}

	public Color hpProgressEffectImageColor
	{
		get
		{
			if (_ohpProgressEffectImageImage != null)
			{
				return _ohpProgressEffectImageImage.color;
			}
			return Color.white;
		}
		set
		{
			if (hpProgressEffectImageColor != value && _ohpProgressEffectImageImage != null)
			{
				_ohpProgressEffectImageImage.color = value;
			}
		}
	}

	public bool hpProgressImageShow
	{
		get
		{
			if (_ohpProgressImage != null)
			{
				return _ohpProgressImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (hpProgressImageShow != value && _ohpProgressImage != null)
			{
				_ohpProgressImage.SetObjectActive(value);
			}
		}
	}

	public Sprite hpProgressImageSprite
	{
		get
		{
			if (_ohpProgressImageImage != null)
			{
				return _ohpProgressImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (hpProgressImageSprite != value && _ohpProgressImageImage != null)
			{
				_ohpProgressImageImage.sprite = value;
			}
		}
	}

	public float hpProgressImageFillamount
	{
		get
		{
			if (_ohpProgressImageImage != null)
			{
				return _ohpProgressImageImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (hpProgressImageFillamount != value && _ohpProgressImageImage != null)
			{
				_ohpProgressImageImage.fillAmount = value;
			}
		}
	}

	public Color hpProgressImageColor
	{
		get
		{
			if (_ohpProgressImageImage != null)
			{
				return _ohpProgressImageImage.color;
			}
			return Color.white;
		}
		set
		{
			if (hpProgressImageColor != value && _ohpProgressImageImage != null)
			{
				_ohpProgressImageImage.color = value;
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
			case "pvetdbothp":
				_opvetdbothp = transform.gameObject;
				break;
			case "botHPBackImage":
				_obotHPBackImage = transform.gameObject;
				break;
			case "botName":
				_obotName = transform.gameObject;
				_obotNameText = transform.gameObject.GetComponent<Text>();
				break;
			case "hpProgressEffectImage":
				_ohpProgressEffectImage = transform.gameObject;
				_ohpProgressEffectImageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "hpProgressImage":
				_ohpProgressImage = transform.gameObject;
				_ohpProgressImageImage = transform.gameObject.GetComponent<Image>();
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
