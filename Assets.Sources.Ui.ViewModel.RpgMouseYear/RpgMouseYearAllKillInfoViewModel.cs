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

namespace Assets.Sources.Ui.ViewModel.RpgMouseYear;

[GameUiTest]
public class RpgMouseYearAllKillInfoViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oRpgMouseYearAllKillInfo;

	private GameObject _oShow;

	private GameObject _oBack;

	private GameObject _oRoomName;

	private Text _oRoomNameText;

	private GameObject _oPlayerCount;

	private Text _oPlayerCountText;

	private GameObject _oTeamGrid;

	private GameObject _oTitle;

	private Image _oTitleImage;

	private GameObject _oResult;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/rpgmouseyear";

	private string _resourceAssetName = "RpgMouseYearAllKillInfo";

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

	public bool RpgMouseYearAllKillInfoShow
	{
		get
		{
			if (_oRpgMouseYearAllKillInfo != null)
			{
				return _oRpgMouseYearAllKillInfo.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RpgMouseYearAllKillInfoShow != value && _oRpgMouseYearAllKillInfo != null)
			{
				_oRpgMouseYearAllKillInfo.SetObjectActive(value);
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

	public bool BackShow
	{
		get
		{
			if (_oBack != null)
			{
				return _oBack.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BackShow != value && _oBack != null)
			{
				_oBack.SetObjectActive(value);
			}
		}
	}

	public string RoomNameString
	{
		get
		{
			if (_oRoomNameText != null)
			{
				return _oRoomNameText.text;
			}
			return null;
		}
		set
		{
			if (RoomNameString != value && _oRoomNameText != null)
			{
				_oRoomNameText.text = value;
			}
		}
	}

	public string PlayerCountString
	{
		get
		{
			if (_oPlayerCountText != null)
			{
				return _oPlayerCountText.text;
			}
			return null;
		}
		set
		{
			if (PlayerCountString != value && _oPlayerCountText != null)
			{
				_oPlayerCountText.text = value;
			}
		}
	}

	public GameObject TeamGridObj => _oTeamGrid;

	public Sprite TitleSprite
	{
		get
		{
			if (_oTitleImage != null)
			{
				return _oTitleImage.sprite;
			}
			return null;
		}
		set
		{
			if (TitleSprite != value && _oTitleImage != null)
			{
				_oTitleImage.sprite = value;
			}
		}
	}

	public bool ResultShow
	{
		get
		{
			if (_oResult != null)
			{
				return _oResult.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ResultShow != value && _oResult != null)
			{
				_oResult.SetObjectActive(value);
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
			case "RpgMouseYearAllKillInfo":
				_oRpgMouseYearAllKillInfo = transform.gameObject;
				break;
			case "Show":
				_oShow = transform.gameObject;
				break;
			case "Back":
				_oBack = transform.gameObject;
				break;
			case "RoomName":
				_oRoomName = transform.gameObject;
				_oRoomNameText = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerCount":
				_oPlayerCount = transform.gameObject;
				_oPlayerCountText = transform.gameObject.GetComponent<Text>();
				break;
			case "TeamGrid":
				_oTeamGrid = transform.gameObject;
				break;
			case "Title":
				_oTitle = transform.gameObject;
				_oTitleImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Result":
				_oResult = transform.gameObject;
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
		return null;
	}
}
