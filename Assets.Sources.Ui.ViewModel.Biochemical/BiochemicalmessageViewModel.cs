using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Biochemical;

[GameUiTest]
public class BiochemicalmessageViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oSelfMessageImage;

	private Image _oSelfMessageImageImage;

	private GameObject _oMessageImage;

	private Image _oMessageImageImage;

	private GameObject _oStateImage;

	private Image _oStateImageImage;

	private GameObject _oSkillImage;

	private Image _oSkillImageImage;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/biochemical";

	private string _resourceAssetName = "Biochemicalmessage";

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

	public bool StateImageShow
	{
		get
		{
			if (_oStateImage != null)
			{
				return _oStateImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (StateImageShow != value && _oStateImage != null)
			{
				_oStateImage.SetObjectActive(value);
			}
		}
	}

	public Sprite StateImageSprite
	{
		get
		{
			if (_oStateImageImage != null)
			{
				return _oStateImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (StateImageSprite != value && _oStateImageImage != null)
			{
				_oStateImageImage.sprite = value;
			}
		}
	}

	public bool SkillImageShow
	{
		get
		{
			if (_oSkillImage != null)
			{
				return _oSkillImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillImageShow != value && _oSkillImage != null)
			{
				_oSkillImage.SetObjectActive(value);
			}
		}
	}

	public Sprite SkillImageSprite
	{
		get
		{
			if (_oSkillImageImage != null)
			{
				return _oSkillImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (SkillImageSprite != value && _oSkillImageImage != null)
			{
				_oSkillImageImage.sprite = value;
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
			case "SelfMessageImage":
				_oSelfMessageImage = transform.gameObject;
				_oSelfMessageImageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "MessageImage":
				_oMessageImage = transform.gameObject;
				_oMessageImageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "StateImage":
				_oStateImage = transform.gameObject;
				_oStateImageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "SkillImage":
				_oSkillImage = transform.gameObject;
				_oSkillImageImage = transform.gameObject.GetComponent<Image>();
				break;
			}
		}
	}

	public void SelfMessageImageNtvsize()
	{
		if (_oSelfMessageImageImage != null)
		{
			_oSelfMessageImageImage.SetNativeSize();
		}
	}

	public void MessageImageNtvsize()
	{
		if (_oMessageImageImage != null)
		{
			_oMessageImageImage.SetNativeSize();
		}
	}

	public void StateImageNtvsize()
	{
		if (_oStateImageImage != null)
		{
			_oStateImageImage.SetNativeSize();
		}
	}

	public void SkillImageNtvsize()
	{
		if (_oSkillImageImage != null)
		{
			_oSkillImageImage.SetNativeSize();
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
