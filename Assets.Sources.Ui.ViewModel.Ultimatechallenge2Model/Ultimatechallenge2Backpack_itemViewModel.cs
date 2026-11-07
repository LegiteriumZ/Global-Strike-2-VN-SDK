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

namespace Assets.Sources.Ui.ViewModel.Ultimatechallenge2Model;

[GameUiTest]
public class Ultimatechallenge2Backpack_itemViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oUltimatechallenge2Backpack_item;

	private GameObject _oImage;

	private Image _oImageImage;

	private GameObject _oName;

	private Text _oNameText;

	private GameObject _oText;

	private Text _oTextText;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/ultimatechallenge2model";

	private string _resourceAssetName = "ultimatechallenge2backpack_item";

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

	public GameObject Ultimatechallenge2Backpack_itemObj => _oUltimatechallenge2Backpack_item;

	public bool Ultimatechallenge2Backpack_itemShow
	{
		get
		{
			if (_oUltimatechallenge2Backpack_item != null)
			{
				return _oUltimatechallenge2Backpack_item.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (Ultimatechallenge2Backpack_itemShow != value && _oUltimatechallenge2Backpack_item != null)
			{
				_oUltimatechallenge2Backpack_item.SetObjectActive(value);
			}
		}
	}

	public Sprite ImageSprite
	{
		get
		{
			if (_oImageImage != null)
			{
				return _oImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (ImageSprite != value && _oImageImage != null)
			{
				_oImageImage.sprite = value;
			}
		}
	}

	public string NameString
	{
		get
		{
			if (_oNameText != null)
			{
				return _oNameText.text;
			}
			return null;
		}
		set
		{
			if (NameString != value && _oNameText != null)
			{
				_oNameText.text = value;
			}
		}
	}

	public string TextString
	{
		get
		{
			if (_oTextText != null)
			{
				return _oTextText.text;
			}
			return null;
		}
		set
		{
			if (TextString != value && _oTextText != null)
			{
				_oTextText.text = value;
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
			case "Ultimatechallenge2Backpack_item":
				_oUltimatechallenge2Backpack_item = transform.gameObject;
				break;
			case "Image":
				_oImage = transform.gameObject;
				_oImageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Name":
				_oName = transform.gameObject;
				_oNameText = transform.gameObject.GetComponent<Text>();
				break;
			case "Text":
				_oText = transform.gameObject;
				_oTextText = transform.gameObject.GetComponent<Text>();
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
