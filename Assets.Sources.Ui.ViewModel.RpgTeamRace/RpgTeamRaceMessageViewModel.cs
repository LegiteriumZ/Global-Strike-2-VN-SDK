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

namespace Assets.Sources.Ui.ViewModel.RpgTeamRace;

[GameUiTest]
public class RpgTeamRaceMessageViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oRpgTeamRaceMessage;

	private GameObject _oShow;

	private GameObject _oBlueAllBeKilled;

	private GameObject _oBlueAllRevive;

	private GameObject _oRedAllBeKilled;

	private GameObject _oRedAllRevive;

	private GameObject _oYellowAllBeKilled;

	private GameObject _oYellowAllRevive;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/rpgteamrace";

	private string _resourceAssetName = "RpgTeamRaceMessage";

	private List<RectTransform> _holdPosTrans;

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

	public bool RpgTeamRaceMessageShow
	{
		get
		{
			if (_oRpgTeamRaceMessage != null)
			{
				return _oRpgTeamRaceMessage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RpgTeamRaceMessageShow != value && _oRpgTeamRaceMessage != null)
			{
				_oRpgTeamRaceMessage.SetObjectActive(value);
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

	public bool BlueAllBeKilledShow
	{
		get
		{
			if (_oBlueAllBeKilled != null)
			{
				return _oBlueAllBeKilled.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BlueAllBeKilledShow != value && _oBlueAllBeKilled != null)
			{
				_oBlueAllBeKilled.SetObjectActive(value);
			}
		}
	}

	public bool BlueAllReviveShow
	{
		get
		{
			if (_oBlueAllRevive != null)
			{
				return _oBlueAllRevive.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BlueAllReviveShow != value && _oBlueAllRevive != null)
			{
				_oBlueAllRevive.SetObjectActive(value);
			}
		}
	}

	public bool RedAllBeKilledShow
	{
		get
		{
			if (_oRedAllBeKilled != null)
			{
				return _oRedAllBeKilled.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RedAllBeKilledShow != value && _oRedAllBeKilled != null)
			{
				_oRedAllBeKilled.SetObjectActive(value);
			}
		}
	}

	public bool RedAllReviveShow
	{
		get
		{
			if (_oRedAllRevive != null)
			{
				return _oRedAllRevive.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RedAllReviveShow != value && _oRedAllRevive != null)
			{
				_oRedAllRevive.SetObjectActive(value);
			}
		}
	}

	public bool YellowAllBeKilledShow
	{
		get
		{
			if (_oYellowAllBeKilled != null)
			{
				return _oYellowAllBeKilled.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (YellowAllBeKilledShow != value && _oYellowAllBeKilled != null)
			{
				_oYellowAllBeKilled.SetObjectActive(value);
			}
		}
	}

	public bool YellowAllReviveShow
	{
		get
		{
			if (_oYellowAllRevive != null)
			{
				return _oYellowAllRevive.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (YellowAllReviveShow != value && _oYellowAllRevive != null)
			{
				_oYellowAllRevive.SetObjectActive(value);
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
			case "RpgTeamRaceMessage":
				_oRpgTeamRaceMessage = transform.gameObject;
				break;
			case "Show":
				_oShow = transform.gameObject;
				break;
			case "BlueAllBeKilled":
				_oBlueAllBeKilled = transform.gameObject;
				break;
			case "BlueAllRevive":
				_oBlueAllRevive = transform.gameObject;
				break;
			case "RedAllBeKilled":
				_oRedAllBeKilled = transform.gameObject;
				break;
			case "RedAllRevive":
				_oRedAllRevive = transform.gameObject;
				break;
			case "YellowAllBeKilled":
				_oYellowAllBeKilled = transform.gameObject;
				break;
			case "YellowAllRevive":
				_oYellowAllRevive = transform.gameObject;
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

	public List<RectTransform> GetHoldPosIntergeTrans()
	{
		if (_holdPosTrans != null)
		{
			return _holdPosTrans;
		}
		_holdPosTrans = new List<RectTransform>();
		return _holdPosTrans;
	}
}
