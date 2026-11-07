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

namespace Assets.Sources.Ui.ViewModel.RpgTower;

[GameUiTest]
public class RpgTowerMoneyViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oCell1;

	private GameObject _oCell2;

	private GameObject _oCell3;

	private Image _oCellImage1;

	private Image _oCellImage2;

	private Image _oCellImage3;

	private GameObject _onumtxt1;

	private GameObject _onumtxt2;

	private GameObject _onumtxt3;

	private Text _onumtxtText1;

	private Text _onumtxtText2;

	private Text _onumtxtText3;

	private GameObject _oJinbi;

	private GameObject _oJinbiCount;

	private Text _oJinbiCountText;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/rpgtower";

	private string _resourceAssetName = "RpgTowerMoney";

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

	public Color CellColor1
	{
		get
		{
			if (_oCellImage1 != null)
			{
				return _oCellImage1.color;
			}
			return Color.white;
		}
		set
		{
			if (CellColor1 != value && _oCellImage1 != null)
			{
				_oCellImage1.color = value;
			}
		}
	}

	public Color CellColor2
	{
		get
		{
			if (_oCellImage2 != null)
			{
				return _oCellImage2.color;
			}
			return Color.white;
		}
		set
		{
			if (CellColor2 != value && _oCellImage2 != null)
			{
				_oCellImage2.color = value;
			}
		}
	}

	public Color CellColor3
	{
		get
		{
			if (_oCellImage3 != null)
			{
				return _oCellImage3.color;
			}
			return Color.white;
		}
		set
		{
			if (CellColor3 != value && _oCellImage3 != null)
			{
				_oCellImage3.color = value;
			}
		}
	}

	public Image CellImage1
	{
		get
		{
			if (_oCellImage1 != null)
			{
				return _oCellImage1;
			}
			return null;
		}
		set
		{
			if (CellImage1 != value && _oCellImage1 != null)
			{
				_oCellImage1 = value;
			}
		}
	}

	public Image CellImage2
	{
		get
		{
			if (_oCellImage2 != null)
			{
				return _oCellImage2;
			}
			return null;
		}
		set
		{
			if (CellImage2 != value && _oCellImage2 != null)
			{
				_oCellImage2 = value;
			}
		}
	}

	public Image CellImage3
	{
		get
		{
			if (_oCellImage3 != null)
			{
				return _oCellImage3;
			}
			return null;
		}
		set
		{
			if (CellImage3 != value && _oCellImage3 != null)
			{
				_oCellImage3 = value;
			}
		}
	}

	public bool numtxtShow1
	{
		get
		{
			if (_onumtxt1 != null)
			{
				return _onumtxt1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (numtxtShow1 != value && _onumtxt1 != null)
			{
				_onumtxt1.SetObjectActive(value);
			}
		}
	}

	public bool numtxtShow2
	{
		get
		{
			if (_onumtxt2 != null)
			{
				return _onumtxt2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (numtxtShow2 != value && _onumtxt2 != null)
			{
				_onumtxt2.SetObjectActive(value);
			}
		}
	}

	public bool numtxtShow3
	{
		get
		{
			if (_onumtxt3 != null)
			{
				return _onumtxt3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (numtxtShow3 != value && _onumtxt3 != null)
			{
				_onumtxt3.SetObjectActive(value);
			}
		}
	}

	public string numtxtString1
	{
		get
		{
			if (_onumtxtText1 != null)
			{
				return _onumtxtText1.text;
			}
			return null;
		}
		set
		{
			if (numtxtString1 != value && _onumtxtText1 != null)
			{
				_onumtxtText1.text = value;
			}
		}
	}

	public string numtxtString2
	{
		get
		{
			if (_onumtxtText2 != null)
			{
				return _onumtxtText2.text;
			}
			return null;
		}
		set
		{
			if (numtxtString2 != value && _onumtxtText2 != null)
			{
				_onumtxtText2.text = value;
			}
		}
	}

	public string numtxtString3
	{
		get
		{
			if (_onumtxtText3 != null)
			{
				return _onumtxtText3.text;
			}
			return null;
		}
		set
		{
			if (numtxtString3 != value && _onumtxtText3 != null)
			{
				_onumtxtText3.text = value;
			}
		}
	}

	public Color numtxtTextcolor1
	{
		get
		{
			if (_onumtxtText1 != null)
			{
				return _onumtxtText1.color;
			}
			return Color.white;
		}
		set
		{
			if (numtxtTextcolor1 != value && _onumtxtText1 != null)
			{
				_onumtxtText1.color = value;
			}
		}
	}

	public Color numtxtTextcolor2
	{
		get
		{
			if (_onumtxtText2 != null)
			{
				return _onumtxtText2.color;
			}
			return Color.white;
		}
		set
		{
			if (numtxtTextcolor2 != value && _onumtxtText2 != null)
			{
				_onumtxtText2.color = value;
			}
		}
	}

	public Color numtxtTextcolor3
	{
		get
		{
			if (_onumtxtText3 != null)
			{
				return _onumtxtText3.color;
			}
			return Color.white;
		}
		set
		{
			if (numtxtTextcolor3 != value && _onumtxtText3 != null)
			{
				_onumtxtText3.color = value;
			}
		}
	}

	public bool JinbiShow
	{
		get
		{
			if (_oJinbi != null)
			{
				return _oJinbi.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (JinbiShow != value && _oJinbi != null)
			{
				_oJinbi.SetObjectActive(value);
			}
		}
	}

	public bool JinbiCountShow
	{
		get
		{
			if (_oJinbiCount != null)
			{
				return _oJinbiCount.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (JinbiCountShow != value && _oJinbiCount != null)
			{
				_oJinbiCount.SetObjectActive(value);
			}
		}
	}

	public string JinbiCountString
	{
		get
		{
			if (_oJinbiCountText != null)
			{
				return _oJinbiCountText.text;
			}
			return null;
		}
		set
		{
			if (JinbiCountString != value && _oJinbiCountText != null)
			{
				_oJinbiCountText.text = value;
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
				_oCellImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Cell2":
				_oCell2 = transform.gameObject;
				_oCellImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Cell3":
				_oCell3 = transform.gameObject;
				_oCellImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "numtxt1":
				_onumtxt1 = transform.gameObject;
				_onumtxtText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "numtxt2":
				_onumtxt2 = transform.gameObject;
				_onumtxtText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "numtxt3":
				_onumtxt3 = transform.gameObject;
				_onumtxtText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "Jinbi":
				_oJinbi = transform.gameObject;
				break;
			case "JinbiCount":
				_oJinbiCount = transform.gameObject;
				_oJinbiCountText = transform.gameObject.GetComponent<Text>();
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

	public bool GetCellShow(int index)
	{
		return index switch
		{
			1 => CellShow1, 
			2 => CellShow2, 
			3 => CellShow3, 
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
		}
	}

	public int GetCellCount()
	{
		return 3;
	}

	public Color GetCellColor(int index)
	{
		return index switch
		{
			1 => CellColor1, 
			2 => CellColor2, 
			3 => CellColor3, 
			_ => Color.white, 
		};
	}

	public void SetCellColor(int index, Color value)
	{
		switch (index)
		{
		case 1:
			CellColor1 = value;
			break;
		case 2:
			CellColor2 = value;
			break;
		case 3:
			CellColor3 = value;
			break;
		}
	}

	public Image GetCellImage(int index)
	{
		return index switch
		{
			1 => CellImage1, 
			2 => CellImage2, 
			3 => CellImage3, 
			_ => null, 
		};
	}

	public void SetCellImage(int index, Image value)
	{
		switch (index)
		{
		case 1:
			CellImage1 = value;
			break;
		case 2:
			CellImage2 = value;
			break;
		case 3:
			CellImage3 = value;
			break;
		}
	}

	public bool GetnumtxtShow(int index)
	{
		return index switch
		{
			1 => numtxtShow1, 
			2 => numtxtShow2, 
			3 => numtxtShow3, 
			_ => false, 
		};
	}

	public void SetnumtxtShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			numtxtShow1 = value;
			break;
		case 2:
			numtxtShow2 = value;
			break;
		case 3:
			numtxtShow3 = value;
			break;
		}
	}

	public int GetnumtxtCount()
	{
		return 3;
	}

	public string GetnumtxtString(int index)
	{
		return index switch
		{
			1 => numtxtString1, 
			2 => numtxtString2, 
			3 => numtxtString3, 
			_ => null, 
		};
	}

	public void SetnumtxtString(int index, string value)
	{
		switch (index)
		{
		case 1:
			numtxtString1 = value;
			break;
		case 2:
			numtxtString2 = value;
			break;
		case 3:
			numtxtString3 = value;
			break;
		}
	}

	public Color GetnumtxtTextcolor(int index)
	{
		return index switch
		{
			1 => numtxtTextcolor1, 
			2 => numtxtTextcolor2, 
			3 => numtxtTextcolor3, 
			_ => Color.white, 
		};
	}

	public void SetnumtxtTextcolor(int index, Color value)
	{
		switch (index)
		{
		case 1:
			numtxtTextcolor1 = value;
			break;
		case 2:
			numtxtTextcolor2 = value;
			break;
		case 3:
			numtxtTextcolor3 = value;
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
