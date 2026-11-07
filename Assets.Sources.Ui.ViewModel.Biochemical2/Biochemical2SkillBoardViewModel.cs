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
public class Biochemical2SkillBoardViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oGrid1;

	private GameObject _oGrid2;

	private GameObject _oTips;

	private RectTransform _oTipsRectTransform;

	private Image _oTipsImage;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/biochemical2";

	private string _resourceAssetName = "Biochemical2SkillBoard";

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

	public GameObject GridObj1 => _oGrid1;

	public GameObject GridObj2 => _oGrid2;

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

	public Vector3 TipsGposition
	{
		get
		{
			if (_oTipsRectTransform != null)
			{
				return _oTipsRectTransform.position;
			}
			return Vector3.zero;
		}
		set
		{
			if (TipsGposition != value && _oTipsRectTransform != null)
			{
				_oTipsRectTransform.position = value;
			}
		}
	}

	public Sprite TipsSprite
	{
		get
		{
			if (_oTipsImage != null)
			{
				return _oTipsImage.sprite;
			}
			return null;
		}
		set
		{
			if (TipsSprite != value && _oTipsImage != null)
			{
				_oTipsImage.sprite = value;
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
			case "Grid1":
				_oGrid1 = transform.gameObject;
				break;
			case "Grid2":
				_oGrid2 = transform.gameObject;
				break;
			case "Tips":
				_oTips = transform.gameObject;
				_oTipsRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oTipsImage = transform.gameObject.GetComponent<Image>();
				break;
			}
		}
	}

	public GameObject GetGridObj(int index)
	{
		return index switch
		{
			1 => GridObj1, 
			2 => GridObj2, 
			_ => null, 
		};
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
