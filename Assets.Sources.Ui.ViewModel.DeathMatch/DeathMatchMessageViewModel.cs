using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.DeathMatch;

[GameUiTest]
public class DeathMatchMessageViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oCenterText;

	private Text _oCenterTextText;

	private GameObject _oCenter;

	private HorizontalLayoutGroup _oCenterHorizontalLayoutGroup;

	private GameObject _oName1;

	private GameObject _oName2;

	private Text _oNameText1;

	private Text _oNameText2;

	private GameObject _oMessage;

	private Image _oMessageImage;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/deathmatch";

	private string _resourceAssetName = "DeathMatchMessage";

	public bool CenterTextShow
	{
		get
		{
			if (_oCenterText != null)
			{
				return _oCenterText.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CenterTextShow != value && _oCenterText != null)
			{
				_oCenterText.SetObjectActive(value);
			}
		}
	}

	public string CenterTextString
	{
		get
		{
			if (_oCenterTextText != null)
			{
				return _oCenterTextText.text;
			}
			return null;
		}
		set
		{
			if (CenterTextString != value && _oCenterTextText != null)
			{
				_oCenterTextText.text = value;
			}
		}
	}

	public bool CenterShow
	{
		get
		{
			if (_oCenter != null)
			{
				return _oCenter.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CenterShow != value && _oCenter != null)
			{
				_oCenter.SetObjectActive(value);
			}
		}
	}

	public bool NameShow1
	{
		get
		{
			if (_oName1 != null)
			{
				return _oName1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NameShow1 != value && _oName1 != null)
			{
				_oName1.SetObjectActive(value);
			}
		}
	}

	public bool NameShow2
	{
		get
		{
			if (_oName2 != null)
			{
				return _oName2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NameShow2 != value && _oName2 != null)
			{
				_oName2.SetObjectActive(value);
			}
		}
	}

	public string NameString1
	{
		get
		{
			if (_oNameText1 != null)
			{
				return _oNameText1.text;
			}
			return null;
		}
		set
		{
			if (NameString1 != value && _oNameText1 != null)
			{
				_oNameText1.text = value;
			}
		}
	}

	public string NameString2
	{
		get
		{
			if (_oNameText2 != null)
			{
				return _oNameText2.text;
			}
			return null;
		}
		set
		{
			if (NameString2 != value && _oNameText2 != null)
			{
				_oNameText2.text = value;
			}
		}
	}

	public Sprite MessageSprite
	{
		get
		{
			if (_oMessageImage != null)
			{
				return _oMessageImage.sprite;
			}
			return null;
		}
		set
		{
			if (MessageSprite != value && _oMessageImage != null)
			{
				_oMessageImage.sprite = value;
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
			case "CenterText":
				_oCenterText = transform.gameObject;
				_oCenterTextText = transform.gameObject.GetComponent<Text>();
				break;
			case "Center":
				_oCenter = transform.gameObject;
				_oCenterHorizontalLayoutGroup = transform.gameObject.GetComponent<HorizontalLayoutGroup>();
				break;
			case "Name1":
				_oName1 = transform.gameObject;
				_oNameText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "Name2":
				_oName2 = transform.gameObject;
				_oNameText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "Message":
				_oMessage = transform.gameObject;
				_oMessageImage = transform.gameObject.GetComponent<Image>();
				break;
			}
		}
	}

	public void CenterHlayoutupdate()
	{
		if (_oCenterHorizontalLayoutGroup != null)
		{
			LayoutRebuilder.ForceRebuildLayoutImmediate(_oCenter.GetComponent<RectTransform>());
		}
	}

	public bool GetNameShow(int index)
	{
		return index switch
		{
			1 => NameShow1, 
			2 => NameShow2, 
			_ => false, 
		};
	}

	public void SetNameShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			NameShow1 = value;
			break;
		case 2:
			NameShow2 = value;
			break;
		}
	}

	public string GetNameString(int index)
	{
		return index switch
		{
			1 => NameString1, 
			2 => NameString2, 
			_ => null, 
		};
	}

	public void SetNameString(int index, string value)
	{
		switch (index)
		{
		case 1:
			NameString1 = value;
			break;
		case 2:
			NameString2 = value;
			break;
		}
	}

	public void MessageNtvsize()
	{
		if (_oMessageImage != null)
		{
			_oMessageImage.SetNativeSize();
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
			Object.Destroy(_viewGameObject);
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

	public List<RectTransform> GetHoldPosIntergeTrans()
	{
		return null;
	}
}
