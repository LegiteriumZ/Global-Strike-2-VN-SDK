using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.BigHead;

[GameUiTest]
public class BigheadmessageViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oMessageImage;

	private Image _oMessageImageImage;

	private GameObject _oBigheadMessageImage;

	private Image _oBigheadMessageImageImage;

	private GameObject _oChangeHeroImage;

	private GameObject _oHaveBigheadImage;

	private GameObject _oHaveBigheadText;

	private Text _oHaveBigheadTextText;

	private GameObject _oMaxHeroText;

	private Text _oMaxHeroTextText;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/bighead";

	private string _resourceAssetName = "Bigheadmessage";

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

	public bool BigheadMessageImageShow
	{
		get
		{
			if (_oBigheadMessageImage != null)
			{
				return _oBigheadMessageImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BigheadMessageImageShow != value && _oBigheadMessageImage != null)
			{
				_oBigheadMessageImage.SetObjectActive(value);
			}
		}
	}

	public Sprite BigheadMessageImageSprite
	{
		get
		{
			if (_oBigheadMessageImageImage != null)
			{
				return _oBigheadMessageImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (BigheadMessageImageSprite != value && _oBigheadMessageImageImage != null)
			{
				_oBigheadMessageImageImage.sprite = value;
			}
		}
	}

	public bool ChangeHeroImageShow
	{
		get
		{
			if (_oChangeHeroImage != null)
			{
				return _oChangeHeroImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ChangeHeroImageShow != value && _oChangeHeroImage != null)
			{
				_oChangeHeroImage.SetObjectActive(value);
			}
		}
	}

	public bool HaveBigheadImageShow
	{
		get
		{
			if (_oHaveBigheadImage != null)
			{
				return _oHaveBigheadImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (HaveBigheadImageShow != value && _oHaveBigheadImage != null)
			{
				_oHaveBigheadImage.SetObjectActive(value);
			}
		}
	}

	public string HaveBigheadTextString
	{
		get
		{
			if (_oHaveBigheadTextText != null)
			{
				return _oHaveBigheadTextText.text;
			}
			return null;
		}
		set
		{
			if (HaveBigheadTextString != value && _oHaveBigheadTextText != null)
			{
				_oHaveBigheadTextText.text = value;
			}
		}
	}

	public string MaxHeroTextString
	{
		get
		{
			if (_oMaxHeroTextText != null)
			{
				return _oMaxHeroTextText.text;
			}
			return null;
		}
		set
		{
			if (MaxHeroTextString != value && _oMaxHeroTextText != null)
			{
				_oMaxHeroTextText.text = value;
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
			case "BigheadMessageImage":
				_oBigheadMessageImage = transform.gameObject;
				_oBigheadMessageImageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "ChangeHeroImage":
				_oChangeHeroImage = transform.gameObject;
				break;
			case "HaveBigheadImage":
				_oHaveBigheadImage = transform.gameObject;
				break;
			case "HaveBigheadText":
				_oHaveBigheadText = transform.gameObject;
				_oHaveBigheadTextText = transform.gameObject.GetComponent<Text>();
				break;
			case "MaxHeroText":
				_oMaxHeroText = transform.gameObject;
				_oMaxHeroTextText = transform.gameObject.GetComponent<Text>();
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

	public void BigheadMessageImageNtvsize()
	{
		if (_oBigheadMessageImageImage != null)
		{
			_oBigheadMessageImageImage.SetNativeSize();
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
