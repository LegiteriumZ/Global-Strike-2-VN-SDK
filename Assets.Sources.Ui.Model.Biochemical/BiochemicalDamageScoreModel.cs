using System.Collections.Generic;
using Assets.Sources.Components.Time;
using Assets.Sources.Constant.Career;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Biochemical;
using Assets.Sources.Utils.Chip;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using NotifyEvent;
using SSJJAsset.Asset;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Biochemical;

public class BiochemicalDamageScoreModel : AbstractModel, IPlaybackSystem
{
	private BiochemicaldamagescoreViewModel _viewModel = new BiochemicaldamagescoreViewModel();

	private PositionChip[] _positionChips;

	private ActiveChip[] _visibleChips;

	private FrameAnimaChip[] _animaChips;

	private bool[] _animaVisibles = new bool[20];

	private ActiveChip _damageVisibleChip;

	private PercentMaskChip _maskMoveChip;

	private ScaleChip _scaleChip;

	private AlphaChip _alphaChip;

	private int _totalSocre;

	private int _currScore;

	private Vector3 _waitPosition;

	private int _FragmentSocre;

	private PositionChip _fragmentPositionChips;

	private static AssetInfo _5000Kdamage = new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/humanitydamagescore/5000kdamage.png");

	private static AssetInfo _1000Kdamage = new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/humanitydamagescore/1000kdamage.png");

	private static AssetInfo _500Kdamage = new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/humanitydamagescore/500kdamage.png");

	private static AssetInfo _100Kdamage = new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/humanitydamagescore/100kdamage.png");

	private static AssetInfo _50Kdamage = new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/humanitydamagescore/50kdamage.png");

	private static AssetInfo _10000Damage = new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/humanitydamagescore/10000damage.png");

	private static AssetInfo _5000Damage = new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/humanitydamagescore/5000damage.png");

	private static AssetInfo _1000Damage = new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/humanitydamagescore/1000damage.png");

	private static AssetInfo _waitdamage = new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/humanitydamagescore/waitdamage.png");

	private static Dictionary<string, AssetInfo> _scoreEffects = new Dictionary<string, AssetInfo>
	{
		{
			"effect1_1.png",
			new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/humanitydamagescore/effect1_1.png")
		},
		{
			"effect1_2.png",
			new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/humanitydamagescore/effect1_2.png")
		},
		{
			"effect1_3.png",
			new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/humanitydamagescore/effect1_3.png")
		},
		{
			"effect1_4.png",
			new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/humanitydamagescore/effect1_4.png")
		},
		{
			"effect1_5.png",
			new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/humanitydamagescore/effect1_5.png")
		},
		{
			"effect2_1.png",
			new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/humanitydamagescore/effect2_1.png")
		},
		{
			"effect2_2.png",
			new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/humanitydamagescore/effect2_2.png")
		},
		{
			"effect2_3.png",
			new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/humanitydamagescore/effect2_3.png")
		},
		{
			"effect2_4.png",
			new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/humanitydamagescore/effect2_4.png")
		},
		{
			"effect2_5.png",
			new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/humanitydamagescore/effect2_5.png")
		},
		{
			"effect3_1.png",
			new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/humanitydamagescore/effect3_1.png")
		},
		{
			"effect3_2.png",
			new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/humanitydamagescore/effect3_2.png")
		},
		{
			"effect3_3.png",
			new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/humanitydamagescore/effect3_3.png")
		},
		{
			"effect3_4.png",
			new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/humanitydamagescore/effect3_4.png")
		},
		{
			"effect3_5.png",
			new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/humanitydamagescore/effect3_5.png")
		}
	};

	protected override IUiViewModel ViewModel => _viewModel;

	protected override void DoSubscribe()
	{
		_viewModel.WaitEffectImageShow = false;
		_positionChips = new PositionChip[15];
		for (int i = 0; i < _positionChips.Length; i++)
		{
			_positionChips[i] = new PositionChip();
		}
		_visibleChips = new ActiveChip[15];
		for (int j = 0; j < _visibleChips.Length; j++)
		{
			_visibleChips[j] = new ActiveChip
			{
				Time = 0
			};
			_viewModel.SetMoveDamageScoreImageShow(j + 1, value: false);
		}
		_animaChips = new FrameAnimaChip[20];
		for (int k = 0; k < _animaChips.Length; k++)
		{
			_animaChips[k] = new FrameAnimaChip
			{
				Path = "effect1_",
				Delay = 200,
				Count = 5,
				IsLoop = true
			};
			_animaChips[k].Init();
		}
		_damageVisibleChip = new ActiveChip
		{
			Time = 0
		};
		_maskMoveChip = new PercentMaskChip();
		_scaleChip = new ScaleChip
		{
			Scale = Vector3.one,
			Speed = Vector3.one * 2f,
			TargetScale = Vector3.one * 2f
		};
		_alphaChip = new AlphaChip
		{
			Alpha = 0f,
			Speed = -2f
		};
		NotifyManager.MakeNotify(51, UiIEventCondition.Get_bioDamageScoreData_HumanityDamageScore, SetHumanityDamageScore, initinvoke: true);
		NotifyManager.MakeNotify(75, UiIEventCondition.Get_bioDamageScoreData_HumanityFragment, SetHumanityFragmentScore, initinvoke: true);
		_viewModel.DamageScoreImageFragmentShow = false;
		_viewModel.MoveDamageFragmentShow = false;
		_viewModel.FragmentCountShow = false;
	}

	private void SetHumanityFragmentScore(int arg1, int arg2)
	{
		_FragmentSocre = arg2;
		_fragmentPositionChips = new PositionChip();
		_fragmentPositionChips.Position = new Vector3(-850f, 0f);
		_fragmentPositionChips.TargetPosition = _viewModel.DamageScoreImageFragmentPosition;
		_fragmentPositionChips.Speed = (_fragmentPositionChips.TargetPosition - _fragmentPositionChips.Position) / 150f * 1000f;
		ShowFragmentScore();
	}

	private void ShowFragmentScore()
	{
		_viewModel.DamageScoreImageFragmentShow = true;
		_viewModel.MoveDamageFragmentShow = true;
		_viewModel.FragmentCountShow = true;
		_viewModel.FragmentCountTextString = StringCache.IntToString(_FragmentSocre);
	}

	public void OnPlayback()
	{
		if (!_viewModel.IsInited)
		{
			return;
		}
		for (int j = 0; j < _visibleChips.Length; j++)
		{
			_visibleChips[j].Update(_timeComponent);
			if (_visibleChips[j].Changed)
			{
				_viewModel.SetMoveDamageScoreImageShow(j + 1, _visibleChips[j].Value);
			}
		}
		for (int k = 0; k < _positionChips.Length; k++)
		{
			if (_visibleChips[k].Value)
			{
				_viewModel.SetMoveDamageScoreImagePosition(k + 1, _positionChips[k].Update(_timeComponent));
			}
		}
		for (int l = 0; l < _animaChips.Length; l++)
		{
			if (!_animaVisibles[l])
			{
				continue;
			}
			_animaChips[l].Update(_timeComponent);
			if (_animaChips[l].Changed)
			{
				int i1 = l;
				this.GetLoader().RetriveSprite(_scoreEffects[_animaChips[l].Value], delegate(Sprite sprite)
				{
					_viewModel.SetDamageScoreEffectImageSprite(i1 + 1, sprite);
				});
			}
		}
		_viewModel.BioDamageShow = _damageVisibleChip.Update(_timeComponent);
		_viewModel.ScoreEffectImageScale = _scaleChip.Update(_timeComponent);
		_viewModel.ScoreEffectImageAlpha = _alphaChip.Update(_timeComponent);
		_viewModel.MoveDamageFragmentPosition = _fragmentPositionChips.Update(_timeComponent);
	}

	private void SetHumanityDamageScore(int ov, int score)
	{
		_totalSocre += score;
		_currScore += score;
		ShowBioDamage();
		AddDamageScore(Contexts.sharedInstance.time.time);
		AddMoveDamageScore();
	}

	private void AddDamageScore(TimeComponent time)
	{
		int num = _totalSocre;
		int index = 0;
		while (num > 50000 && index < 20)
		{
			num -= 50000;
			SetScoreImage(++index, _5000Kdamage, "effect1_", time);
			this.GetLoader().RetriveSprite(_5000Kdamage, delegate(Sprite sprite)
			{
				_viewModel.ScoreEffectImageSprite = sprite;
			});
		}
		while (num > 10000 && index < 20)
		{
			num -= 10000;
			SetScoreImage(++index, _1000Kdamage, "effect1_", time);
			this.GetLoader().RetriveSprite(_1000Kdamage, delegate(Sprite sprite)
			{
				_viewModel.ScoreEffectImageSprite = sprite;
			});
		}
		while (num > 5000 && index < 20)
		{
			num -= 5000;
			SetScoreImage(++index, _500Kdamage, "effect2_", time);
			this.GetLoader().RetriveSprite(_500Kdamage, delegate(Sprite sprite)
			{
				_viewModel.ScoreEffectImageSprite = sprite;
			});
		}
		while (num > 1000 && index < 20)
		{
			num -= 1000;
			SetScoreImage(++index, _100Kdamage, "effect2_", time);
			this.GetLoader().RetriveSprite(_100Kdamage, delegate(Sprite sprite)
			{
				_viewModel.ScoreEffectImageSprite = sprite;
			});
		}
		while (num > 500 && index < 20)
		{
			num -= 500;
			SetScoreImage(++index, _50Kdamage, "effect2_", time);
			this.GetLoader().RetriveSprite(_50Kdamage, delegate(Sprite sprite)
			{
				_viewModel.ScoreEffectImageSprite = sprite;
			});
		}
		while (num > 100 && index < 20)
		{
			num -= 100;
			SetScoreImage(++index, _10000Damage, "effect3_", time);
			this.GetLoader().RetriveSprite(_10000Damage, delegate(Sprite sprite)
			{
				_viewModel.ScoreEffectImageSprite = sprite;
			});
		}
		while (num > 50 && index < 20)
		{
			num -= 50;
			SetScoreImage(++index, _5000Damage, "effect3_", time);
			this.GetLoader().RetriveSprite(_5000Damage, delegate(Sprite sprite)
			{
				_viewModel.ScoreEffectImageSprite = sprite;
			});
		}
		while (num > 10 && index < 20)
		{
			num -= 10;
			SetScoreImage(++index, _1000Damage, "", time);
			this.GetLoader().RetriveSprite(_1000Damage, delegate(Sprite sprite)
			{
				_viewModel.ScoreEffectImageSprite = sprite;
			});
		}
		if (_totalSocre > 0)
		{
			if (index < 11)
			{
				_viewModel.ScoreEffectImagePosition = new Vector3(-32f, 241 - (index - 1) * 55);
			}
			else
			{
				_viewModel.ScoreEffectImagePosition = new Vector3(-96f, 241 - (index - 10) * 55);
			}
			index++;
			if (index <= 20)
			{
				_viewModel.SetDamageScoreImageShow(index, value: true);
				this.GetLoader().RetriveSprite(_waitdamage, delegate(Sprite sprite)
				{
					_viewModel.SetDamageScoreImageSprite(index, sprite);
				});
				if (index < 11)
				{
					_waitPosition = new Vector3(-32f, 241 - (index - 1) * 55);
				}
				else
				{
					_waitPosition = new Vector3(-96f, 241 - (index - 11) * 55);
				}
				_maskMoveChip.FromPosition = _waitPosition - new Vector3(0f, 60f);
				_maskMoveChip.TargetPosition = _waitPosition;
				_maskMoveChip.Update((float)num / 10f);
				_viewModel.WaitEffectMaskPosition = _maskMoveChip.MaskPosition;
				_viewModel.WaitEffectImageShow = true;
				_viewModel.WaitEffectImagePosition = _maskMoveChip.ProgressPosition;
			}
		}
		for (int i = index; i < 20; i++)
		{
			_viewModel.SetDamageScoreImageShow(i + 1, value: false);
			_viewModel.SetDamageScoreEffectImageShow(i + 1, value: false);
			_animaVisibles[index] = false;
		}
	}

	private void SetScoreImage(int index, AssetInfo imageAsset, string effect, TimeComponent time)
	{
		_viewModel.SetDamageScoreImageShow(index, value: true);
		_viewModel.SetDamageScoreImageSprite(index, this.GetLoader().RetriveSprite(imageAsset, delegate(Sprite sprite)
		{
			_viewModel.SetDamageScoreImageSprite(index, sprite);
		}));
		if (effect == "")
		{
			_viewModel.SetDamageScoreEffectImageShow(index, value: false);
			_animaVisibles[index - 1] = false;
			return;
		}
		_viewModel.SetDamageScoreEffectImageShow(index, value: true);
		_animaVisibles[index - 1] = true;
		_animaChips[index - 1].Path = effect;
		_viewModel.SetDamageScoreEffectImageSprite(index, this.GetLoader().RetriveSprite(_scoreEffects[_animaChips[index - 1].Update(time)], delegate(Sprite sprite)
		{
			_viewModel.SetDamageScoreEffectImageSprite(index, sprite);
		}));
	}

	private void ShowBioDamage()
	{
		while (_currScore > 10)
		{
			_currScore -= 10;
			if (!PlayerCareerConstantUtility.IsDoun(UiIEventCondition.Get_cameraOwnerData_Career()))
			{
				_damageVisibleChip.Time = 1000;
				_scaleChip.Scale = Vector3.one;
				_alphaChip.Alpha = 1f;
			}
		}
	}

	private void AddMoveDamageScore()
	{
		for (int i = 0; i < _visibleChips.Length; i++)
		{
			if (!_visibleChips[i].Value)
			{
				_visibleChips[i].Time = 150;
				_positionChips[i].Position = new Vector3(-850f, 0f);
				_positionChips[i].TargetPosition = _waitPosition;
				_positionChips[i].Speed = (_positionChips[i].TargetPosition - _positionChips[i].Position) / _visibleChips[i].Time * 1000f;
				break;
			}
		}
	}
}
