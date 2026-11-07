using System;
using System.Collections.Generic;
using Assets.Res.Assets.Scripts.Refrenceless;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Weapon;

[GameUiTest]
public class BowprogressViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oProgressBack;

	private RectTransform _oProgressBackRectTransform;

	private Image _oProgressBackImage;

	private GameObject _oProgress;

	private RectTransform _oProgressRectTransform;

	private Image _oProgressImage;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/weapon";

	private string _resourceAssetName = "Bowprogress";

	public GameObject ViewGameObject => _viewGameObject;

	public bool ViewGameObjectShow
	{
		get
		{
			if (_viewGameObject != null)
			{
				return _viewGameObject.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ViewGameObjectShow != value && _viewGameObject != null)
			{
				_viewGameObject.SetObjectActive(value);
			}
		}
	}

	public bool ShowShow
	{
		get
		{
			if (_oShow != null)
			{
				return _oShow.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ShowShow != value && _oShow != null)
			{
				_oShow.SetObjectActive(value);
			}
		}
	}

	public Vector3 ProgressBackPosition
	{
		get
		{
			if (_oProgressBackRectTransform != null)
			{
				return _oProgressBackRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (ProgressBackPosition != value && _oProgressBackRectTransform != null)
			{
				_oProgressBackRectTransform.localPosition = value;
			}
		}
	}

	public Sprite ProgressBackSprite
	{
		get
		{
			if (_oProgressBackImage != null)
			{
				return _oProgressBackImage.sprite;
			}
			return null;
		}
		set
		{
			if (ProgressBackSprite != value && _oProgressBackImage != null)
			{
				_oProgressBackImage.sprite = value;
			}
		}
	}

	public Image ProgressBackImage
	{
		get
		{
			if (_oProgressBackImage != null)
			{
				return _oProgressBackImage;
			}
			return null;
		}
		set
		{
			if (ProgressBackImage != value && _oProgressBackImage != null)
			{
				_oProgressBackImage = value;
			}
		}
	}

	public Vector3 ProgressPosition
	{
		get
		{
			if (_oProgressRectTransform != null)
			{
				return _oProgressRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (ProgressPosition != value && _oProgressRectTransform != null)
			{
				_oProgressRectTransform.localPosition = value;
			}
		}
	}

	public Sprite ProgressSprite
	{
		get
		{
			if (_oProgressImage != null)
			{
				return _oProgressImage.sprite;
			}
			return null;
		}
		set
		{
			if (ProgressSprite != value && _oProgressImage != null)
			{
				_oProgressImage.sprite = value;
			}
		}
	}

	public float ProgressFillamount
	{
		get
		{
			if (_oProgressImage != null)
			{
				return _oProgressImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ProgressFillamount != value && _oProgressImage != null)
			{
				_oProgressImage.fillAmount = value;
			}
		}
	}

	public Image ProgressImage
	{
		get
		{
			if (_oProgressImage != null)
			{
				return _oProgressImage;
			}
			return null;
		}
		set
		{
			if (ProgressImage != value && _oProgressImage != null)
			{
				_oProgressImage = value;
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
			case "Show":
				_oShow = transform.gameObject;
				break;
			case "ProgressBack":
				_oProgressBack = transform.gameObject;
				_oProgressBackRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oProgressBackImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Progress":
				_oProgress = transform.gameObject;
				_oProgressRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oProgressImage = transform.gameObject.GetComponent<Image>();
				break;
			}
		}
	}

	public void LoadRefrenceless(IUiResourcesLoader loader)
	{
		if (_refrencelessLoaded)
		{
			return;
		}
		_refrencelessLoaded = true;
		RefrencelessHelper component = _viewGameObject.GetComponent<RefrencelessHelper>();
		if (!(component != null))
		{
			return;
		}
		for (int i = 0; i < component.SpritePaths.Count; i++)
		{
			try
			{
				if (i < component.AutoLoad.Count && !component.AutoLoad[i])
				{
					continue;
				}
				string[] array = component.SpritePaths[i].Split(':');
				Image image = component.transform.Find(component.Images[i]).GetComponent<Image>();
				if (!string.IsNullOrEmpty(array[0]))
				{
					loader.RetriveSprite(array[0], array[1], delegate(Sprite sprite)
					{
						image.sprite = sprite;
					});
				}
			}
			catch (Exception message)
			{
				Debug.LogError(message);
			}
		}
	}

	public void ProgressBackNtvsize()
	{
		if (_oProgressBackImage != null)
		{
			_oProgressBackImage.SetNativeSize();
		}
	}

	public void ProgressNtvsize()
	{
		if (_oProgressImage != null)
		{
			_oProgressImage.SetNativeSize();
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
			UnityEngine.Object.Destroy(_viewGameObject);
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
