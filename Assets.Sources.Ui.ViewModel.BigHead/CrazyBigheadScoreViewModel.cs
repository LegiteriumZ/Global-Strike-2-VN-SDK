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
public class CrazyBigheadScoreViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oCrazyCt;

	private GameObject _oCrazyT;

	private GameObject _oCrazyCtProgress;

	private Image _oCrazyCtProgressImage;

	private GameObject _oCtProgress;

	private Image _oCtProgressImage;

	private GameObject _oTProgress;

	private Image _oTProgressImage;

	private GameObject _oCrazyTProgress;

	private Image _oCrazyTProgressImage;

	private GameObject _oCtScore;

	private Text _oCtScoreText;

	private GameObject _oTScore;

	private Text _oTScoreText;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/bighead";

	private string _resourceAssetName = "CrazyBigheadScore";

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

	public bool CrazyCtShow
	{
		get
		{
			if (_oCrazyCt != null)
			{
				return _oCrazyCt.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CrazyCtShow != value && _oCrazyCt != null)
			{
				_oCrazyCt.SetObjectActive(value);
			}
		}
	}

	public bool CrazyTShow
	{
		get
		{
			if (_oCrazyT != null)
			{
				return _oCrazyT.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CrazyTShow != value && _oCrazyT != null)
			{
				_oCrazyT.SetObjectActive(value);
			}
		}
	}

	public bool CrazyCtProgressShow
	{
		get
		{
			if (_oCrazyCtProgress != null)
			{
				return _oCrazyCtProgress.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CrazyCtProgressShow != value && _oCrazyCtProgress != null)
			{
				_oCrazyCtProgress.SetObjectActive(value);
			}
		}
	}

	public Image.FillMethod CrazyCtProgressFillmethod
	{
		get
		{
			if (_oCrazyCtProgressImage != null)
			{
				return _oCrazyCtProgressImage.fillMethod;
			}
			return Image.FillMethod.Horizontal;
		}
		set
		{
			if (CrazyCtProgressFillmethod != value && _oCrazyCtProgressImage != null)
			{
				_oCrazyCtProgressImage.fillMethod = value;
			}
		}
	}

	public float CrazyCtProgressFillamount
	{
		get
		{
			if (_oCrazyCtProgressImage != null)
			{
				return _oCrazyCtProgressImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (CrazyCtProgressFillamount != value && _oCrazyCtProgressImage != null)
			{
				_oCrazyCtProgressImage.fillAmount = value;
			}
		}
	}

	public bool CtProgressShow
	{
		get
		{
			if (_oCtProgress != null)
			{
				return _oCtProgress.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtProgressShow != value && _oCtProgress != null)
			{
				_oCtProgress.SetObjectActive(value);
			}
		}
	}

	public Image.FillMethod CtProgressFillmethod
	{
		get
		{
			if (_oCtProgressImage != null)
			{
				return _oCtProgressImage.fillMethod;
			}
			return Image.FillMethod.Horizontal;
		}
		set
		{
			if (CtProgressFillmethod != value && _oCtProgressImage != null)
			{
				_oCtProgressImage.fillMethod = value;
			}
		}
	}

	public float CtProgressFillamount
	{
		get
		{
			if (_oCtProgressImage != null)
			{
				return _oCtProgressImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (CtProgressFillamount != value && _oCtProgressImage != null)
			{
				_oCtProgressImage.fillAmount = value;
			}
		}
	}

	public bool TProgressShow
	{
		get
		{
			if (_oTProgress != null)
			{
				return _oTProgress.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TProgressShow != value && _oTProgress != null)
			{
				_oTProgress.SetObjectActive(value);
			}
		}
	}

	public Image.FillMethod TProgressFillmethod
	{
		get
		{
			if (_oTProgressImage != null)
			{
				return _oTProgressImage.fillMethod;
			}
			return Image.FillMethod.Horizontal;
		}
		set
		{
			if (TProgressFillmethod != value && _oTProgressImage != null)
			{
				_oTProgressImage.fillMethod = value;
			}
		}
	}

	public float TProgressFillamount
	{
		get
		{
			if (_oTProgressImage != null)
			{
				return _oTProgressImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (TProgressFillamount != value && _oTProgressImage != null)
			{
				_oTProgressImage.fillAmount = value;
			}
		}
	}

	public bool CrazyTProgressShow
	{
		get
		{
			if (_oCrazyTProgress != null)
			{
				return _oCrazyTProgress.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CrazyTProgressShow != value && _oCrazyTProgress != null)
			{
				_oCrazyTProgress.SetObjectActive(value);
			}
		}
	}

	public Image.FillMethod CrazyTProgressFillmethod
	{
		get
		{
			if (_oCrazyTProgressImage != null)
			{
				return _oCrazyTProgressImage.fillMethod;
			}
			return Image.FillMethod.Horizontal;
		}
		set
		{
			if (CrazyTProgressFillmethod != value && _oCrazyTProgressImage != null)
			{
				_oCrazyTProgressImage.fillMethod = value;
			}
		}
	}

	public float CrazyTProgressFillamount
	{
		get
		{
			if (_oCrazyTProgressImage != null)
			{
				return _oCrazyTProgressImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (CrazyTProgressFillamount != value && _oCrazyTProgressImage != null)
			{
				_oCrazyTProgressImage.fillAmount = value;
			}
		}
	}

	public bool CtScoreShow
	{
		get
		{
			if (_oCtScore != null)
			{
				return _oCtScore.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CtScoreShow != value && _oCtScore != null)
			{
				_oCtScore.SetObjectActive(value);
			}
		}
	}

	public string CtScoreString
	{
		get
		{
			if (_oCtScoreText != null)
			{
				return _oCtScoreText.text;
			}
			return null;
		}
		set
		{
			if (CtScoreString != value && _oCtScoreText != null)
			{
				_oCtScoreText.text = value;
			}
		}
	}

	public bool TScoreShow
	{
		get
		{
			if (_oTScore != null)
			{
				return _oTScore.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TScoreShow != value && _oTScore != null)
			{
				_oTScore.SetObjectActive(value);
			}
		}
	}

	public string TScoreString
	{
		get
		{
			if (_oTScoreText != null)
			{
				return _oTScoreText.text;
			}
			return null;
		}
		set
		{
			if (TScoreString != value && _oTScoreText != null)
			{
				_oTScoreText.text = value;
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
			case "CrazyCt":
				_oCrazyCt = transform.gameObject;
				break;
			case "CrazyT":
				_oCrazyT = transform.gameObject;
				break;
			case "CrazyCtProgress":
				_oCrazyCtProgress = transform.gameObject;
				_oCrazyCtProgressImage = transform.gameObject.GetComponent<Image>();
				break;
			case "CtProgress":
				_oCtProgress = transform.gameObject;
				_oCtProgressImage = transform.gameObject.GetComponent<Image>();
				break;
			case "TProgress":
				_oTProgress = transform.gameObject;
				_oTProgressImage = transform.gameObject.GetComponent<Image>();
				break;
			case "CrazyTProgress":
				_oCrazyTProgress = transform.gameObject;
				_oCrazyTProgressImage = transform.gameObject.GetComponent<Image>();
				break;
			case "CtScore":
				_oCtScore = transform.gameObject;
				_oCtScoreText = transform.gameObject.GetComponent<Text>();
				break;
			case "TScore":
				_oTScore = transform.gameObject;
				_oTScoreText = transform.gameObject.GetComponent<Text>();
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
		if (_oCtScoreText != null)
		{
			_holdPosTrans.Add(_oCtScoreText.GetComponent<RectTransform>());
		}
		if (_oTScoreText != null)
		{
			_holdPosTrans.Add(_oTScoreText.GetComponent<RectTransform>());
		}
		return _holdPosTrans;
	}
}
