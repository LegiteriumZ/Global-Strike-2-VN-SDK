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
public class CountdownViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oCenter;

	private GameObject _oremainattacktime;

	private Image _oremainattacktimeImage;

	private GameObject _oremainattacktimedian;

	private Image _oremainattacktimedianImage;

	private GameObject _osecond;

	private Text _osecondText;

	private GameObject _omillisecond;

	private Text _omillisecondText;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/weapon";

	private string _resourceAssetName = "Countdown";

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

	public Sprite remainattacktimeSprite
	{
		get
		{
			if (_oremainattacktimeImage != null)
			{
				return _oremainattacktimeImage.sprite;
			}
			return null;
		}
		set
		{
			if (remainattacktimeSprite != value && _oremainattacktimeImage != null)
			{
				_oremainattacktimeImage.sprite = value;
			}
		}
	}

	public Sprite remainattacktimedianSprite
	{
		get
		{
			if (_oremainattacktimedianImage != null)
			{
				return _oremainattacktimedianImage.sprite;
			}
			return null;
		}
		set
		{
			if (remainattacktimedianSprite != value && _oremainattacktimedianImage != null)
			{
				_oremainattacktimedianImage.sprite = value;
			}
		}
	}

	public string secondString
	{
		get
		{
			if (_osecondText != null)
			{
				return _osecondText.text;
			}
			return null;
		}
		set
		{
			if (secondString != value && _osecondText != null)
			{
				_osecondText.text = value;
			}
		}
	}

	public string millisecondString
	{
		get
		{
			if (_omillisecondText != null)
			{
				return _omillisecondText.text;
			}
			return null;
		}
		set
		{
			if (millisecondString != value && _omillisecondText != null)
			{
				_omillisecondText.text = value;
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
			case "remainattacktime":
				_oremainattacktime = transform.gameObject;
				_oremainattacktimeImage = transform.gameObject.GetComponent<Image>();
				break;
			case "remainattacktimedian":
				_oremainattacktimedian = transform.gameObject;
				_oremainattacktimedianImage = transform.gameObject.GetComponent<Image>();
				break;
			case "second":
				_osecond = transform.gameObject;
				_osecondText = transform.gameObject.GetComponent<Text>();
				break;
			case "millisecond":
				_omillisecond = transform.gameObject;
				_omillisecondText = transform.gameObject.GetComponent<Text>();
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
