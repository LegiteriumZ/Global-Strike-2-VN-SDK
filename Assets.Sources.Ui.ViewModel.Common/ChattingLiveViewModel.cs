using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Common;

[GameUiTest]
public class ChattingLiveViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oGiftText1;

	private GameObject _oGiftText2;

	private GameObject _oGiftText3;

	private GameObject _oGiftText4;

	private GameObject _oGiftText5;

	private GameObject _oGiftText6;

	private GameObject _oGiftText7;

	private GameObject _oGiftText8;

	private Text _oGiftTextText1;

	private Text _oGiftTextText2;

	private Text _oGiftTextText3;

	private Text _oGiftTextText4;

	private Text _oGiftTextText5;

	private Text _oGiftTextText6;

	private Text _oGiftTextText7;

	private Text _oGiftTextText8;

	private GameObject _oBarrage1;

	private GameObject _oBarrage2;

	private GameObject _oBarrage3;

	private GameObject _oBarrage4;

	private GameObject _oBarrage5;

	private GameObject _oBarrage6;

	private GameObject _oBarrage7;

	private GameObject _oBarrage8;

	private Text _oBarrageText1;

	private Text _oBarrageText2;

	private Text _oBarrageText3;

	private Text _oBarrageText4;

	private Text _oBarrageText5;

	private Text _oBarrageText6;

	private Text _oBarrageText7;

	private Text _oBarrageText8;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/common";

	private string _resourceAssetName = "ChattingLive";

	public bool GiftTextShow1
	{
		get
		{
			if (_oGiftText1 != null)
			{
				return _oGiftText1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GiftTextShow1 != value && _oGiftText1 != null)
			{
				_oGiftText1.SetObjectActive(value);
			}
		}
	}

	public bool GiftTextShow2
	{
		get
		{
			if (_oGiftText2 != null)
			{
				return _oGiftText2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GiftTextShow2 != value && _oGiftText2 != null)
			{
				_oGiftText2.SetObjectActive(value);
			}
		}
	}

	public bool GiftTextShow3
	{
		get
		{
			if (_oGiftText3 != null)
			{
				return _oGiftText3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GiftTextShow3 != value && _oGiftText3 != null)
			{
				_oGiftText3.SetObjectActive(value);
			}
		}
	}

	public bool GiftTextShow4
	{
		get
		{
			if (_oGiftText4 != null)
			{
				return _oGiftText4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GiftTextShow4 != value && _oGiftText4 != null)
			{
				_oGiftText4.SetObjectActive(value);
			}
		}
	}

	public bool GiftTextShow5
	{
		get
		{
			if (_oGiftText5 != null)
			{
				return _oGiftText5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GiftTextShow5 != value && _oGiftText5 != null)
			{
				_oGiftText5.SetObjectActive(value);
			}
		}
	}

	public bool GiftTextShow6
	{
		get
		{
			if (_oGiftText6 != null)
			{
				return _oGiftText6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GiftTextShow6 != value && _oGiftText6 != null)
			{
				_oGiftText6.SetObjectActive(value);
			}
		}
	}

	public bool GiftTextShow7
	{
		get
		{
			if (_oGiftText7 != null)
			{
				return _oGiftText7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GiftTextShow7 != value && _oGiftText7 != null)
			{
				_oGiftText7.SetObjectActive(value);
			}
		}
	}

	public bool GiftTextShow8
	{
		get
		{
			if (_oGiftText8 != null)
			{
				return _oGiftText8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GiftTextShow8 != value && _oGiftText8 != null)
			{
				_oGiftText8.SetObjectActive(value);
			}
		}
	}

	public string GiftTextString1
	{
		get
		{
			if (_oGiftTextText1 != null)
			{
				return _oGiftTextText1.text;
			}
			return null;
		}
		set
		{
			if (GiftTextString1 != value && _oGiftTextText1 != null)
			{
				_oGiftTextText1.text = value;
			}
		}
	}

	public string GiftTextString2
	{
		get
		{
			if (_oGiftTextText2 != null)
			{
				return _oGiftTextText2.text;
			}
			return null;
		}
		set
		{
			if (GiftTextString2 != value && _oGiftTextText2 != null)
			{
				_oGiftTextText2.text = value;
			}
		}
	}

	public string GiftTextString3
	{
		get
		{
			if (_oGiftTextText3 != null)
			{
				return _oGiftTextText3.text;
			}
			return null;
		}
		set
		{
			if (GiftTextString3 != value && _oGiftTextText3 != null)
			{
				_oGiftTextText3.text = value;
			}
		}
	}

	public string GiftTextString4
	{
		get
		{
			if (_oGiftTextText4 != null)
			{
				return _oGiftTextText4.text;
			}
			return null;
		}
		set
		{
			if (GiftTextString4 != value && _oGiftTextText4 != null)
			{
				_oGiftTextText4.text = value;
			}
		}
	}

	public string GiftTextString5
	{
		get
		{
			if (_oGiftTextText5 != null)
			{
				return _oGiftTextText5.text;
			}
			return null;
		}
		set
		{
			if (GiftTextString5 != value && _oGiftTextText5 != null)
			{
				_oGiftTextText5.text = value;
			}
		}
	}

	public string GiftTextString6
	{
		get
		{
			if (_oGiftTextText6 != null)
			{
				return _oGiftTextText6.text;
			}
			return null;
		}
		set
		{
			if (GiftTextString6 != value && _oGiftTextText6 != null)
			{
				_oGiftTextText6.text = value;
			}
		}
	}

	public string GiftTextString7
	{
		get
		{
			if (_oGiftTextText7 != null)
			{
				return _oGiftTextText7.text;
			}
			return null;
		}
		set
		{
			if (GiftTextString7 != value && _oGiftTextText7 != null)
			{
				_oGiftTextText7.text = value;
			}
		}
	}

	public string GiftTextString8
	{
		get
		{
			if (_oGiftTextText8 != null)
			{
				return _oGiftTextText8.text;
			}
			return null;
		}
		set
		{
			if (GiftTextString8 != value && _oGiftTextText8 != null)
			{
				_oGiftTextText8.text = value;
			}
		}
	}

	public bool BarrageShow1
	{
		get
		{
			if (_oBarrage1 != null)
			{
				return _oBarrage1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BarrageShow1 != value && _oBarrage1 != null)
			{
				_oBarrage1.SetObjectActive(value);
			}
		}
	}

	public bool BarrageShow2
	{
		get
		{
			if (_oBarrage2 != null)
			{
				return _oBarrage2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BarrageShow2 != value && _oBarrage2 != null)
			{
				_oBarrage2.SetObjectActive(value);
			}
		}
	}

	public bool BarrageShow3
	{
		get
		{
			if (_oBarrage3 != null)
			{
				return _oBarrage3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BarrageShow3 != value && _oBarrage3 != null)
			{
				_oBarrage3.SetObjectActive(value);
			}
		}
	}

	public bool BarrageShow4
	{
		get
		{
			if (_oBarrage4 != null)
			{
				return _oBarrage4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BarrageShow4 != value && _oBarrage4 != null)
			{
				_oBarrage4.SetObjectActive(value);
			}
		}
	}

	public bool BarrageShow5
	{
		get
		{
			if (_oBarrage5 != null)
			{
				return _oBarrage5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BarrageShow5 != value && _oBarrage5 != null)
			{
				_oBarrage5.SetObjectActive(value);
			}
		}
	}

	public bool BarrageShow6
	{
		get
		{
			if (_oBarrage6 != null)
			{
				return _oBarrage6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BarrageShow6 != value && _oBarrage6 != null)
			{
				_oBarrage6.SetObjectActive(value);
			}
		}
	}

	public bool BarrageShow7
	{
		get
		{
			if (_oBarrage7 != null)
			{
				return _oBarrage7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BarrageShow7 != value && _oBarrage7 != null)
			{
				_oBarrage7.SetObjectActive(value);
			}
		}
	}

	public bool BarrageShow8
	{
		get
		{
			if (_oBarrage8 != null)
			{
				return _oBarrage8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BarrageShow8 != value && _oBarrage8 != null)
			{
				_oBarrage8.SetObjectActive(value);
			}
		}
	}

	public string BarrageString1
	{
		get
		{
			if (_oBarrageText1 != null)
			{
				return _oBarrageText1.text;
			}
			return null;
		}
		set
		{
			if (BarrageString1 != value && _oBarrageText1 != null)
			{
				_oBarrageText1.text = value;
			}
		}
	}

	public string BarrageString2
	{
		get
		{
			if (_oBarrageText2 != null)
			{
				return _oBarrageText2.text;
			}
			return null;
		}
		set
		{
			if (BarrageString2 != value && _oBarrageText2 != null)
			{
				_oBarrageText2.text = value;
			}
		}
	}

	public string BarrageString3
	{
		get
		{
			if (_oBarrageText3 != null)
			{
				return _oBarrageText3.text;
			}
			return null;
		}
		set
		{
			if (BarrageString3 != value && _oBarrageText3 != null)
			{
				_oBarrageText3.text = value;
			}
		}
	}

	public string BarrageString4
	{
		get
		{
			if (_oBarrageText4 != null)
			{
				return _oBarrageText4.text;
			}
			return null;
		}
		set
		{
			if (BarrageString4 != value && _oBarrageText4 != null)
			{
				_oBarrageText4.text = value;
			}
		}
	}

	public string BarrageString5
	{
		get
		{
			if (_oBarrageText5 != null)
			{
				return _oBarrageText5.text;
			}
			return null;
		}
		set
		{
			if (BarrageString5 != value && _oBarrageText5 != null)
			{
				_oBarrageText5.text = value;
			}
		}
	}

	public string BarrageString6
	{
		get
		{
			if (_oBarrageText6 != null)
			{
				return _oBarrageText6.text;
			}
			return null;
		}
		set
		{
			if (BarrageString6 != value && _oBarrageText6 != null)
			{
				_oBarrageText6.text = value;
			}
		}
	}

	public string BarrageString7
	{
		get
		{
			if (_oBarrageText7 != null)
			{
				return _oBarrageText7.text;
			}
			return null;
		}
		set
		{
			if (BarrageString7 != value && _oBarrageText7 != null)
			{
				_oBarrageText7.text = value;
			}
		}
	}

	public string BarrageString8
	{
		get
		{
			if (_oBarrageText8 != null)
			{
				return _oBarrageText8.text;
			}
			return null;
		}
		set
		{
			if (BarrageString8 != value && _oBarrageText8 != null)
			{
				_oBarrageText8.text = value;
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
			case "GiftText1":
				_oGiftText1 = transform.gameObject;
				_oGiftTextText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "GiftText2":
				_oGiftText2 = transform.gameObject;
				_oGiftTextText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "GiftText3":
				_oGiftText3 = transform.gameObject;
				_oGiftTextText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "GiftText4":
				_oGiftText4 = transform.gameObject;
				_oGiftTextText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "GiftText5":
				_oGiftText5 = transform.gameObject;
				_oGiftTextText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "GiftText6":
				_oGiftText6 = transform.gameObject;
				_oGiftTextText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "GiftText7":
				_oGiftText7 = transform.gameObject;
				_oGiftTextText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "GiftText8":
				_oGiftText8 = transform.gameObject;
				_oGiftTextText8 = transform.gameObject.GetComponent<Text>();
				break;
			case "Barrage1":
				_oBarrage1 = transform.gameObject;
				_oBarrageText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "Barrage2":
				_oBarrage2 = transform.gameObject;
				_oBarrageText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "Barrage3":
				_oBarrage3 = transform.gameObject;
				_oBarrageText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "Barrage4":
				_oBarrage4 = transform.gameObject;
				_oBarrageText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "Barrage5":
				_oBarrage5 = transform.gameObject;
				_oBarrageText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "Barrage6":
				_oBarrage6 = transform.gameObject;
				_oBarrageText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "Barrage7":
				_oBarrage7 = transform.gameObject;
				_oBarrageText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "Barrage8":
				_oBarrage8 = transform.gameObject;
				_oBarrageText8 = transform.gameObject.GetComponent<Text>();
				break;
			}
		}
	}

	public bool GetGiftTextShow(int index)
	{
		return index switch
		{
			1 => GiftTextShow1, 
			2 => GiftTextShow2, 
			3 => GiftTextShow3, 
			4 => GiftTextShow4, 
			5 => GiftTextShow5, 
			6 => GiftTextShow6, 
			7 => GiftTextShow7, 
			8 => GiftTextShow8, 
			_ => false, 
		};
	}

	public void SetGiftTextShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			GiftTextShow1 = value;
			break;
		case 2:
			GiftTextShow2 = value;
			break;
		case 3:
			GiftTextShow3 = value;
			break;
		case 4:
			GiftTextShow4 = value;
			break;
		case 5:
			GiftTextShow5 = value;
			break;
		case 6:
			GiftTextShow6 = value;
			break;
		case 7:
			GiftTextShow7 = value;
			break;
		case 8:
			GiftTextShow8 = value;
			break;
		}
	}

	public string GetGiftTextString(int index)
	{
		return index switch
		{
			1 => GiftTextString1, 
			2 => GiftTextString2, 
			3 => GiftTextString3, 
			4 => GiftTextString4, 
			5 => GiftTextString5, 
			6 => GiftTextString6, 
			7 => GiftTextString7, 
			8 => GiftTextString8, 
			_ => null, 
		};
	}

	public void SetGiftTextString(int index, string value)
	{
		switch (index)
		{
		case 1:
			GiftTextString1 = value;
			break;
		case 2:
			GiftTextString2 = value;
			break;
		case 3:
			GiftTextString3 = value;
			break;
		case 4:
			GiftTextString4 = value;
			break;
		case 5:
			GiftTextString5 = value;
			break;
		case 6:
			GiftTextString6 = value;
			break;
		case 7:
			GiftTextString7 = value;
			break;
		case 8:
			GiftTextString8 = value;
			break;
		}
	}

	public bool GetBarrageShow(int index)
	{
		return index switch
		{
			1 => BarrageShow1, 
			2 => BarrageShow2, 
			3 => BarrageShow3, 
			4 => BarrageShow4, 
			5 => BarrageShow5, 
			6 => BarrageShow6, 
			7 => BarrageShow7, 
			8 => BarrageShow8, 
			_ => false, 
		};
	}

	public void SetBarrageShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			BarrageShow1 = value;
			break;
		case 2:
			BarrageShow2 = value;
			break;
		case 3:
			BarrageShow3 = value;
			break;
		case 4:
			BarrageShow4 = value;
			break;
		case 5:
			BarrageShow5 = value;
			break;
		case 6:
			BarrageShow6 = value;
			break;
		case 7:
			BarrageShow7 = value;
			break;
		case 8:
			BarrageShow8 = value;
			break;
		}
	}

	public string GetBarrageString(int index)
	{
		return index switch
		{
			1 => BarrageString1, 
			2 => BarrageString2, 
			3 => BarrageString3, 
			4 => BarrageString4, 
			5 => BarrageString5, 
			6 => BarrageString6, 
			7 => BarrageString7, 
			8 => BarrageString8, 
			_ => null, 
		};
	}

	public void SetBarrageString(int index, string value)
	{
		switch (index)
		{
		case 1:
			BarrageString1 = value;
			break;
		case 2:
			BarrageString2 = value;
			break;
		case 3:
			BarrageString3 = value;
			break;
		case 4:
			BarrageString4 = value;
			break;
		case 5:
			BarrageString5 = value;
			break;
		case 6:
			BarrageString6 = value;
			break;
		case 7:
			BarrageString7 = value;
			break;
		case 8:
			BarrageString8 = value;
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
