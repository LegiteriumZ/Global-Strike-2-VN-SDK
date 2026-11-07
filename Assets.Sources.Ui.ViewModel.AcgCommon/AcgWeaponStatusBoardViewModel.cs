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

namespace Assets.Sources.Ui.ViewModel.AcgCommon;

[GameUiTest]
public class AcgWeaponStatusBoardViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oWeaponIcon;

	private Image _oWeaponIconImage;

	private GameObject _oCurrentClip;

	private Text _oCurrentClipText;

	private GameObject _oBackClip;

	private Text _oBackClipText;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/acgcommon";

	private string _resourceAssetName = "acgweaponstatusboard";

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

	public Image WeaponIconImage
	{
		get
		{
			if (_oWeaponIconImage != null)
			{
				return _oWeaponIconImage;
			}
			return null;
		}
		set
		{
			if (WeaponIconImage != value && _oWeaponIconImage != null)
			{
				_oWeaponIconImage = value;
			}
		}
	}

	public string CurrentClipString
	{
		get
		{
			if (_oCurrentClipText != null)
			{
				return _oCurrentClipText.text;
			}
			return null;
		}
		set
		{
			if (CurrentClipString != value && _oCurrentClipText != null)
			{
				_oCurrentClipText.text = value;
			}
		}
	}

	public Color CurrentClipTextcolor
	{
		get
		{
			if (_oCurrentClipText != null)
			{
				return _oCurrentClipText.color;
			}
			return Color.white;
		}
		set
		{
			if (CurrentClipTextcolor != value && _oCurrentClipText != null)
			{
				_oCurrentClipText.color = value;
			}
		}
	}

	public string BackClipString
	{
		get
		{
			if (_oBackClipText != null)
			{
				return _oBackClipText.text;
			}
			return null;
		}
		set
		{
			if (BackClipString != value && _oBackClipText != null)
			{
				_oBackClipText.text = value;
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
			case "WeaponIcon":
				_oWeaponIcon = transform.gameObject;
				_oWeaponIconImage = transform.gameObject.GetComponent<Image>();
				break;
			case "CurrentClip":
				_oCurrentClip = transform.gameObject;
				_oCurrentClipText = transform.gameObject.GetComponent<Text>();
				break;
			case "BackClip":
				_oBackClip = transform.gameObject;
				_oBackClipText = transform.gameObject.GetComponent<Text>();
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
