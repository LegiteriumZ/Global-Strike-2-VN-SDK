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
public class GunGloryViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oGlory1;

	private GameObject _oGlory2;

	private GameObject _oGlory3;

	private Image _oGloryImage1;

	private Image _oGloryImage2;

	private Image _oGloryImage3;

	private GameObject _oEffect1;

	private GameObject _oEffect2;

	private GameObject _oEffect3;

	private Image _oEffectImage1;

	private Image _oEffectImage2;

	private Image _oEffectImage3;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/common";

	private string _resourceAssetName = "GunGlory";

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

	public bool GloryShow1
	{
		get
		{
			if (_oGlory1 != null)
			{
				return _oGlory1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GloryShow1 != value && _oGlory1 != null)
			{
				_oGlory1.SetObjectActive(value);
			}
		}
	}

	public bool GloryShow2
	{
		get
		{
			if (_oGlory2 != null)
			{
				return _oGlory2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GloryShow2 != value && _oGlory2 != null)
			{
				_oGlory2.SetObjectActive(value);
			}
		}
	}

	public bool GloryShow3
	{
		get
		{
			if (_oGlory3 != null)
			{
				return _oGlory3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GloryShow3 != value && _oGlory3 != null)
			{
				_oGlory3.SetObjectActive(value);
			}
		}
	}

	public Sprite GlorySprite1
	{
		get
		{
			if (_oGloryImage1 != null)
			{
				return _oGloryImage1.sprite;
			}
			return null;
		}
		set
		{
			if (GlorySprite1 != value && _oGloryImage1 != null)
			{
				_oGloryImage1.sprite = value;
			}
		}
	}

	public Sprite GlorySprite2
	{
		get
		{
			if (_oGloryImage2 != null)
			{
				return _oGloryImage2.sprite;
			}
			return null;
		}
		set
		{
			if (GlorySprite2 != value && _oGloryImage2 != null)
			{
				_oGloryImage2.sprite = value;
			}
		}
	}

	public Sprite GlorySprite3
	{
		get
		{
			if (_oGloryImage3 != null)
			{
				return _oGloryImage3.sprite;
			}
			return null;
		}
		set
		{
			if (GlorySprite3 != value && _oGloryImage3 != null)
			{
				_oGloryImage3.sprite = value;
			}
		}
	}

	public bool EffectShow1
	{
		get
		{
			if (_oEffect1 != null)
			{
				return _oEffect1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (EffectShow1 != value && _oEffect1 != null)
			{
				_oEffect1.SetObjectActive(value);
			}
		}
	}

	public bool EffectShow2
	{
		get
		{
			if (_oEffect2 != null)
			{
				return _oEffect2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (EffectShow2 != value && _oEffect2 != null)
			{
				_oEffect2.SetObjectActive(value);
			}
		}
	}

	public bool EffectShow3
	{
		get
		{
			if (_oEffect3 != null)
			{
				return _oEffect3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (EffectShow3 != value && _oEffect3 != null)
			{
				_oEffect3.SetObjectActive(value);
			}
		}
	}

	public Sprite EffectSprite1
	{
		get
		{
			if (_oEffectImage1 != null)
			{
				return _oEffectImage1.sprite;
			}
			return null;
		}
		set
		{
			if (EffectSprite1 != value && _oEffectImage1 != null)
			{
				_oEffectImage1.sprite = value;
			}
		}
	}

	public Sprite EffectSprite2
	{
		get
		{
			if (_oEffectImage2 != null)
			{
				return _oEffectImage2.sprite;
			}
			return null;
		}
		set
		{
			if (EffectSprite2 != value && _oEffectImage2 != null)
			{
				_oEffectImage2.sprite = value;
			}
		}
	}

	public Sprite EffectSprite3
	{
		get
		{
			if (_oEffectImage3 != null)
			{
				return _oEffectImage3.sprite;
			}
			return null;
		}
		set
		{
			if (EffectSprite3 != value && _oEffectImage3 != null)
			{
				_oEffectImage3.sprite = value;
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
			case "Glory1":
				_oGlory1 = transform.gameObject;
				_oGloryImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Glory2":
				_oGlory2 = transform.gameObject;
				_oGloryImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Glory3":
				_oGlory3 = transform.gameObject;
				_oGloryImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Effect1":
				_oEffect1 = transform.gameObject;
				_oEffectImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Effect2":
				_oEffect2 = transform.gameObject;
				_oEffectImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Effect3":
				_oEffect3 = transform.gameObject;
				_oEffectImage3 = transform.gameObject.GetComponent<Image>();
				break;
			}
		}
	}

	public bool GetGloryShow(int index)
	{
		return index switch
		{
			1 => GloryShow1, 
			2 => GloryShow2, 
			3 => GloryShow3, 
			_ => false, 
		};
	}

	public void SetGloryShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			GloryShow1 = value;
			break;
		case 2:
			GloryShow2 = value;
			break;
		case 3:
			GloryShow3 = value;
			break;
		}
	}

	public Sprite GetGlorySprite(int index)
	{
		return index switch
		{
			1 => GlorySprite1, 
			2 => GlorySprite2, 
			3 => GlorySprite3, 
			_ => null, 
		};
	}

	public void SetGlorySprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			GlorySprite1 = value;
			break;
		case 2:
			GlorySprite2 = value;
			break;
		case 3:
			GlorySprite3 = value;
			break;
		}
	}

	public bool GetEffectShow(int index)
	{
		return index switch
		{
			1 => EffectShow1, 
			2 => EffectShow2, 
			3 => EffectShow3, 
			_ => false, 
		};
	}

	public void SetEffectShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			EffectShow1 = value;
			break;
		case 2:
			EffectShow2 = value;
			break;
		case 3:
			EffectShow3 = value;
			break;
		}
	}

	public Sprite GetEffectSprite(int index)
	{
		return index switch
		{
			1 => EffectSprite1, 
			2 => EffectSprite2, 
			3 => EffectSprite3, 
			_ => null, 
		};
	}

	public void SetEffectSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			EffectSprite1 = value;
			break;
		case 2:
			EffectSprite2 = value;
			break;
		case 3:
			EffectSprite3 = value;
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
