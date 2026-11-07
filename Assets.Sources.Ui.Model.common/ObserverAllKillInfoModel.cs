using System.Collections.Generic;
using Assets.Sources.Constant;
using Assets.Sources.Constant.Career;
using Assets.Sources.Framework;
using Assets.Sources.Free.Data;
using Assets.Sources.Modules.Ui;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJBase.Input;
using SSJJBase.String;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Sources.Ui.Model.Common;

public class ObserverAllKillInfoModel : AbstractModel, IPlaybackSystem, ISetBattleServerContext, ISetPlayerContext, ICursorControl, IKeyboardResponder, ISetGameRuleContext, ISetBattleRoomContext
{
	private ObserverAllKillInfoViewModel _viewModel;

	private PlayerContext _playerContext;

	private BattleServerContext _battleServerContext;

	private BattleRoomContext _battleRoomContext;

	private Dictionary<int, long> _hpMax = new Dictionary<int, long>();

	private string[] _ctWeapon = new string[10] { "", "", "", "", "", "", "", "", "", "" };

	private string[] _tWeapon = new string[10] { "", "", "", "", "", "", "", "", "", "" };

	private List<OneKillInfoData> _ctList = new List<OneKillInfoData>();

	private List<OneKillInfoData> _tList = new List<OneKillInfoData>();

	private bool _mPressed;

	private GameRuleContext _gameRuleContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public int CloseDelay { get; set; }

	public void SetBattleServerContext(BattleServerContext context)
	{
		_battleServerContext = context;
	}

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new ObserverAllKillInfoViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			UpdateChips();
			UpdateHp();
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiRoomData_IsObserver, SetIsObserver, null, initinvoke: true);
		bool flag = !RuleUtilty.isRpgDuelDianfeng(_battleRoomContext.roomData.Data.RaceType);
		for (int j = 0; j < 8; j++)
		{
			if (flag)
			{
				EventTrigger.Entry entry = new EventTrigger.Entry
				{
					callback = new EventTrigger.TriggerEvent(),
					eventID = EventTriggerType.PointerClick
				};
				int i2 = j;
				entry.callback.AddListener(delegate
				{
					_battleServerContext.battleServer.Server.SendTcpMessage(9, _ctList[i2].Id);
				});
				_viewModel.GetCtPlayerTriggers(j + 1).Add(entry);
			}
		}
		for (int k = 0; k < 8; k++)
		{
			if (flag)
			{
				EventTrigger.Entry entry2 = new EventTrigger.Entry
				{
					callback = new EventTrigger.TriggerEvent(),
					eventID = EventTriggerType.PointerClick
				};
				int i1 = k;
				entry2.callback.AddListener(delegate
				{
					_battleServerContext.battleServer.Server.SendTcpMessage(9, _tList[i1].Id);
				});
				_viewModel.GetTPlayerTriggers(k + 1).Add(entry2);
			}
			int i3 = k;
			_viewModel.SetTC4IconSprite(k + 1, base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName("c4"), UiAssetBundleUtils.GetWeaponFullPath() + "c4/ui/c4-2.png", delegate(Sprite v)
			{
				_viewModel.SetTC4IconSprite(i3 + 1, v);
			}));
		}
	}

	private void UpdateHp()
	{
		if (!_viewModel.PanelRootshow)
		{
			return;
		}
		_ctList.Clear();
		_tList.Clear();
		if (_gameRuleContext.currentRule.Rule.IsPersonal())
		{
			List<OneKillInfoData> allKillInfo_All = UiIEventCondition.Get_allKillInfo_All();
			int j;
			for (j = 0; j < allKillInfo_All.Count; j++)
			{
				PlayerEntity entityWithEntityId = _playerContext.GetEntityWithEntityId(allKillInfo_All[j].Id);
				if (entityWithEntityId != null && !entityWithEntityId.basicInfo.Current.IsBot)
				{
					_ctList.Add(allKillInfo_All[j]);
					if (_ctList.Count >= 8)
					{
						break;
					}
				}
			}
			for (; j < allKillInfo_All.Count; j++)
			{
				PlayerEntity entityWithEntityId2 = _playerContext.GetEntityWithEntityId(allKillInfo_All[j].Id);
				if (entityWithEntityId2 != null && !entityWithEntityId2.basicInfo.Current.IsBot)
				{
					_tList.Add(allKillInfo_All[j]);
					if (_tList.Count >= 8)
					{
						break;
					}
				}
			}
		}
		else
		{
			List<OneKillInfoData> allKillInfo_Team = UiIEventCondition.Get_allKillInfo_Team1();
			List<OneKillInfoData> allKillInfo_Team2 = UiIEventCondition.Get_allKillInfo_Team2();
			for (int k = 0; k < allKillInfo_Team.Count; k++)
			{
				PlayerEntity entityWithEntityId3 = _playerContext.GetEntityWithEntityId(allKillInfo_Team[k].Id);
				if (entityWithEntityId3 != null && !entityWithEntityId3.basicInfo.Current.IsBot)
				{
					_ctList.Add(allKillInfo_Team[k]);
					if (_ctList.Count >= 8)
					{
						break;
					}
				}
			}
			for (int l = 0; l < allKillInfo_Team2.Count; l++)
			{
				PlayerEntity entityWithEntityId4 = _playerContext.GetEntityWithEntityId(allKillInfo_Team2[l].Id);
				if (entityWithEntityId4 != null && !entityWithEntityId4.basicInfo.Current.IsBot)
				{
					_tList.Add(allKillInfo_Team2[l]);
					if (_tList.Count >= 8)
					{
						break;
					}
				}
			}
		}
		int cameraOwnerData_Observer = UiIEventCondition.Get_cameraOwnerData_Observer();
		for (int m = 0; m < 8; m++)
		{
			if (m < _ctList.Count)
			{
				OneKillInfoData oneKillInfoData = _ctList[m];
				PlayerEntity entityWithEntityId5 = _playerContext.GetEntityWithEntityId(oneKillInfoData.Id);
				if (entityWithEntityId5 == null)
				{
					_viewModel.SetCtPlayerShow(m + 1, value: false);
				}
				else
				{
					_viewModel.SetCtPlayerShow(m + 1, value: true);
					if (!_hpMax.ContainsKey(oneKillInfoData.Id))
					{
						_hpMax[oneKillInfoData.Id] = 100L;
					}
					if (entityWithEntityId5.basicInfo.Current.MaxHp > 0)
					{
						_hpMax[oneKillInfoData.Id] = entityWithEntityId5.basicInfo.Current.MaxHp;
					}
					float num = (float)entityWithEntityId5.basicInfo.Current.Hp / (float)_hpMax[oneKillInfoData.Id];
					_viewModel.SetCtHpRecImageFillamount(m + 1, num);
					_viewModel.SetCtHpTriImagePosition(m + 1, new Vector3(196f * num, 0f));
					_viewModel.SetCtHpCountString(m + 1, entityWithEntityId5.basicInfo.Current.Hp.ToString());
					_viewModel.SetCtKillCountString(m + 1, oneKillInfoData.KillNum.ToString());
					_viewModel.SetCtPlayerNameString(m + 1, oneKillInfoData.PlayerName);
					_viewModel.SetCtUncheckedShow(m + 1, oneKillInfoData.Id != cameraOwnerData_Observer);
					_viewModel.SetCtCheckedShow(m + 1, oneKillInfoData.Id == cameraOwnerData_Observer);
					_viewModel.SetCtDounShow(m + 1, PlayerCareerConstantUtility.IsDoun(oneKillInfoData.Career) || PlayerCareerConstantUtility.IsEmpress(oneKillInfoData.Career));
					if (PlayerCareerConstantUtility.IsHumanity(entityWithEntityId5.GetCareer()))
					{
						string weaponName2 = entityWithEntityId5.GetCurrentWeaponName();
						if (_ctWeapon[m] != weaponName2)
						{
							_ctWeapon[m] = weaponName2;
							int i2 = m;
							_viewModel.SetCtWeaponSprite(i2 + 1, base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName2), UiAssetBundleUtils.GetWeaponFullPath() + weaponName2 + "/ui/" + weaponName2 + "-2.png", delegate(Sprite v)
							{
								if (_ctWeapon[i2] == weaponName2)
								{
									_viewModel.SetCtWeaponSprite(i2 + 1, v);
								}
							}));
						}
					}
					else
					{
						_viewModel.SetCtWeaponSprite(m + 1, UiResourcesLoader.DefaultSprite);
						_ctWeapon[m] = "";
					}
				}
			}
			else
			{
				_viewModel.SetCtPlayerShow(m + 1, value: false);
			}
			if (m < _tList.Count)
			{
				OneKillInfoData oneKillInfoData2 = _tList[m];
				PlayerEntity entityWithEntityId6 = _playerContext.GetEntityWithEntityId(oneKillInfoData2.Id);
				if (entityWithEntityId6 == null)
				{
					_viewModel.SetTPlayerShow(m + 1, value: false);
					continue;
				}
				_viewModel.SetTPlayerShow(m + 1, value: true);
				if (!_hpMax.ContainsKey(oneKillInfoData2.Id))
				{
					_hpMax[oneKillInfoData2.Id] = 100L;
				}
				if (entityWithEntityId6.basicInfo.Current.MaxHp > 0)
				{
					_hpMax[oneKillInfoData2.Id] = entityWithEntityId6.basicInfo.Current.MaxHp;
				}
				float num2 = (float)entityWithEntityId6.basicInfo.Current.Hp * 1f / (float)_hpMax[oneKillInfoData2.Id];
				_viewModel.SetTHpRecImageFillamount(m + 1, num2);
				_viewModel.SetTHpTriImagePosition(m + 1, new Vector3(-196f * num2, 0f));
				_viewModel.SetTHpCountString(m + 1, StringCache.LongToString(entityWithEntityId6.basicInfo.Current.Hp));
				_viewModel.SetTKillCountString(m + 1, StringCache.IntToString(oneKillInfoData2.KillNum));
				_viewModel.SetTPlayerNameString(m + 1, oneKillInfoData2.PlayerName);
				_viewModel.SetTUncheckedShow(m + 1, oneKillInfoData2.Id != cameraOwnerData_Observer);
				_viewModel.SetTCheckedShow(m + 1, oneKillInfoData2.Id == cameraOwnerData_Observer);
				_viewModel.SetTDounShow(m + 1, PlayerCareerConstantUtility.IsDoun(oneKillInfoData2.Career) || PlayerCareerConstantUtility.IsEmpress(oneKillInfoData2.Career));
				if (PlayerCareerConstantUtility.IsHumanity(entityWithEntityId6.GetCareer()))
				{
					string weaponName = entityWithEntityId6.GetCurrentWeaponName();
					if (_tWeapon[m] != weaponName)
					{
						_tWeapon[m] = weaponName;
						int i1 = m;
						_viewModel.SetTWeaponSprite(i1 + 1, base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponFullPath() + weaponName + "/ui/" + weaponName + "-2.png", delegate(Sprite v)
						{
							if (_tWeapon[i1] == weaponName)
							{
								_viewModel.SetTWeaponSprite(i1 + 1, v);
							}
						}));
					}
				}
				else
				{
					_viewModel.SetTWeaponSprite(m + 1, UiResourcesLoader.DefaultSprite);
					_tWeapon[m] = "";
				}
				_viewModel.SetTC4IconShow(m + 1, entityWithEntityId6.basicInfo.Current.HasC4);
			}
			else
			{
				_viewModel.SetTPlayerShow(m + 1, value: false);
			}
		}
	}

	private void SetIsObserver(bool ov, bool flag)
	{
		_viewModel.PanelRootshow = false;
		_viewModel.PanelRootshow = flag;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	public int GetCursorState()
	{
		if (!GameModelLocator.GetInstance().GameModel.IsObserver || !_mPressed)
		{
			return 0;
		}
		return 256;
	}

	public int GetForbidButtons()
	{
		return 0;
	}

	public bool OnKeyDown(KeyCode key)
	{
		if (key == KeyCode.M)
		{
			_mPressed = !_mPressed;
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

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
	}
}
