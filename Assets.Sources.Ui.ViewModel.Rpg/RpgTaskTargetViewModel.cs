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
public class RpgTaskTargetViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oWaveText;

	private Text _oWaveTextText;

	private GameObject _oReward1;

	private GameObject _oReward2;

	private Text _oRewardText1;

	private Text _oRewardText2;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/rpg";

	private string _resourceAssetName = "RpgTaskTarget";

	public string WaveTextString
	{
		get
		{
			if (_oWaveTextText != null)
			{
				return _oWaveTextText.text;
			}
			return null;
		}
		set
		{
			if (WaveTextString != value && _oWaveTextText != null)
			{
				_oWaveTextText.text = value;
			}
		}
	}

	public string RewardString1
	{
		get
		{
			if (_oRewardText1 != null)
			{
				return _oRewardText1.text;
			}
			return null;
		}
		set
		{
			if (RewardString1 != value && _oRewardText1 != null)
			{
				_oRewardText1.text = value;
			}
		}
	}

	public string RewardString2
	{
		get
		{
			if (_oRewardText2 != null)
			{
				return _oRewardText2.text;
			}
			return null;
		}
		set
		{
			if (RewardString2 != value && _oRewardText2 != null)
			{
				_oRewardText2.text = value;
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
			case "WaveText":
				_oWaveText = transform.gameObject;
				_oWaveTextText = transform.gameObject.GetComponent<Text>();
				break;
			case "Reward1":
				_oReward1 = transform.gameObject;
				_oRewardText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "Reward2":
				_oReward2 = transform.gameObject;
				_oRewardText2 = transform.gameObject.GetComponent<Text>();
				break;
			}
		}
	}

	public string GetRewardString(int index)
	{
		return index switch
		{
			1 => RewardString1, 
			2 => RewardString2, 
			_ => null, 
		};
	}

	public void SetRewardString(int index, string value)
	{
		switch (index)
		{
		case 1:
			RewardString1 = value;
			break;
		case 2:
			RewardString2 = value;
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
