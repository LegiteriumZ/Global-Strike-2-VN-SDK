using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Rpg;

[GameUiTest]
public class LastDefenseEffectViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _olastDefenseEffect;

	private GameObject _opanel;

	private GameObject _oback;

	private Image _obackImage;

	private GameObject _otips1;

	private GameObject _otips2;

	private Image _otipsImage1;

	private Image _otipsImage2;

	private GameObject _viewGameObject;

	public const string tips1Name = "tips1";

	public const string tips2Name = "tips2";

	private string _resourceBundleName = "uiprefabs/rpg";

	private string _resourceAssetName = "LastDefenseEffect";

	public GameObject lastDefenseEffectObj => _olastDefenseEffect;

	public bool lastDefenseEffectShow
	{
		get
		{
			if (_olastDefenseEffect != null)
			{
				return _olastDefenseEffect.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (lastDefenseEffectShow != value && _olastDefenseEffect != null)
			{
				_olastDefenseEffect.SetObjectActive(value);
			}
		}
	}

	public bool panelShow
	{
		get
		{
			if (_opanel != null)
			{
				return _opanel.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (panelShow != value && _opanel != null)
			{
				_opanel.SetObjectActive(value);
			}
		}
	}

	public bool backShow
	{
		get
		{
			if (_oback != null)
			{
				return _oback.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (backShow != value && _oback != null)
			{
				_oback.SetObjectActive(value);
			}
		}
	}

	public Image backImage
	{
		get
		{
			if (_obackImage != null)
			{
				return _obackImage;
			}
			return null;
		}
		set
		{
			if (backImage != value && _obackImage != null)
			{
				_obackImage = value;
			}
		}
	}

	public bool tipsShow1
	{
		get
		{
			if (_otips1 != null)
			{
				return _otips1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (tipsShow1 != value && _otips1 != null)
			{
				_otips1.SetObjectActive(value);
			}
		}
	}

	public bool tipsShow2
	{
		get
		{
			if (_otips2 != null)
			{
				return _otips2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (tipsShow2 != value && _otips2 != null)
			{
				_otips2.SetObjectActive(value);
			}
		}
	}

	public Image tipsImage1
	{
		get
		{
			if (_otipsImage1 != null)
			{
				return _otipsImage1;
			}
			return null;
		}
		set
		{
			if (tipsImage1 != value && _otipsImage1 != null)
			{
				_otipsImage1 = value;
			}
		}
	}

	public Image tipsImage2
	{
		get
		{
			if (_otipsImage2 != null)
			{
				return _otipsImage2;
			}
			return null;
		}
		set
		{
			if (tipsImage2 != value && _otipsImage2 != null)
			{
				_otipsImage2 = value;
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
			case "lastDefenseEffect":
				_olastDefenseEffect = transform.gameObject;
				break;
			case "panel":
				_opanel = transform.gameObject;
				break;
			case "back":
				_oback = transform.gameObject;
				_obackImage = transform.gameObject.GetComponent<Image>();
				break;
			case "tips1":
				_otips1 = transform.gameObject;
				_otipsImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "tips2":
				_otips2 = transform.gameObject;
				_otipsImage2 = transform.gameObject.GetComponent<Image>();
				break;
			}
		}
	}

	public string GettipsName(int index)
	{
		return index switch
		{
			1 => "tips1", 
			2 => "tips2", 
			_ => null, 
		};
	}

	public bool GettipsShow(int index)
	{
		return index switch
		{
			1 => tipsShow1, 
			2 => tipsShow2, 
			_ => false, 
		};
	}

	public void SettipsShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			tipsShow1 = value;
			break;
		case 2:
			tipsShow2 = value;
			break;
		}
	}

	public Image GettipsImage(int index)
	{
		return index switch
		{
			1 => tipsImage1, 
			2 => tipsImage2, 
			_ => null, 
		};
	}

	public void SettipsImage(int index, Image value)
	{
		switch (index)
		{
		case 1:
			tipsImage1 = value;
			break;
		case 2:
			tipsImage2 = value;
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
