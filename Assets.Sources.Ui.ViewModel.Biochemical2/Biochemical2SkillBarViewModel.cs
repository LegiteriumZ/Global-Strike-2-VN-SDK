using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Biochemical2;

[GameUiTest]
public class Biochemical2SkillBarViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oProgress;

	private Image _oProgressImage;

	private GameObject _oSkillItem;

	private GameObject _oGainPoint;

	private Text _oGainPointText;

	private GameObject _oSkillPoint;

	private Text _oSkillPointText;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/biochemical2";

	private string _resourceAssetName = "Biochemical2SkillBar";

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

	public float ProgressFillamount
	{
		get
		{
			if (_oProgressImage != null)
			{
				return _oProgressImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ProgressFillamount != value && _oProgressImage != null)
			{
				_oProgressImage.fillAmount = value;
			}
		}
	}

	public bool SkillItemShow
	{
		get
		{
			if (_oSkillItem != null)
			{
				return _oSkillItem.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillItemShow != value && _oSkillItem != null)
			{
				_oSkillItem.SetObjectActive(value);
			}
		}
	}

	public string GainPointString
	{
		get
		{
			if (_oGainPointText != null)
			{
				return _oGainPointText.text;
			}
			return null;
		}
		set
		{
			if (GainPointString != value && _oGainPointText != null)
			{
				_oGainPointText.text = value;
			}
		}
	}

	public string SkillPointString
	{
		get
		{
			if (_oSkillPointText != null)
			{
				return _oSkillPointText.text;
			}
			return null;
		}
		set
		{
			if (SkillPointString != value && _oSkillPointText != null)
			{
				_oSkillPointText.text = value;
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
			case "Progress":
				_oProgress = transform.gameObject;
				_oProgressImage = transform.gameObject.GetComponent<Image>();
				break;
			case "SkillItem":
				_oSkillItem = transform.gameObject;
				break;
			case "GainPoint":
				_oGainPoint = transform.gameObject;
				_oGainPointText = transform.gameObject.GetComponent<Text>();
				break;
			case "SkillPoint":
				_oSkillPoint = transform.gameObject;
				_oSkillPointText = transform.gameObject.GetComponent<Text>();
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
