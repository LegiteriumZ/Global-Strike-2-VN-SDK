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
public class RpgSelectViewViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oRpgSelectView;

	private GameObject _opanel;

	private GameObject _ocanbuytip;

	private Image _ocanbuytipImage;

	private GameObject _olastprogress;

	private GameObject _oback;

	private GameObject _oblue_pro;

	private Image _oblue_proImage;

	private GameObject _ored_pro;

	private RectTransform _ored_proRectTransform;

	private Image _ored_proImage;

	private GameObject _oeffect_pro;

	private RectTransform _oeffect_proRectTransform;

	private Image _oeffect_proImage;

	private GameObject _ored_frame;

	private Image _ored_frameImage;

	private GameObject _oblue_frame;

	private Image _oblue_frameImage;

	private GameObject _viewGameObject;

	public const string red_proName = "red_pro";

	public const string effect_proName = "effect_pro";

	private string _resourceBundleName = "uiprefabs/rpg";

	private string _resourceAssetName = "RpgSelectView";

	public GameObject RpgSelectViewObj => _oRpgSelectView;

	public bool RpgSelectViewShow
	{
		get
		{
			if (_oRpgSelectView != null)
			{
				return _oRpgSelectView.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RpgSelectViewShow != value && _oRpgSelectView != null)
			{
				_oRpgSelectView.SetObjectActive(value);
			}
		}
	}

	public bool panelShow
	{
		get
		{
			if (_opanel != null)
			{
				return _opanel.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (panelShow != value && _opanel != null)
			{
				_opanel.SetObjectActive(value);
			}
		}
	}

	public bool canbuytipShow
	{
		get
		{
			if (_ocanbuytip != null)
			{
				return _ocanbuytip.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (canbuytipShow != value && _ocanbuytip != null)
			{
				_ocanbuytip.SetObjectActive(value);
			}
		}
	}

	public Image canbuytipImage
	{
		get
		{
			if (_ocanbuytipImage != null)
			{
				return _ocanbuytipImage;
			}
			return null;
		}
		set
		{
			if (canbuytipImage != value && _ocanbuytipImage != null)
			{
				_ocanbuytipImage = value;
			}
		}
	}

	public bool lastprogressShow
	{
		get
		{
			if (_olastprogress != null)
			{
				return _olastprogress.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (lastprogressShow != value && _olastprogress != null)
			{
				_olastprogress.SetObjectActive(value);
			}
		}
	}

	public bool backShow
	{
		get
		{
			if (_oback != null)
			{
				return _oback.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (backShow != value && _oback != null)
			{
				_oback.SetObjectActive(value);
			}
		}
	}

	public bool blue_proShow
	{
		get
		{
			if (_oblue_pro != null)
			{
				return _oblue_pro.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (blue_proShow != value && _oblue_pro != null)
			{
				_oblue_pro.SetObjectActive(value);
			}
		}
	}

	public float blue_proFillamount
	{
		get
		{
			if (_oblue_proImage != null)
			{
				return _oblue_proImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (blue_proFillamount != value && _oblue_proImage != null)
			{
				_oblue_proImage.fillAmount = value;
			}
		}
	}

	public bool red_proShow
	{
		get
		{
			if (_ored_pro != null)
			{
				return _ored_pro.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (red_proShow != value && _ored_pro != null)
			{
				_ored_pro.SetObjectActive(value);
			}
		}
	}

	public Vector3 red_proSize
	{
		get
		{
			if (_ored_proRectTransform != null)
			{
				return _ored_proRectTransform.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (red_proSize != value && _ored_proRectTransform != null)
			{
				_ored_proRectTransform.sizeDelta = value;
			}
		}
	}

	public float red_proFillamount
	{
		get
		{
			if (_ored_proImage != null)
			{
				return _ored_proImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (red_proFillamount != value && _ored_proImage != null)
			{
				_ored_proImage.fillAmount = value;
			}
		}
	}

	public bool effect_proShow
	{
		get
		{
			if (_oeffect_pro != null)
			{
				return _oeffect_pro.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (effect_proShow != value && _oeffect_pro != null)
			{
				_oeffect_pro.SetObjectActive(value);
			}
		}
	}

	public Vector2 effect_proAnchoredposition
	{
		get
		{
			if (_oeffect_proRectTransform != null)
			{
				return _oeffect_proRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (effect_proAnchoredposition != value && _oeffect_proRectTransform != null)
			{
				_oeffect_proRectTransform.anchoredPosition = value;
			}
		}
	}

	public Image effect_proImage
	{
		get
		{
			if (_oeffect_proImage != null)
			{
				return _oeffect_proImage;
			}
			return null;
		}
		set
		{
			if (effect_proImage != value && _oeffect_proImage != null)
			{
				_oeffect_proImage = value;
			}
		}
	}

	public bool red_frameShow
	{
		get
		{
			if (_ored_frame != null)
			{
				return _ored_frame.activeSelf;
			}
			return false;
		}
		set
		{
			if (red_frameShow != value && _ored_frame != null)
			{
				_ored_frame.SetActive(value);
			}
		}
	}

	public Image red_frameImage
	{
		get
		{
			if (_ored_frameImage != null)
			{
				return _ored_frameImage;
			}
			return null;
		}
		set
		{
			if (red_frameImage != value && _ored_frameImage != null)
			{
				_ored_frameImage = value;
			}
		}
	}

	public bool blue_frameShow
	{
		get
		{
			if (_oblue_frame != null)
			{
				return _oblue_frame.activeSelf;
			}
			return false;
		}
		set
		{
			if (blue_frameShow != value && _oblue_frame != null)
			{
				_oblue_frame.SetActive(value);
			}
		}
	}

	public Image blue_frameImage
	{
		get
		{
			if (_oblue_frameImage != null)
			{
				return _oblue_frameImage;
			}
			return null;
		}
		set
		{
			if (blue_frameImage != value && _oblue_frameImage != null)
			{
				_oblue_frameImage = value;
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
			case "RpgSelectView":
				_oRpgSelectView = transform.gameObject;
				break;
			case "panel":
				_opanel = transform.gameObject;
				break;
			case "canbuytip":
				_ocanbuytip = transform.gameObject;
				_ocanbuytipImage = transform.gameObject.GetComponent<Image>();
				break;
			case "lastprogress":
				_olastprogress = transform.gameObject;
				break;
			case "back":
				_oback = transform.gameObject;
				break;
			case "blue_pro":
				_oblue_pro = transform.gameObject;
				_oblue_proImage = transform.gameObject.GetComponent<Image>();
				break;
			case "red_pro":
				_ored_pro = transform.gameObject;
				_ored_proRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_ored_proImage = transform.gameObject.GetComponent<Image>();
				break;
			case "effect_pro":
				_oeffect_pro = transform.gameObject;
				_oeffect_proRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oeffect_proImage = transform.gameObject.GetComponent<Image>();
				break;
			case "red_frame":
				_ored_frame = transform.gameObject;
				_ored_frameImage = transform.gameObject.GetComponent<Image>();
				break;
			case "blue_frame":
				_oblue_frame = transform.gameObject;
				_oblue_frameImage = transform.gameObject.GetComponent<Image>();
				break;
			}
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
