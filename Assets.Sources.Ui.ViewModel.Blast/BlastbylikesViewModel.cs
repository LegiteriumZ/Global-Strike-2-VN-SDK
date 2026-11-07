using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Blast;

[GameUiTest]
public class BlastbylikesViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oLikesImage1;

	private GameObject _oLikesImage2;

	private GameObject _oLikesImage3;

	private GameObject _oLikesImage4;

	private GameObject _oLikesImage5;

	private GameObject _oLikesImage6;

	private GameObject _oLikesImage7;

	private GameObject _oLikesImage8;

	private GameObject _oLikesImage9;

	private GameObject _oLikesImage10;

	private RectTransform _oLikesImageRectTransform1;

	private RectTransform _oLikesImageRectTransform2;

	private RectTransform _oLikesImageRectTransform3;

	private RectTransform _oLikesImageRectTransform4;

	private RectTransform _oLikesImageRectTransform5;

	private RectTransform _oLikesImageRectTransform6;

	private RectTransform _oLikesImageRectTransform7;

	private RectTransform _oLikesImageRectTransform8;

	private RectTransform _oLikesImageRectTransform9;

	private RectTransform _oLikesImageRectTransform10;

	private Image _oLikesImageImage1;

	private Image _oLikesImageImage2;

	private Image _oLikesImageImage3;

	private Image _oLikesImageImage4;

	private Image _oLikesImageImage5;

	private Image _oLikesImageImage6;

	private Image _oLikesImageImage7;

	private Image _oLikesImageImage8;

	private Image _oLikesImageImage9;

	private Image _oLikesImageImage10;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/blast";

	private string _resourceAssetName = "Blastbylikes";

	public bool LikesImageShow1
	{
		get
		{
			if (_oLikesImage1 != null)
			{
				return _oLikesImage1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LikesImageShow1 != value && _oLikesImage1 != null)
			{
				_oLikesImage1.SetObjectActive(value);
			}
		}
	}

	public bool LikesImageShow2
	{
		get
		{
			if (_oLikesImage2 != null)
			{
				return _oLikesImage2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LikesImageShow2 != value && _oLikesImage2 != null)
			{
				_oLikesImage2.SetObjectActive(value);
			}
		}
	}

	public bool LikesImageShow3
	{
		get
		{
			if (_oLikesImage3 != null)
			{
				return _oLikesImage3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LikesImageShow3 != value && _oLikesImage3 != null)
			{
				_oLikesImage3.SetObjectActive(value);
			}
		}
	}

	public bool LikesImageShow4
	{
		get
		{
			if (_oLikesImage4 != null)
			{
				return _oLikesImage4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LikesImageShow4 != value && _oLikesImage4 != null)
			{
				_oLikesImage4.SetObjectActive(value);
			}
		}
	}

	public bool LikesImageShow5
	{
		get
		{
			if (_oLikesImage5 != null)
			{
				return _oLikesImage5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LikesImageShow5 != value && _oLikesImage5 != null)
			{
				_oLikesImage5.SetObjectActive(value);
			}
		}
	}

	public bool LikesImageShow6
	{
		get
		{
			if (_oLikesImage6 != null)
			{
				return _oLikesImage6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LikesImageShow6 != value && _oLikesImage6 != null)
			{
				_oLikesImage6.SetObjectActive(value);
			}
		}
	}

	public bool LikesImageShow7
	{
		get
		{
			if (_oLikesImage7 != null)
			{
				return _oLikesImage7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LikesImageShow7 != value && _oLikesImage7 != null)
			{
				_oLikesImage7.SetObjectActive(value);
			}
		}
	}

	public bool LikesImageShow8
	{
		get
		{
			if (_oLikesImage8 != null)
			{
				return _oLikesImage8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LikesImageShow8 != value && _oLikesImage8 != null)
			{
				_oLikesImage8.SetObjectActive(value);
			}
		}
	}

	public bool LikesImageShow9
	{
		get
		{
			if (_oLikesImage9 != null)
			{
				return _oLikesImage9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LikesImageShow9 != value && _oLikesImage9 != null)
			{
				_oLikesImage9.SetObjectActive(value);
			}
		}
	}

	public bool LikesImageShow10
	{
		get
		{
			if (_oLikesImage10 != null)
			{
				return _oLikesImage10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LikesImageShow10 != value && _oLikesImage10 != null)
			{
				_oLikesImage10.SetObjectActive(value);
			}
		}
	}

	public Vector3 LikesImageScale1
	{
		get
		{
			if (_oLikesImageRectTransform1 != null)
			{
				return _oLikesImageRectTransform1.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (LikesImageScale1 != value && _oLikesImageRectTransform1 != null)
			{
				_oLikesImageRectTransform1.localScale = value;
			}
		}
	}

	public Vector3 LikesImageScale2
	{
		get
		{
			if (_oLikesImageRectTransform2 != null)
			{
				return _oLikesImageRectTransform2.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (LikesImageScale2 != value && _oLikesImageRectTransform2 != null)
			{
				_oLikesImageRectTransform2.localScale = value;
			}
		}
	}

	public Vector3 LikesImageScale3
	{
		get
		{
			if (_oLikesImageRectTransform3 != null)
			{
				return _oLikesImageRectTransform3.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (LikesImageScale3 != value && _oLikesImageRectTransform3 != null)
			{
				_oLikesImageRectTransform3.localScale = value;
			}
		}
	}

	public Vector3 LikesImageScale4
	{
		get
		{
			if (_oLikesImageRectTransform4 != null)
			{
				return _oLikesImageRectTransform4.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (LikesImageScale4 != value && _oLikesImageRectTransform4 != null)
			{
				_oLikesImageRectTransform4.localScale = value;
			}
		}
	}

	public Vector3 LikesImageScale5
	{
		get
		{
			if (_oLikesImageRectTransform5 != null)
			{
				return _oLikesImageRectTransform5.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (LikesImageScale5 != value && _oLikesImageRectTransform5 != null)
			{
				_oLikesImageRectTransform5.localScale = value;
			}
		}
	}

	public Vector3 LikesImageScale6
	{
		get
		{
			if (_oLikesImageRectTransform6 != null)
			{
				return _oLikesImageRectTransform6.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (LikesImageScale6 != value && _oLikesImageRectTransform6 != null)
			{
				_oLikesImageRectTransform6.localScale = value;
			}
		}
	}

	public Vector3 LikesImageScale7
	{
		get
		{
			if (_oLikesImageRectTransform7 != null)
			{
				return _oLikesImageRectTransform7.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (LikesImageScale7 != value && _oLikesImageRectTransform7 != null)
			{
				_oLikesImageRectTransform7.localScale = value;
			}
		}
	}

	public Vector3 LikesImageScale8
	{
		get
		{
			if (_oLikesImageRectTransform8 != null)
			{
				return _oLikesImageRectTransform8.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (LikesImageScale8 != value && _oLikesImageRectTransform8 != null)
			{
				_oLikesImageRectTransform8.localScale = value;
			}
		}
	}

	public Vector3 LikesImageScale9
	{
		get
		{
			if (_oLikesImageRectTransform9 != null)
			{
				return _oLikesImageRectTransform9.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (LikesImageScale9 != value && _oLikesImageRectTransform9 != null)
			{
				_oLikesImageRectTransform9.localScale = value;
			}
		}
	}

	public Vector3 LikesImageScale10
	{
		get
		{
			if (_oLikesImageRectTransform10 != null)
			{
				return _oLikesImageRectTransform10.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (LikesImageScale10 != value && _oLikesImageRectTransform10 != null)
			{
				_oLikesImageRectTransform10.localScale = value;
			}
		}
	}

	public Sprite LikesImageSprite1
	{
		get
		{
			if (_oLikesImageImage1 != null)
			{
				return _oLikesImageImage1.sprite;
			}
			return null;
		}
		set
		{
			if (LikesImageSprite1 != value && _oLikesImageImage1 != null)
			{
				_oLikesImageImage1.sprite = value;
			}
		}
	}

	public Sprite LikesImageSprite2
	{
		get
		{
			if (_oLikesImageImage2 != null)
			{
				return _oLikesImageImage2.sprite;
			}
			return null;
		}
		set
		{
			if (LikesImageSprite2 != value && _oLikesImageImage2 != null)
			{
				_oLikesImageImage2.sprite = value;
			}
		}
	}

	public Sprite LikesImageSprite3
	{
		get
		{
			if (_oLikesImageImage3 != null)
			{
				return _oLikesImageImage3.sprite;
			}
			return null;
		}
		set
		{
			if (LikesImageSprite3 != value && _oLikesImageImage3 != null)
			{
				_oLikesImageImage3.sprite = value;
			}
		}
	}

	public Sprite LikesImageSprite4
	{
		get
		{
			if (_oLikesImageImage4 != null)
			{
				return _oLikesImageImage4.sprite;
			}
			return null;
		}
		set
		{
			if (LikesImageSprite4 != value && _oLikesImageImage4 != null)
			{
				_oLikesImageImage4.sprite = value;
			}
		}
	}

	public Sprite LikesImageSprite5
	{
		get
		{
			if (_oLikesImageImage5 != null)
			{
				return _oLikesImageImage5.sprite;
			}
			return null;
		}
		set
		{
			if (LikesImageSprite5 != value && _oLikesImageImage5 != null)
			{
				_oLikesImageImage5.sprite = value;
			}
		}
	}

	public Sprite LikesImageSprite6
	{
		get
		{
			if (_oLikesImageImage6 != null)
			{
				return _oLikesImageImage6.sprite;
			}
			return null;
		}
		set
		{
			if (LikesImageSprite6 != value && _oLikesImageImage6 != null)
			{
				_oLikesImageImage6.sprite = value;
			}
		}
	}

	public Sprite LikesImageSprite7
	{
		get
		{
			if (_oLikesImageImage7 != null)
			{
				return _oLikesImageImage7.sprite;
			}
			return null;
		}
		set
		{
			if (LikesImageSprite7 != value && _oLikesImageImage7 != null)
			{
				_oLikesImageImage7.sprite = value;
			}
		}
	}

	public Sprite LikesImageSprite8
	{
		get
		{
			if (_oLikesImageImage8 != null)
			{
				return _oLikesImageImage8.sprite;
			}
			return null;
		}
		set
		{
			if (LikesImageSprite8 != value && _oLikesImageImage8 != null)
			{
				_oLikesImageImage8.sprite = value;
			}
		}
	}

	public Sprite LikesImageSprite9
	{
		get
		{
			if (_oLikesImageImage9 != null)
			{
				return _oLikesImageImage9.sprite;
			}
			return null;
		}
		set
		{
			if (LikesImageSprite9 != value && _oLikesImageImage9 != null)
			{
				_oLikesImageImage9.sprite = value;
			}
		}
	}

	public Sprite LikesImageSprite10
	{
		get
		{
			if (_oLikesImageImage10 != null)
			{
				return _oLikesImageImage10.sprite;
			}
			return null;
		}
		set
		{
			if (LikesImageSprite10 != value && _oLikesImageImage10 != null)
			{
				_oLikesImageImage10.sprite = value;
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
			case "LikesImage1":
				_oLikesImage1 = transform.gameObject;
				_oLikesImageRectTransform1 = transform.gameObject.GetComponent<RectTransform>();
				_oLikesImageImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "LikesImage2":
				_oLikesImage2 = transform.gameObject;
				_oLikesImageRectTransform2 = transform.gameObject.GetComponent<RectTransform>();
				_oLikesImageImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "LikesImage3":
				_oLikesImage3 = transform.gameObject;
				_oLikesImageRectTransform3 = transform.gameObject.GetComponent<RectTransform>();
				_oLikesImageImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "LikesImage4":
				_oLikesImage4 = transform.gameObject;
				_oLikesImageRectTransform4 = transform.gameObject.GetComponent<RectTransform>();
				_oLikesImageImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "LikesImage5":
				_oLikesImage5 = transform.gameObject;
				_oLikesImageRectTransform5 = transform.gameObject.GetComponent<RectTransform>();
				_oLikesImageImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "LikesImage6":
				_oLikesImage6 = transform.gameObject;
				_oLikesImageRectTransform6 = transform.gameObject.GetComponent<RectTransform>();
				_oLikesImageImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "LikesImage7":
				_oLikesImage7 = transform.gameObject;
				_oLikesImageRectTransform7 = transform.gameObject.GetComponent<RectTransform>();
				_oLikesImageImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "LikesImage8":
				_oLikesImage8 = transform.gameObject;
				_oLikesImageRectTransform8 = transform.gameObject.GetComponent<RectTransform>();
				_oLikesImageImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "LikesImage9":
				_oLikesImage9 = transform.gameObject;
				_oLikesImageRectTransform9 = transform.gameObject.GetComponent<RectTransform>();
				_oLikesImageImage9 = transform.gameObject.GetComponent<Image>();
				break;
			case "LikesImage10":
				_oLikesImage10 = transform.gameObject;
				_oLikesImageRectTransform10 = transform.gameObject.GetComponent<RectTransform>();
				_oLikesImageImage10 = transform.gameObject.GetComponent<Image>();
				break;
			}
		}
	}

	public bool GetLikesImageShow(int index)
	{
		return index switch
		{
			1 => LikesImageShow1, 
			2 => LikesImageShow2, 
			3 => LikesImageShow3, 
			4 => LikesImageShow4, 
			5 => LikesImageShow5, 
			6 => LikesImageShow6, 
			7 => LikesImageShow7, 
			8 => LikesImageShow8, 
			9 => LikesImageShow9, 
			10 => LikesImageShow10, 
			_ => false, 
		};
	}

	public void SetLikesImageShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			LikesImageShow1 = value;
			break;
		case 2:
			LikesImageShow2 = value;
			break;
		case 3:
			LikesImageShow3 = value;
			break;
		case 4:
			LikesImageShow4 = value;
			break;
		case 5:
			LikesImageShow5 = value;
			break;
		case 6:
			LikesImageShow6 = value;
			break;
		case 7:
			LikesImageShow7 = value;
			break;
		case 8:
			LikesImageShow8 = value;
			break;
		case 9:
			LikesImageShow9 = value;
			break;
		case 10:
			LikesImageShow10 = value;
			break;
		}
	}

	public Vector3 GetLikesImageScale(int index)
	{
		return index switch
		{
			1 => LikesImageScale1, 
			2 => LikesImageScale2, 
			3 => LikesImageScale3, 
			4 => LikesImageScale4, 
			5 => LikesImageScale5, 
			6 => LikesImageScale6, 
			7 => LikesImageScale7, 
			8 => LikesImageScale8, 
			9 => LikesImageScale9, 
			10 => LikesImageScale10, 
			_ => Vector3.zero, 
		};
	}

	public void SetLikesImageScale(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			LikesImageScale1 = value;
			break;
		case 2:
			LikesImageScale2 = value;
			break;
		case 3:
			LikesImageScale3 = value;
			break;
		case 4:
			LikesImageScale4 = value;
			break;
		case 5:
			LikesImageScale5 = value;
			break;
		case 6:
			LikesImageScale6 = value;
			break;
		case 7:
			LikesImageScale7 = value;
			break;
		case 8:
			LikesImageScale8 = value;
			break;
		case 9:
			LikesImageScale9 = value;
			break;
		case 10:
			LikesImageScale10 = value;
			break;
		}
	}

	public Sprite GetLikesImageSprite(int index)
	{
		return index switch
		{
			1 => LikesImageSprite1, 
			2 => LikesImageSprite2, 
			3 => LikesImageSprite3, 
			4 => LikesImageSprite4, 
			5 => LikesImageSprite5, 
			6 => LikesImageSprite6, 
			7 => LikesImageSprite7, 
			8 => LikesImageSprite8, 
			9 => LikesImageSprite9, 
			10 => LikesImageSprite10, 
			_ => null, 
		};
	}

	public void SetLikesImageSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			LikesImageSprite1 = value;
			break;
		case 2:
			LikesImageSprite2 = value;
			break;
		case 3:
			LikesImageSprite3 = value;
			break;
		case 4:
			LikesImageSprite4 = value;
			break;
		case 5:
			LikesImageSprite5 = value;
			break;
		case 6:
			LikesImageSprite6 = value;
			break;
		case 7:
			LikesImageSprite7 = value;
			break;
		case 8:
			LikesImageSprite8 = value;
			break;
		case 9:
			LikesImageSprite9 = value;
			break;
		case 10:
			LikesImageSprite10 = value;
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
