using System;
using System.Collections.Generic;
using Assets.Res.Assets.Scripts.Refrenceless;
using Assets.Sources.Ui.DynamicLoader;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using SSJJBase.Manager;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Common;

[GameUiTest]
public class AntiAddictionViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oTitle;

	private Text _oTitleText;

	private GameObject _oTitleContent;

	private Text _oTitleContentText;

	private GameObject _oTips;

	private Text _oTipsText;

	private GameObject _oTipsContent;

	private Text _oTipsContentText;

	private GameObject _oComfirm1;

	private GameObject _oComfirm2;

	private GameObject _oComfirm3;

	private RectTransform _oComfirmRectTransform1;

	private RectTransform _oComfirmRectTransform2;

	private RectTransform _oComfirmRectTransform3;

	private EventTrigger _oComfirmEventTrigger1;

	private EventTrigger _oComfirmEventTrigger2;

	private EventTrigger _oComfirmEventTrigger3;

	private Button _oComfirmButton1;

	private Button _oComfirmButton2;

	private Button _oComfirmButton3;

	private GameObject _ochattext1;

	private GameObject _ochattext2;

	private GameObject _ochattext3;

	private Text _ochattextText1;

	private Text _ochattextText2;

	private Text _ochattextText3;

	private GameObject _oClose;

	private EventTrigger _oCloseEventTrigger;

	private Button _oCloseButton;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/common";

	private string _resourceAssetName = "antiaddiction";

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

	public bool ShowRootshow
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
			if (ShowRootshow == value || !(_oShow != null))
			{
				return;
			}
			if (value)
			{
				BattleSingletonInstance<UiDynamicLoadManager>.Instance.Register(_resourceAssetName, delegate
				{
					_oShow.SetObjectActive(value);
				});
			}
			else
			{
				BattleSingletonInstance<UiDynamicLoadManager>.Instance.UnRegister(_resourceAssetName);
				_oShow.SetObjectActive(value);
			}
		}
	}

	public bool TitleShow
	{
		get
		{
			if (_oTitle != null)
			{
				return _oTitle.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TitleShow != value && _oTitle != null)
			{
				_oTitle.SetObjectActive(value);
			}
		}
	}

	public string TitleString
	{
		get
		{
			if (_oTitleText != null)
			{
				return _oTitleText.text;
			}
			return null;
		}
		set
		{
			if (TitleString != value && _oTitleText != null)
			{
				_oTitleText.text = value;
			}
		}
	}

	public bool TitleContentShow
	{
		get
		{
			if (_oTitleContent != null)
			{
				return _oTitleContent.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TitleContentShow != value && _oTitleContent != null)
			{
				_oTitleContent.SetObjectActive(value);
			}
		}
	}

	public string TitleContentString
	{
		get
		{
			if (_oTitleContentText != null)
			{
				return _oTitleContentText.text;
			}
			return null;
		}
		set
		{
			if (TitleContentString != value && _oTitleContentText != null)
			{
				_oTitleContentText.text = value;
			}
		}
	}

	public bool TipsShow
	{
		get
		{
			if (_oTips != null)
			{
				return _oTips.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TipsShow != value && _oTips != null)
			{
				_oTips.SetObjectActive(value);
			}
		}
	}

	public string TipsString
	{
		get
		{
			if (_oTipsText != null)
			{
				return _oTipsText.text;
			}
			return null;
		}
		set
		{
			if (TipsString != value && _oTipsText != null)
			{
				_oTipsText.text = value;
			}
		}
	}

	public bool TipsContentShow
	{
		get
		{
			if (_oTipsContent != null)
			{
				return _oTipsContent.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TipsContentShow != value && _oTipsContent != null)
			{
				_oTipsContent.SetObjectActive(value);
			}
		}
	}

	public string TipsContentString
	{
		get
		{
			if (_oTipsContentText != null)
			{
				return _oTipsContentText.text;
			}
			return null;
		}
		set
		{
			if (TipsContentString != value && _oTipsContentText != null)
			{
				_oTipsContentText.text = value;
			}
		}
	}

	public bool ComfirmShow1
	{
		get
		{
			if (_oComfirm1 != null)
			{
				return _oComfirm1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ComfirmShow1 != value && _oComfirm1 != null)
			{
				_oComfirm1.SetObjectActive(value);
			}
		}
	}

	public bool ComfirmShow2
	{
		get
		{
			if (_oComfirm2 != null)
			{
				return _oComfirm2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ComfirmShow2 != value && _oComfirm2 != null)
			{
				_oComfirm2.SetObjectActive(value);
			}
		}
	}

	public bool ComfirmShow3
	{
		get
		{
			if (_oComfirm3 != null)
			{
				return _oComfirm3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ComfirmShow3 != value && _oComfirm3 != null)
			{
				_oComfirm3.SetObjectActive(value);
			}
		}
	}

	public Vector3 ComfirmPosition1
	{
		get
		{
			if (_oComfirmRectTransform1 != null)
			{
				return _oComfirmRectTransform1.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (ComfirmPosition1 != value && _oComfirmRectTransform1 != null)
			{
				_oComfirmRectTransform1.localPosition = value;
			}
		}
	}

	public Vector3 ComfirmPosition2
	{
		get
		{
			if (_oComfirmRectTransform2 != null)
			{
				return _oComfirmRectTransform2.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (ComfirmPosition2 != value && _oComfirmRectTransform2 != null)
			{
				_oComfirmRectTransform2.localPosition = value;
			}
		}
	}

	public Vector3 ComfirmPosition3
	{
		get
		{
			if (_oComfirmRectTransform3 != null)
			{
				return _oComfirmRectTransform3.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (ComfirmPosition3 != value && _oComfirmRectTransform3 != null)
			{
				_oComfirmRectTransform3.localPosition = value;
			}
		}
	}

	public List<EventTrigger.Entry> ComfirmTriggers1
	{
		get
		{
			if (_oComfirmEventTrigger1 != null)
			{
				return _oComfirmEventTrigger1.triggers;
			}
			return null;
		}
		set
		{
			if (ComfirmTriggers1 != value && _oComfirmEventTrigger1 != null)
			{
				_oComfirmEventTrigger1.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> ComfirmTriggers2
	{
		get
		{
			if (_oComfirmEventTrigger2 != null)
			{
				return _oComfirmEventTrigger2.triggers;
			}
			return null;
		}
		set
		{
			if (ComfirmTriggers2 != value && _oComfirmEventTrigger2 != null)
			{
				_oComfirmEventTrigger2.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> ComfirmTriggers3
	{
		get
		{
			if (_oComfirmEventTrigger3 != null)
			{
				return _oComfirmEventTrigger3.triggers;
			}
			return null;
		}
		set
		{
			if (ComfirmTriggers3 != value && _oComfirmEventTrigger3 != null)
			{
				_oComfirmEventTrigger3.triggers = value;
			}
		}
	}

	public bool ComfirmButtonable1
	{
		get
		{
			if (_oComfirmButton1 != null)
			{
				return _oComfirmButton1.interactable;
			}
			return true;
		}
		set
		{
			if (ComfirmButtonable1 != value && _oComfirmButton1 != null)
			{
				_oComfirmButton1.interactable = value;
			}
		}
	}

	public bool ComfirmButtonable2
	{
		get
		{
			if (_oComfirmButton2 != null)
			{
				return _oComfirmButton2.interactable;
			}
			return true;
		}
		set
		{
			if (ComfirmButtonable2 != value && _oComfirmButton2 != null)
			{
				_oComfirmButton2.interactable = value;
			}
		}
	}

	public bool ComfirmButtonable3
	{
		get
		{
			if (_oComfirmButton3 != null)
			{
				return _oComfirmButton3.interactable;
			}
			return true;
		}
		set
		{
			if (ComfirmButtonable3 != value && _oComfirmButton3 != null)
			{
				_oComfirmButton3.interactable = value;
			}
		}
	}

	public bool chattextShow1
	{
		get
		{
			if (_ochattext1 != null)
			{
				return _ochattext1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (chattextShow1 != value && _ochattext1 != null)
			{
				_ochattext1.SetObjectActive(value);
			}
		}
	}

	public bool chattextShow2
	{
		get
		{
			if (_ochattext2 != null)
			{
				return _ochattext2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (chattextShow2 != value && _ochattext2 != null)
			{
				_ochattext2.SetObjectActive(value);
			}
		}
	}

	public bool chattextShow3
	{
		get
		{
			if (_ochattext3 != null)
			{
				return _ochattext3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (chattextShow3 != value && _ochattext3 != null)
			{
				_ochattext3.SetObjectActive(value);
			}
		}
	}

	public string chattextString1
	{
		get
		{
			if (_ochattextText1 != null)
			{
				return _ochattextText1.text;
			}
			return null;
		}
		set
		{
			if (chattextString1 != value && _ochattextText1 != null)
			{
				_ochattextText1.text = value;
			}
		}
	}

	public string chattextString2
	{
		get
		{
			if (_ochattextText2 != null)
			{
				return _ochattextText2.text;
			}
			return null;
		}
		set
		{
			if (chattextString2 != value && _ochattextText2 != null)
			{
				_ochattextText2.text = value;
			}
		}
	}

	public string chattextString3
	{
		get
		{
			if (_ochattextText3 != null)
			{
				return _ochattextText3.text;
			}
			return null;
		}
		set
		{
			if (chattextString3 != value && _ochattextText3 != null)
			{
				_ochattextText3.text = value;
			}
		}
	}

	public bool CloseShow
	{
		get
		{
			if (_oClose != null)
			{
				return _oClose.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CloseShow != value && _oClose != null)
			{
				_oClose.SetObjectActive(value);
			}
		}
	}

	public List<EventTrigger.Entry> CloseTriggers
	{
		get
		{
			if (_oCloseEventTrigger != null)
			{
				return _oCloseEventTrigger.triggers;
			}
			return null;
		}
		set
		{
			if (CloseTriggers != value && _oCloseEventTrigger != null)
			{
				_oCloseEventTrigger.triggers = value;
			}
		}
	}

	public bool CloseButtonable
	{
		get
		{
			if (_oCloseButton != null)
			{
				return _oCloseButton.interactable;
			}
			return true;
		}
		set
		{
			if (CloseButtonable != value && _oCloseButton != null)
			{
				_oCloseButton.interactable = value;
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
			case "Title":
				_oTitle = transform.gameObject;
				_oTitleText = transform.gameObject.GetComponent<Text>();
				break;
			case "TitleContent":
				_oTitleContent = transform.gameObject;
				_oTitleContentText = transform.gameObject.GetComponent<Text>();
				break;
			case "Tips":
				_oTips = transform.gameObject;
				_oTipsText = transform.gameObject.GetComponent<Text>();
				break;
			case "TipsContent":
				_oTipsContent = transform.gameObject;
				_oTipsContentText = transform.gameObject.GetComponent<Text>();
				break;
			case "Comfirm1":
				_oComfirm1 = transform.gameObject;
				_oComfirmRectTransform1 = transform.gameObject.GetComponent<RectTransform>();
				_oComfirmEventTrigger1 = transform.gameObject.GetComponent<EventTrigger>();
				_oComfirmButton1 = transform.gameObject.GetComponent<Button>();
				break;
			case "Comfirm2":
				_oComfirm2 = transform.gameObject;
				_oComfirmRectTransform2 = transform.gameObject.GetComponent<RectTransform>();
				_oComfirmEventTrigger2 = transform.gameObject.GetComponent<EventTrigger>();
				_oComfirmButton2 = transform.gameObject.GetComponent<Button>();
				break;
			case "Comfirm3":
				_oComfirm3 = transform.gameObject;
				_oComfirmRectTransform3 = transform.gameObject.GetComponent<RectTransform>();
				_oComfirmEventTrigger3 = transform.gameObject.GetComponent<EventTrigger>();
				_oComfirmButton3 = transform.gameObject.GetComponent<Button>();
				break;
			case "chattext1":
				_ochattext1 = transform.gameObject;
				_ochattextText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "chattext2":
				_ochattext2 = transform.gameObject;
				_ochattextText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "chattext3":
				_ochattext3 = transform.gameObject;
				_ochattextText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "Close":
				_oClose = transform.gameObject;
				_oCloseEventTrigger = transform.gameObject.GetComponent<EventTrigger>();
				_oCloseButton = transform.gameObject.GetComponent<Button>();
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

	public bool GetComfirmShow(int index)
	{
		return index switch
		{
			1 => ComfirmShow1, 
			2 => ComfirmShow2, 
			3 => ComfirmShow3, 
			_ => false, 
		};
	}

	public void SetComfirmShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			ComfirmShow1 = value;
			break;
		case 2:
			ComfirmShow2 = value;
			break;
		case 3:
			ComfirmShow3 = value;
			break;
		}
	}

	public int GetComfirmCount()
	{
		return 3;
	}

	public Vector3 GetComfirmPosition(int index)
	{
		return index switch
		{
			1 => ComfirmPosition1, 
			2 => ComfirmPosition2, 
			3 => ComfirmPosition3, 
			_ => Vector3.zero, 
		};
	}

	public void SetComfirmPosition(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			ComfirmPosition1 = value;
			break;
		case 2:
			ComfirmPosition2 = value;
			break;
		case 3:
			ComfirmPosition3 = value;
			break;
		}
	}

	private void CreateComfirmTriggers1Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(ComfirmTriggers1, eventId, callback);
	}

	private void RemoveComfirmTriggers1Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(ComfirmTriggers1, eventId);
	}

	private void CreateComfirmTriggers2Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(ComfirmTriggers2, eventId, callback);
	}

	private void RemoveComfirmTriggers2Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(ComfirmTriggers2, eventId);
	}

	private void CreateComfirmTriggers3Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(ComfirmTriggers3, eventId, callback);
	}

	private void RemoveComfirmTriggers3Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(ComfirmTriggers3, eventId);
	}

	public List<EventTrigger.Entry> GetComfirmTriggers(int index)
	{
		return index switch
		{
			1 => ComfirmTriggers1, 
			2 => ComfirmTriggers2, 
			3 => ComfirmTriggers3, 
			_ => null, 
		};
	}

	public void SetComfirmTriggers(int index, List<EventTrigger.Entry> value)
	{
		switch (index)
		{
		case 1:
			ComfirmTriggers1 = value;
			break;
		case 2:
			ComfirmTriggers2 = value;
			break;
		case 3:
			ComfirmTriggers3 = value;
			break;
		}
	}

	private void CreateComfirmTriggersEntry(int index, EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(GetComfirmTriggers(index), eventId, callback);
	}

	private void RemoveComfirmTriggersEntry(int index, EventTriggerType eventId)
	{
		RemoveTriggerEntry(GetComfirmTriggers(index), eventId);
	}

	public bool GetComfirmButtonable(int index)
	{
		return index switch
		{
			1 => ComfirmButtonable1, 
			2 => ComfirmButtonable2, 
			3 => ComfirmButtonable3, 
			_ => true, 
		};
	}

	public void SetComfirmButtonable(int index, bool value)
	{
		switch (index)
		{
		case 1:
			ComfirmButtonable1 = value;
			break;
		case 2:
			ComfirmButtonable2 = value;
			break;
		case 3:
			ComfirmButtonable3 = value;
			break;
		}
	}

	public bool GetchattextShow(int index)
	{
		return index switch
		{
			1 => chattextShow1, 
			2 => chattextShow2, 
			3 => chattextShow3, 
			_ => false, 
		};
	}

	public void SetchattextShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			chattextShow1 = value;
			break;
		case 2:
			chattextShow2 = value;
			break;
		case 3:
			chattextShow3 = value;
			break;
		}
	}

	public int GetchattextCount()
	{
		return 3;
	}

	public string GetchattextString(int index)
	{
		return index switch
		{
			1 => chattextString1, 
			2 => chattextString2, 
			3 => chattextString3, 
			_ => null, 
		};
	}

	public void SetchattextString(int index, string value)
	{
		switch (index)
		{
		case 1:
			chattextString1 = value;
			break;
		case 2:
			chattextString2 = value;
			break;
		case 3:
			chattextString3 = value;
			break;
		}
	}

	private void CreateCloseTriggersEntry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(CloseTriggers, eventId, callback);
	}

	private void RemoveCloseTriggersEntry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(CloseTriggers, eventId);
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
