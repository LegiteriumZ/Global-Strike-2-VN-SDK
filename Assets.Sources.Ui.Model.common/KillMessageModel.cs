using System.Collections.Generic;
using Assets.Sources.Constant.Weapon;
using Assets.Sources.Framework;
using Assets.Sources.Info.Weapon;
using Assets.Sources.Modules.Ui;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Sources.Utils;
using Assets.Sources.Utils.Chip;
using Assets.Sources.Utils.Ui;
using Assets.Sources.Utils.Weapon;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJAnim.Weapon;
using SSJJAsset.Asset;
using SSJJBase.Singleton;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Common;

public class KillMessageModel : AbstractModel, IPlaybackSystem
{
	private class AssetData
	{
		public string WeaponName;

		public int WeaponLevel;

		public bool IsSecondary;

		public bool IsAwakenKill;

		public bool Permanent;

		public AssetInfo Asset;

		public bool HasAsset;

		public AssetInfo DefaultAsset;

		public string SkinName;
	}

	private KillmessageViewModel _viewModel = new KillmessageViewModel();

	private const int MessageNumber = 8;

	private const int Duration = 5000;

	private List<long> _startTimeList;

	private List<int> _messageList;

	private Dictionary<int, FrameAnimaChip> _timeDic;

	private int _index;

	private List<int> _refresh = new List<int>();

	private Dictionary<int, int> _reliveTime = new Dictionary<int, int>();

	private Dictionary<string, int> _gloryDic = new Dictionary<string, int>();

	private Dictionary<int, string> _numDic = new Dictionary<int, string>();

	private List<AssetData> _weaponAsset = new List<AssetData>();

	private Dictionary<int, AssetInfo> _assetDic = new Dictionary<int, AssetInfo>();

	private Dictionary<int, string> _nameDic = new Dictionary<int, string>();

	private static AssetInfo _permanentAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/kill/permanent.png");

	private static AssetInfo _heroAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/kill/hero.png");

	private static AssetInfo _legendAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/kill/legend.png");

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		base.Initialize();
		_startTimeList = new List<long>();
		_messageList = new List<int>();
		_timeDic = new Dictionary<int, FrameAnimaChip>();
		_index = 1;
	}

	protected override void OnGameobjectInitialized()
	{
		for (int i = 1; i <= 8; i++)
		{
			_viewModel.SetMessageShow(i, value: false);
		}
		base.OnGameobjectInitialized();
	}

	public void OnPlayback()
	{
		if (_messageList.Count > 0 && TimeUtility.UnixTimeNow() - _startTimeList[0] > 5000)
		{
			_startTimeList.RemoveAt(0);
			_viewModel.SetMessageShow(_messageList[0], value: false);
			_viewModel.GetMessageObj(_messageList[0]).transform.SetAsLastSibling();
			_messageList.RemoveAt(0);
		}
		if (_refresh.Count > 0)
		{
			_viewModel.CallMessageHlayoutupdate(_refresh[0]);
			_viewModel.PanelVlayoutupdate();
			_refresh.RemoveAt(0);
		}
		foreach (int key in _timeDic.Keys)
		{
			if (!_viewModel.GetMessageShow(key))
			{
				continue;
			}
			_timeDic[key].Update(_timeComponent);
			if (_timeDic[key].Changed)
			{
				int i1 = key;
				base.Loader.RetriveSprite("ui/common", _timeDic[key].Value, delegate(Sprite sprite)
				{
					_viewModel.SetKillTypeSprite(i1, sprite);
					_viewModel.CallKillTypeNtvsize(i1);
				});
			}
		}
	}

	private void AddMessage(int i, KillPlayerInfoData data)
	{
		_viewModel.SetMessageShow(i, value: true);
		GetGlory(i, data);
		GetWeapon(i, data);
		_viewModel.SetReliveShow(i, value: false);
		_viewModel.SetLabelShow(i, SingletonInstance<ChampionWeaponAndSkillParser>.Instance.GetChampionWeaponAndSkillfig(data.WeaponSkinName));
		_reliveTime[i] = 0;
		_viewModel.SetKillerString(i, data.KillPlayerName);
		_viewModel.SetKillerTextcolor(i, (data.KillPlayerId == UiIEventCondition.Get_uiMyPlayer_PlayerId()) ? Color.green : ((data.KillTeam == 1) ? Color.red : new Color(0.266f, 0.805f, 0.96f)));
		_viewModel.SetVictimString(i, data.BeKillPlayerName);
		_viewModel.SetVictimTextcolor(i, (data.BeKillPlayerId == UiIEventCondition.Get_uiMyPlayer_PlayerId()) ? Color.green : ((data.BekillTeam == 1) ? Color.red : new Color(0.266f, 0.805f, 0.96f)));
		GetKillNum(i, data);
		GetKillType(i, data);
		GetAssistType(i, data);
		GetModeKill(i, data);
		_refresh.Add(i);
		_refresh.Add(i);
		_viewModel.PanelVlayoutupdate();
		_viewModel.ViewGameObjectShow = false;
		_viewModel.ViewGameObjectShow = true;
		_viewModel.PanelVlayoutupdate();
	}

	private void GetAssistType(int i, KillPlayerInfoData data)
	{
		if (!string.IsNullOrEmpty(data.ConnectPlayerName))
		{
			_viewModel.SetAssistantTypeShow(i, value: true);
			base.Loader.RetriveSprite("ui/common", "love", delegate(Sprite sprite)
			{
				_viewModel.SetAssistantTypeSprite(i, sprite);
				_refresh.Add(i);
			});
			_viewModel.CallAssistantTypeNtvsize(i);
			_viewModel.SetAssisterShow(i, value: true);
			_viewModel.SetAssisterString(i, data.ConnectPlayerName);
			_viewModel.SetAssisterTextcolor(i, new Color(1f, 0.4f, 0.8f));
		}
		else
		{
			_viewModel.SetAssistantTypeShow(i, value: false);
			_viewModel.SetAssisterShow(i, value: false);
		}
	}

	private void GetGlory(int i, KillPlayerInfoData data)
	{
		_viewModel.SetGloryAShow(i, data.GunGloryList.Count > 0);
		if (data.GunGloryList.Count > 0 && (!_gloryDic.ContainsKey("A" + i) || _gloryDic["A" + i] != data.GunGloryList[0] + 1))
		{
			_gloryDic["A" + i] = data.GunGloryList[0] + 1;
			base.Loader.RetriveSprite("ui/halfloadedres/gunglory", "s" + data.GunGloryList[0], delegate(Sprite sprite)
			{
				_viewModel.SetGloryASprite(i, sprite);
				_refresh.Add(i);
			});
		}
		_viewModel.SetGloryBShow(i, data.GunGloryList.Count > 1);
		if (data.GunGloryList.Count > 1 && (!_gloryDic.ContainsKey("B" + i) || _gloryDic["B" + i] != data.GunGloryList[1] + 1))
		{
			_gloryDic["B" + i] = data.GunGloryList[1] + 1;
			base.Loader.RetriveSprite("ui/halfloadedres/gunglory", "s" + data.GunGloryList[1], delegate(Sprite sprite)
			{
				_viewModel.SetGloryBSprite(i, sprite);
				_refresh.Add(i);
			});
		}
		_viewModel.SetGloryCShow(i, data.GunGloryList.Count > 2);
		if (data.GunGloryList.Count > 2 && (!_gloryDic.ContainsKey("C" + i) || _gloryDic["C" + i] != data.GunGloryList[2] + 1))
		{
			_gloryDic["C" + i] = data.GunGloryList[2] + 1;
			base.Loader.RetriveSprite("ui/halfloadedres/gunglory", "s" + data.GunGloryList[2], delegate(Sprite sprite)
			{
				_viewModel.SetGloryCSprite(i, sprite);
				_refresh.Add(i);
			});
		}
	}

	private void GetKillNum(int i, KillPlayerInfoData data)
	{
		string text = "";
		if (data.FirstBlood)
		{
			text = "ui_kill_1b";
			_viewModel.SetKillCountString(i, "");
		}
		else if (data.CurKillNum > 99)
		{
			text = "ui_kill_r";
			_viewModel.SetKillCountString(i, "");
		}
		else if (data.CurKillNum > 1)
		{
			text = "ui_kill_number";
			_viewModel.SetKillCountString(i, data.CurKillNum.ToString());
		}
		if (string.IsNullOrEmpty(text))
		{
			_viewModel.SetKillCountBackShow(i, value: false);
			return;
		}
		_viewModel.SetKillCountBackShow(i, value: true);
		if (!_numDic.ContainsKey(i) || _numDic[i] != text)
		{
			_numDic[i] = text;
			base.Loader.RetriveSprite("ui/common", text, delegate(Sprite sprite)
			{
				_viewModel.SetKillCountBackSprite(i, sprite);
				_refresh.Add(i);
			});
		}
	}

	private void GetModeKill(int i, KillPlayerInfoData data)
	{
		string value = "";
		if (data.WeaponRule == 1)
		{
			value = "biokill";
		}
		else if (data.WeaponRule == 2)
		{
			value = "rechargekill";
		}
		else if (data.WeaponRule == 3)
		{
			value = "sportskill";
		}
		if (string.IsNullOrEmpty(value) || data.RuleKillNumber <= 0)
		{
			_viewModel.SetModeKillBackShow(i, value: false);
			return;
		}
		_viewModel.SetModeKillBackShow(i, value: true);
		_refresh.Add(i);
		_viewModel.SetModeKillCountString(i, data.RuleKillNumber.ToString());
	}

	private void GetKillType(int i, KillPlayerInfoData data)
	{
		string text = "";
		text = (data.SpecialAttack ? ((!WeaponConstant.IsGoldWeapon(data.WeaponName)) ? "killinfospecialkill" : "goldweaponspecialkill") : (data.Headshot ? ((data.WeaponType == 3) ? "knifeheadshot" : ((!data.Wallshot) ? "headshot" : "wallheadshot")) : (data.Wallshot ? "wallkill" : ((!data.IsAwakenKill) ? "" : "killinfoawakekill"))));
		if (SingletonInstance<ChampionWeaponAndSkillParser>.Instance.GetChampionWeaponAndSkillfig(data.WeaponSkinName))
		{
			if (_timeDic.ContainsKey(i))
			{
				_timeDic[i].Index = 1;
				_timeDic[i].RemainTime = 0;
			}
			else
			{
				FrameAnimaChip frameAnimaChip = new FrameAnimaChip
				{
					Count = 4,
					StartIndex = 1,
					Path = "Assets/Res/Assets/ui/GameGUIRes/common/kill/kill",
					Delay = 125,
					IsLoop = false
				};
				frameAnimaChip.Init();
				_timeDic.Add(i, frameAnimaChip);
			}
			_viewModel.SetKillTypeShow(i, value: true);
			_refresh.Add(i);
			_assetDic[i] = default(AssetInfo);
			return;
		}
		if (string.IsNullOrEmpty(text))
		{
			_viewModel.SetKillTypeShow(i, value: false);
			return;
		}
		_viewModel.SetKillTypeShow(i, value: true);
		AssetInfo assetInfo = ((text == "killinfospecialkill" || text == "killinfoawakekill") ? new AssetInfo(UiAssetBundleUtils.GetWeaponBundleName(data.WeaponName), text) : new AssetInfo("ui/common", text));
		if (!_assetDic.ContainsKey(i) || _assetDic[i] != assetInfo)
		{
			_assetDic[i] = assetInfo;
			_viewModel.SetKillTypeSprite(i, this.GetLoader().RetriveSprite(assetInfo, delegate(Sprite sprite)
			{
				_viewModel.SetKillTypeSprite(i, sprite);
				_viewModel.CallKillTypeNtvsize(i);
				_refresh.Add(i);
			}));
			_viewModel.CallKillTypeNtvsize(i);
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeNotifyClass(22, UiIEventCondition.Get_killPlayerInfo_InfoList, SetInfoList, initinvoke: true);
	}

	private void SetInfoList(Queue<KillPlayerInfoData> ov, Queue<KillPlayerInfoData> infoList)
	{
		foreach (KillPlayerInfoData info in infoList)
		{
			_startTimeList.Add(TimeUtility.UnixTimeNow());
			_messageList.Add(_index);
			AddMessage(_index, info);
			if (_startTimeList.Count > 8)
			{
				_startTimeList.RemoveAt(0);
				_viewModel.GetMessageObj(_messageList[0]).transform.SetAsLastSibling();
				_messageList.RemoveAt(0);
			}
			_index++;
			if (_index > 8)
			{
				_index = 1;
			}
		}
	}

	private void GetWeapon(int i, KillPlayerInfoData data)
	{
		AssetData assetData = GetAssetInfo(data);
		AssetInfo asset = assetData.Asset;
		if (_assetDic.ContainsKey(i) && !(_assetDic[i] != asset) && !(assetData.WeaponName != _nameDic[i]))
		{
			return;
		}
		_assetDic[i] = asset;
		_nameDic[i] = assetData.WeaponName;
		_viewModel.SetWeaponSprite(i, this.GetLoader().RetriveSprite(asset, delegate(Sprite sprite)
		{
			_viewModel.SetWeaponSprite(i, sprite);
			_viewModel.CallWeaponNtvsize(i);
			assetData.HasAsset = sprite != null && sprite != UiResourcesLoader.DefaultSprite;
			_refresh.Add(i);
		}));
		if (!assetData.HasAsset)
		{
			this.GetLoader().RetriveSprite(assetData.DefaultAsset, delegate(Sprite sprite)
			{
				if (!assetData.HasAsset)
				{
					_viewModel.SetWeaponSprite(i, sprite);
					_viewModel.CallWeaponNtvsize(i);
					_refresh.Add(i);
				}
			});
		}
		_viewModel.SetIconShow(i, value: false);
		_viewModel.SetPermanentShow(i, value: false);
		_viewModel.SetNameShow(i, value: false);
		if (string.IsNullOrEmpty(data.WeaponSkinName))
		{
			return;
		}
		IWeaponInfo weaponInfo = WeaponInfoFactory.Instance.GetWeaponInfo(data.WeaponName);
		this.GetLoader().RetriveSprite(weaponInfo.GetWeaponSkinJyIconAssetInfo(data.WeaponSkinName), delegate(Sprite sprite)
		{
			if (sprite != null)
			{
				_viewModel.SetIconShow(i, value: true);
				_viewModel.SetIconSprite(i, sprite);
				_viewModel.CallIconNtvsize(i);
				_refresh.Add(i);
			}
		});
		this.GetLoader().RetriveSprite(weaponInfo.GetWeaponNameIconAssetInfo(data.WeaponSkinName), delegate(Sprite sprite)
		{
			if (sprite != null)
			{
				_viewModel.SetNameShow(i, value: true);
				_viewModel.SetNameSprite(i, sprite);
				_viewModel.CallNameNtvsize(i);
				_refresh.Add(i);
			}
		});
		if (data.IsLegend)
		{
			this.GetLoader().RetriveSprite(_legendAsset, delegate(Sprite sprite)
			{
				if (sprite != null)
				{
					_viewModel.SetPermanentShow(i, value: true);
					_viewModel.SetPermanentSprite(i, sprite);
					_viewModel.CallPermanentNtvsize(i);
					_refresh.Add(i);
				}
			});
		}
		else if (data.IsHero)
		{
			this.GetLoader().RetriveSprite(_heroAsset, delegate(Sprite sprite)
			{
				if (sprite != null)
				{
					_viewModel.SetPermanentShow(i, value: true);
					_viewModel.SetPermanentSprite(i, sprite);
					_viewModel.CallPermanentNtvsize(i);
					_refresh.Add(i);
				}
			});
		}
		else
		{
			if (!data.Permanent)
			{
				return;
			}
			this.GetLoader().RetriveSprite(_permanentAsset, delegate(Sprite sprite)
			{
				if (sprite != null)
				{
					_viewModel.SetPermanentShow(i, value: true);
					_viewModel.SetPermanentSprite(i, sprite);
					_viewModel.CallPermanentNtvsize(i);
					_refresh.Add(i);
				}
			});
		}
	}

	private AssetData GetAssetInfo(KillPlayerInfoData data)
	{
		for (int i = 0; i < _weaponAsset.Count; i++)
		{
			if (_weaponAsset[i].WeaponName == data.WeaponName && _weaponAsset[i].WeaponLevel == data.WeaponLevel && _weaponAsset[i].IsSecondary == data.IsSecondary && _weaponAsset[i].IsAwakenKill == data.IsAwakenKill && _weaponAsset[i].Permanent == data.Permanent && _weaponAsset[i].SkinName == data.WeaponSkinName)
			{
				return _weaponAsset[i];
			}
		}
		AssetData assetData = new AssetData();
		assetData.WeaponName = data.WeaponName;
		assetData.WeaponLevel = data.WeaponLevel;
		assetData.IsSecondary = data.IsSecondary;
		assetData.IsAwakenKill = data.IsAwakenKill;
		assetData.Permanent = data.Permanent;
		assetData.SkinName = data.WeaponSkinName;
		if (string.IsNullOrEmpty(assetData.SkinName))
		{
			assetData.Asset = new AssetInfo(UiAssetBundleUtils.GetWeaponBundleName(data.WeaponName), string.Format("ui_jy_{0}{1}{2}{3}{4}", data.WeaponName, (data.WeaponLevel > 0) ? ("_" + data.WeaponLevel) : "", data.IsSecondary ? "-S" : "", data.IsAwakenKill ? "-A" : "", data.Permanent ? "-P" : ""));
			assetData.DefaultAsset = new AssetInfo(UiAssetBundleUtils.GetWeaponBundleName(data.WeaponName), $"ui_jy_{data.WeaponName}");
		}
		else
		{
			IWeaponInfo weaponInfo = WeaponInfoFactory.Instance.GetWeaponInfo(data.WeaponName);
			assetData.Asset = (assetData.DefaultAsset = weaponInfo.GetWeaponColorIconAssetInfo(data.WeaponSkinName));
		}
		_weaponAsset.Add(assetData);
		return assetData;
	}
}
