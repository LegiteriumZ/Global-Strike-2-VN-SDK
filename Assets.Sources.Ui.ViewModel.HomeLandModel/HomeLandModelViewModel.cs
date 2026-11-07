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

namespace Assets.Sources.Ui.ViewModel.HomeLandModel;

[GameUiTest]
public class HomeLandModelViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oMsg;

	private Image _oMsgImage;

	private GameObject _oTime1;

	private GameObject _oTime2;

	private Text _oTimeText1;

	private Text _oTimeText2;

	private GameObject _ounlockmsg;

	private GameObject _oProgressShow;

	private GameObject _oProgress;

	private Image _oProgressImage;

	private GameObject _oQ_msg;

	private GameObject _oE_msg;

	private GameObject _oT_msg;

	private GameObject _oE_Oth_msg;

	private GameObject _oerrorMsg;

	private Text _oerrorMsgText;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/homelandmodel";

	private string _resourceAssetName = "homelandmodel";

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

	public bool MsgShow
	{
		get
		{
			if (_oMsg != null)
			{
				return _oMsg.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MsgShow != value && _oMsg != null)
			{
				_oMsg.SetObjectActive(value);
			}
		}
	}

	public Sprite MsgSprite
	{
		get
		{
			if (_oMsgImage != null)
			{
				return _oMsgImage.sprite;
			}
			return null;
		}
		set
		{
			if (MsgSprite != value && _oMsgImage != null)
			{
				_oMsgImage.sprite = value;
			}
		}
	}

	public string TimeString1
	{
		get
		{
			if (_oTimeText1 != null)
			{
				return _oTimeText1.text;
			}
			return null;
		}
		set
		{
			if (TimeString1 != value && _oTimeText1 != null)
			{
				_oTimeText1.text = value;
			}
		}
	}

	public string TimeString2
	{
		get
		{
			if (_oTimeText2 != null)
			{
				return _oTimeText2.text;
			}
			return null;
		}
		set
		{
			if (TimeString2 != value && _oTimeText2 != null)
			{
				_oTimeText2.text = value;
			}
		}
	}

	public Color TimeTextcolor1
	{
		get
		{
			if (_oTimeText1 != null)
			{
				return _oTimeText1.color;
			}
			return Color.white;
		}
		set
		{
			if (TimeTextcolor1 != value && _oTimeText1 != null)
			{
				_oTimeText1.color = value;
			}
		}
	}

	public Color TimeTextcolor2
	{
		get
		{
			if (_oTimeText2 != null)
			{
				return _oTimeText2.color;
			}
			return Color.white;
		}
		set
		{
			if (TimeTextcolor2 != value && _oTimeText2 != null)
			{
				_oTimeText2.color = value;
			}
		}
	}

	public bool unlockmsgShow
	{
		get
		{
			if (_ounlockmsg != null)
			{
				return _ounlockmsg.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (unlockmsgShow != value && _ounlockmsg != null)
			{
				_ounlockmsg.SetObjectActive(value);
			}
		}
	}

	public bool ProgressShowShow
	{
		get
		{
			if (_oProgressShow != null)
			{
				return _oProgressShow.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ProgressShowShow != value && _oProgressShow != null)
			{
				_oProgressShow.SetObjectActive(value);
			}
		}
	}

	public float ProgressFillamount
	{
		get
		{
			if (_oProgressImage != null)
			{
				return _oProgressImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ProgressFillamount != value && _oProgressImage != null)
			{
				_oProgressImage.fillAmount = value;
			}
		}
	}

	public bool Q_msgShow
	{
		get
		{
			if (_oQ_msg != null)
			{
				return _oQ_msg.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (Q_msgShow != value && _oQ_msg != null)
			{
				_oQ_msg.SetObjectActive(value);
			}
		}
	}

	public bool E_msgShow
	{
		get
		{
			if (_oE_msg != null)
			{
				return _oE_msg.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (E_msgShow != value && _oE_msg != null)
			{
				_oE_msg.SetObjectActive(value);
			}
		}
	}

	public bool T_msgShow
	{
		get
		{
			if (_oT_msg != null)
			{
				return _oT_msg.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (T_msgShow != value && _oT_msg != null)
			{
				_oT_msg.SetObjectActive(value);
			}
		}
	}

	public bool E_Oth_msgShow
	{
		get
		{
			if (_oE_Oth_msg != null)
			{
				return _oE_Oth_msg.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (E_Oth_msgShow != value && _oE_Oth_msg != null)
			{
				_oE_Oth_msg.SetObjectActive(value);
			}
		}
	}

	public string errorMsgString
	{
		get
		{
			if (_oerrorMsgText != null)
			{
				return _oerrorMsgText.text;
			}
			return null;
		}
		set
		{
			if (errorMsgString != value && _oerrorMsgText != null)
			{
				_oerrorMsgText.text = value;
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
			case "Msg":
				_oMsg = transform.gameObject;
				_oMsgImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Time1":
				_oTime1 = transform.gameObject;
				_oTimeText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "Time2":
				_oTime2 = transform.gameObject;
				_oTimeText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "unlockmsg":
				_ounlockmsg = transform.gameObject;
				break;
			case "ProgressShow":
				_oProgressShow = transform.gameObject;
				break;
			case "Progress":
				_oProgress = transform.gameObject;
				_oProgressImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Q_msg":
				_oQ_msg = transform.gameObject;
				break;
			case "E_msg":
				_oE_msg = transform.gameObject;
				break;
			case "T_msg":
				_oT_msg = transform.gameObject;
				break;
			case "E_Oth_msg":
				_oE_Oth_msg = transform.gameObject;
				break;
			case "errorMsg":
				_oerrorMsg = transform.gameObject;
				_oerrorMsgText = transform.gameObject.GetComponent<Text>();
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

	public string GetTimeString(int index)
	{
		return index switch
		{
			1 => TimeString1, 
			2 => TimeString2, 
			_ => null, 
		};
	}

	public void SetTimeString(int index, string value)
	{
		switch (index)
		{
		case 1:
			TimeString1 = value;
			break;
		case 2:
			TimeString2 = value;
			break;
		}
	}

	public int GetTimeCount()
	{
		return 2;
	}

	public Color GetTimeTextcolor(int index)
	{
		return index switch
		{
			1 => TimeTextcolor1, 
			2 => TimeTextcolor2, 
			_ => Color.white, 
		};
	}

	public void SetTimeTextcolor(int index, Color value)
	{
		switch (index)
		{
		case 1:
			TimeTextcolor1 = value;
			break;
		case 2:
			TimeTextcolor2 = value;
			break;
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
