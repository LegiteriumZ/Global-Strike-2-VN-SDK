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

namespace Assets.Sources.Ui.ViewModel.HulaoguanModel;

[GameUiTest]
public class HuLaoGuanNewYearMessageViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oPanel;

	private GameObject _oboss1;

	private GameObject _oboss2;

	private GameObject _oboss3;

	private GameObject _ofht;

	private GameObject _omsg;

	private GameObject _oft;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/hulaoguanmodel";

	private string _resourceAssetName = "hulaoguannewyearmessage";

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

	public bool PanelShow
	{
		get
		{
			if (_oPanel != null)
			{
				return _oPanel.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PanelShow != value && _oPanel != null)
			{
				_oPanel.SetObjectActive(value);
			}
		}
	}

	public bool bossShow1
	{
		get
		{
			if (_oboss1 != null)
			{
				return _oboss1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (bossShow1 != value && _oboss1 != null)
			{
				_oboss1.SetObjectActive(value);
			}
		}
	}

	public bool bossShow2
	{
		get
		{
			if (_oboss2 != null)
			{
				return _oboss2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (bossShow2 != value && _oboss2 != null)
			{
				_oboss2.SetObjectActive(value);
			}
		}
	}

	public bool bossShow3
	{
		get
		{
			if (_oboss3 != null)
			{
				return _oboss3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (bossShow3 != value && _oboss3 != null)
			{
				_oboss3.SetObjectActive(value);
			}
		}
	}

	public bool fhtShow
	{
		get
		{
			if (_ofht != null)
			{
				return _ofht.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (fhtShow != value && _ofht != null)
			{
				_ofht.SetObjectActive(value);
			}
		}
	}

	public bool msgShow
	{
		get
		{
			if (_omsg != null)
			{
				return _omsg.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (msgShow != value && _omsg != null)
			{
				_omsg.SetObjectActive(value);
			}
		}
	}

	public bool ftShow
	{
		get
		{
			if (_oft != null)
			{
				return _oft.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ftShow != value && _oft != null)
			{
				_oft.SetObjectActive(value);
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
			case "Panel":
				_oPanel = transform.gameObject;
				break;
			case "boss1":
				_oboss1 = transform.gameObject;
				break;
			case "boss2":
				_oboss2 = transform.gameObject;
				break;
			case "boss3":
				_oboss3 = transform.gameObject;
				break;
			case "fht":
				_ofht = transform.gameObject;
				break;
			case "msg":
				_omsg = transform.gameObject;
				break;
			case "ft":
				_oft = transform.gameObject;
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

	public bool GetbossShow(int index)
	{
		return index switch
		{
			1 => bossShow1, 
			2 => bossShow2, 
			3 => bossShow3, 
			_ => false, 
		};
	}

	public void SetbossShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			bossShow1 = value;
			break;
		case 2:
			bossShow2 = value;
			break;
		case 3:
			bossShow3 = value;
			break;
		}
	}

	public int GetbossCount()
	{
		return 3;
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
