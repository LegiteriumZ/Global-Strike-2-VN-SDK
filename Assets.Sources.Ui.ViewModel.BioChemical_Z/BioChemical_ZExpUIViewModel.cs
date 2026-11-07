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

namespace Assets.Sources.Ui.ViewModel.BioChemical_Z;

[GameUiTest]
public class BioChemical_ZExpUIViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oexp;

	private Image _oexpImage;

	private GameObject _oys;

	private Text _oysText;

	private GameObject _oty;

	private Text _otyText;

	private GameObject _osh;

	private Text _oshText;

	private GameObject _oskillIcon;

	private Image _oskillIconImage;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/biochemical_z";

	private string _resourceAssetName = "biochemical_zexpui";

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

	public float expFillamount
	{
		get
		{
			if (_oexpImage != null)
			{
				return _oexpImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (expFillamount != value && _oexpImage != null)
			{
				_oexpImage.fillAmount = value;
			}
		}
	}

	public string ysString
	{
		get
		{
			if (_oysText != null)
			{
				return _oysText.text;
			}
			return null;
		}
		set
		{
			if (ysString != value && _oysText != null)
			{
				_oysText.text = value;
			}
		}
	}

	public string tyString
	{
		get
		{
			if (_otyText != null)
			{
				return _otyText.text;
			}
			return null;
		}
		set
		{
			if (tyString != value && _otyText != null)
			{
				_otyText.text = value;
			}
		}
	}

	public string shString
	{
		get
		{
			if (_oshText != null)
			{
				return _oshText.text;
			}
			return null;
		}
		set
		{
			if (shString != value && _oshText != null)
			{
				_oshText.text = value;
			}
		}
	}

	public bool skillIconShow
	{
		get
		{
			if (_oskillIcon != null)
			{
				return _oskillIcon.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillIconShow != value && _oskillIcon != null)
			{
				_oskillIcon.SetObjectActive(value);
			}
		}
	}

	public Sprite skillIconSprite
	{
		get
		{
			if (_oskillIconImage != null)
			{
				return _oskillIconImage.sprite;
			}
			return null;
		}
		set
		{
			if (skillIconSprite != value && _oskillIconImage != null)
			{
				_oskillIconImage.sprite = value;
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
			case "exp":
				_oexp = transform.gameObject;
				_oexpImage = transform.gameObject.GetComponent<Image>();
				break;
			case "ys":
				_oys = transform.gameObject;
				_oysText = transform.gameObject.GetComponent<Text>();
				break;
			case "ty":
				_oty = transform.gameObject;
				_otyText = transform.gameObject.GetComponent<Text>();
				break;
			case "sh":
				_osh = transform.gameObject;
				_oshText = transform.gameObject.GetComponent<Text>();
				break;
			case "skillIcon":
				_oskillIcon = transform.gameObject;
				_oskillIconImage = transform.gameObject.GetComponent<Image>();
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
