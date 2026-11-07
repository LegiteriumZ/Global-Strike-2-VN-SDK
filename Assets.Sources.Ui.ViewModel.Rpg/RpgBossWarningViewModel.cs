using System;
using System.Collections.Generic;
using Assets.Res.Assets.Scripts.Refrenceless;
using Assets.Sources.Ui.DynamicLoader;
using Assets.Sources.Utils.Ui;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using SSJJBase.Extensions;
using SSJJBase.Manager;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Rpg;

[GameUiTest]
public class RpgBossWarningViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oPanel;

	private GameObject _oDown2;

	private GameObject _oUp2;

	private GameObject _oWarnning;

	private CanvasGroup _oWarnningCanvasGroup;

	private GameObject _viewGameObject;

	private UiReferences uiRef;

	private bool _refrencelessLoaded;

	public const string Down2Name = "Down2";

	public const string Up2Name = "Up2";

	private string _resourceBundleName = "uiprefabs/rpg";

	private string _resourceAssetName = "rpgbosswarning";

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

	public UiReferences UI => uiRef;

	public GameObject PanelObj => _oPanel;

	public bool PanelRootshow
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
			if (PanelRootshow == value || !(_oPanel != null))
			{
				return;
			}
			if (value)
			{
				BattleSingletonInstance<UiDynamicLoadManager>.Instance.Register(_resourceAssetName, delegate
				{
					_oPanel.SetObjectActive(value);
				});
			}
			else
			{
				BattleSingletonInstance<UiDynamicLoadManager>.Instance.UnRegister(_resourceAssetName);
				_oPanel.SetObjectActive(value);
			}
		}
	}

	public bool DownShow2
	{
		get
		{
			if (_oDown2 != null)
			{
				return _oDown2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DownShow2 != value && _oDown2 != null)
			{
				_oDown2.SetObjectActive(value);
			}
		}
	}

	public bool UpShow2
	{
		get
		{
			if (_oUp2 != null)
			{
				return _oUp2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (UpShow2 != value && _oUp2 != null)
			{
				_oUp2.SetObjectActive(value);
			}
		}
	}

	public float WarnningAlpha
	{
		get
		{
			if (_oWarnningCanvasGroup != null)
			{
				return _oWarnningCanvasGroup.alpha;
			}
			return 0f;
		}
		set
		{
			if (WarnningAlpha != value && _oWarnningCanvasGroup != null)
			{
				_oWarnningCanvasGroup.alpha = value;
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
		uiRef = instance.TryAddComponent<UiReferences>();
		Transform[] componentsInChildren = instance.GetComponentsInChildren<Transform>(includeInactive: true);
		foreach (Transform transform in componentsInChildren)
		{
			switch (transform.name.Replace("(Clone)", ""))
			{
			case "Panel":
				_oPanel = transform.gameObject;
				uiRef.Set("Panel", _oPanel.transform);
				break;
			case "Down2":
				_oDown2 = transform.gameObject;
				uiRef.Set("Down2", _oDown2.transform);
				break;
			case "Up2":
				_oUp2 = transform.gameObject;
				uiRef.Set("Up2", _oUp2.transform);
				break;
			case "Warnning":
				_oWarnning = transform.gameObject;
				uiRef.Set("Warnning", _oWarnning.transform);
				_oWarnningCanvasGroup = transform.gameObject.GetComponent<CanvasGroup>();
				uiRef.Set("WarnningCanvasGroup", _oWarnningCanvasGroup);
				break;
			}
		}
		BattleSingletonInstance<UiDynamicLoadManager>.Instance.InitDynLoader(_resourceAssetName, instance.transform);
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

	public string GetDownName(int index)
	{
		if (index == 2)
		{
			return "Down2";
		}
		return null;
	}

	public int GetDownCount()
	{
		return 2;
	}

	public bool GetDownShow(int index)
	{
		if (index == 2)
		{
			return DownShow2;
		}
		return false;
	}

	public void SetDownShow(int index, bool value)
	{
		if (index == 2)
		{
			DownShow2 = value;
		}
	}

	public string GetUpName(int index)
	{
		if (index == 2)
		{
			return "Up2";
		}
		return null;
	}

	public int GetUpCount()
	{
		return 2;
	}

	public bool GetUpShow(int index)
	{
		if (index == 2)
		{
			return UpShow2;
		}
		return false;
	}

	public void SetUpShow(int index, bool value)
	{
		if (index == 2)
		{
			UpShow2 = value;
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
