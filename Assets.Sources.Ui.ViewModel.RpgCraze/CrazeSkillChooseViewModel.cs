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

namespace Assets.Sources.Ui.ViewModel.RpgCraze;

[GameUiTest]
public class CrazeSkillChooseViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oImageBG;

	private GameObject _oDes1;

	private GameObject _oDes2;

	private GameObject _oDes3;

	private Text _oDesText1;

	private Text _oDesText2;

	private Text _oDesText3;

	private GameObject _oChoose1;

	private GameObject _oChoose2;

	private GameObject _oChoose3;

	private EventTrigger _oChooseEventTrigger1;

	private EventTrigger _oChooseEventTrigger2;

	private EventTrigger _oChooseEventTrigger3;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/rpgcraze";

	private string _resourceAssetName = "CrazeSkillChoose";

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

	public bool ImageBGShow
	{
		get
		{
			if (_oImageBG != null)
			{
				return _oImageBG.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ImageBGShow != value && _oImageBG != null)
			{
				_oImageBG.SetObjectActive(value);
			}
		}
	}

	public bool DesShow1
	{
		get
		{
			if (_oDes1 != null)
			{
				return _oDes1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DesShow1 != value && _oDes1 != null)
			{
				_oDes1.SetObjectActive(value);
			}
		}
	}

	public bool DesShow2
	{
		get
		{
			if (_oDes2 != null)
			{
				return _oDes2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DesShow2 != value && _oDes2 != null)
			{
				_oDes2.SetObjectActive(value);
			}
		}
	}

	public bool DesShow3
	{
		get
		{
			if (_oDes3 != null)
			{
				return _oDes3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DesShow3 != value && _oDes3 != null)
			{
				_oDes3.SetObjectActive(value);
			}
		}
	}

	public string DesString1
	{
		get
		{
			if (_oDesText1 != null)
			{
				return _oDesText1.text;
			}
			return null;
		}
		set
		{
			if (DesString1 != value && _oDesText1 != null)
			{
				_oDesText1.text = value;
			}
		}
	}

	public string DesString2
	{
		get
		{
			if (_oDesText2 != null)
			{
				return _oDesText2.text;
			}
			return null;
		}
		set
		{
			if (DesString2 != value && _oDesText2 != null)
			{
				_oDesText2.text = value;
			}
		}
	}

	public string DesString3
	{
		get
		{
			if (_oDesText3 != null)
			{
				return _oDesText3.text;
			}
			return null;
		}
		set
		{
			if (DesString3 != value && _oDesText3 != null)
			{
				_oDesText3.text = value;
			}
		}
	}

	public bool ChooseShow1
	{
		get
		{
			if (_oChoose1 != null)
			{
				return _oChoose1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ChooseShow1 != value && _oChoose1 != null)
			{
				_oChoose1.SetObjectActive(value);
			}
		}
	}

	public bool ChooseShow2
	{
		get
		{
			if (_oChoose2 != null)
			{
				return _oChoose2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ChooseShow2 != value && _oChoose2 != null)
			{
				_oChoose2.SetObjectActive(value);
			}
		}
	}

	public bool ChooseShow3
	{
		get
		{
			if (_oChoose3 != null)
			{
				return _oChoose3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ChooseShow3 != value && _oChoose3 != null)
			{
				_oChoose3.SetObjectActive(value);
			}
		}
	}

	public List<EventTrigger.Entry> ChooseTriggers1
	{
		get
		{
			if (_oChooseEventTrigger1 != null)
			{
				return _oChooseEventTrigger1.triggers;
			}
			return null;
		}
		set
		{
			if (ChooseTriggers1 != value && _oChooseEventTrigger1 != null)
			{
				_oChooseEventTrigger1.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> ChooseTriggers2
	{
		get
		{
			if (_oChooseEventTrigger2 != null)
			{
				return _oChooseEventTrigger2.triggers;
			}
			return null;
		}
		set
		{
			if (ChooseTriggers2 != value && _oChooseEventTrigger2 != null)
			{
				_oChooseEventTrigger2.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> ChooseTriggers3
	{
		get
		{
			if (_oChooseEventTrigger3 != null)
			{
				return _oChooseEventTrigger3.triggers;
			}
			return null;
		}
		set
		{
			if (ChooseTriggers3 != value && _oChooseEventTrigger3 != null)
			{
				_oChooseEventTrigger3.triggers = value;
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
			case "ImageBG":
				_oImageBG = transform.gameObject;
				break;
			case "Des1":
				_oDes1 = transform.gameObject;
				_oDesText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "Des2":
				_oDes2 = transform.gameObject;
				_oDesText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "Des3":
				_oDes3 = transform.gameObject;
				_oDesText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "Choose1":
				_oChoose1 = transform.gameObject;
				_oChooseEventTrigger1 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "Choose2":
				_oChoose2 = transform.gameObject;
				_oChooseEventTrigger2 = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "Choose3":
				_oChoose3 = transform.gameObject;
				_oChooseEventTrigger3 = transform.gameObject.GetComponent<EventTrigger>();
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

	public bool GetDesShow(int index)
	{
		return index switch
		{
			1 => DesShow1, 
			2 => DesShow2, 
			3 => DesShow3, 
			_ => false, 
		};
	}

	public void SetDesShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			DesShow1 = value;
			break;
		case 2:
			DesShow2 = value;
			break;
		case 3:
			DesShow3 = value;
			break;
		}
	}

	public int GetDesCount()
	{
		return 3;
	}

	public string GetDesString(int index)
	{
		return index switch
		{
			1 => DesString1, 
			2 => DesString2, 
			3 => DesString3, 
			_ => null, 
		};
	}

	public void SetDesString(int index, string value)
	{
		switch (index)
		{
		case 1:
			DesString1 = value;
			break;
		case 2:
			DesString2 = value;
			break;
		case 3:
			DesString3 = value;
			break;
		}
	}

	public bool GetChooseShow(int index)
	{
		return index switch
		{
			1 => ChooseShow1, 
			2 => ChooseShow2, 
			3 => ChooseShow3, 
			_ => false, 
		};
	}

	public void SetChooseShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			ChooseShow1 = value;
			break;
		case 2:
			ChooseShow2 = value;
			break;
		case 3:
			ChooseShow3 = value;
			break;
		}
	}

	public int GetChooseCount()
	{
		return 3;
	}

	private void CreateChooseTriggers1Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(ChooseTriggers1, eventId, callback);
	}

	private void RemoveChooseTriggers1Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(ChooseTriggers1, eventId);
	}

	private void CreateChooseTriggers2Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(ChooseTriggers2, eventId, callback);
	}

	private void RemoveChooseTriggers2Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(ChooseTriggers2, eventId);
	}

	private void CreateChooseTriggers3Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(ChooseTriggers3, eventId, callback);
	}

	private void RemoveChooseTriggers3Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(ChooseTriggers3, eventId);
	}

	public List<EventTrigger.Entry> GetChooseTriggers(int index)
	{
		return index switch
		{
			1 => ChooseTriggers1, 
			2 => ChooseTriggers2, 
			3 => ChooseTriggers3, 
			_ => null, 
		};
	}

	public void SetChooseTriggers(int index, List<EventTrigger.Entry> value)
	{
		switch (index)
		{
		case 1:
			ChooseTriggers1 = value;
			break;
		case 2:
			ChooseTriggers2 = value;
			break;
		case 3:
			ChooseTriggers3 = value;
			break;
		}
	}

	private void CreateChooseTriggersEntry(int index, EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(GetChooseTriggers(index), eventId, callback);
	}

	private void RemoveChooseTriggersEntry(int index, EventTriggerType eventId)
	{
		RemoveTriggerEntry(GetChooseTriggers(index), eventId);
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
		if (_oDesText1 != null)
		{
			_holdPosTrans.Add(_oDesText1.GetComponent<RectTransform>());
		}
		if (_oDesText2 != null)
		{
			_holdPosTrans.Add(_oDesText2.GetComponent<RectTransform>());
		}
		if (_oDesText3 != null)
		{
			_holdPosTrans.Add(_oDesText3.GetComponent<RectTransform>());
		}
		return _holdPosTrans;
	}
}
