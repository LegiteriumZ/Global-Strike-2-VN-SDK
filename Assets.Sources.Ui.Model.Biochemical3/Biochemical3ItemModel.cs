using Assets.Libs.NotifyLib.Simplify;
using Assets.Sources.Components.GameRule.Biochemical;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.Biochemical3;
using Assets.Sources.Utils.Chip;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Biochemical3;

[GameUiTest]
public class Biochemical3ItemModel : AbstractModel, IPlaybackSystem, ISetGameRuleContext
{
	private Biochemical3ItemViewModel _viewModel;

	private GameRuleContext _gameRuleContext;

	private BioItemsComponent _bioItems;

	private FrameAnimaChip[] _animaChips = new FrameAnimaChip[3];

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
		_bioItems = _gameRuleContext.bioItems;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new Biochemical3ItemViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited)
		{
			UpdateChips();
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		for (int i = 0; i < 3; i++)
		{
			SimpleNotify.Add(GetItemId, SetItemId, i);
			SimpleNotify.Add(GetOwn, SetOwn, i);
			SimpleNotify.Add(GetKey, SetKey, i);
			SimpleNotify.Add(GetActive, SetActive, i);
			SimpleNotify.Add(GetMask, SetMask, i);
			SimpleNotify.Add(GetEffect, SetEffect, i);
		}
		SimpleNotify.Add(GetVisible, SetVisible);
	}

	private void SetEffect(bool arg1, int arg2)
	{
		_viewModel.SetEffectShow(arg2 + 1, arg1);
	}

	private bool GetEffect(int arg1)
	{
		if (GetItemId(arg1) > 0)
		{
			if (GetActive(arg1) || GetMask(arg1))
			{
				return false;
			}
			return true;
		}
		return false;
	}

	private void SetMask(bool arg1, int arg2)
	{
		_viewModel.SetMaskShow(arg2 + 1, arg1);
	}

	private bool GetMask(int arg1)
	{
		return GetNeed(arg1) >= GetOwn(arg1);
	}

	private void SetActive(bool arg1, int arg2)
	{
		_viewModel.SetActiveShow(arg2 + 1, arg1);
	}

	private bool GetActive(int arg1)
	{
		if (_bioItems.BioItemsData != null && arg1 < _bioItems.BioItemsData.List.Count)
		{
			return _bioItems.BioItemsData.List[arg1].Active;
		}
		return false;
	}

	private void SetVisible(bool arg1, int arg2)
	{
		_viewModel.LeftShow = arg1;
	}

	private bool GetVisible(int arg1)
	{
		if (_bioItems.BioItemsData != null)
		{
			return _bioItems.BioItemsData.List != null;
		}
		return false;
	}

	private void SetKey(int arg1, int arg2)
	{
		_viewModel.SetKeyString(arg2 + 1, arg1.ToString());
	}

	private int GetKey(int arg1)
	{
		if (_bioItems.BioItemsData != null && arg1 < _bioItems.BioItemsData.List.Count)
		{
			return _bioItems.BioItemsData.List[arg1].KeyBorad;
		}
		return 0;
	}

	private void SetOwn(int arg1, int arg2)
	{
		_viewModel.SetOwnString(arg2 + 1, arg1.ToString());
	}

	private int GetOwn(int arg1)
	{
		if (_bioItems.BioItemsData != null && arg1 < _bioItems.BioItemsData.List.Count)
		{
			return _bioItems.BioItemsData.List[arg1].Num;
		}
		return 0;
	}

	private void SetNeed(int arg1, int arg2)
	{
		_viewModel.SetNeedString(arg2 + 1, arg1.ToString());
	}

	private int GetNeed(int arg1)
	{
		if (_bioItems.BioItemsData != null && arg1 < _bioItems.BioItemsData.List.Count)
		{
			return 10;
		}
		return 0;
	}

	private void SetItemId(int arg1, int arg2)
	{
		if (arg1 > 0)
		{
			_viewModel.SetItemShow(arg2 + 1, value: true);
			base.Loader.RetriveSprite("ui/biomodel", $"Assets/Res/Assets/ui/GameGUIRes/bioModel/item/{arg1}.png", delegate(Sprite sprite)
			{
				_viewModel.SetIconSprite(arg2 + 1, sprite);
			});
		}
		else
		{
			_viewModel.SetItemShow(arg2 + 1, value: false);
		}
	}

	private int GetItemId(int arg1)
	{
		if (_bioItems.BioItemsData != null && arg1 < _bioItems.BioItemsData.List.Count)
		{
			return _bioItems.BioItemsData.List[arg1].ItemId;
		}
		return 0;
	}

	private void InitChips()
	{
		for (int i = 0; i < _animaChips.Length; i++)
		{
			_animaChips[i] = new FrameAnimaChip();
			_animaChips[i].StartIndex = 0;
			_animaChips[i].Count = 4;
			_animaChips[i].Path = "Assets/Res/Assets/ui/GameGUIRes/bio3Model/item/effect";
			_animaChips[i].IsLoop = true;
			_animaChips[i].Init();
		}
	}

	private void UpdateChips()
	{
		for (int j = 0; j < _animaChips.Length; j++)
		{
			if (!_viewModel.GetEffectShow(j + 1))
			{
				continue;
			}
			_animaChips[j].Update(_timeComponent);
			if (_animaChips[j].Changed)
			{
				int i1 = j;
				base.Loader.RetriveSprite("ui/bio3model", _animaChips[j].Value, delegate(Sprite sprite)
				{
					_viewModel.SetEffectSprite(i1 + 1, sprite);
				});
			}
		}
	}
}
