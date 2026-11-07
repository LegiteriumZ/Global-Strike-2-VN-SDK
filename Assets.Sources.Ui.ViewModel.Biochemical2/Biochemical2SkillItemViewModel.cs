using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Biochemical2;

[GameUiTest]
public class Biochemical2SkillItemViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oBiochemical2SkillItem;

	private GameObject _oBack;

	private Image _oBackImage;

	private EventTrigger _oBackEventTrigger;

	private GameObject _oSelectBack;

	private RectTransform _oSelectBackRectTransform;

	private Image _oSelectBackImage;

	private GameObject _oProgress1;

	private GameObject _oProgress2;

	private GameObject _oProgress3;

	private GameObject _oProgress4;

	private Image _oProgressImage1;

	private Image _oProgressImage2;

	private Image _oProgressImage3;

	private Image _oProgressImage4;

	private GameObject _oName;

	private Image _oNameImage;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/biochemical2";

	private string _resourceAssetName = "Biochemical2SkillItem";

	public GameObject Biochemical2SkillItemObj => _oBiochemical2SkillItem;

	public bool Biochemical2SkillItemShow
	{
		get
		{
			if (_oBiochemical2SkillItem != null)
			{
				return _oBiochemical2SkillItem.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (Biochemical2SkillItemShow != value && _oBiochemical2SkillItem != null)
			{
				_oBiochemical2SkillItem.SetObjectActive(value);
			}
		}
	}

	public Sprite BackSprite
	{
		get
		{
			if (_oBackImage != null)
			{
				return _oBackImage.sprite;
			}
			return null;
		}
		set
		{
			if (BackSprite != value && _oBackImage != null)
			{
				_oBackImage.sprite = value;
			}
		}
	}

	public List<EventTrigger.Entry> BackTriggers
	{
		get
		{
			if (_oBackEventTrigger != null)
			{
				return _oBackEventTrigger.triggers;
			}
			return null;
		}
		set
		{
			if (BackTriggers != value && _oBackEventTrigger != null)
			{
				_oBackEventTrigger.triggers = value;
			}
		}
	}

	public bool SelectBackShow
	{
		get
		{
			if (_oSelectBack != null)
			{
				return _oSelectBack.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectBackShow != value && _oSelectBack != null)
			{
				_oSelectBack.SetObjectActive(value);
			}
		}
	}

	public Vector3 SelectBackGposition
	{
		get
		{
			if (_oSelectBackRectTransform != null)
			{
				return _oSelectBackRectTransform.position;
			}
			return Vector3.zero;
		}
		set
		{
			if (SelectBackGposition != value && _oSelectBackRectTransform != null)
			{
				_oSelectBackRectTransform.position = value;
			}
		}
	}

	public Sprite SelectBackSprite
	{
		get
		{
			if (_oSelectBackImage != null)
			{
				return _oSelectBackImage.sprite;
			}
			return null;
		}
		set
		{
			if (SelectBackSprite != value && _oSelectBackImage != null)
			{
				_oSelectBackImage.sprite = value;
			}
		}
	}

	public bool ProgressShow1
	{
		get
		{
			if (_oProgress1 != null)
			{
				return _oProgress1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ProgressShow1 != value && _oProgress1 != null)
			{
				_oProgress1.SetObjectActive(value);
			}
		}
	}

	public bool ProgressShow2
	{
		get
		{
			if (_oProgress2 != null)
			{
				return _oProgress2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ProgressShow2 != value && _oProgress2 != null)
			{
				_oProgress2.SetObjectActive(value);
			}
		}
	}

	public bool ProgressShow3
	{
		get
		{
			if (_oProgress3 != null)
			{
				return _oProgress3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ProgressShow3 != value && _oProgress3 != null)
			{
				_oProgress3.SetObjectActive(value);
			}
		}
	}

	public bool ProgressShow4
	{
		get
		{
			if (_oProgress4 != null)
			{
				return _oProgress4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ProgressShow4 != value && _oProgress4 != null)
			{
				_oProgress4.SetObjectActive(value);
			}
		}
	}

	public Sprite ProgressSprite1
	{
		get
		{
			if (_oProgressImage1 != null)
			{
				return _oProgressImage1.sprite;
			}
			return null;
		}
		set
		{
			if (ProgressSprite1 != value && _oProgressImage1 != null)
			{
				_oProgressImage1.sprite = value;
			}
		}
	}

	public Sprite ProgressSprite2
	{
		get
		{
			if (_oProgressImage2 != null)
			{
				return _oProgressImage2.sprite;
			}
			return null;
		}
		set
		{
			if (ProgressSprite2 != value && _oProgressImage2 != null)
			{
				_oProgressImage2.sprite = value;
			}
		}
	}

	public Sprite ProgressSprite3
	{
		get
		{
			if (_oProgressImage3 != null)
			{
				return _oProgressImage3.sprite;
			}
			return null;
		}
		set
		{
			if (ProgressSprite3 != value && _oProgressImage3 != null)
			{
				_oProgressImage3.sprite = value;
			}
		}
	}

	public Sprite ProgressSprite4
	{
		get
		{
			if (_oProgressImage4 != null)
			{
				return _oProgressImage4.sprite;
			}
			return null;
		}
		set
		{
			if (ProgressSprite4 != value && _oProgressImage4 != null)
			{
				_oProgressImage4.sprite = value;
			}
		}
	}

	public Sprite NameSprite
	{
		get
		{
			if (_oNameImage != null)
			{
				return _oNameImage.sprite;
			}
			return null;
		}
		set
		{
			if (NameSprite != value && _oNameImage != null)
			{
				_oNameImage.sprite = value;
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
			case "Biochemical2SkillItem":
				_oBiochemical2SkillItem = transform.gameObject;
				break;
			case "Back":
				_oBack = transform.gameObject;
				_oBackImage = transform.gameObject.GetComponent<Image>();
				_oBackEventTrigger = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "SelectBack":
				_oSelectBack = transform.gameObject;
				_oSelectBackRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oSelectBackImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Progress1":
				_oProgress1 = transform.gameObject;
				_oProgressImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Progress2":
				_oProgress2 = transform.gameObject;
				_oProgressImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Progress3":
				_oProgress3 = transform.gameObject;
				_oProgressImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Progress4":
				_oProgress4 = transform.gameObject;
				_oProgressImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "Name":
				_oName = transform.gameObject;
				_oNameImage = transform.gameObject.GetComponent<Image>();
				break;
			}
		}
	}

	public bool GetProgressShow(int index)
	{
		return index switch
		{
			1 => ProgressShow1, 
			2 => ProgressShow2, 
			3 => ProgressShow3, 
			4 => ProgressShow4, 
			_ => false, 
		};
	}

	public void SetProgressShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			ProgressShow1 = value;
			break;
		case 2:
			ProgressShow2 = value;
			break;
		case 3:
			ProgressShow3 = value;
			break;
		case 4:
			ProgressShow4 = value;
			break;
		}
	}

	public Sprite GetProgressSprite(int index)
	{
		return index switch
		{
			1 => ProgressSprite1, 
			2 => ProgressSprite2, 
			3 => ProgressSprite3, 
			4 => ProgressSprite4, 
			_ => null, 
		};
	}

	public void SetProgressSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			ProgressSprite1 = value;
			break;
		case 2:
			ProgressSprite2 = value;
			break;
		case 3:
			ProgressSprite3 = value;
			break;
		case 4:
			ProgressSprite4 = value;
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
