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
public class SawprogressViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oProgessBack;

	private Image _oProgessBackImage;

	private GameObject _oProgess;

	private Image _oProgessImage;

	private GameObject _oWait;

	private Image _oWaitImage;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/weapon";

	private string _resourceAssetName = "Sawprogress";

	public Sprite ProgessBackSprite
	{
		get
		{
			if (_oProgessBackImage != null)
			{
				return _oProgessBackImage.sprite;
			}
			return null;
		}
		set
		{
			if (ProgessBackSprite != value && _oProgessBackImage != null)
			{
				_oProgessBackImage.sprite = value;
			}
		}
	}

	public Sprite ProgessSprite
	{
		get
		{
			if (_oProgessImage != null)
			{
				return _oProgessImage.sprite;
			}
			return null;
		}
		set
		{
			if (ProgessSprite != value && _oProgessImage != null)
			{
				_oProgessImage.sprite = value;
			}
		}
	}

	public float ProgessFillamount
	{
		get
		{
			if (_oProgessImage != null)
			{
				return _oProgessImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ProgessFillamount != value && _oProgessImage != null)
			{
				_oProgessImage.fillAmount = value;
			}
		}
	}

	public bool WaitShow
	{
		get
		{
			if (_oWait != null)
			{
				return _oWait.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WaitShow != value && _oWait != null)
			{
				_oWait.SetObjectActive(value);
			}
		}
	}

	public Sprite WaitSprite
	{
		get
		{
			if (_oWaitImage != null)
			{
				return _oWaitImage.sprite;
			}
			return null;
		}
		set
		{
			if (WaitSprite != value && _oWaitImage != null)
			{
				_oWaitImage.sprite = value;
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
			case "ProgessBack":
				_oProgessBack = transform.gameObject;
				_oProgessBackImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Progess":
				_oProgess = transform.gameObject;
				_oProgessImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Wait":
				_oWait = transform.gameObject;
				_oWaitImage = transform.gameObject.GetComponent<Image>();
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
