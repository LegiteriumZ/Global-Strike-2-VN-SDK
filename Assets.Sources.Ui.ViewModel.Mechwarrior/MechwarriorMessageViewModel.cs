using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Mechwarrior;

[GameUiTest]
public class MechwarriorMessageViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oMessageImage;

	private Image _oMessageImageImage;

	private GameObject _oMessageText;

	private Text _oMessageTextText;

	private GameObject _oSelfMessageImage;

	private Image _oSelfMessageImageImage;

	private GameObject _oStateMessageImage;

	private Image _oStateMessageImageImage;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/mechwarrior";

	private string _resourceAssetName = "MechwarriorMessage";

	public bool MessageImageShow
	{
		get
		{
			if (_oMessageImage != null)
			{
				return _oMessageImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MessageImageShow != value && _oMessageImage != null)
			{
				_oMessageImage.SetObjectActive(value);
			}
		}
	}

	public Sprite MessageImageSprite
	{
		get
		{
			if (_oMessageImageImage != null)
			{
				return _oMessageImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (MessageImageSprite != value && _oMessageImageImage != null)
			{
				_oMessageImageImage.sprite = value;
			}
		}
	}

	public bool MessageTextShow
	{
		get
		{
			if (_oMessageText != null)
			{
				return _oMessageText.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MessageTextShow != value && _oMessageText != null)
			{
				_oMessageText.SetObjectActive(value);
			}
		}
	}

	public string MessageTextString
	{
		get
		{
			if (_oMessageTextText != null)
			{
				return _oMessageTextText.text;
			}
			return null;
		}
		set
		{
			if (MessageTextString != value && _oMessageTextText != null)
			{
				_oMessageTextText.text = value;
			}
		}
	}

	public bool SelfMessageImageShow
	{
		get
		{
			if (_oSelfMessageImage != null)
			{
				return _oSelfMessageImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelfMessageImageShow != value && _oSelfMessageImage != null)
			{
				_oSelfMessageImage.SetObjectActive(value);
			}
		}
	}

	public Sprite SelfMessageImageSprite
	{
		get
		{
			if (_oSelfMessageImageImage != null)
			{
				return _oSelfMessageImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (SelfMessageImageSprite != value && _oSelfMessageImageImage != null)
			{
				_oSelfMessageImageImage.sprite = value;
			}
		}
	}

	public bool StateMessageImageShow
	{
		get
		{
			if (_oStateMessageImage != null)
			{
				return _oStateMessageImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (StateMessageImageShow != value && _oStateMessageImage != null)
			{
				_oStateMessageImage.SetObjectActive(value);
			}
		}
	}

	public Sprite StateMessageImageSprite
	{
		get
		{
			if (_oStateMessageImageImage != null)
			{
				return _oStateMessageImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (StateMessageImageSprite != value && _oStateMessageImageImage != null)
			{
				_oStateMessageImageImage.sprite = value;
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
			case "MessageImage":
				_oMessageImage = transform.gameObject;
				_oMessageImageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "MessageText":
				_oMessageText = transform.gameObject;
				_oMessageTextText = transform.gameObject.GetComponent<Text>();
				break;
			case "SelfMessageImage":
				_oSelfMessageImage = transform.gameObject;
				_oSelfMessageImageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "StateMessageImage":
				_oStateMessageImage = transform.gameObject;
				_oStateMessageImageImage = transform.gameObject.GetComponent<Image>();
				break;
			}
		}
	}

	public void MessageImageNtvsize()
	{
		if (_oMessageImageImage != null)
		{
			_oMessageImageImage.SetNativeSize();
		}
	}

	public void SelfMessageImageNtvsize()
	{
		if (_oSelfMessageImageImage != null)
		{
			_oSelfMessageImageImage.SetNativeSize();
		}
	}

	public void StateMessageImageNtvsize()
	{
		if (_oStateMessageImageImage != null)
		{
			_oStateMessageImageImage.SetNativeSize();
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
