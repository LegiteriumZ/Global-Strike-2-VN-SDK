using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Biochemical;

[GameUiTest]
public class BiochemicalhumanitygrowupViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oBottom;

	private GameObject _oPointImage1;

	private GameObject _oPointImage2;

	private GameObject _oPointImage3;

	private GameObject _oPointImage4;

	private GameObject _oPointImage5;

	private GameObject _oPointImage6;

	private GameObject _oPointImage7;

	private GameObject _oPointImage8;

	private GameObject _oPointImage9;

	private GameObject _oPointImage10;

	private GameObject _oHeadImage;

	private GameObject _oHeroText;

	private Text _oHeroTextText;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/biochemical";

	private string _resourceAssetName = "Biochemicalhumanitygrowup";

	public bool BottomShow
	{
		get
		{
			if (_oBottom != null)
			{
				return _oBottom.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BottomShow != value && _oBottom != null)
			{
				_oBottom.SetObjectActive(value);
			}
		}
	}

	public bool PointImageShow1
	{
		get
		{
			if (_oPointImage1 != null)
			{
				return _oPointImage1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PointImageShow1 != value && _oPointImage1 != null)
			{
				_oPointImage1.SetObjectActive(value);
			}
		}
	}

	public bool PointImageShow2
	{
		get
		{
			if (_oPointImage2 != null)
			{
				return _oPointImage2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PointImageShow2 != value && _oPointImage2 != null)
			{
				_oPointImage2.SetObjectActive(value);
			}
		}
	}

	public bool PointImageShow3
	{
		get
		{
			if (_oPointImage3 != null)
			{
				return _oPointImage3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PointImageShow3 != value && _oPointImage3 != null)
			{
				_oPointImage3.SetObjectActive(value);
			}
		}
	}

	public bool PointImageShow4
	{
		get
		{
			if (_oPointImage4 != null)
			{
				return _oPointImage4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PointImageShow4 != value && _oPointImage4 != null)
			{
				_oPointImage4.SetObjectActive(value);
			}
		}
	}

	public bool PointImageShow5
	{
		get
		{
			if (_oPointImage5 != null)
			{
				return _oPointImage5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PointImageShow5 != value && _oPointImage5 != null)
			{
				_oPointImage5.SetObjectActive(value);
			}
		}
	}

	public bool PointImageShow6
	{
		get
		{
			if (_oPointImage6 != null)
			{
				return _oPointImage6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PointImageShow6 != value && _oPointImage6 != null)
			{
				_oPointImage6.SetObjectActive(value);
			}
		}
	}

	public bool PointImageShow7
	{
		get
		{
			if (_oPointImage7 != null)
			{
				return _oPointImage7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PointImageShow7 != value && _oPointImage7 != null)
			{
				_oPointImage7.SetObjectActive(value);
			}
		}
	}

	public bool PointImageShow8
	{
		get
		{
			if (_oPointImage8 != null)
			{
				return _oPointImage8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PointImageShow8 != value && _oPointImage8 != null)
			{
				_oPointImage8.SetObjectActive(value);
			}
		}
	}

	public bool PointImageShow9
	{
		get
		{
			if (_oPointImage9 != null)
			{
				return _oPointImage9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PointImageShow9 != value && _oPointImage9 != null)
			{
				_oPointImage9.SetObjectActive(value);
			}
		}
	}

	public bool PointImageShow10
	{
		get
		{
			if (_oPointImage10 != null)
			{
				return _oPointImage10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PointImageShow10 != value && _oPointImage10 != null)
			{
				_oPointImage10.SetObjectActive(value);
			}
		}
	}

	public bool HeadImageShow
	{
		get
		{
			if (_oHeadImage != null)
			{
				return _oHeadImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (HeadImageShow != value && _oHeadImage != null)
			{
				_oHeadImage.SetObjectActive(value);
			}
		}
	}

	public string HeroTextString
	{
		get
		{
			if (_oHeroTextText != null)
			{
				return _oHeroTextText.text;
			}
			return null;
		}
		set
		{
			if (HeroTextString != value && _oHeroTextText != null)
			{
				_oHeroTextText.text = value;
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
			case "Bottom":
				_oBottom = transform.gameObject;
				break;
			case "PointImage1":
				_oPointImage1 = transform.gameObject;
				break;
			case "PointImage2":
				_oPointImage2 = transform.gameObject;
				break;
			case "PointImage3":
				_oPointImage3 = transform.gameObject;
				break;
			case "PointImage4":
				_oPointImage4 = transform.gameObject;
				break;
			case "PointImage5":
				_oPointImage5 = transform.gameObject;
				break;
			case "PointImage6":
				_oPointImage6 = transform.gameObject;
				break;
			case "PointImage7":
				_oPointImage7 = transform.gameObject;
				break;
			case "PointImage8":
				_oPointImage8 = transform.gameObject;
				break;
			case "PointImage9":
				_oPointImage9 = transform.gameObject;
				break;
			case "PointImage10":
				_oPointImage10 = transform.gameObject;
				break;
			case "HeadImage":
				_oHeadImage = transform.gameObject;
				break;
			case "HeroText":
				_oHeroText = transform.gameObject;
				_oHeroTextText = transform.gameObject.GetComponent<Text>();
				break;
			}
		}
	}

	public bool GetPointImageShow(int index)
	{
		return index switch
		{
			1 => PointImageShow1, 
			2 => PointImageShow2, 
			3 => PointImageShow3, 
			4 => PointImageShow4, 
			5 => PointImageShow5, 
			6 => PointImageShow6, 
			7 => PointImageShow7, 
			8 => PointImageShow8, 
			9 => PointImageShow9, 
			10 => PointImageShow10, 
			_ => false, 
		};
	}

	public void SetPointImageShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			PointImageShow1 = value;
			break;
		case 2:
			PointImageShow2 = value;
			break;
		case 3:
			PointImageShow3 = value;
			break;
		case 4:
			PointImageShow4 = value;
			break;
		case 5:
			PointImageShow5 = value;
			break;
		case 6:
			PointImageShow6 = value;
			break;
		case 7:
			PointImageShow7 = value;
			break;
		case 8:
			PointImageShow8 = value;
			break;
		case 9:
			PointImageShow9 = value;
			break;
		case 10:
			PointImageShow10 = value;
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

	public List<RectTransform> GetHoldPosIntergeTrans()
	{
		return null;
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
}
