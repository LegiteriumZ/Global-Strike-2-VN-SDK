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
public class BioUnionBasePlayerInfoViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oPIcon;

	private Image _oPIconImage;

	private GameObject _oHP;

	private Image _oHPImage;

	private GameObject _oHP_2;

	private Text _oHP_Text2;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/biounionbase";

	private string _resourceAssetName = "BioUnionBase_PlayerInfo";

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

	public Sprite PIconSprite
	{
		get
		{
			if (_oPIconImage != null)
			{
				return _oPIconImage.sprite;
			}
			return null;
		}
		set
		{
			if (PIconSprite != value && _oPIconImage != null)
			{
				_oPIconImage.sprite = value;
			}
		}
	}

	public float HPFillamount
	{
		get
		{
			if (_oHPImage != null)
			{
				return _oHPImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (HPFillamount != value && _oHPImage != null)
			{
				_oHPImage.fillAmount = value;
			}
		}
	}

	public string HP_String2
	{
		get
		{
			if (_oHP_Text2 != null)
			{
				return _oHP_Text2.text;
			}
			return null;
		}
		set
		{
			if (HP_String2 != value && _oHP_Text2 != null)
			{
				_oHP_Text2.text = value;
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
			case "PIcon":
				_oPIcon = transform.gameObject;
				_oPIconImage = transform.gameObject.GetComponent<Image>();
				break;
			case "HP":
				_oHP = transform.gameObject;
				_oHPImage = transform.gameObject.GetComponent<Image>();
				break;
			case "HP_2":
				_oHP_2 = transform.gameObject;
				_oHP_Text2 = transform.gameObject.GetComponent<Text>();
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

	public string GetHP_String(int index)
	{
		if (index == 2)
		{
			return HP_String2;
		}
		return null;
	}

	public void SetHP_String(int index, string value)
	{
		if (index == 2)
		{
			HP_String2 = value;
		}
	}

	public int GetHP_Count()
	{
		return 2;
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
