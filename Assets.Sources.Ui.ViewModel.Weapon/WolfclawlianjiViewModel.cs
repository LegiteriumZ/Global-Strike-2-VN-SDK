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
public class WolfclawlianjiViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oshow;

	private GameObject _olianji;

	private Image _olianjiImage;

	private GameObject _osucTimes;

	private Text _osucTimesText;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/weapon";

	private string _resourceAssetName = "Wolfclawlianji";

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

	public Sprite lianjiSprite
	{
		get
		{
			if (_olianjiImage != null)
			{
				return _olianjiImage.sprite;
			}
			return null;
		}
		set
		{
			if (lianjiSprite != value && _olianjiImage != null)
			{
				_olianjiImage.sprite = value;
			}
		}
	}

	public string sucTimesString
	{
		get
		{
			if (_osucTimesText != null)
			{
				return _osucTimesText.text;
			}
			return null;
		}
		set
		{
			if (sucTimesString != value && _osucTimesText != null)
			{
				_osucTimesText.text = value;
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
			case "lianji":
				_olianji = transform.gameObject;
				_olianjiImage = transform.gameObject.GetComponent<Image>();
				break;
			case "sucTimes":
				_osucTimes = transform.gameObject;
				_osucTimesText = transform.gameObject.GetComponent<Text>();
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
