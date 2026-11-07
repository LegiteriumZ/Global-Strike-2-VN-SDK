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

namespace Assets.Sources.Ui.ViewModel.BigHead;

[GameUiTest]
public class BigHeadProgressViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oProgressShow;

	private GameObject _oChangeHeroFlash;

	private CanvasGroup _oChangeHeroFlashCanvasGroup;

	private GameObject _oProgress1;

	private GameObject _oProgress2;

	private GameObject _oProgress3;

	private GameObject _oProgress4;

	private GameObject _oProgress5;

	private GameObject _oProgress6;

	private Image _oProgressImage1;

	private Image _oProgressImage2;

	private Image _oProgressImage3;

	private Image _oProgressImage4;

	private Image _oProgressImage5;

	private Image _oProgressImage6;

	private GameObject _oFlash1;

	private GameObject _oFlash2;

	private GameObject _oFlash3;

	private GameObject _oFlash4;

	private GameObject _oFlash5;

	private GameObject _oFlash6;

	private RectTransform _oFlashRectTransform1;

	private RectTransform _oFlashRectTransform2;

	private RectTransform _oFlashRectTransform3;

	private RectTransform _oFlashRectTransform4;

	private RectTransform _oFlashRectTransform5;

	private RectTransform _oFlashRectTransform6;

	private GameObject _oNote;

	private GameObject _oMaxCount;

	private Text _oMaxCountText;

	private GameObject _oCurrentCount;

	private Text _oCurrentCountText;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/bighead";

	private string _resourceAssetName = "BigHeadProgress";

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

	public bool ProgressShowShow
	{
		get
		{
			if (_oProgressShow != null)
			{
				return _oProgressShow.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ProgressShowShow != value && _oProgressShow != null)
			{
				_oProgressShow.SetObjectActive(value);
			}
		}
	}

	public bool ChangeHeroFlashShow
	{
		get
		{
			if (_oChangeHeroFlash != null)
			{
				return _oChangeHeroFlash.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ChangeHeroFlashShow != value && _oChangeHeroFlash != null)
			{
				_oChangeHeroFlash.SetObjectActive(value);
			}
		}
	}

	public float ChangeHeroFlashAlpha
	{
		get
		{
			if (_oChangeHeroFlashCanvasGroup != null)
			{
				return _oChangeHeroFlashCanvasGroup.alpha;
			}
			return 0f;
		}
		set
		{
			if (ChangeHeroFlashAlpha != value && _oChangeHeroFlashCanvasGroup != null)
			{
				_oChangeHeroFlashCanvasGroup.alpha = value;
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

	public float ProgressFillamount6
	{
		get
		{
			if (_oProgressImage6 != null)
			{
				return _oProgressImage6.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ProgressFillamount6 != value && _oProgressImage6 != null)
			{
				_oProgressImage6.fillAmount = value;
			}
		}
	}

	public bool FlashShow1
	{
		get
		{
			if (_oFlash1 != null)
			{
				return _oFlash1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (FlashShow1 != value && _oFlash1 != null)
			{
				_oFlash1.SetObjectActive(value);
			}
		}
	}

	public bool FlashShow2
	{
		get
		{
			if (_oFlash2 != null)
			{
				return _oFlash2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (FlashShow2 != value && _oFlash2 != null)
			{
				_oFlash2.SetObjectActive(value);
			}
		}
	}

	public bool FlashShow3
	{
		get
		{
			if (_oFlash3 != null)
			{
				return _oFlash3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (FlashShow3 != value && _oFlash3 != null)
			{
				_oFlash3.SetObjectActive(value);
			}
		}
	}

	public bool FlashShow4
	{
		get
		{
			if (_oFlash4 != null)
			{
				return _oFlash4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (FlashShow4 != value && _oFlash4 != null)
			{
				_oFlash4.SetObjectActive(value);
			}
		}
	}

	public bool FlashShow5
	{
		get
		{
			if (_oFlash5 != null)
			{
				return _oFlash5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (FlashShow5 != value && _oFlash5 != null)
			{
				_oFlash5.SetObjectActive(value);
			}
		}
	}

	public bool FlashShow6
	{
		get
		{
			if (_oFlash6 != null)
			{
				return _oFlash6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (FlashShow6 != value && _oFlash6 != null)
			{
				_oFlash6.SetObjectActive(value);
			}
		}
	}

	public Vector3 FlashPosition1
	{
		get
		{
			if (_oFlashRectTransform1 != null)
			{
				return _oFlashRectTransform1.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (FlashPosition1 != value && _oFlashRectTransform1 != null)
			{
				_oFlashRectTransform1.localPosition = value;
			}
		}
	}

	public Vector3 FlashPosition2
	{
		get
		{
			if (_oFlashRectTransform2 != null)
			{
				return _oFlashRectTransform2.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (FlashPosition2 != value && _oFlashRectTransform2 != null)
			{
				_oFlashRectTransform2.localPosition = value;
			}
		}
	}

	public Vector3 FlashPosition3
	{
		get
		{
			if (_oFlashRectTransform3 != null)
			{
				return _oFlashRectTransform3.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (FlashPosition3 != value && _oFlashRectTransform3 != null)
			{
				_oFlashRectTransform3.localPosition = value;
			}
		}
	}

	public Vector3 FlashPosition4
	{
		get
		{
			if (_oFlashRectTransform4 != null)
			{
				return _oFlashRectTransform4.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (FlashPosition4 != value && _oFlashRectTransform4 != null)
			{
				_oFlashRectTransform4.localPosition = value;
			}
		}
	}

	public Vector3 FlashPosition5
	{
		get
		{
			if (_oFlashRectTransform5 != null)
			{
				return _oFlashRectTransform5.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (FlashPosition5 != value && _oFlashRectTransform5 != null)
			{
				_oFlashRectTransform5.localPosition = value;
			}
		}
	}

	public Vector3 FlashPosition6
	{
		get
		{
			if (_oFlashRectTransform6 != null)
			{
				return _oFlashRectTransform6.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (FlashPosition6 != value && _oFlashRectTransform6 != null)
			{
				_oFlashRectTransform6.localPosition = value;
			}
		}
	}

	public GameObject NoteObj => _oNote;

	public bool NoteShow
	{
		get
		{
			if (_oNote != null)
			{
				return _oNote.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NoteShow != value && _oNote != null)
			{
				_oNote.SetObjectActive(value);
			}
		}
	}

	public string MaxCountString
	{
		get
		{
			if (_oMaxCountText != null)
			{
				return _oMaxCountText.text;
			}
			return null;
		}
		set
		{
			if (MaxCountString != value && _oMaxCountText != null)
			{
				_oMaxCountText.text = value;
			}
		}
	}

	public string CurrentCountString
	{
		get
		{
			if (_oCurrentCountText != null)
			{
				return _oCurrentCountText.text;
			}
			return null;
		}
		set
		{
			if (CurrentCountString != value && _oCurrentCountText != null)
			{
				_oCurrentCountText.text = value;
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
			case "ProgressShow":
				_oProgressShow = transform.gameObject;
				break;
			case "ChangeHeroFlash":
				_oChangeHeroFlash = transform.gameObject;
				_oChangeHeroFlashCanvasGroup = transform.gameObject.GetComponent<CanvasGroup>();
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
			case "Progress6":
				_oProgress6 = transform.gameObject;
				_oProgressImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "Flash1":
				_oFlash1 = transform.gameObject;
				_oFlashRectTransform1 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "Flash2":
				_oFlash2 = transform.gameObject;
				_oFlashRectTransform2 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "Flash3":
				_oFlash3 = transform.gameObject;
				_oFlashRectTransform3 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "Flash4":
				_oFlash4 = transform.gameObject;
				_oFlashRectTransform4 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "Flash5":
				_oFlash5 = transform.gameObject;
				_oFlashRectTransform5 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "Flash6":
				_oFlash6 = transform.gameObject;
				_oFlashRectTransform6 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "Note":
				_oNote = transform.gameObject;
				break;
			case "MaxCount":
				_oMaxCount = transform.gameObject;
				_oMaxCountText = transform.gameObject.GetComponent<Text>();
				break;
			case "CurrentCount":
				_oCurrentCount = transform.gameObject;
				_oCurrentCountText = transform.gameObject.GetComponent<Text>();
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

	public float GetProgressFillamount(int index)
	{
		return index switch
		{
			1 => ProgressFillamount1, 
			2 => ProgressFillamount2, 
			3 => ProgressFillamount3, 
			4 => ProgressFillamount4, 
			5 => ProgressFillamount5, 
			6 => ProgressFillamount6, 
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
		case 6:
			ProgressFillamount6 = value;
			break;
		}
	}

	public int GetProgressCount()
	{
		return 6;
	}

	public bool GetFlashShow(int index)
	{
		return index switch
		{
			1 => FlashShow1, 
			2 => FlashShow2, 
			3 => FlashShow3, 
			4 => FlashShow4, 
			5 => FlashShow5, 
			6 => FlashShow6, 
			_ => false, 
		};
	}

	public void SetFlashShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			FlashShow1 = value;
			break;
		case 2:
			FlashShow2 = value;
			break;
		case 3:
			FlashShow3 = value;
			break;
		case 4:
			FlashShow4 = value;
			break;
		case 5:
			FlashShow5 = value;
			break;
		case 6:
			FlashShow6 = value;
			break;
		}
	}

	public int GetFlashCount()
	{
		return 6;
	}

	public Vector3 GetFlashPosition(int index)
	{
		return index switch
		{
			1 => FlashPosition1, 
			2 => FlashPosition2, 
			3 => FlashPosition3, 
			4 => FlashPosition4, 
			5 => FlashPosition5, 
			6 => FlashPosition6, 
			_ => Vector3.zero, 
		};
	}

	public void SetFlashPosition(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			FlashPosition1 = value;
			break;
		case 2:
			FlashPosition2 = value;
			break;
		case 3:
			FlashPosition3 = value;
			break;
		case 4:
			FlashPosition4 = value;
			break;
		case 5:
			FlashPosition5 = value;
			break;
		case 6:
			FlashPosition6 = value;
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

	public List<RectTransform> GetHoldPosIntergeTrans()
	{
		if (_holdPosTrans != null)
		{
			return _holdPosTrans;
		}
		_holdPosTrans = new List<RectTransform>();
		if (_oMaxCountText != null)
		{
			_holdPosTrans.Add(_oMaxCountText.GetComponent<RectTransform>());
		}
		if (_oCurrentCountText != null)
		{
			_holdPosTrans.Add(_oCurrentCountText.GetComponent<RectTransform>());
		}
		return _holdPosTrans;
	}
}
