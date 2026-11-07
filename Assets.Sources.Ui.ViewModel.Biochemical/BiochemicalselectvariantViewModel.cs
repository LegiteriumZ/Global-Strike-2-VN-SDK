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

namespace Assets.Sources.Ui.ViewModel.Biochemical;

[GameUiTest]
public class BiochemicalselectvariantViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oBottom;

	private GameObject _oCheckedImage1;

	private GameObject _oCheckedImage2;

	private GameObject _oCheckedImage3;

	private GameObject _oCheckedImage4;

	private GameObject _oCheckedImage5;

	private GameObject _oCheckedImage6;

	private GameObject _oCheckedImage7;

	private GameObject _oCheckedImage8;

	private GameObject _oCheckedImage9;

	private GameObject _oNoHaveImage1;

	private GameObject _oNoHaveImage2;

	private GameObject _oNoHaveImage3;

	private GameObject _oNoHaveImage4;

	private GameObject _oNoHaveImage5;

	private GameObject _oNoHaveImage6;

	private GameObject _oNoHaveImage7;

	private GameObject _oNoHaveImage8;

	private GameObject _oNoHaveImage9;

	private GameObject _oTimeText;

	private Text _oTimeTextText;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/biochemical";

	private string _resourceAssetName = "Biochemicalselectvariant";

	private List<RectTransform> _holdPosTrans;

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

	public bool CheckedImageShow1
	{
		get
		{
			if (_oCheckedImage1 != null)
			{
				return _oCheckedImage1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CheckedImageShow1 != value && _oCheckedImage1 != null)
			{
				_oCheckedImage1.SetObjectActive(value);
			}
		}
	}

	public bool CheckedImageShow2
	{
		get
		{
			if (_oCheckedImage2 != null)
			{
				return _oCheckedImage2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CheckedImageShow2 != value && _oCheckedImage2 != null)
			{
				_oCheckedImage2.SetObjectActive(value);
			}
		}
	}

	public bool CheckedImageShow3
	{
		get
		{
			if (_oCheckedImage3 != null)
			{
				return _oCheckedImage3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CheckedImageShow3 != value && _oCheckedImage3 != null)
			{
				_oCheckedImage3.SetObjectActive(value);
			}
		}
	}

	public bool CheckedImageShow4
	{
		get
		{
			if (_oCheckedImage4 != null)
			{
				return _oCheckedImage4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CheckedImageShow4 != value && _oCheckedImage4 != null)
			{
				_oCheckedImage4.SetObjectActive(value);
			}
		}
	}

	public bool CheckedImageShow5
	{
		get
		{
			if (_oCheckedImage5 != null)
			{
				return _oCheckedImage5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CheckedImageShow5 != value && _oCheckedImage5 != null)
			{
				_oCheckedImage5.SetObjectActive(value);
			}
		}
	}

	public bool CheckedImageShow6
	{
		get
		{
			if (_oCheckedImage6 != null)
			{
				return _oCheckedImage6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CheckedImageShow6 != value && _oCheckedImage6 != null)
			{
				_oCheckedImage6.SetObjectActive(value);
			}
		}
	}

	public bool CheckedImageShow7
	{
		get
		{
			if (_oCheckedImage7 != null)
			{
				return _oCheckedImage7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CheckedImageShow7 != value && _oCheckedImage7 != null)
			{
				_oCheckedImage7.SetObjectActive(value);
			}
		}
	}

	public bool CheckedImageShow8
	{
		get
		{
			if (_oCheckedImage8 != null)
			{
				return _oCheckedImage8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CheckedImageShow8 != value && _oCheckedImage8 != null)
			{
				_oCheckedImage8.SetObjectActive(value);
			}
		}
	}

	public bool CheckedImageShow9
	{
		get
		{
			if (_oCheckedImage9 != null)
			{
				return _oCheckedImage9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CheckedImageShow9 != value && _oCheckedImage9 != null)
			{
				_oCheckedImage9.SetObjectActive(value);
			}
		}
	}

	public bool NoHaveImageShow1
	{
		get
		{
			if (_oNoHaveImage1 != null)
			{
				return _oNoHaveImage1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NoHaveImageShow1 != value && _oNoHaveImage1 != null)
			{
				_oNoHaveImage1.SetObjectActive(value);
			}
		}
	}

	public bool NoHaveImageShow2
	{
		get
		{
			if (_oNoHaveImage2 != null)
			{
				return _oNoHaveImage2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NoHaveImageShow2 != value && _oNoHaveImage2 != null)
			{
				_oNoHaveImage2.SetObjectActive(value);
			}
		}
	}

	public bool NoHaveImageShow3
	{
		get
		{
			if (_oNoHaveImage3 != null)
			{
				return _oNoHaveImage3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NoHaveImageShow3 != value && _oNoHaveImage3 != null)
			{
				_oNoHaveImage3.SetObjectActive(value);
			}
		}
	}

	public bool NoHaveImageShow4
	{
		get
		{
			if (_oNoHaveImage4 != null)
			{
				return _oNoHaveImage4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NoHaveImageShow4 != value && _oNoHaveImage4 != null)
			{
				_oNoHaveImage4.SetObjectActive(value);
			}
		}
	}

	public bool NoHaveImageShow5
	{
		get
		{
			if (_oNoHaveImage5 != null)
			{
				return _oNoHaveImage5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NoHaveImageShow5 != value && _oNoHaveImage5 != null)
			{
				_oNoHaveImage5.SetObjectActive(value);
			}
		}
	}

	public bool NoHaveImageShow6
	{
		get
		{
			if (_oNoHaveImage6 != null)
			{
				return _oNoHaveImage6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NoHaveImageShow6 != value && _oNoHaveImage6 != null)
			{
				_oNoHaveImage6.SetObjectActive(value);
			}
		}
	}

	public bool NoHaveImageShow7
	{
		get
		{
			if (_oNoHaveImage7 != null)
			{
				return _oNoHaveImage7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NoHaveImageShow7 != value && _oNoHaveImage7 != null)
			{
				_oNoHaveImage7.SetObjectActive(value);
			}
		}
	}

	public bool NoHaveImageShow8
	{
		get
		{
			if (_oNoHaveImage8 != null)
			{
				return _oNoHaveImage8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NoHaveImageShow8 != value && _oNoHaveImage8 != null)
			{
				_oNoHaveImage8.SetObjectActive(value);
			}
		}
	}

	public bool NoHaveImageShow9
	{
		get
		{
			if (_oNoHaveImage9 != null)
			{
				return _oNoHaveImage9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NoHaveImageShow9 != value && _oNoHaveImage9 != null)
			{
				_oNoHaveImage9.SetObjectActive(value);
			}
		}
	}

	public string TimeTextString
	{
		get
		{
			if (_oTimeTextText != null)
			{
				return _oTimeTextText.text;
			}
			return null;
		}
		set
		{
			if (TimeTextString != value && _oTimeTextText != null)
			{
				_oTimeTextText.text = value;
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
			case "CheckedImage1":
				_oCheckedImage1 = transform.gameObject;
				break;
			case "CheckedImage2":
				_oCheckedImage2 = transform.gameObject;
				break;
			case "CheckedImage3":
				_oCheckedImage3 = transform.gameObject;
				break;
			case "CheckedImage4":
				_oCheckedImage4 = transform.gameObject;
				break;
			case "CheckedImage5":
				_oCheckedImage5 = transform.gameObject;
				break;
			case "CheckedImage6":
				_oCheckedImage6 = transform.gameObject;
				break;
			case "CheckedImage7":
				_oCheckedImage7 = transform.gameObject;
				break;
			case "CheckedImage8":
				_oCheckedImage8 = transform.gameObject;
				break;
			case "CheckedImage9":
				_oCheckedImage9 = transform.gameObject;
				break;
			case "NoHaveImage1":
				_oNoHaveImage1 = transform.gameObject;
				break;
			case "NoHaveImage2":
				_oNoHaveImage2 = transform.gameObject;
				break;
			case "NoHaveImage3":
				_oNoHaveImage3 = transform.gameObject;
				break;
			case "NoHaveImage4":
				_oNoHaveImage4 = transform.gameObject;
				break;
			case "NoHaveImage5":
				_oNoHaveImage5 = transform.gameObject;
				break;
			case "NoHaveImage6":
				_oNoHaveImage6 = transform.gameObject;
				break;
			case "NoHaveImage7":
				_oNoHaveImage7 = transform.gameObject;
				break;
			case "NoHaveImage8":
				_oNoHaveImage8 = transform.gameObject;
				break;
			case "NoHaveImage9":
				_oNoHaveImage9 = transform.gameObject;
				break;
			case "TimeText":
				_oTimeText = transform.gameObject;
				_oTimeTextText = transform.gameObject.GetComponent<Text>();
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

	public bool GetCheckedImageShow(int index)
	{
		return index switch
		{
			1 => CheckedImageShow1, 
			2 => CheckedImageShow2, 
			3 => CheckedImageShow3, 
			4 => CheckedImageShow4, 
			5 => CheckedImageShow5, 
			6 => CheckedImageShow6, 
			7 => CheckedImageShow7, 
			8 => CheckedImageShow8, 
			9 => CheckedImageShow9, 
			_ => false, 
		};
	}

	public void SetCheckedImageShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			CheckedImageShow1 = value;
			break;
		case 2:
			CheckedImageShow2 = value;
			break;
		case 3:
			CheckedImageShow3 = value;
			break;
		case 4:
			CheckedImageShow4 = value;
			break;
		case 5:
			CheckedImageShow5 = value;
			break;
		case 6:
			CheckedImageShow6 = value;
			break;
		case 7:
			CheckedImageShow7 = value;
			break;
		case 8:
			CheckedImageShow8 = value;
			break;
		case 9:
			CheckedImageShow9 = value;
			break;
		}
	}

	public int GetCheckedImageCount()
	{
		return 9;
	}

	public bool GetNoHaveImageShow(int index)
	{
		return index switch
		{
			1 => NoHaveImageShow1, 
			2 => NoHaveImageShow2, 
			3 => NoHaveImageShow3, 
			4 => NoHaveImageShow4, 
			5 => NoHaveImageShow5, 
			6 => NoHaveImageShow6, 
			7 => NoHaveImageShow7, 
			8 => NoHaveImageShow8, 
			9 => NoHaveImageShow9, 
			_ => false, 
		};
	}

	public void SetNoHaveImageShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			NoHaveImageShow1 = value;
			break;
		case 2:
			NoHaveImageShow2 = value;
			break;
		case 3:
			NoHaveImageShow3 = value;
			break;
		case 4:
			NoHaveImageShow4 = value;
			break;
		case 5:
			NoHaveImageShow5 = value;
			break;
		case 6:
			NoHaveImageShow6 = value;
			break;
		case 7:
			NoHaveImageShow7 = value;
			break;
		case 8:
			NoHaveImageShow8 = value;
			break;
		case 9:
			NoHaveImageShow9 = value;
			break;
		}
	}

	public int GetNoHaveImageCount()
	{
		return 9;
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

	public List<RectTransform> GetHoldPosIntergeTrans()
	{
		if (_holdPosTrans != null)
		{
			return _holdPosTrans;
		}
		_holdPosTrans = new List<RectTransform>();
		if (_oTimeTextText != null)
		{
			_holdPosTrans.Add(_oTimeTextText.GetComponent<RectTransform>());
		}
		return _holdPosTrans;
	}
}
