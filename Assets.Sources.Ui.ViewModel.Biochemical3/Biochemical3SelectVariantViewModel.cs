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

namespace Assets.Sources.Ui.ViewModel.Biochemical3;

[GameUiTest]
public class Biochemical3SelectVariantViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oSelect1;

	private GameObject _oSelect2;

	private GameObject _oSelect3;

	private GameObject _oSelect4;

	private GameObject _oSelect5;

	private GameObject _oSelect6;

	private GameObject _oSelectImage1;

	private GameObject _oSelectImage2;

	private GameObject _oSelectImage3;

	private GameObject _oSelectImage4;

	private GameObject _oSelectImage5;

	private GameObject _oSelectImage6;

	private Image _oSelectImageImage1;

	private Image _oSelectImageImage2;

	private Image _oSelectImageImage3;

	private Image _oSelectImageImage4;

	private Image _oSelectImageImage5;

	private Image _oSelectImageImage6;

	private GameObject _oNumberSelect1;

	private GameObject _oNumberSelect2;

	private GameObject _oNumberSelect3;

	private GameObject _oNumberSelect4;

	private GameObject _oNumberSelect5;

	private GameObject _oNumberSelect6;

	private GameObject _oNohas1;

	private GameObject _oNohas2;

	private GameObject _oNohas3;

	private GameObject _oNohas4;

	private GameObject _oNohas5;

	private GameObject _oNohas6;

	private GameObject _oTime;

	private Text _oTimeText;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/biochemical3";

	private string _resourceAssetName = "Biochemical3SelectVariant";

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

	public bool SelectShow1
	{
		get
		{
			if (_oSelect1 != null)
			{
				return _oSelect1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectShow1 != value && _oSelect1 != null)
			{
				_oSelect1.SetObjectActive(value);
			}
		}
	}

	public bool SelectShow2
	{
		get
		{
			if (_oSelect2 != null)
			{
				return _oSelect2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectShow2 != value && _oSelect2 != null)
			{
				_oSelect2.SetObjectActive(value);
			}
		}
	}

	public bool SelectShow3
	{
		get
		{
			if (_oSelect3 != null)
			{
				return _oSelect3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectShow3 != value && _oSelect3 != null)
			{
				_oSelect3.SetObjectActive(value);
			}
		}
	}

	public bool SelectShow4
	{
		get
		{
			if (_oSelect4 != null)
			{
				return _oSelect4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectShow4 != value && _oSelect4 != null)
			{
				_oSelect4.SetObjectActive(value);
			}
		}
	}

	public bool SelectShow5
	{
		get
		{
			if (_oSelect5 != null)
			{
				return _oSelect5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectShow5 != value && _oSelect5 != null)
			{
				_oSelect5.SetObjectActive(value);
			}
		}
	}

	public bool SelectShow6
	{
		get
		{
			if (_oSelect6 != null)
			{
				return _oSelect6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectShow6 != value && _oSelect6 != null)
			{
				_oSelect6.SetObjectActive(value);
			}
		}
	}

	public bool SelectImageShow1
	{
		get
		{
			if (_oSelectImage1 != null)
			{
				return _oSelectImage1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectImageShow1 != value && _oSelectImage1 != null)
			{
				_oSelectImage1.SetObjectActive(value);
			}
		}
	}

	public bool SelectImageShow2
	{
		get
		{
			if (_oSelectImage2 != null)
			{
				return _oSelectImage2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectImageShow2 != value && _oSelectImage2 != null)
			{
				_oSelectImage2.SetObjectActive(value);
			}
		}
	}

	public bool SelectImageShow3
	{
		get
		{
			if (_oSelectImage3 != null)
			{
				return _oSelectImage3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectImageShow3 != value && _oSelectImage3 != null)
			{
				_oSelectImage3.SetObjectActive(value);
			}
		}
	}

	public bool SelectImageShow4
	{
		get
		{
			if (_oSelectImage4 != null)
			{
				return _oSelectImage4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectImageShow4 != value && _oSelectImage4 != null)
			{
				_oSelectImage4.SetObjectActive(value);
			}
		}
	}

	public bool SelectImageShow5
	{
		get
		{
			if (_oSelectImage5 != null)
			{
				return _oSelectImage5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectImageShow5 != value && _oSelectImage5 != null)
			{
				_oSelectImage5.SetObjectActive(value);
			}
		}
	}

	public bool SelectImageShow6
	{
		get
		{
			if (_oSelectImage6 != null)
			{
				return _oSelectImage6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectImageShow6 != value && _oSelectImage6 != null)
			{
				_oSelectImage6.SetObjectActive(value);
			}
		}
	}

	public Sprite SelectImageSprite1
	{
		get
		{
			if (_oSelectImageImage1 != null)
			{
				return _oSelectImageImage1.sprite;
			}
			return null;
		}
		set
		{
			if (SelectImageSprite1 != value && _oSelectImageImage1 != null)
			{
				_oSelectImageImage1.sprite = value;
			}
		}
	}

	public Sprite SelectImageSprite2
	{
		get
		{
			if (_oSelectImageImage2 != null)
			{
				return _oSelectImageImage2.sprite;
			}
			return null;
		}
		set
		{
			if (SelectImageSprite2 != value && _oSelectImageImage2 != null)
			{
				_oSelectImageImage2.sprite = value;
			}
		}
	}

	public Sprite SelectImageSprite3
	{
		get
		{
			if (_oSelectImageImage3 != null)
			{
				return _oSelectImageImage3.sprite;
			}
			return null;
		}
		set
		{
			if (SelectImageSprite3 != value && _oSelectImageImage3 != null)
			{
				_oSelectImageImage3.sprite = value;
			}
		}
	}

	public Sprite SelectImageSprite4
	{
		get
		{
			if (_oSelectImageImage4 != null)
			{
				return _oSelectImageImage4.sprite;
			}
			return null;
		}
		set
		{
			if (SelectImageSprite4 != value && _oSelectImageImage4 != null)
			{
				_oSelectImageImage4.sprite = value;
			}
		}
	}

	public Sprite SelectImageSprite5
	{
		get
		{
			if (_oSelectImageImage5 != null)
			{
				return _oSelectImageImage5.sprite;
			}
			return null;
		}
		set
		{
			if (SelectImageSprite5 != value && _oSelectImageImage5 != null)
			{
				_oSelectImageImage5.sprite = value;
			}
		}
	}

	public Sprite SelectImageSprite6
	{
		get
		{
			if (_oSelectImageImage6 != null)
			{
				return _oSelectImageImage6.sprite;
			}
			return null;
		}
		set
		{
			if (SelectImageSprite6 != value && _oSelectImageImage6 != null)
			{
				_oSelectImageImage6.sprite = value;
			}
		}
	}

	public bool NumberSelectShow1
	{
		get
		{
			if (_oNumberSelect1 != null)
			{
				return _oNumberSelect1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NumberSelectShow1 != value && _oNumberSelect1 != null)
			{
				_oNumberSelect1.SetObjectActive(value);
			}
		}
	}

	public bool NumberSelectShow2
	{
		get
		{
			if (_oNumberSelect2 != null)
			{
				return _oNumberSelect2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NumberSelectShow2 != value && _oNumberSelect2 != null)
			{
				_oNumberSelect2.SetObjectActive(value);
			}
		}
	}

	public bool NumberSelectShow3
	{
		get
		{
			if (_oNumberSelect3 != null)
			{
				return _oNumberSelect3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NumberSelectShow3 != value && _oNumberSelect3 != null)
			{
				_oNumberSelect3.SetObjectActive(value);
			}
		}
	}

	public bool NumberSelectShow4
	{
		get
		{
			if (_oNumberSelect4 != null)
			{
				return _oNumberSelect4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NumberSelectShow4 != value && _oNumberSelect4 != null)
			{
				_oNumberSelect4.SetObjectActive(value);
			}
		}
	}

	public bool NumberSelectShow5
	{
		get
		{
			if (_oNumberSelect5 != null)
			{
				return _oNumberSelect5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NumberSelectShow5 != value && _oNumberSelect5 != null)
			{
				_oNumberSelect5.SetObjectActive(value);
			}
		}
	}

	public bool NumberSelectShow6
	{
		get
		{
			if (_oNumberSelect6 != null)
			{
				return _oNumberSelect6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NumberSelectShow6 != value && _oNumberSelect6 != null)
			{
				_oNumberSelect6.SetObjectActive(value);
			}
		}
	}

	public bool NohasShow1
	{
		get
		{
			if (_oNohas1 != null)
			{
				return _oNohas1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NohasShow1 != value && _oNohas1 != null)
			{
				_oNohas1.SetObjectActive(value);
			}
		}
	}

	public bool NohasShow2
	{
		get
		{
			if (_oNohas2 != null)
			{
				return _oNohas2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NohasShow2 != value && _oNohas2 != null)
			{
				_oNohas2.SetObjectActive(value);
			}
		}
	}

	public bool NohasShow3
	{
		get
		{
			if (_oNohas3 != null)
			{
				return _oNohas3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NohasShow3 != value && _oNohas3 != null)
			{
				_oNohas3.SetObjectActive(value);
			}
		}
	}

	public bool NohasShow4
	{
		get
		{
			if (_oNohas4 != null)
			{
				return _oNohas4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NohasShow4 != value && _oNohas4 != null)
			{
				_oNohas4.SetObjectActive(value);
			}
		}
	}

	public bool NohasShow5
	{
		get
		{
			if (_oNohas5 != null)
			{
				return _oNohas5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NohasShow5 != value && _oNohas5 != null)
			{
				_oNohas5.SetObjectActive(value);
			}
		}
	}

	public bool NohasShow6
	{
		get
		{
			if (_oNohas6 != null)
			{
				return _oNohas6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NohasShow6 != value && _oNohas6 != null)
			{
				_oNohas6.SetObjectActive(value);
			}
		}
	}

	public string TimeString
	{
		get
		{
			if (_oTimeText != null)
			{
				return _oTimeText.text;
			}
			return null;
		}
		set
		{
			if (TimeString != value && _oTimeText != null)
			{
				_oTimeText.text = value;
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
			case "Select1":
				_oSelect1 = transform.gameObject;
				break;
			case "Select2":
				_oSelect2 = transform.gameObject;
				break;
			case "Select3":
				_oSelect3 = transform.gameObject;
				break;
			case "Select4":
				_oSelect4 = transform.gameObject;
				break;
			case "Select5":
				_oSelect5 = transform.gameObject;
				break;
			case "Select6":
				_oSelect6 = transform.gameObject;
				break;
			case "SelectImage1":
				_oSelectImage1 = transform.gameObject;
				_oSelectImageImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "SelectImage2":
				_oSelectImage2 = transform.gameObject;
				_oSelectImageImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "SelectImage3":
				_oSelectImage3 = transform.gameObject;
				_oSelectImageImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "SelectImage4":
				_oSelectImage4 = transform.gameObject;
				_oSelectImageImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "SelectImage5":
				_oSelectImage5 = transform.gameObject;
				_oSelectImageImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "SelectImage6":
				_oSelectImage6 = transform.gameObject;
				_oSelectImageImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "NumberSelect1":
				_oNumberSelect1 = transform.gameObject;
				break;
			case "NumberSelect2":
				_oNumberSelect2 = transform.gameObject;
				break;
			case "NumberSelect3":
				_oNumberSelect3 = transform.gameObject;
				break;
			case "NumberSelect4":
				_oNumberSelect4 = transform.gameObject;
				break;
			case "NumberSelect5":
				_oNumberSelect5 = transform.gameObject;
				break;
			case "NumberSelect6":
				_oNumberSelect6 = transform.gameObject;
				break;
			case "Nohas1":
				_oNohas1 = transform.gameObject;
				break;
			case "Nohas2":
				_oNohas2 = transform.gameObject;
				break;
			case "Nohas3":
				_oNohas3 = transform.gameObject;
				break;
			case "Nohas4":
				_oNohas4 = transform.gameObject;
				break;
			case "Nohas5":
				_oNohas5 = transform.gameObject;
				break;
			case "Nohas6":
				_oNohas6 = transform.gameObject;
				break;
			case "Time":
				_oTime = transform.gameObject;
				_oTimeText = transform.gameObject.GetComponent<Text>();
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

	public bool GetSelectShow(int index)
	{
		return index switch
		{
			1 => SelectShow1, 
			2 => SelectShow2, 
			3 => SelectShow3, 
			4 => SelectShow4, 
			5 => SelectShow5, 
			6 => SelectShow6, 
			_ => false, 
		};
	}

	public void SetSelectShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			SelectShow1 = value;
			break;
		case 2:
			SelectShow2 = value;
			break;
		case 3:
			SelectShow3 = value;
			break;
		case 4:
			SelectShow4 = value;
			break;
		case 5:
			SelectShow5 = value;
			break;
		case 6:
			SelectShow6 = value;
			break;
		}
	}

	public bool GetSelectImageShow(int index)
	{
		return index switch
		{
			1 => SelectImageShow1, 
			2 => SelectImageShow2, 
			3 => SelectImageShow3, 
			4 => SelectImageShow4, 
			5 => SelectImageShow5, 
			6 => SelectImageShow6, 
			_ => false, 
		};
	}

	public void SetSelectImageShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			SelectImageShow1 = value;
			break;
		case 2:
			SelectImageShow2 = value;
			break;
		case 3:
			SelectImageShow3 = value;
			break;
		case 4:
			SelectImageShow4 = value;
			break;
		case 5:
			SelectImageShow5 = value;
			break;
		case 6:
			SelectImageShow6 = value;
			break;
		}
	}

	public Sprite GetSelectImageSprite(int index)
	{
		return index switch
		{
			1 => SelectImageSprite1, 
			2 => SelectImageSprite2, 
			3 => SelectImageSprite3, 
			4 => SelectImageSprite4, 
			5 => SelectImageSprite5, 
			6 => SelectImageSprite6, 
			_ => null, 
		};
	}

	public void SetSelectImageSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			SelectImageSprite1 = value;
			break;
		case 2:
			SelectImageSprite2 = value;
			break;
		case 3:
			SelectImageSprite3 = value;
			break;
		case 4:
			SelectImageSprite4 = value;
			break;
		case 5:
			SelectImageSprite5 = value;
			break;
		case 6:
			SelectImageSprite6 = value;
			break;
		}
	}

	public bool GetNumberSelectShow(int index)
	{
		return index switch
		{
			1 => NumberSelectShow1, 
			2 => NumberSelectShow2, 
			3 => NumberSelectShow3, 
			4 => NumberSelectShow4, 
			5 => NumberSelectShow5, 
			6 => NumberSelectShow6, 
			_ => false, 
		};
	}

	public void SetNumberSelectShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			NumberSelectShow1 = value;
			break;
		case 2:
			NumberSelectShow2 = value;
			break;
		case 3:
			NumberSelectShow3 = value;
			break;
		case 4:
			NumberSelectShow4 = value;
			break;
		case 5:
			NumberSelectShow5 = value;
			break;
		case 6:
			NumberSelectShow6 = value;
			break;
		}
	}

	public bool GetNohasShow(int index)
	{
		return index switch
		{
			1 => NohasShow1, 
			2 => NohasShow2, 
			3 => NohasShow3, 
			4 => NohasShow4, 
			5 => NohasShow5, 
			6 => NohasShow6, 
			_ => false, 
		};
	}

	public void SetNohasShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			NohasShow1 = value;
			break;
		case 2:
			NohasShow2 = value;
			break;
		case 3:
			NohasShow3 = value;
			break;
		case 4:
			NohasShow4 = value;
			break;
		case 5:
			NohasShow5 = value;
			break;
		case 6:
			NohasShow6 = value;
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

	public List<RectTransform> GetHoldPosIntergeTrans()
	{
		return null;
	}
}
