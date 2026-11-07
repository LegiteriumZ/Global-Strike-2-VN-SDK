using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Rpg;

[GameUiTest]
public class RpgRuoDianHpViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oCell1;

	private GameObject _oCell2;

	private GameObject _oCell3;

	private GameObject _oCell4;

	private GameObject _oCell5;

	private GameObject _oProgress1;

	private GameObject _oProgress2;

	private GameObject _oProgress3;

	private GameObject _oProgress4;

	private GameObject _oProgress5;

	private Image _oProgressImage1;

	private Image _oProgressImage2;

	private Image _oProgressImage3;

	private Image _oProgressImage4;

	private Image _oProgressImage5;

	private GameObject _oIcon1;

	private GameObject _oIcon2;

	private GameObject _oIcon3;

	private GameObject _oIcon4;

	private GameObject _oIcon5;

	private Image _oIconImage1;

	private Image _oIconImage2;

	private Image _oIconImage3;

	private Image _oIconImage4;

	private Image _oIconImage5;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/rpg";

	private string _resourceAssetName = "RpgRuoDianHp";

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

	public bool CellShow1
	{
		get
		{
			if (_oCell1 != null)
			{
				return _oCell1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CellShow1 != value && _oCell1 != null)
			{
				_oCell1.SetObjectActive(value);
			}
		}
	}

	public bool CellShow2
	{
		get
		{
			if (_oCell2 != null)
			{
				return _oCell2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CellShow2 != value && _oCell2 != null)
			{
				_oCell2.SetObjectActive(value);
			}
		}
	}

	public bool CellShow3
	{
		get
		{
			if (_oCell3 != null)
			{
				return _oCell3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CellShow3 != value && _oCell3 != null)
			{
				_oCell3.SetObjectActive(value);
			}
		}
	}

	public bool CellShow4
	{
		get
		{
			if (_oCell4 != null)
			{
				return _oCell4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CellShow4 != value && _oCell4 != null)
			{
				_oCell4.SetObjectActive(value);
			}
		}
	}

	public bool CellShow5
	{
		get
		{
			if (_oCell5 != null)
			{
				return _oCell5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CellShow5 != value && _oCell5 != null)
			{
				_oCell5.SetObjectActive(value);
			}
		}
	}

	public float ProgressFillamount1
	{
		get
		{
			if (_oProgressImage1 != null)
			{
				return _oProgressImage1.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ProgressFillamount1 != value && _oProgressImage1 != null)
			{
				_oProgressImage1.fillAmount = value;
			}
		}
	}

	public float ProgressFillamount2
	{
		get
		{
			if (_oProgressImage2 != null)
			{
				return _oProgressImage2.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ProgressFillamount2 != value && _oProgressImage2 != null)
			{
				_oProgressImage2.fillAmount = value;
			}
		}
	}

	public float ProgressFillamount3
	{
		get
		{
			if (_oProgressImage3 != null)
			{
				return _oProgressImage3.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ProgressFillamount3 != value && _oProgressImage3 != null)
			{
				_oProgressImage3.fillAmount = value;
			}
		}
	}

	public float ProgressFillamount4
	{
		get
		{
			if (_oProgressImage4 != null)
			{
				return _oProgressImage4.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ProgressFillamount4 != value && _oProgressImage4 != null)
			{
				_oProgressImage4.fillAmount = value;
			}
		}
	}

	public float ProgressFillamount5
	{
		get
		{
			if (_oProgressImage5 != null)
			{
				return _oProgressImage5.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ProgressFillamount5 != value && _oProgressImage5 != null)
			{
				_oProgressImage5.fillAmount = value;
			}
		}
	}

	public Sprite IconSprite1
	{
		get
		{
			if (_oIconImage1 != null)
			{
				return _oIconImage1.sprite;
			}
			return null;
		}
		set
		{
			if (IconSprite1 != value && _oIconImage1 != null)
			{
				_oIconImage1.sprite = value;
			}
		}
	}

	public Sprite IconSprite2
	{
		get
		{
			if (_oIconImage2 != null)
			{
				return _oIconImage2.sprite;
			}
			return null;
		}
		set
		{
			if (IconSprite2 != value && _oIconImage2 != null)
			{
				_oIconImage2.sprite = value;
			}
		}
	}

	public Sprite IconSprite3
	{
		get
		{
			if (_oIconImage3 != null)
			{
				return _oIconImage3.sprite;
			}
			return null;
		}
		set
		{
			if (IconSprite3 != value && _oIconImage3 != null)
			{
				_oIconImage3.sprite = value;
			}
		}
	}

	public Sprite IconSprite4
	{
		get
		{
			if (_oIconImage4 != null)
			{
				return _oIconImage4.sprite;
			}
			return null;
		}
		set
		{
			if (IconSprite4 != value && _oIconImage4 != null)
			{
				_oIconImage4.sprite = value;
			}
		}
	}

	public Sprite IconSprite5
	{
		get
		{
			if (_oIconImage5 != null)
			{
				return _oIconImage5.sprite;
			}
			return null;
		}
		set
		{
			if (IconSprite5 != value && _oIconImage5 != null)
			{
				_oIconImage5.sprite = value;
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
			case "Cell1":
				_oCell1 = transform.gameObject;
				break;
			case "Cell2":
				_oCell2 = transform.gameObject;
				break;
			case "Cell3":
				_oCell3 = transform.gameObject;
				break;
			case "Cell4":
				_oCell4 = transform.gameObject;
				break;
			case "Cell5":
				_oCell5 = transform.gameObject;
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
			case "Progress5":
				_oProgress5 = transform.gameObject;
				_oProgressImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "Icon1":
				_oIcon1 = transform.gameObject;
				_oIconImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Icon2":
				_oIcon2 = transform.gameObject;
				_oIconImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Icon3":
				_oIcon3 = transform.gameObject;
				_oIconImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Icon4":
				_oIcon4 = transform.gameObject;
				_oIconImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "Icon5":
				_oIcon5 = transform.gameObject;
				_oIconImage5 = transform.gameObject.GetComponent<Image>();
				break;
			}
		}
	}

	public bool GetCellShow(int index)
	{
		return index switch
		{
			1 => CellShow1, 
			2 => CellShow2, 
			3 => CellShow3, 
			4 => CellShow4, 
			5 => CellShow5, 
			_ => false, 
		};
	}

	public void SetCellShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			CellShow1 = value;
			break;
		case 2:
			CellShow2 = value;
			break;
		case 3:
			CellShow3 = value;
			break;
		case 4:
			CellShow4 = value;
			break;
		case 5:
			CellShow5 = value;
			break;
		}
	}

	public float GetProgressFillamount(int index)
	{
		return index switch
		{
			1 => ProgressFillamount1, 
			2 => ProgressFillamount2, 
			3 => ProgressFillamount3, 
			4 => ProgressFillamount4, 
			5 => ProgressFillamount5, 
			_ => 0f, 
		};
	}

	public void SetProgressFillamount(int index, float value)
	{
		switch (index)
		{
		case 1:
			ProgressFillamount1 = value;
			break;
		case 2:
			ProgressFillamount2 = value;
			break;
		case 3:
			ProgressFillamount3 = value;
			break;
		case 4:
			ProgressFillamount4 = value;
			break;
		case 5:
			ProgressFillamount5 = value;
			break;
		}
	}

	public Sprite GetIconSprite(int index)
	{
		return index switch
		{
			1 => IconSprite1, 
			2 => IconSprite2, 
			3 => IconSprite3, 
			4 => IconSprite4, 
			5 => IconSprite5, 
			_ => null, 
		};
	}

	public void SetIconSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			IconSprite1 = value;
			break;
		case 2:
			IconSprite2 = value;
			break;
		case 3:
			IconSprite3 = value;
			break;
		case 4:
			IconSprite4 = value;
			break;
		case 5:
			IconSprite5 = value;
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
