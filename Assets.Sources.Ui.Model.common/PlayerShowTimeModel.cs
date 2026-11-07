using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Assets.Sources.Components.Message.Bochemical;
using Assets.Sources.Config;
using Assets.Sources.Constant;
using Assets.Sources.Constant.Career;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Sources.Utils.Chip;
using Assets.Sources.Utils.Ui;
using Assets.Sources.Utils.Weapon;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJAsset.Asset;
using SSJJBase.Logger;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Common;

public class PlayerShowTimeModel : AbstractModel, IPlaybackSystem, ISetGameRuleContext, ISetMessageContext, ISetPlayerContext, ISetBattleRoomContext
{
	private PlayerShowTimeViewModel _viewModel;

	private const int ShowTime = 3000;

	private const int GoodNum = 5;

	private const int GreatNum = 7;

	private const int PerfectNum = 9;

	private const int GodLikeNum = 11;

	private List<AssetInfo> _selfKill;

	private bool _knifeKillDoun;

	private bool _infect;

	private int _raceType;

	private AlphaChip _showAlphaChip = new AlphaChip();

	private FrameAnimaChip _showFrameAnimaChip = new FrameAnimaChip();

	private string _currAsset;

	private AssetInfo _rpgComboAsset = new AssetInfo("ui/pvecommon", "Assets/Res/Assets/ui/GameGUIRes/pveCommon/selfkill/combo.png");

	private static AssetInfo _bioKnifeKillAsset = new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/message/knifekill.png");

	private static List<AssetInfo> _defaultKillAsset;

	private static List<AssetInfo> _headshotKillAsset;

	private static List<AssetInfo> _knifeKillAsset;

	private static List<AssetInfo> _specialKillAsset;

	private static List<AssetInfo> _wetAsset;

	private AssetInfo _broadSwordModeOneKillAsset = new AssetInfo("ui/BroadSwordModel", "Assets/Res/Assets/ui/GameGUIRes/BroadSwordModel/Kill/KillOne1.png");

	private AssetInfo _broadSwordModeTwoKillAsset = new AssetInfo("ui/BroadSwordModel", "Assets/Res/Assets/ui/GameGUIRes/BroadSwordModel/Kill/KillTwo1.png");

	private AssetInfo _broadSwordModeSomeKillAsset = new AssetInfo("ui/BroadSwordModel", "Assets/Res/Assets/ui/GameGUIRes/BroadSwordModel/Kill/KillSome1.png");

	private static AssetInfo _helpKillAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/selfkill/helpkill.png");

	private static AssetInfo _bigkillAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/selfkill/bigkill.png");

	private static AssetInfo _unstoppableAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/selfkill/unstoppable.png");

	private static AssetInfo _killingspreeAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/selfkill/killingspree.png");

	private GameRuleContext _gameRuleContext;

	private MessageContext _messageContext;

	private PlayerContext _playerContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new PlayerShowTimeViewModel();
	}

	public void OnPlayback()
	{
		if (!_viewModel.IsInited)
		{
			return;
		}
		UpdateChips();
		if (_knifeKillDoun)
		{
			MessageDataInfo message = _messageContext.bioMessageData.Message;
			if (message != null && message.Type == BioMessageType.KNIFEKILLLEVELDOWN)
			{
				_knifeKillDoun = false;
				_viewModel.KillImageShow = false;
			}
		}
	}

	private void InitChips()
	{
		_showAlphaChip.Alpha = 0f;
		_showAlphaChip.Speed = -1f;
		_showFrameAnimaChip.Delay = int.MaxValue;
		_showFrameAnimaChip.IsLoop = false;
		_showFrameAnimaChip.StartIndex = 1;
		_showFrameAnimaChip.Init();
	}

	private void UpdateChips()
	{
		_viewModel.ShowAlpha = _showAlphaChip.Update(_timeComponent);
		_showFrameAnimaChip.Update(_timeComponent);
		if (!_showFrameAnimaChip.Changed || _selfKill == null)
		{
			return;
		}
		string assetName = (_currAsset = _showFrameAnimaChip.Value);
		base.Loader.RetriveSprite(_selfKill[0].BundleName, _currAsset, delegate(Sprite v)
		{
			if (_currAsset == assetName)
			{
				_viewModel.KillImageSprite = v;
			}
		});
	}

	protected override void DoSubscribe()
	{
		_defaultKillAsset = new List<AssetInfo>
		{
			new AssetInfo($"ui/selfkill_{TplManager.Instance.GameBootConfig.SelfKillNormal.ToLower()}", $"Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/selfKill/{TplManager.Instance.GameBootConfig.SelfKillNormal}/selfKill1.png")
		};
		_headshotKillAsset = new List<AssetInfo>
		{
			new AssetInfo($"ui/selfkill_{TplManager.Instance.GameBootConfig.SelfKillHeadShot.ToLower()}", $"Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/selfKill/{TplManager.Instance.GameBootConfig.SelfKillHeadShot}/selfKill1.png")
		};
		_knifeKillAsset = new List<AssetInfo>
		{
			new AssetInfo($"ui/selfkill_{TplManager.Instance.GameBootConfig.SelfKillKnife.ToLower()}", $"Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/selfKill/{TplManager.Instance.GameBootConfig.SelfKillKnife}/selfKill1.png")
		};
		_specialKillAsset = new List<AssetInfo>
		{
			new AssetInfo($"ui/selfkill_{TplManager.Instance.GameBootConfig.SelfKillSpecial.ToLower()}", $"Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/selfKill/{TplManager.Instance.GameBootConfig.SelfKillSpecial}/selfKill1.png")
		};
		base.DoSubscribe();
		NotifyManager.MakeNotifyClass(22, UiIEventCondition.Get_killPlayerInfo_InfoList, SetInfoList, initinvoke: true);
		NotifyManager.MakeNotify(35, UiIEventCondition.Get_assistsNumData_AssistsNum, SetAssistsNum);
		if (_gameRuleContext.currentRule.Rule.IsRpg())
		{
			_viewModel.RpgComboSprite = this.GetLoader().RetriveSprite(_rpgComboAsset, delegate(Sprite sprite)
			{
				_viewModel.RpgComboSprite = sprite;
			});
		}
		_viewModel.RpgComboShow = false;
		_viewModel.ContinusKillShow = false;
		_viewModel.ShowAlpha = 0f;
		LoadConfig(_defaultKillAsset, TplManager.Instance.GameBootConfig.SelfKillNormal);
		LoadConfig(_headshotKillAsset, TplManager.Instance.GameBootConfig.SelfKillHeadShot);
		LoadConfig(_knifeKillAsset, TplManager.Instance.GameBootConfig.SelfKillKnife);
		LoadConfig(_specialKillAsset, TplManager.Instance.GameBootConfig.SelfKillSpecial);
	}

	private void LoadConfig(List<AssetInfo> list, string weapon)
	{
		base.Loader.Load($"ui/selfkill_{weapon.ToLower()}", $"Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/selfKill/{weapon}/selfKillConfig.xml", delegate(UnityEngine.Object text)
		{
			try
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.LoadXml(text.ToString());
				IEnumerator enumerator = xmlDocument.DocumentElement.GetEnumerator();
				try
				{
					if (enumerator.MoveNext())
					{
						int num = int.Parse(((XmlElement)enumerator.Current).GetAttribute("movieLenth"));
						list.Clear();
						for (int i = 0; i < num; i++)
						{
							list.Add(new AssetInfo($"ui/selfkill_{weapon.ToLower()}", $"Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/selfKill/{weapon}/selfKill{i + 1}.png"));
						}
					}
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
			}
			catch (Exception message)
			{
				this.LogError(message);
			}
		});
	}

	public List<AssetInfo> GetBroadSwordKillList(KillPlayerInfoData killPlayerInfo)
	{
		using (List<int>.Enumerator enumerator = killPlayerInfo.GunGloryList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				switch (enumerator.Current)
				{
				case 22:
					return new List<AssetInfo> { _broadSwordModeSomeKillAsset };
				case 21:
					return new List<AssetInfo> { _broadSwordModeTwoKillAsset };
				}
			}
		}
		return new List<AssetInfo> { _broadSwordModeOneKillAsset };
	}

	public List<AssetInfo> GetSelfKillAsset(KillPlayerInfoData killPlayerInfo)
	{
		if (killPlayerInfo.WeaponType == 2)
		{
			return _knifeKillAsset;
		}
		if (killPlayerInfo.Headshot)
		{
			return _headshotKillAsset;
		}
		if (killPlayerInfo.SpecialAttack)
		{
			return _specialKillAsset;
		}
		return _defaultKillAsset;
	}

	private void SetInfoList(Queue<KillPlayerInfoData> ov, Queue<KillPlayerInfoData> killPlayerInfos)
	{
		foreach (KillPlayerInfoData killPlayerInfo in killPlayerInfos)
		{
			if (killPlayerInfo.KillPlayerId != UiIEventCondition.Get_cameraOwnerData_PlayerId())
			{
				continue;
			}
			ShowBioInfect();
			ShowBioKnifeKill(killPlayerInfo);
			RefreshShowTime(killPlayerInfo);
			if (!_infect)
			{
				_viewModel.ShowShow = true;
				_showAlphaChip.Delay = ((_gameRuleContext.gunGlory.GunGloryList.Count > 0) ? 1500 : 3000) - 1000;
				_showAlphaChip.Alpha = 1f;
				if (_knifeKillDoun)
				{
					_viewModel.KillImageShow = true;
					_viewModel.KillImageSprite = ((UiResourcesLoader)base.Loader).RetriveSprite(_bioKnifeKillAsset, delegate(Sprite v)
					{
						_viewModel.KillImageSprite = v;
					});
					_showFrameAnimaChip.Delay = int.MaxValue;
					if (_timeComponent != null)
					{
						_showFrameAnimaChip.Update(_timeComponent);
					}
				}
				else
				{
					if (_raceType == 123)
					{
						_selfKill = GetBroadSwordKillList(killPlayerInfo);
					}
					else
					{
						_selfKill = GetSelfKillAsset(killPlayerInfo);
					}
					if (_selfKill == null)
					{
						this.LogErrorFormat("WeaponSelfKillInfoFactory.Instance.GetSelfKillTempData return null {0}", UiIEventCondition.Get_weaponState_WeaponName());
					}
					else
					{
						_viewModel.KillImageShow = true;
						_showFrameAnimaChip.Delay = ((_selfKill.Count <= 1) ? int.MaxValue : (500 / _selfKill.Count));
						_showFrameAnimaChip.Index = 1;
						_showFrameAnimaChip.RemainTime = 0;
						_showFrameAnimaChip.Count = _selfKill.Count;
						_showFrameAnimaChip.Path = _selfKill[0].AssetName.Info.Substring(0, _selfKill[0].AssetName.Info.Length - 5);
						if (_selfKill.Count <= 1 && _timeComponent != null)
						{
							_showFrameAnimaChip.Update(_timeComponent);
						}
						_viewModel.KillImageSprite = base.Loader.RetriveSprite(_selfKill[0].BundleName, _selfKill[0].AssetName, delegate(Sprite v)
						{
							_viewModel.KillImageSprite = v;
						});
					}
				}
			}
			else
			{
				_viewModel.KillImageShow = false;
			}
			if (killPlayerInfo.KillScore > 0)
			{
				_viewModel.KillScoreBackShow = true;
				_viewModel.KillScroeString = killPlayerInfo.KillScore.ToString();
			}
			else
			{
				_viewModel.KillScoreBackShow = false;
			}
		}
	}

	private void ShowBioKnifeKill(KillPlayerInfoData killPlayerInfo)
	{
		_knifeKillDoun = false;
		if (KillTypeConstant.GetKillType(killPlayerInfo) != 5 || !ShowSpecialKillBroad(killPlayerInfo.WeaponName))
		{
			_knifeKillDoun = _gameRuleContext.currentRule.Rule.IsBio() && WeaponUtility.IsBioKnifeKill(killPlayerInfo.WeaponType, killPlayerInfo.WeaponName, killPlayerInfo.SpecialAttack);
		}
	}

	private void ShowBioInfect()
	{
		_infect = _gameRuleContext.currentRule.Rule.IsBio() && (PlayerCareerConstantUtility.IsDoun(UiIEventCondition.Get_cameraOwnerData_Career()) || PlayerCareerConstantUtility.IsEmpress(UiIEventCondition.Get_cameraOwnerData_Career()));
	}

	private bool ShowSpecialKillBroad(string weaponName)
	{
		if ("double_scythe" == weaponName || "double_fangs_g" == weaponName || "axe_g" == weaponName || "shovel_g" == weaponName || "nbr_knife_g" == weaponName)
		{
			return true;
		}
		return false;
	}

	private void SetAssistsNum(int ov, int assistsNum)
	{
		if (assistsNum <= 0)
		{
			return;
		}
		_viewModel.ContinusKillShow = false;
		_viewModel.RpgComboShow = false;
		_viewModel.RevengeShow = false;
		_viewModel.GradeShow = false;
		_showAlphaChip.Delay = 2000f;
		_showAlphaChip.Alpha = 1f;
		_showFrameAnimaChip.Delay = int.MaxValue;
		if (_timeComponent != null)
		{
			_showFrameAnimaChip.Update(_timeComponent);
		}
		string career = _playerContext.cameraOwnerEntity.GetCareer();
		if (PlayerCareerConstantUtility.IsHumanity(career) || PlayerCareerConstantUtility.IsHero(career))
		{
			_viewModel.KillImageSprite = ((UiResourcesLoader)base.Loader).RetriveSprite(_helpKillAsset, delegate(Sprite v)
			{
				_viewModel.KillImageSprite = v;
			});
		}
	}

	private void RefreshShowTime(KillPlayerInfoData killPlayerInfoData)
	{
		if (killPlayerInfoData.Revenge)
		{
			_viewModel.RevengeShow = true;
		}
		else
		{
			_viewModel.RevengeShow = false;
		}
		if (_gameRuleContext.currentRule.Rule.IsRpg())
		{
			_viewModel.ComboCountString = killPlayerInfoData.PveCurKillNum.ToString();
			_viewModel.RpgComboShow = killPlayerInfoData.PveCurKillNum > 1;
			if (killPlayerInfoData.CurKillNum >= 30)
			{
				_viewModel.GradeShow = true;
				_viewModel.GradeSprite = this.GetLoader().RetriveSprite(_killingspreeAsset, delegate(Sprite sprite)
				{
					_viewModel.GradeSprite = sprite;
				});
			}
			else if (killPlayerInfoData.CurKillNum >= 15)
			{
				_viewModel.GradeShow = true;
				_viewModel.GradeSprite = this.GetLoader().RetriveSprite(_unstoppableAsset, delegate(Sprite sprite)
				{
					_viewModel.GradeSprite = sprite;
				});
			}
			else if (killPlayerInfoData.CurKillNum >= 5)
			{
				_viewModel.GradeShow = true;
				_viewModel.GradeSprite = this.GetLoader().RetriveSprite(_bigkillAsset, delegate(Sprite sprite)
				{
					_viewModel.GradeSprite = sprite;
				});
			}
			else
			{
				_viewModel.GradeShow = false;
			}
		}
		else if (killPlayerInfoData.CurKillNum > 1)
		{
			_viewModel.ContinusKillShow = true;
			if (killPlayerInfoData.CurKillNum >= 11)
			{
				base.Loader.RetriveSprite("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/selfkill/10kill+.png", delegate(Sprite sprite)
				{
					_viewModel.ContinusKillSprite = sprite;
				});
			}
			else
			{
				base.Loader.RetriveSprite("ui/common", $"Assets/Res/Assets/ui/GameGUIRes/common/selfkill/{killPlayerInfoData.CurKillNum}kill.png", delegate(Sprite sprite)
				{
					_viewModel.ContinusKillSprite = sprite;
				});
			}
			if (killPlayerInfoData.CurKillNum >= 9)
			{
				_viewModel.GradeShow = true;
				_viewModel.GradeSprite = this.GetLoader().RetriveSprite(_killingspreeAsset, delegate(Sprite sprite)
				{
					_viewModel.GradeSprite = sprite;
				});
			}
			else if (killPlayerInfoData.CurKillNum >= 7)
			{
				_viewModel.GradeShow = true;
				_viewModel.GradeSprite = this.GetLoader().RetriveSprite(_unstoppableAsset, delegate(Sprite sprite)
				{
					_viewModel.GradeSprite = sprite;
				});
			}
			else if (killPlayerInfoData.CurKillNum >= 5)
			{
				_viewModel.GradeShow = true;
				_viewModel.GradeSprite = this.GetLoader().RetriveSprite(_bigkillAsset, delegate(Sprite sprite)
				{
					_viewModel.GradeSprite = sprite;
				});
			}
			else
			{
				_viewModel.GradeShow = false;
			}
		}
		else
		{
			_viewModel.GradeShow = false;
			_viewModel.ContinusKillShow = false;
		}
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public void SetMessageContext(MessageContext context)
	{
		_messageContext = context;
	}

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_raceType = context.roomData.Data.RaceType;
	}
}
