using System.Collections.Generic;
using Assets.Libs.NotifyLib.Simplify;
using Assets.Sources.Components.Time;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.BioChemical_Z;
using Assets.Sources.Utils.Chip;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJBase.Input;
using SSJJNetworking.BattleServer;
using UnityEngine;

namespace Assets.Sources.Ui.Model.BioChemical_Z;

[GameUiTest]
public class BioChemical_ZModel : AbstractModel, IKeyboardResponder, ISetPlayerContext
{
	private BioChemical_ZViewModel _viewModel;

	private int pageNum;

	private int maxPage;

	private float _alphaAdd;

	private float _effectAlpha;

	private int _enterTime;

	private PlayerContext _playerContext;

	private ActiveChip _tPlayerDes = new ActiveChip();

	private ActiveChip _tSkillDes = new ActiveChip();

	private bool isShowShop;

	private ActiveChip[] _goleUpdate = new ActiveChip[8];

	public int _userGoldId = 8;

	protected override IUiViewModel ViewModel => _viewModel;

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
		_viewModel = new BioChemical_ZViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel == null || !_viewModel.IsInited)
		{
			return;
		}
		UpdateChips(_timeComponent);
		_enterTime += _timeComponent.FrameInterval;
		_viewModel.LevelUpEffectShow = _enterTime < 1000;
		if (_viewModel.LevelUpEffectShow)
		{
			_effectAlpha += _alphaAdd * (float)_timeComponent.FrameInterval / 500f * 0.7f;
			if (_effectAlpha >= 1f)
			{
				_alphaAdd = -1f;
			}
			else if (_effectAlpha <= 0.3f)
			{
				_alphaAdd = 1f;
			}
			BioChemical_ZViewModel viewModel = _viewModel;
			float leftAlpha = (_viewModel.RightAlpha = _effectAlpha);
			viewModel.LeftAlpha = leftAlpha;
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeNotifyClass(124, UiIEventCondition.Get_gameBioZ_TipsEvent, SetBioZEvent, initinvoke: true);
		NotifyManager.MakeNotifyClass(125, UiIEventCondition.Get_gameTipsShow_TipsEvent, SetTipsEvent, initinvoke: true);
		NotifyManager.MakeNotifyClass(126, UiIEventCondition.Get_gameBioZ_DiffWeaponEvent, SetBioZDiffWeaponEvent);
		SimpleNotify.Add(GetCareer, SetCareer);
		SimpleNotify.Add(GetHpPercent, SetHpPercent);
		SimpleNotify.Add(GetHdPercent, SetHdPercent);
		for (int i = 1; i < 6; i++)
		{
			_viewModel.SetbtnIconShow(i, value: false);
		}
	}

	private string GetCareer(int arg1)
	{
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		if (cameraOwnerEntity != null)
		{
			return cameraOwnerEntity.GetCareer();
		}
		return "";
	}

	private void SetCareer(string arg1, int arg2)
	{
		if (!string.IsNullOrEmpty(arg1))
		{
			base.Loader.RetriveSprite("ui/halfloadedres/pveplayerstate", $"Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/pveplayerstate/{arg1}.png", delegate(Sprite sprite)
			{
				_viewModel.PIconSprite = sprite;
			});
			base.Loader.RetriveSprite("ui/halfloadedres/bio3SelectVariant", $"Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/bio3SelectVariant/{arg1}.png", delegate(Sprite sprite)
			{
				_viewModel.playerDesSprite = sprite;
				_tPlayerDes.Time = 3000;
			});
		}
	}

	private bool GetHaveBv(int arg1)
	{
		return _playerContext.cameraOwnerEntity?.basicInfo.Current.ArmorBody ?? false;
	}

	private void SetHpPercent(float arg1, int arg2)
	{
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		if (cameraOwnerEntity != null && cameraOwnerEntity.basicInfo.Current.MaxHp > 0)
		{
			_viewModel.HP_String2 = cameraOwnerEntity.basicInfo.Current.Hp + "/" + cameraOwnerEntity.basicInfo.Current.MaxHp;
		}
		_viewModel.HPFillamount = arg1;
	}

	private float GetHpPercent(int arg1)
	{
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		if (cameraOwnerEntity != null && cameraOwnerEntity.basicInfo.Current.MaxHp > 0)
		{
			return 1f * (float)cameraOwnerEntity.basicInfo.Current.Hp / (float)cameraOwnerEntity.basicInfo.Current.MaxHp;
		}
		return 0f;
	}

	private void SetHdPercent(float arg1, int arg2)
	{
		_viewModel.HDFillamount = arg1;
	}

	private float GetHdPercent(int arg1)
	{
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		if (cameraOwnerEntity != null && cameraOwnerEntity.basicInfo.Current.BiozShieldMaxHp > 0)
		{
			return 1f * (float)cameraOwnerEntity.basicInfo.Current.BiozShieldHp / (float)cameraOwnerEntity.basicInfo.Current.BiozShieldMaxHp;
		}
		return 0f;
	}

	protected virtual void SetBioZEvent(NBioZInitData ov, NBioZInitData biozData)
	{
		List<NBioZCareerData> careerList = biozData.CareerList;
		careerList.Sort(delegate(NBioZCareerData a, NBioZCareerData b)
		{
			if (a.Lv >= Contexts.sharedInstance.message.bioZInit.Level && b.Lv >= Contexts.sharedInstance.message.bioZInit.Level)
			{
				if (a.Lv < b.Lv)
				{
					return -1;
				}
				return 1;
			}
			if (a.Lv <= Contexts.sharedInstance.message.bioZInit.Level && b.Lv <= Contexts.sharedInstance.message.bioZInit.Level)
			{
				if (a.Lv <= b.Lv)
				{
					return 1;
				}
				return -1;
			}
			return (a.Lv >= Contexts.sharedInstance.message.bioZInit.Level) ? 1 : (-1);
		});
		int num = pageNum * 9;
		int num2 = Mathf.Min(num + 9, careerList.Count);
		int num3 = 0;
		int num4 = num;
		while (num4 < num2)
		{
			int headid = num3 + 1;
			_viewModel.SetPlayerbgShow(num3, value: true);
			base.Loader.RetriveSprite("ui/biochemical_z", $"Assets/Res/Assets/ui/GameGUIRes/biochemical_z/head/{careerList[num4].Career}.png", delegate(Sprite sprite)
			{
				_viewModel.SetPlayerIconSprite(headid, sprite);
			});
			num4++;
			num3++;
		}
		for (int i = num3; i < 9; i++)
		{
			_viewModel.SetPlayerbgShow(i, value: false);
		}
		maxPage = biozData.CareerList.Count / 9;
	}

	protected virtual void SetTipsEvent(List<RpgTipsEventData> ov, List<RpgTipsEventData> tipsEvent)
	{
		if (tipsEvent == null)
		{
			return;
		}
		int num;
		for (num = 0; num < tipsEvent.Count; num++)
		{
			if (tipsEvent[num].TypeId == -13520)
			{
				_viewModel.btnIconShow1 = tipsEvent[num].Show;
				_viewModel.SkillCountString = tipsEvent[num].Time1.ToString();
			}
			else if (tipsEvent[num].TypeId == -13521)
			{
				_viewModel.btnIconShow3 = tipsEvent[num].Show;
			}
			else if (tipsEvent[num].TypeId == -13522)
			{
				_viewModel.btnIconShow2 = tipsEvent[num].Show;
				if (!tipsEvent[num].Show)
				{
					_viewModel.playerSelectShow = false;
				}
			}
			else if (tipsEvent[num].TypeId == -13526)
			{
				_viewModel.btnIconShow5 = tipsEvent[num].Show;
			}
			else if (tipsEvent[num].TypeId == -13527)
			{
				_viewModel.btnIconShow4 = tipsEvent[num].Show;
			}
			else if (tipsEvent[num].TypeId == -13523 && _viewModel.btnIconShow1)
			{
				_tSkillDes.Time = 3000;
			}
			else if (tipsEvent[num].TypeId == -13524)
			{
				Debug.LogError(tipsEvent[num].Time2);
				if (tipsEvent[num].Time2 != 0)
				{
					_viewModel.Getmoney_Obj(_userGoldId).transform.SetAsLastSibling();
					string text = "";
					text = ((tipsEvent[num].Time2 <= 0) ? $"<color=#ff0a0a>{tipsEvent[num].Time2}</color>" : $"<color=#dfd620>+{tipsEvent[num].Time2}</color>");
					_viewModel.Setmoney_String(_userGoldId, text);
					_goleUpdate[_userGoldId - 1].Time = 3000;
					_userGoldId--;
					if (_userGoldId <= 0)
					{
						_userGoldId = 8;
					}
				}
				_viewModel.moneyString = tipsEvent[num].Time1.ToString();
				Contexts.sharedInstance.message.bioZInit.gold = tipsEvent[num].Time1;
			}
			else if (tipsEvent[num].TypeId == -13525)
			{
				_viewModel.expFillamount = (float)tipsEvent[num].Time1 * 1f / (float)tipsEvent[num].Time2;
				if (Contexts.sharedInstance.message.bioZInit.Level != tipsEvent[num].Time3)
				{
					Contexts.sharedInstance.message.bioZInit.Level = tipsEvent[num].Time3;
					_viewModel.LvString = "Lv." + tipsEvent[num].Time3;
					_enterTime = 0;
					_alphaAdd = 1f;
					_effectAlpha = 0.3f;
				}
			}
			else if (tipsEvent[num].TypeId == -13528)
			{
				_viewModel.ysString = tipsEvent[num].Time1.ToString();
				_viewModel.tyString = tipsEvent[num].Time2.ToString();
				_viewModel.shString = (tipsEvent[num].Time3 / 1000).ToString();
			}
			tipsEvent.RemoveAt(num);
			num--;
		}
	}

	protected virtual void SetBioZDiffWeaponEvent(NBioZDiffWeaponData ov, NBioZDiffWeaponData biozData)
	{
		isShowShop = true;
	}

	private void InitChips()
	{
		_tSkillDes = new ActiveChip();
		_tPlayerDes = new ActiveChip();
		for (int i = 0; i < 8; i++)
		{
			_goleUpdate[i] = new ActiveChip();
		}
	}

	private void UpdateChips(TimeComponent time)
	{
		_viewModel.SkillDesShow = _tSkillDes.Update(time);
		_viewModel.playerDesShow = _tPlayerDes.Update(time);
		for (int i = 0; i < 8; i++)
		{
			_viewModel.Setmoney_Show(i + 1, _goleUpdate[i].Update(time));
			_viewModel.Setmoney_Alpha(i + 1, (float)_goleUpdate[i].Time / 3000f);
		}
	}

	public bool OnKeyDown(KeyCode key)
	{
		if (key == KeyCode.V)
		{
			Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(143);
		}
		else if (key == KeyCode.M && !_viewModel.playerSelectShow && _viewModel.btnIconShow2)
		{
			_viewModel.playerSelectShow = true;
			pageNum = 0;
			_viewModel.lbtnShow = false;
		}
		else if (key == KeyCode.B && _viewModel.btnIconShow3)
		{
			if (!isShowShop)
			{
				IBattleServer server = Contexts.sharedInstance.battleServer.battleServer.Server;
				IntData message = new IntData
				{
					Data = 1
				};
				server.SendTcpMessage(146, message);
			}
			else
			{
				isShowShop = false;
			}
		}
		else if (key == KeyCode.L && _viewModel.btnIconShow4)
		{
			Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(142);
		}
		else if (key == KeyCode.N && _viewModel.btnIconShow5)
		{
			Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(145);
		}
		if (_viewModel.playerSelectShow)
		{
			if (key == KeyCode.Comma)
			{
				pageNum = Mathf.Max(0, pageNum - 1);
				SetBioZEvent(null, UiIEventCondition.Get_gameBioZ_TipsEvent());
			}
			if (key == KeyCode.Period)
			{
				pageNum = Mathf.Min(maxPage, pageNum + 1);
				SetBioZEvent(null, UiIEventCondition.Get_gameBioZ_TipsEvent());
			}
			_viewModel.lbtnShow = pageNum != 0;
			_viewModel.rbtnShow = pageNum != maxPage;
			int num = -1;
			if (key - 48 > KeyCode.None && key - 48 < (KeyCode)10)
			{
				num = (int)(key - 48 + pageNum * 9);
			}
			if (key - 256 > KeyCode.None && key - 256 < (KeyCode)10)
			{
				num = (int)(key - 256 + pageNum * 9);
			}
			num--;
			if (num >= 0 && num < UiIEventCondition.Get_gameBioZ_TipsEvent().CareerList.Count)
			{
				IBattleServer server2 = Contexts.sharedInstance.battleServer.battleServer.Server;
				StringData message2 = new StringData
				{
					Data = UiIEventCondition.Get_gameBioZ_TipsEvent().CareerList[num].Career
				};
				server2.SendTcpMessage(141, message2);
				_viewModel.playerSelectShow = false;
			}
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
