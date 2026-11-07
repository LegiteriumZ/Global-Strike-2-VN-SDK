using System.Collections;
using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Info.Weapon;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.RpgMouseYear;
using Assets.Sources.Utils.Ui;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJAnim.Weapon;
using SSJJBase.Input;
using SSJJBase.Thread;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Sources.Ui.Model.RpgMouseYear;

[GameUiTest]
public class RpgMouseYearChooseDropWeaponModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ICursorControl, IKeyboardResponder
{
	private RpgMouseYearChooseDropWeaponViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private GameRuleContext _gameRuleContext;

	private int _chooseWeaponType = 1;

	private bool _isStartScroll;

	private readonly bool[] _isScrollUpdates = new bool[3];

	private int _scrollInveral = 120;

	private float _speed = 2f;

	private float[] _nowSpeed = new float[3];

	private float _speedMin = 0.3f;

	private float _speedGlus = 0.00038f;

	private int[] _trueIndexes = new int[3];

	private IEnumerator _updateScroll;

	private List<string> _defaultWeaponList = new List<string>();

	private List<string> _randomWeaponList = new List<string>();

	private Dictionary<int, List<string>> _scrollWeaponDic = new Dictionary<int, List<string>>();

	protected override IUiViewModel ViewModel => _viewModel;

	public int CloseDelay { get; set; }

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
		_defaultWeaponList.Add("ak47_a");
		_defaultWeaponList.Add("ak12");
		_defaultWeaponList.Add("ak47_blue_dragon");
		_defaultWeaponList.Add("ak47_dragon");
		_defaultWeaponList.Add("ak47_g");
		_defaultWeaponList.Add("ak47_mars");
	}

	public override void CreateViewModel()
	{
		_viewModel = new RpgMouseYearChooseDropWeaponViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited)
		{
			UpdateChips();
			UpdateScroll();
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		_viewModel.ShowShow = false;
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_MouseYear_ShowDropWeapon, ShowDropWeapon, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_MouseYear_ShowDropWeaponListUi, ShowDropWeaponCodeName, null, initinvoke: true);
		_viewModel.CreateTriggerEntry(_viewModel.CloseTriggers, EventTriggerType.PointerClick, delegate
		{
			CloseClick();
		});
		_viewModel.CreateTriggerEntry(_viewModel.StartTriggers, EventTriggerType.PointerClick, delegate
		{
			StartClick();
		});
		_viewModel.CreateTriggerEntry(_viewModel.TypeTriggers1, EventTriggerType.PointerClick, delegate
		{
			TypeWeaponClick(1);
		});
		_viewModel.CreateTriggerEntry(_viewModel.TypeTriggers2, EventTriggerType.PointerClick, delegate
		{
			TypeWeaponClick(2);
		});
		_viewModel.CreateTriggerEntry(_viewModel.TypeTriggers3, EventTriggerType.PointerClick, delegate
		{
			TypeWeaponClick(3);
		});
		_viewModel.CreateTriggerEntry(_viewModel.TypeTriggers4, EventTriggerType.PointerClick, delegate
		{
			TypeWeaponClick(4);
		});
		_viewModel.CreateTriggerEntry(_viewModel.ChooseTriggers1, EventTriggerType.PointerClick, delegate
		{
			ChooseWeaponCodeClick(1);
		});
		_viewModel.CreateTriggerEntry(_viewModel.ChooseTriggers2, EventTriggerType.PointerClick, delegate
		{
			ChooseWeaponCodeClick(2);
		});
		_viewModel.CreateTriggerEntry(_viewModel.ChooseTriggers3, EventTriggerType.PointerClick, delegate
		{
			ChooseWeaponCodeClick(3);
		});
	}

	private void CloseClick()
	{
		_gameRuleContext.mouseYear.ChooseDropWeapon = false;
	}

	private void StartClick()
	{
		if (_gameRuleContext.mouseYear.ChooseDropWeapon)
		{
			Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(106, new BaoxiangChooseWeaponTypeRequest
			{
				Type = _chooseWeaponType
			});
		}
	}

	private void TypeWeaponClick(int type)
	{
		_chooseWeaponType = type;
		SetChooseTypeVisible(type);
	}

	private void ChooseWeaponCodeClick(int index)
	{
		if (_gameRuleContext.mouseYear.ChooseDropWeapon)
		{
			Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(107, new BaoxiangChooseWeaponRequest
			{
				CodeName = _gameRuleContext.mouseYear.ChooseDropWeaponList[index - 1]
			});
			_gameRuleContext.mouseYear.ChooseDropWeapon = false;
		}
	}

	private void SetChooseTypeVisible(int index)
	{
		for (int i = 1; i < 5; i++)
		{
			_viewModel.SetTypeShow(i, i != index);
			_viewModel.SetTypeChooseShow(i, i == index);
		}
		for (int j = 1; j <= _viewModel.GetChooseTypeShadowCount(); j++)
		{
			_viewModel.SetChooseTypeShadowShow(j, index == j);
		}
	}

	private void SetChooseWeaponStartVisible(bool isVisible)
	{
		_viewModel.StartShow = isVisible;
	}

	private void ShowDropWeaponCodeName(bool arg1, bool arg2)
	{
		if (!arg2)
		{
			return;
		}
		_gameRuleContext.mouseYear.IsChooseDropWeaponList = false;
		SetChooseWeaponStartVisible(isVisible: false);
		SetChooseTypeCanClick(isCanClick: false);
		SetChooseWeaponClick(isCanClick: false);
		_randomWeaponList.Clear();
		List<string> list = new List<string>();
		if (_chooseWeaponType == 1)
		{
			list = _gameRuleContext.mouseYear.MasterWeaponPools;
		}
		else if (_chooseWeaponType == 2)
		{
			list = _gameRuleContext.mouseYear.SecondWeaponPools;
		}
		else if (_chooseWeaponType == 3)
		{
			list = _gameRuleContext.mouseYear.CloseWeaponPools;
		}
		else if (_chooseWeaponType == 4)
		{
			list = _gameRuleContext.mouseYear.GrenadeWeaponPools;
		}
		if (list == null || list.Count == 0)
		{
			_randomWeaponList = _defaultWeaponList;
		}
		else
		{
			for (int i = 0; i < 6; i++)
			{
				int index = Random.Range(0, list.Count);
				_randomWeaponList.Add(list[index]);
			}
		}
		List<string> chooseDropWeaponList = _gameRuleContext.mouseYear.ChooseDropWeaponList;
		for (int j = 0; j < _randomWeaponList.Count; j++)
		{
			chooseDropWeaponList.Add(_randomWeaponList[j]);
		}
		_isStartScroll = false;
		LoadedOverStartScroll();
		for (int k = 0; k < 3; k++)
		{
			_viewModel.SetWeaponNameString(k + 1, "");
		}
	}

	private void LoadedOverStartScroll()
	{
		if (!_isStartScroll)
		{
			_isStartScroll = true;
			_viewModel.ChooseAllShow = true;
			_viewModel.ChooseTypeShow = false;
			if (_updateScroll != null)
			{
				BaseAsyncManager.Instance.StopCoRoutine(_updateScroll);
			}
			_updateScroll = StartScroll();
			BaseAsyncManager.Instance.StartCoRoutine(_updateScroll);
		}
	}

	private IEnumerator StartScroll()
	{
		InitScroll();
		for (int i = 0; i < _isScrollUpdates.Length; i++)
		{
			_isScrollUpdates[i] = true;
			yield return new WaitForSeconds(0.05f);
		}
	}

	private void InitScroll()
	{
		for (int i = 0; i < _isScrollUpdates.Length; i++)
		{
			_isScrollUpdates[i] = false;
		}
		for (int j = 0; j < _nowSpeed.Length; j++)
		{
			_nowSpeed[j] = _speed;
		}
		for (int k = 0; k < _trueIndexes.Length; k++)
		{
			_trueIndexes[k] = Random.Range(0, 3);
		}
		for (int l = 1; l <= 5; l++)
		{
			_viewModel.SetType1WeaponPosition(l, new Vector3(0f, (3 - l) * _scrollInveral, 0f));
			_viewModel.SetType2WeaponPosition(l, new Vector3(0f, (3 - l) * _scrollInveral, 0f));
			_viewModel.SetType3WeaponPosition(l, new Vector3(0f, (3 - l) * _scrollInveral, 0f));
		}
		_scrollWeaponDic.Clear();
		for (int m = 0; m < _trueIndexes.Length; m++)
		{
			List<string> weaponList = GetWeaponList(m, _trueIndexes[m]);
			_scrollWeaponDic.Add(m, weaponList);
		}
		List<string> list = _scrollWeaponDic[0];
		IWeaponInfo weaponInfo = WeaponInfoFactory.Instance.GetWeaponInfo(list[0]);
		if (weaponInfo != null)
		{
			this.GetLoader().RetriveSprite(weaponInfo.GetWeaponIconAssetInfo(""), delegate(Sprite spr)
			{
				_viewModel.SetType1WeaponSprite(1, spr);
				_viewModel.CallType1WeaponNtvsize(1);
				_viewModel.SetType1WeaponScale(1, (_chooseWeaponType == 1 || _chooseWeaponType == 3) ? new Vector3(0.8f, 0.8f, 0.8f) : Vector3.one);
			});
		}
		weaponInfo = WeaponInfoFactory.Instance.GetWeaponInfo(list[1]);
		if (weaponInfo != null)
		{
			this.GetLoader().RetriveSprite(weaponInfo.GetWeaponIconAssetInfo(""), delegate(Sprite spr)
			{
				_viewModel.SetType1WeaponSprite(2, spr);
				_viewModel.CallType1WeaponNtvsize(2);
				_viewModel.SetType1WeaponScale(2, (_chooseWeaponType == 1 || _chooseWeaponType == 3) ? new Vector3(0.8f, 0.8f, 0.8f) : Vector3.one);
			});
		}
		weaponInfo = WeaponInfoFactory.Instance.GetWeaponInfo(list[2]);
		if (weaponInfo != null)
		{
			this.GetLoader().RetriveSprite(weaponInfo.GetWeaponIconAssetInfo(""), delegate(Sprite spr)
			{
				_viewModel.SetType1WeaponSprite(3, spr);
				_viewModel.CallType1WeaponNtvsize(3);
				_viewModel.SetType1WeaponScale(3, (_chooseWeaponType == 1 || _chooseWeaponType == 3) ? new Vector3(0.8f, 0.8f, 0.8f) : Vector3.one);
			});
		}
		weaponInfo = WeaponInfoFactory.Instance.GetWeaponInfo(list[3]);
		if (weaponInfo != null)
		{
			this.GetLoader().RetriveSprite(weaponInfo.GetWeaponIconAssetInfo(""), delegate(Sprite spr)
			{
				_viewModel.SetType1WeaponSprite(4, spr);
				_viewModel.CallType1WeaponNtvsize(4);
				_viewModel.SetType1WeaponScale(4, (_chooseWeaponType == 1 || _chooseWeaponType == 3) ? new Vector3(0.8f, 0.8f, 0.8f) : Vector3.one);
			});
		}
		weaponInfo = WeaponInfoFactory.Instance.GetWeaponInfo(list[4]);
		if (weaponInfo != null)
		{
			this.GetLoader().RetriveSprite(weaponInfo.GetWeaponIconAssetInfo(""), delegate(Sprite spr)
			{
				_viewModel.SetType1WeaponSprite(5, spr);
				_viewModel.CallType1WeaponNtvsize(5);
				_viewModel.SetType1WeaponScale(5, (_chooseWeaponType == 1 || _chooseWeaponType == 3) ? new Vector3(0.8f, 0.8f, 0.8f) : Vector3.one);
			});
		}
		list = _scrollWeaponDic[1];
		weaponInfo = WeaponInfoFactory.Instance.GetWeaponInfo(list[0]);
		if (weaponInfo != null)
		{
			this.GetLoader().RetriveSprite(weaponInfo.GetWeaponIconAssetInfo(""), delegate(Sprite spr)
			{
				_viewModel.SetType2WeaponSprite(1, spr);
				_viewModel.CallType2WeaponNtvsize(1);
				_viewModel.SetType2WeaponScale(1, (_chooseWeaponType == 1 || _chooseWeaponType == 3) ? new Vector3(0.8f, 0.8f, 0.8f) : Vector3.one);
			});
		}
		weaponInfo = WeaponInfoFactory.Instance.GetWeaponInfo(list[1]);
		if (weaponInfo != null)
		{
			this.GetLoader().RetriveSprite(weaponInfo.GetWeaponIconAssetInfo(""), delegate(Sprite spr)
			{
				_viewModel.SetType2WeaponSprite(2, spr);
				_viewModel.CallType2WeaponNtvsize(2);
				_viewModel.SetType2WeaponScale(2, (_chooseWeaponType == 1 || _chooseWeaponType == 3) ? new Vector3(0.8f, 0.8f, 0.8f) : Vector3.one);
			});
		}
		weaponInfo = WeaponInfoFactory.Instance.GetWeaponInfo(list[2]);
		if (weaponInfo != null)
		{
			this.GetLoader().RetriveSprite(weaponInfo.GetWeaponIconAssetInfo(""), delegate(Sprite spr)
			{
				_viewModel.SetType2WeaponSprite(3, spr);
				_viewModel.CallType2WeaponNtvsize(3);
				_viewModel.SetType2WeaponScale(3, (_chooseWeaponType == 1 || _chooseWeaponType == 3) ? new Vector3(0.8f, 0.8f, 0.8f) : Vector3.one);
			});
		}
		weaponInfo = WeaponInfoFactory.Instance.GetWeaponInfo(list[3]);
		if (weaponInfo != null)
		{
			this.GetLoader().RetriveSprite(weaponInfo.GetWeaponIconAssetInfo(""), delegate(Sprite spr)
			{
				_viewModel.SetType2WeaponSprite(4, spr);
				_viewModel.CallType2WeaponNtvsize(4);
				_viewModel.SetType2WeaponScale(4, (_chooseWeaponType == 1 || _chooseWeaponType == 3) ? new Vector3(0.8f, 0.8f, 0.8f) : Vector3.one);
			});
		}
		weaponInfo = WeaponInfoFactory.Instance.GetWeaponInfo(list[4]);
		if (weaponInfo != null)
		{
			this.GetLoader().RetriveSprite(weaponInfo.GetWeaponIconAssetInfo(""), delegate(Sprite spr)
			{
				_viewModel.SetType2WeaponSprite(5, spr);
				_viewModel.CallType2WeaponNtvsize(5);
				_viewModel.SetType2WeaponScale(5, (_chooseWeaponType == 1 || _chooseWeaponType == 3) ? new Vector3(0.8f, 0.8f, 0.8f) : Vector3.one);
			});
		}
		list = _scrollWeaponDic[2];
		weaponInfo = WeaponInfoFactory.Instance.GetWeaponInfo(list[0]);
		if (weaponInfo != null)
		{
			this.GetLoader().RetriveSprite(weaponInfo.GetWeaponIconAssetInfo(""), delegate(Sprite spr)
			{
				_viewModel.SetType3WeaponSprite(1, spr);
				_viewModel.CallType3WeaponNtvsize(1);
				_viewModel.SetType3WeaponScale(1, (_chooseWeaponType == 1 || _chooseWeaponType == 3) ? new Vector3(0.8f, 0.8f, 0.8f) : Vector3.one);
			});
		}
		weaponInfo = WeaponInfoFactory.Instance.GetWeaponInfo(list[1]);
		if (weaponInfo != null)
		{
			this.GetLoader().RetriveSprite(weaponInfo.GetWeaponIconAssetInfo(""), delegate(Sprite spr)
			{
				_viewModel.SetType3WeaponSprite(2, spr);
				_viewModel.CallType3WeaponNtvsize(2);
				_viewModel.SetType3WeaponScale(2, (_chooseWeaponType == 1 || _chooseWeaponType == 3) ? new Vector3(0.8f, 0.8f, 0.8f) : Vector3.one);
			});
		}
		weaponInfo = WeaponInfoFactory.Instance.GetWeaponInfo(list[2]);
		if (weaponInfo != null)
		{
			this.GetLoader().RetriveSprite(weaponInfo.GetWeaponIconAssetInfo(""), delegate(Sprite spr)
			{
				_viewModel.SetType3WeaponSprite(3, spr);
				_viewModel.CallType3WeaponNtvsize(3);
				_viewModel.SetType3WeaponScale(3, (_chooseWeaponType == 1 || _chooseWeaponType == 3) ? new Vector3(0.8f, 0.8f, 0.8f) : Vector3.one);
			});
		}
		weaponInfo = WeaponInfoFactory.Instance.GetWeaponInfo(list[3]);
		if (weaponInfo != null)
		{
			this.GetLoader().RetriveSprite(weaponInfo.GetWeaponIconAssetInfo(""), delegate(Sprite spr)
			{
				_viewModel.SetType3WeaponSprite(4, spr);
				_viewModel.CallType3WeaponNtvsize(4);
				_viewModel.SetType3WeaponScale(4, (_chooseWeaponType == 1 || _chooseWeaponType == 3) ? new Vector3(0.8f, 0.8f, 0.8f) : Vector3.one);
			});
		}
		weaponInfo = WeaponInfoFactory.Instance.GetWeaponInfo(list[4]);
		if (weaponInfo != null)
		{
			this.GetLoader().RetriveSprite(weaponInfo.GetWeaponIconAssetInfo(""), delegate(Sprite spr)
			{
				_viewModel.SetType3WeaponSprite(5, spr);
				_viewModel.CallType3WeaponNtvsize(5);
				_viewModel.SetType3WeaponScale(5, (_chooseWeaponType == 1 || _chooseWeaponType == 3) ? new Vector3(0.8f, 0.8f, 0.8f) : Vector3.one);
			});
		}
	}

	private List<string> GetWeaponList(int index, int randomIndex)
	{
		List<string> list = new List<string>();
		switch (randomIndex)
		{
		case 0:
			list.Add(_gameRuleContext.mouseYear.ChooseDropWeaponList[index]);
			list.Add(_randomWeaponList[index * 2]);
			list.Add(_randomWeaponList[index * 2 + 1]);
			list.Add(_gameRuleContext.mouseYear.ChooseDropWeaponList[index]);
			list.Add(_randomWeaponList[index * 2]);
			break;
		case 1:
			list.Add(_randomWeaponList[index * 2]);
			list.Add(_gameRuleContext.mouseYear.ChooseDropWeaponList[index]);
			list.Add(_randomWeaponList[index * 2 + 1]);
			list.Add(_randomWeaponList[index * 2]);
			list.Add(_gameRuleContext.mouseYear.ChooseDropWeaponList[index]);
			break;
		default:
			list.Add(_randomWeaponList[index * 2]);
			list.Add(_randomWeaponList[index * 2 + 1]);
			list.Add(_gameRuleContext.mouseYear.ChooseDropWeaponList[index]);
			list.Add(_randomWeaponList[index * 2]);
			list.Add(_randomWeaponList[index * 2 + 1]);
			break;
		}
		return list;
	}

	private void UpdateScroll()
	{
		if (_isScrollUpdates[0])
		{
			List<Transform> list = new List<Transform>();
			for (int i = 1; i <= 5; i++)
			{
				list.Add(_viewModel.GetType1WeaponObj(i).transform);
			}
			UpdateScroll(list, 0);
		}
		if (_isScrollUpdates[1])
		{
			List<Transform> list2 = new List<Transform>();
			for (int j = 1; j <= 5; j++)
			{
				list2.Add(_viewModel.GetType2WeaponObj(j).transform);
			}
			UpdateScroll(list2, 1);
		}
		if (_isScrollUpdates[2])
		{
			List<Transform> list3 = new List<Transform>();
			for (int k = 1; k <= 5; k++)
			{
				list3.Add(_viewModel.GetType3WeaponObj(k).transform);
			}
			UpdateScroll(list3, 2);
		}
	}

	private void UpdateScroll(List<Transform> trans, int index)
	{
		for (int i = 0; i < trans.Count; i++)
		{
			Vector3 localPosition = trans[i].localPosition;
			_nowSpeed[index] -= (float)_timeComponent.FrameInterval * _speedGlus;
			if (_nowSpeed[index] <= _speedMin)
			{
				_nowSpeed[index] = _speedMin;
				EndScroll(index, trans);
				break;
			}
			localPosition.y -= _nowSpeed[index] * (float)_timeComponent.FrameInterval;
			float num = localPosition.y - (float)(_scrollInveral * -2);
			if (num < 0f)
			{
				localPosition.y = (float)(_scrollInveral * 3) + num;
			}
			trans[i].localPosition = localPosition;
		}
		for (int j = 0; j < trans.Count; j++)
		{
			Vector3 localPosition2 = trans[j].localPosition;
			if (localPosition2.y <= (float)_scrollInveral * 0.6f && localPosition2.y > (float)(-_scrollInveral) * 0.6f)
			{
				List<string> list = _scrollWeaponDic[index];
				IWeaponInfo weaponInfo = WeaponInfoFactory.Instance.GetWeaponInfo(list[j]);
				if (weaponInfo != null)
				{
					_viewModel.SetWeaponNameString(index + 1, LanguageUtils.GetWeaponCnName(weaponInfo.Name));
				}
			}
		}
	}

	private void EndScroll(int index, List<Transform> trans)
	{
		int index2 = _trueIndexes[index];
		bool flag = trans[index2].transform.localPosition.y > 0f;
		for (int i = 0; i < trans.Count; i++)
		{
			Vector3 localPosition = trans[i].localPosition;
			localPosition.y -= _nowSpeed[index] * (float)_timeComponent.FrameInterval;
			float num = localPosition.y - (float)(_scrollInveral * -2);
			if (num < 0f)
			{
				localPosition.y = (float)(_scrollInveral * 3) + num;
			}
			trans[i].localPosition = localPosition;
		}
		bool flag2 = trans[index2].transform.localPosition.y <= 0f;
		if (flag && flag2)
		{
			float y = trans[index2].transform.localPosition.y;
			for (int j = 0; j < trans.Count; j++)
			{
				Vector3 localPosition2 = trans[j].localPosition;
				localPosition2.y -= y;
				trans[j].localPosition = localPosition2;
			}
			_isScrollUpdates[index] = false;
			SetChooseWeaponClick(isCanClick: true, index + 1);
		}
	}

	private void SetChooseTypeCanClick(bool isCanClick)
	{
		for (int i = 1; i < 5; i++)
		{
			_viewModel.GetTypeImage(i).raycastTarget = isCanClick;
		}
	}

	private void SetChooseWeaponClick(bool isCanClick, int index = -1)
	{
		for (int i = 1; i <= 3; i++)
		{
			if (i == index || index == -1)
			{
				_viewModel.SetChooseShow(i, isCanClick);
			}
		}
	}

	private void ShowDropWeapon(bool arg1, bool arg2)
	{
		_viewModel.ShowShow = arg2;
		_viewModel.ChooseAllShow = false;
		_viewModel.ChooseTypeShow = true;
		_chooseWeaponType = 1;
		SetChooseTypeCanClick(isCanClick: true);
		SetChooseTypeVisible(_chooseWeaponType);
		SetChooseWeaponStartVisible(arg2);
	}

	public int GetCursorState()
	{
		if (!_viewModel.ShowShow)
		{
			return 0;
		}
		return 4096;
	}

	public int GetForbidButtons()
	{
		return 175;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	public bool OnKeyDown(KeyCode key)
	{
		if (key == KeyCode.B)
		{
			_gameRuleContext.mouseYear.ChooseDropWeapon = false;
		}
		return false;
	}

	public bool OnKeyUp(KeyCode key)
	{
		return false;
	}

	public bool ForbidKeyDown(KeyCode key)
	{
		return false;
	}

	public bool ForbidKeyUp(KeyCode key)
	{
		return false;
	}
}
