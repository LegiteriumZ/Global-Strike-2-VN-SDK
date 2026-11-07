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
public class BioChemical_ZSkillDesViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oSkillDes;

	private Image _oSkillDesImage;

	private GameObject _oImage;

	private Image _oImageImage;

	private GameObject _oIocnBG;

	private Image _oIocnBGImage;

	private GameObject _oIocn;

	private Image _oIocnImage;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/biochemical_z";

	private string _resourceAssetName = "biochemical_zskilldes";

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

	public bool SkillDesShow
	{
		get
		{
			if (_oSkillDes != null)
			{
				return _oSkillDes.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillDesShow != value && _oSkillDes != null)
			{
				_oSkillDes.SetObjectActive(value);
			}
		}
	}

	public Sprite SkillDesSprite
	{
		get
		{
			if (_oSkillDesImage != null)
			{
				return _oSkillDesImage.sprite;
			}
			return null;
		}
		set
		{
			if (SkillDesSprite != value && _oSkillDesImage != null)
			{
				_oSkillDesImage.sprite = value;
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

	public Sprite IocnBGSprite
	{
		get
		{
			if (_oIocnBGImage != null)
			{
				return _oIocnBGImage.sprite;
			}
			return null;
		}
		set
		{
			if (IocnBGSprite != value && _oIocnBGImage != null)
			{
				_oIocnBGImage.sprite = value;
			}
		}
	}

	public Sprite IocnSprite
	{
		get
		{
			if (_oIocnImage != null)
			{
				return _oIocnImage.sprite;
			}
			return null;
		}
		set
		{
			if (IocnSprite != value && _oIocnImage != null)
			{
				_oIocnImage.sprite = value;
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
			case "SkillDes":
				_oSkillDes = transform.gameObject;
				_oSkillDesImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Image":
				_oImage = transform.gameObject;
				_oImageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "IocnBG":
				_oIocnBG = transform.gameObject;
				_oIocnBGImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Iocn":
				_oIocn = transform.gameObject;
				_oIocnImage = transform.gameObject.GetComponent<Image>();
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
