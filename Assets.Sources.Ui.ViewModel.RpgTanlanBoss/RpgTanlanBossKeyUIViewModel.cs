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

namespace Assets.Sources.Ui.ViewModel.RpgTanlanBoss;

[GameUiTest]
public class RpgTanlanBossKeyUIViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oitemContainer;

	private RectTransform _oitemContainerRectTransform;

	private GameObject _oitem0;

	private RectTransform _oitemRectTransform0;

	private GameObject _oimgProgress;

	private Image _oimgProgressImage;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/rpgtanlanboss";

	private string _resourceAssetName = "rpgtanlanbosskeyui";

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

	public GameObject itemContainerObj => _oitemContainer;

	public Vector3 itemContainerSize
	{
		get
		{
			if (_oitemContainerRectTransform != null)
			{
				return _oitemContainerRectTransform.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (itemContainerSize != value && _oitemContainerRectTransform != null)
			{
				_oitemContainerRectTransform.sizeDelta = value;
			}
		}
	}

	public Vector3 itemSize0
	{
		get
		{
			if (_oitemRectTransform0 != null)
			{
				return _oitemRectTransform0.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (itemSize0 != value && _oitemRectTransform0 != null)
			{
				_oitemRectTransform0.sizeDelta = value;
			}
		}
	}

	public float imgProgressFillamount
	{
		get
		{
			if (_oimgProgressImage != null)
			{
				return _oimgProgressImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (imgProgressFillamount != value && _oimgProgressImage != null)
			{
				_oimgProgressImage.fillAmount = value;
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
			case "itemContainer":
				_oitemContainer = transform.gameObject;
				_oitemContainerRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "item0":
				_oitem0 = transform.gameObject;
				_oitemRectTransform0 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "imgProgress":
				_oimgProgress = transform.gameObject;
				_oimgProgressImage = transform.gameObject.GetComponent<Image>();
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

	public Vector3 GetitemSize(int index)
	{
		if (index == 0)
		{
			return itemSize0;
		}
		return Vector3.zero;
	}

	public void SetitemSize(int index, Vector3 value)
	{
		if (index == 0)
		{
			itemSize0 = value;
		}
	}

	public int GetitemCount()
	{
		return 0;
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

	public void RemoveTriggerEntry(List<EventTrigger.Entry> triggers, EventTriggerType eventId)
	{
		foreach (EventTrigger.Entry trigger in triggers)
		{
			if (trigger.eventID == eventId)
			{
				triggers.Remove(trigger);
				break;
			}
		}
	}
}
