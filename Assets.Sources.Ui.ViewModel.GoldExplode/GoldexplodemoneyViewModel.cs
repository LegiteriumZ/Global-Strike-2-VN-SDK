using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.GoldExplode;

[GameUiTest]
public class GoldexplodemoneyViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oMoneyText;

	private Text _oMoneyTextText;

	private GameObject _oAddText1;

	private GameObject _oAddText2;

	private GameObject _oAddText3;

	private RectTransform _oAddTextRectTransform1;

	private RectTransform _oAddTextRectTransform2;

	private RectTransform _oAddTextRectTransform3;

	private Text _oAddTextText1;

	private Text _oAddTextText2;

	private Text _oAddTextText3;

	private CanvasGroup _oAddTextCanvasGroup1;

	private CanvasGroup _oAddTextCanvasGroup2;

	private CanvasGroup _oAddTextCanvasGroup3;

	private GameObject _oLoseText1;

	private GameObject _oLoseText2;

	private GameObject _oLoseText3;

	private RectTransform _oLoseTextRectTransform1;

	private RectTransform _oLoseTextRectTransform2;

	private RectTransform _oLoseTextRectTransform3;

	private Text _oLoseTextText1;

	private Text _oLoseTextText2;

	private Text _oLoseTextText3;

	private CanvasGroup _oLoseTextCanvasGroup1;

	private CanvasGroup _oLoseTextCanvasGroup2;

	private CanvasGroup _oLoseTextCanvasGroup3;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/goldexplode";

	private string _resourceAssetName = "Goldexplodemoney";

	public string MoneyTextString
	{
		get
		{
			if (_oMoneyTextText != null)
			{
				return _oMoneyTextText.text;
			}
			return null;
		}
		set
		{
			if (MoneyTextString != value && _oMoneyTextText != null)
			{
				_oMoneyTextText.text = value;
			}
		}
	}

	public bool AddTextShow1
	{
		get
		{
			if (_oAddText1 != null)
			{
				return _oAddText1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AddTextShow1 != value && _oAddText1 != null)
			{
				_oAddText1.SetObjectActive(value);
			}
		}
	}

	public bool AddTextShow2
	{
		get
		{
			if (_oAddText2 != null)
			{
				return _oAddText2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AddTextShow2 != value && _oAddText2 != null)
			{
				_oAddText2.SetObjectActive(value);
			}
		}
	}

	public bool AddTextShow3
	{
		get
		{
			if (_oAddText3 != null)
			{
				return _oAddText3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AddTextShow3 != value && _oAddText3 != null)
			{
				_oAddText3.SetObjectActive(value);
			}
		}
	}

	public Vector3 AddTextPosition1
	{
		get
		{
			if (_oAddTextRectTransform1 != null)
			{
				return _oAddTextRectTransform1.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (AddTextPosition1 != value && _oAddTextRectTransform1 != null)
			{
				_oAddTextRectTransform1.localPosition = value;
			}
		}
	}

	public Vector3 AddTextPosition2
	{
		get
		{
			if (_oAddTextRectTransform2 != null)
			{
				return _oAddTextRectTransform2.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (AddTextPosition2 != value && _oAddTextRectTransform2 != null)
			{
				_oAddTextRectTransform2.localPosition = value;
			}
		}
	}

	public Vector3 AddTextPosition3
	{
		get
		{
			if (_oAddTextRectTransform3 != null)
			{
				return _oAddTextRectTransform3.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (AddTextPosition3 != value && _oAddTextRectTransform3 != null)
			{
				_oAddTextRectTransform3.localPosition = value;
			}
		}
	}

	public string AddTextString1
	{
		get
		{
			if (_oAddTextText1 != null)
			{
				return _oAddTextText1.text;
			}
			return null;
		}
		set
		{
			if (AddTextString1 != value && _oAddTextText1 != null)
			{
				_oAddTextText1.text = value;
			}
		}
	}

	public string AddTextString2
	{
		get
		{
			if (_oAddTextText2 != null)
			{
				return _oAddTextText2.text;
			}
			return null;
		}
		set
		{
			if (AddTextString2 != value && _oAddTextText2 != null)
			{
				_oAddTextText2.text = value;
			}
		}
	}

	public string AddTextString3
	{
		get
		{
			if (_oAddTextText3 != null)
			{
				return _oAddTextText3.text;
			}
			return null;
		}
		set
		{
			if (AddTextString3 != value && _oAddTextText3 != null)
			{
				_oAddTextText3.text = value;
			}
		}
	}

	public float AddTextAlpha1
	{
		get
		{
			if (_oAddTextCanvasGroup1 != null)
			{
				return _oAddTextCanvasGroup1.alpha;
			}
			return 0f;
		}
		set
		{
			if (AddTextAlpha1 != value && _oAddTextCanvasGroup1 != null)
			{
				_oAddTextCanvasGroup1.alpha = value;
			}
		}
	}

	public float AddTextAlpha2
	{
		get
		{
			if (_oAddTextCanvasGroup2 != null)
			{
				return _oAddTextCanvasGroup2.alpha;
			}
			return 0f;
		}
		set
		{
			if (AddTextAlpha2 != value && _oAddTextCanvasGroup2 != null)
			{
				_oAddTextCanvasGroup2.alpha = value;
			}
		}
	}

	public float AddTextAlpha3
	{
		get
		{
			if (_oAddTextCanvasGroup3 != null)
			{
				return _oAddTextCanvasGroup3.alpha;
			}
			return 0f;
		}
		set
		{
			if (AddTextAlpha3 != value && _oAddTextCanvasGroup3 != null)
			{
				_oAddTextCanvasGroup3.alpha = value;
			}
		}
	}

	public bool LoseTextShow1
	{
		get
		{
			if (_oLoseText1 != null)
			{
				return _oLoseText1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LoseTextShow1 != value && _oLoseText1 != null)
			{
				_oLoseText1.SetObjectActive(value);
			}
		}
	}

	public bool LoseTextShow2
	{
		get
		{
			if (_oLoseText2 != null)
			{
				return _oLoseText2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LoseTextShow2 != value && _oLoseText2 != null)
			{
				_oLoseText2.SetObjectActive(value);
			}
		}
	}

	public bool LoseTextShow3
	{
		get
		{
			if (_oLoseText3 != null)
			{
				return _oLoseText3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LoseTextShow3 != value && _oLoseText3 != null)
			{
				_oLoseText3.SetObjectActive(value);
			}
		}
	}

	public Vector3 LoseTextPosition1
	{
		get
		{
			if (_oLoseTextRectTransform1 != null)
			{
				return _oLoseTextRectTransform1.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (LoseTextPosition1 != value && _oLoseTextRectTransform1 != null)
			{
				_oLoseTextRectTransform1.localPosition = value;
			}
		}
	}

	public Vector3 LoseTextPosition2
	{
		get
		{
			if (_oLoseTextRectTransform2 != null)
			{
				return _oLoseTextRectTransform2.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (LoseTextPosition2 != value && _oLoseTextRectTransform2 != null)
			{
				_oLoseTextRectTransform2.localPosition = value;
			}
		}
	}

	public Vector3 LoseTextPosition3
	{
		get
		{
			if (_oLoseTextRectTransform3 != null)
			{
				return _oLoseTextRectTransform3.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (LoseTextPosition3 != value && _oLoseTextRectTransform3 != null)
			{
				_oLoseTextRectTransform3.localPosition = value;
			}
		}
	}

	public string LoseTextString1
	{
		get
		{
			if (_oLoseTextText1 != null)
			{
				return _oLoseTextText1.text;
			}
			return null;
		}
		set
		{
			if (LoseTextString1 != value && _oLoseTextText1 != null)
			{
				_oLoseTextText1.text = value;
			}
		}
	}

	public string LoseTextString2
	{
		get
		{
			if (_oLoseTextText2 != null)
			{
				return _oLoseTextText2.text;
			}
			return null;
		}
		set
		{
			if (LoseTextString2 != value && _oLoseTextText2 != null)
			{
				_oLoseTextText2.text = value;
			}
		}
	}

	public string LoseTextString3
	{
		get
		{
			if (_oLoseTextText3 != null)
			{
				return _oLoseTextText3.text;
			}
			return null;
		}
		set
		{
			if (LoseTextString3 != value && _oLoseTextText3 != null)
			{
				_oLoseTextText3.text = value;
			}
		}
	}

	public float LoseTextAlpha1
	{
		get
		{
			if (_oLoseTextCanvasGroup1 != null)
			{
				return _oLoseTextCanvasGroup1.alpha;
			}
			return 0f;
		}
		set
		{
			if (LoseTextAlpha1 != value && _oLoseTextCanvasGroup1 != null)
			{
				_oLoseTextCanvasGroup1.alpha = value;
			}
		}
	}

	public float LoseTextAlpha2
	{
		get
		{
			if (_oLoseTextCanvasGroup2 != null)
			{
				return _oLoseTextCanvasGroup2.alpha;
			}
			return 0f;
		}
		set
		{
			if (LoseTextAlpha2 != value && _oLoseTextCanvasGroup2 != null)
			{
				_oLoseTextCanvasGroup2.alpha = value;
			}
		}
	}

	public float LoseTextAlpha3
	{
		get
		{
			if (_oLoseTextCanvasGroup3 != null)
			{
				return _oLoseTextCanvasGroup3.alpha;
			}
			return 0f;
		}
		set
		{
			if (LoseTextAlpha3 != value && _oLoseTextCanvasGroup3 != null)
			{
				_oLoseTextCanvasGroup3.alpha = value;
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
			case "MoneyText":
				_oMoneyText = transform.gameObject;
				_oMoneyTextText = transform.gameObject.GetComponent<Text>();
				break;
			case "AddText1":
				_oAddText1 = transform.gameObject;
				_oAddTextRectTransform1 = transform.gameObject.GetComponent<RectTransform>();
				_oAddTextText1 = transform.gameObject.GetComponent<Text>();
				_oAddTextCanvasGroup1 = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "AddText2":
				_oAddText2 = transform.gameObject;
				_oAddTextRectTransform2 = transform.gameObject.GetComponent<RectTransform>();
				_oAddTextText2 = transform.gameObject.GetComponent<Text>();
				_oAddTextCanvasGroup2 = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "AddText3":
				_oAddText3 = transform.gameObject;
				_oAddTextRectTransform3 = transform.gameObject.GetComponent<RectTransform>();
				_oAddTextText3 = transform.gameObject.GetComponent<Text>();
				_oAddTextCanvasGroup3 = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "LoseText1":
				_oLoseText1 = transform.gameObject;
				_oLoseTextRectTransform1 = transform.gameObject.GetComponent<RectTransform>();
				_oLoseTextText1 = transform.gameObject.GetComponent<Text>();
				_oLoseTextCanvasGroup1 = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "LoseText2":
				_oLoseText2 = transform.gameObject;
				_oLoseTextRectTransform2 = transform.gameObject.GetComponent<RectTransform>();
				_oLoseTextText2 = transform.gameObject.GetComponent<Text>();
				_oLoseTextCanvasGroup2 = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "LoseText3":
				_oLoseText3 = transform.gameObject;
				_oLoseTextRectTransform3 = transform.gameObject.GetComponent<RectTransform>();
				_oLoseTextText3 = transform.gameObject.GetComponent<Text>();
				_oLoseTextCanvasGroup3 = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			}
		}
	}

	public bool GetAddTextShow(int index)
	{
		return index switch
		{
			1 => AddTextShow1, 
			2 => AddTextShow2, 
			3 => AddTextShow3, 
			_ => false, 
		};
	}

	public void SetAddTextShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			AddTextShow1 = value;
			break;
		case 2:
			AddTextShow2 = value;
			break;
		case 3:
			AddTextShow3 = value;
			break;
		}
	}

	public Vector3 GetAddTextPosition(int index)
	{
		return index switch
		{
			1 => AddTextPosition1, 
			2 => AddTextPosition2, 
			3 => AddTextPosition3, 
			_ => Vector3.zero, 
		};
	}

	public void SetAddTextPosition(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			AddTextPosition1 = value;
			break;
		case 2:
			AddTextPosition2 = value;
			break;
		case 3:
			AddTextPosition3 = value;
			break;
		}
	}

	public string GetAddTextString(int index)
	{
		return index switch
		{
			1 => AddTextString1, 
			2 => AddTextString2, 
			3 => AddTextString3, 
			_ => null, 
		};
	}

	public void SetAddTextString(int index, string value)
	{
		switch (index)
		{
		case 1:
			AddTextString1 = value;
			break;
		case 2:
			AddTextString2 = value;
			break;
		case 3:
			AddTextString3 = value;
			break;
		}
	}

	public float GetAddTextAlpha(int index)
	{
		return index switch
		{
			1 => AddTextAlpha1, 
			2 => AddTextAlpha2, 
			3 => AddTextAlpha3, 
			_ => 0f, 
		};
	}

	public void SetAddTextAlpha(int index, float value)
	{
		switch (index)
		{
		case 1:
			AddTextAlpha1 = value;
			break;
		case 2:
			AddTextAlpha2 = value;
			break;
		case 3:
			AddTextAlpha3 = value;
			break;
		}
	}

	public bool GetLoseTextShow(int index)
	{
		return index switch
		{
			1 => LoseTextShow1, 
			2 => LoseTextShow2, 
			3 => LoseTextShow3, 
			_ => false, 
		};
	}

	public void SetLoseTextShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			LoseTextShow1 = value;
			break;
		case 2:
			LoseTextShow2 = value;
			break;
		case 3:
			LoseTextShow3 = value;
			break;
		}
	}

	public Vector3 GetLoseTextPosition(int index)
	{
		return index switch
		{
			1 => LoseTextPosition1, 
			2 => LoseTextPosition2, 
			3 => LoseTextPosition3, 
			_ => Vector3.zero, 
		};
	}

	public void SetLoseTextPosition(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			LoseTextPosition1 = value;
			break;
		case 2:
			LoseTextPosition2 = value;
			break;
		case 3:
			LoseTextPosition3 = value;
			break;
		}
	}

	public string GetLoseTextString(int index)
	{
		return index switch
		{
			1 => LoseTextString1, 
			2 => LoseTextString2, 
			3 => LoseTextString3, 
			_ => null, 
		};
	}

	public void SetLoseTextString(int index, string value)
	{
		switch (index)
		{
		case 1:
			LoseTextString1 = value;
			break;
		case 2:
			LoseTextString2 = value;
			break;
		case 3:
			LoseTextString3 = value;
			break;
		}
	}

	public float GetLoseTextAlpha(int index)
	{
		return index switch
		{
			1 => LoseTextAlpha1, 
			2 => LoseTextAlpha2, 
			3 => LoseTextAlpha3, 
			_ => 0f, 
		};
	}

	public void SetLoseTextAlpha(int index, float value)
	{
		switch (index)
		{
		case 1:
			LoseTextAlpha1 = value;
			break;
		case 2:
			LoseTextAlpha2 = value;
			break;
		case 3:
			LoseTextAlpha3 = value;
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
