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
public class WolfclawprogressViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oshow;

	private GameObject _obg;

	private Slider _obgSlider;

	private GameObject _olianjibg;

	private Image _olianjibgImage;

	private GameObject _olianjiprogress;

	private Image _olianjiprogressImage;

	private GameObject _obar;

	private Image _obarImage;

	private GameObject _ohandle;

	private Slider _ohandleSlider;

	private GameObject _onote;

	private Image _onoteImage;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/weapon";

	private string _resourceAssetName = "Wolfclawprogress";

	public bool showShow
	{
		get
		{
			if (_oshow != null)
			{
				return _oshow.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (showShow != value && _oshow != null)
			{
				_oshow.SetObjectActive(value);
			}
		}
	}

	public bool bgShow
	{
		get
		{
			if (_obg != null)
			{
				return _obg.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (bgShow != value && _obg != null)
			{
				_obg.SetObjectActive(value);
			}
		}
	}

	public float bgSlidervalue
	{
		get
		{
			if (_obgSlider != null)
			{
				return _obgSlider.value;
			}
			return 0f;
		}
		set
		{
			if (bgSlidervalue != value && _obgSlider != null)
			{
				_obgSlider.value = value;
			}
		}
	}

	public Sprite lianjibgSprite
	{
		get
		{
			if (_olianjibgImage != null)
			{
				return _olianjibgImage.sprite;
			}
			return null;
		}
		set
		{
			if (lianjibgSprite != value && _olianjibgImage != null)
			{
				_olianjibgImage.sprite = value;
			}
		}
	}

	public Sprite lianjiprogressSprite
	{
		get
		{
			if (_olianjiprogressImage != null)
			{
				return _olianjiprogressImage.sprite;
			}
			return null;
		}
		set
		{
			if (lianjiprogressSprite != value && _olianjiprogressImage != null)
			{
				_olianjiprogressImage.sprite = value;
			}
		}
	}

	public Sprite barSprite
	{
		get
		{
			if (_obarImage != null)
			{
				return _obarImage.sprite;
			}
			return null;
		}
		set
		{
			if (barSprite != value && _obarImage != null)
			{
				_obarImage.sprite = value;
			}
		}
	}

	public bool handleShow
	{
		get
		{
			if (_ohandle != null)
			{
				return _ohandle.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (handleShow != value && _ohandle != null)
			{
				_ohandle.SetObjectActive(value);
			}
		}
	}

	public float handleSlidervalue
	{
		get
		{
			if (_ohandleSlider != null)
			{
				return _ohandleSlider.value;
			}
			return 0f;
		}
		set
		{
			if (handleSlidervalue != value && _ohandleSlider != null)
			{
				_ohandleSlider.value = value;
			}
		}
	}

	public Sprite noteSprite
	{
		get
		{
			if (_onoteImage != null)
			{
				return _onoteImage.sprite;
			}
			return null;
		}
		set
		{
			if (noteSprite != value && _onoteImage != null)
			{
				_onoteImage.sprite = value;
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
			case "show":
				_oshow = transform.gameObject;
				break;
			case "bg":
				_obg = transform.gameObject;
				_obgSlider = transform.gameObject.GetComponent<Slider>();
				break;
			case "lianjibg":
				_olianjibg = transform.gameObject;
				_olianjibgImage = transform.gameObject.GetComponent<Image>();
				break;
			case "lianjiprogress":
				_olianjiprogress = transform.gameObject;
				_olianjiprogressImage = transform.gameObject.GetComponent<Image>();
				break;
			case "bar":
				_obar = transform.gameObject;
				_obarImage = transform.gameObject.GetComponent<Image>();
				break;
			case "handle":
				_ohandle = transform.gameObject;
				_ohandleSlider = transform.gameObject.GetComponent<Slider>();
				break;
			case "note":
				_onote = transform.gameObject;
				_onoteImage = transform.gameObject.GetComponent<Image>();
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
