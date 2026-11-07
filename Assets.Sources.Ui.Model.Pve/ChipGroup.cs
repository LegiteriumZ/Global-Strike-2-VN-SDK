using System.Collections.Generic;
using Assets.Sources.Ui.ViewModel.Pve;
using Assets.Sources.Utils.AssetManager;
using Assets.Sources.Utils.UIChip;
using Assets.UiFramework.Libs;
using SSJJAsset.Asset;
using SSJJBase.Singleton;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Ui.Model.Pve;

internal class ChipGroup
{
	private TimeSetChip<bool> _activeChip;

	private TimeSetChip<Sprite> _spriteChip;

	private Vector2Chip _sizeChip;

	private NumberChip _textChip;

	private TimeSetChip<Color> _colChip;

	private Dictionary<int, float> _cachepercent = new Dictionary<int, float>();

	private string _fontnamecache;

	private string _fontrescache;

	private string _imgrescache;

	private string _imgnamecache;

	public TimeSetChip<bool> ActiveChip
	{
		get
		{
			if (_activeChip == null)
			{
				_activeChip = new TimeSetChip<bool>();
				_activeChip.Start = true;
				_activeChip.Target = false;
			}
			return _activeChip;
		}
	}

	public TimeSetChip<Sprite> SpriteChip
	{
		get
		{
			if (_spriteChip == null)
			{
				_spriteChip = new TimeSetChip<Sprite>();
			}
			return _spriteChip;
		}
	}

	public Vector2Chip SizeChip
	{
		get
		{
			if (_sizeChip == null)
			{
				_sizeChip = new Vector2Chip();
			}
			return _sizeChip;
		}
	}

	public NumberChip TextChip
	{
		get
		{
			if (_textChip == null)
			{
				_textChip = new NumberChip();
			}
			return _textChip;
		}
	}

	public TimeSetChip<Color> ColChip
	{
		get
		{
			if (_colChip == null)
			{
				_colChip = new TimeSetChip<Color>();
			}
			return _colChip;
		}
	}

	public void PauseOld(PvetdmessageViewModel viewModel, ref ImgTxtShowCmd info)
	{
		if (!string.IsNullOrEmpty(info.ResComponent))
		{
			FixShow(viewModel.UI.Get(info.ResComponent), active: false);
		}
		if (!string.IsNullOrEmpty(info.TextComponent))
		{
			FixShow(viewModel.UI.Get(info.TextComponent), active: false);
		}
		if (!string.IsNullOrEmpty(info.ColComponent))
		{
			FixShow(viewModel.UI.Get(info.ColComponent), active: false);
		}
		if (!string.IsNullOrEmpty(info.SizeComponent))
		{
			FixShow(viewModel.UI.Get(info.SizeComponent), active: false);
		}
	}

	public void Init(PvetdmessageViewModel viewModel, ref ImgTxtShowCmd info)
	{
		Reset(viewModel, ref info);
		if (!string.IsNullOrEmpty(info.ResComponent))
		{
			ActiveChip.Time = info.Time;
			SpriteChip.Time = info.Time;
		}
		if (!string.IsNullOrEmpty(info.TextComponent))
		{
			TextChip.Time = info.Time;
		}
		if (!string.IsNullOrEmpty(info.ColComponent))
		{
			ColChip.Start = info.OriginCol.Value;
			ColChip.Target = info.TargetCol.Value;
			ColChip.Time = info.Time;
		}
		if (!string.IsNullOrEmpty(info.SizeComponent))
		{
			SizeChip.Start = info.OriginSize.Value;
			SizeChip.Target = info.TargetSize.Value;
			if (info.SizeTime.HasValue)
			{
				SizeChip.Time = info.SizeTime.Value;
			}
			else
			{
				SizeChip.Time = info.Time;
			}
		}
	}

	private Sprite CreateSpr(IUiResourcesLoader loader, string sprName)
	{
		return loader.RetriveSprite("ui/towerdefensemodel", $"Assets/Res/Assets/ui/GameGUIRes/towerDefenseModel/message/{sprName}.png");
	}

	private void FixShow<T>(T comp, bool active) where T : Component
	{
		if ((bool)comp)
		{
			if (active && !comp.gameObject.IsActiveSelf())
			{
				comp.gameObject.SetObjectActive(isactive: true);
			}
			else if (!active && comp.gameObject.IsActiveSelf())
			{
				comp.gameObject.SetObjectActive(isactive: false);
			}
		}
	}

	public bool DoStep(IUiResourcesLoader loader, int frameInterval, ref ImgTxtShowCmd cmd, PvetdmessageViewModel viewModel)
	{
		if (!string.IsNullOrEmpty(cmd.ResComponent) && cmd.Time > 0)
		{
			Transform comp = viewModel.UI.Get(cmd.ResComponent);
			if (ActiveChip.Time < 1E-06f)
			{
				float priorityPercent = GetPriorityPercent(cmd.Priority);
				if (priorityPercent > 0f)
				{
					Init(viewModel, ref cmd);
					ActiveChip.Time = priorityPercent + (float)cmd.Time;
					float percent = priorityPercent / (float)cmd.Time;
					ActiveChip.JumpToPercent(percent);
					JumpTo(loader, viewModel, ref cmd, percent);
				}
				else if (cmd.StartEvent != null)
				{
					cmd.StartEvent();
				}
			}
			bool activeVal = ((frameInterval >= 0) ? ActiveChip.Update(frameInterval) : ActiveChip.Value);
			SetPriorityPercent(cmd.Priority, ActiveChip.Time);
			DoImageChipStep(loader, frameInterval, viewModel, ref cmd, ref activeVal);
			DoTextChipStep(loader, frameInterval, viewModel, ref cmd, ref activeVal);
			DoColChipStep(loader, frameInterval, viewModel, ref cmd, ref activeVal);
			DoSizeChipStep(loader, frameInterval, viewModel, ref cmd, ref activeVal);
			if (frameInterval > 0 && !ActiveChip.IsOver && cmd.UpdateEvent != null)
			{
				cmd.UpdateEvent(frameInterval);
			}
			if (ActiveChip.IsOver && cmd.EndEvent != null)
			{
				cmd.EndEvent();
			}
			FixShow(comp, activeVal);
			if (ActiveChip.IsOver)
			{
				SetPriorityPercent(cmd.Priority, 0f);
			}
			return ActiveChip.IsOver;
		}
		SetPriorityPercent(cmd.Priority, 0f);
		return true;
	}

	private void DoColChipStep(IUiResourcesLoader loader, int frameInterval, PvetdmessageViewModel viewModel, ref ImgTxtShowCmd cmd, ref bool activeVal)
	{
		if (!cmd.TargetCol.HasValue || string.IsNullOrEmpty(cmd.ColComponent))
		{
			return;
		}
		Graphic graphic = viewModel.UI.Get<Graphic>(cmd.ColComponent);
		if ((bool)graphic)
		{
			FixShow(graphic, activeVal);
			if (frameInterval >= 0)
			{
				graphic.color = ColChip.Update(frameInterval);
			}
			else
			{
				graphic.color = ColChip.Value;
			}
		}
	}

	private void DoSizeChipStep(IUiResourcesLoader loader, int frameInterval, PvetdmessageViewModel viewModel, ref ImgTxtShowCmd cmd, ref bool activeVal)
	{
		if (!cmd.TargetSize.HasValue || string.IsNullOrEmpty(cmd.SizeComponent))
		{
			return;
		}
		RectTransform rectTransform = viewModel.UI.Get(cmd.SizeComponent) as RectTransform;
		if (rectTransform != null)
		{
			FixShow(rectTransform, activeVal);
			if (frameInterval >= 0)
			{
				rectTransform.sizeDelta = SizeChip.Update(frameInterval);
			}
			else
			{
				rectTransform.sizeDelta = SizeChip.Value;
			}
		}
	}

	private void DoTextChipStep(IUiResourcesLoader loader, int frameInterval, PvetdmessageViewModel viewModel, ref ImgTxtShowCmd cmd, ref bool activeVal)
	{
		if (string.IsNullOrEmpty(cmd.TextComponent))
		{
			return;
		}
		Text text = viewModel.UI.Get<Text>(cmd.TextComponent);
		if (!text)
		{
			return;
		}
		FixShow(text, activeVal);
		if (!string.IsNullOrEmpty(cmd.FontRes))
		{
			if (string.IsNullOrEmpty(_fontnamecache) || !_fontnamecache.Equals(cmd.FontRes))
			{
				_fontnamecache = cmd.FontRes;
				_fontrescache = $"Assets/Res/Assets/number/{cmd.FontRes}.fontsettings";
			}
			string fontrescache = _fontrescache;
			AssetInfo assetInfo = new AssetInfo("number", fontrescache);
			if (SingletonInstance<AssetPool>.Instance.IsAssetLoadFinish(assetInfo))
			{
				text.font = SingletonInstance<AssetPool>.Instance.GetOrNull(assetInfo) as Font;
			}
			else if (!loader.isLoading(assetInfo))
			{
				loader.Load("number", fontrescache, null);
			}
		}
		if (!string.IsNullOrEmpty(cmd.AlwaysText))
		{
			text.text = cmd.AlwaysText;
			return;
		}
		TextChip.Start = cmd.OriginText;
		TextChip.Target = cmd.TargetText;
		if (frameInterval >= 0)
		{
			text.text = TextChip.Update(frameInterval).ToString();
		}
		else
		{
			text.text = TextChip.Value.ToString();
		}
	}

	private void DoImageChipStep(IUiResourcesLoader loader, int frameInterval, PvetdmessageViewModel viewModel, ref ImgTxtShowCmd cmd, ref bool activeVal)
	{
		if (string.IsNullOrEmpty(cmd.ResKey))
		{
			return;
		}
		Image image = viewModel.UI.Get<Image>(cmd.ResComponent);
		if (SpriteChip.Start == null)
		{
			if (string.IsNullOrEmpty(_imgnamecache) || !_imgnamecache.Equals(cmd.ResKey))
			{
				_imgnamecache = cmd.ResKey;
				_imgrescache = $"Assets/Res/Assets/ui/GameGUIRes/towerDefenseModel/message/{cmd.ResKey}.png";
			}
			AssetInfo assetInfo = new AssetInfo
			{
				BundleName = "ui/towerdefensemodel",
				AssetName = _imgrescache
			};
			if (SingletonInstance<AssetPool>.Instance.IsAssetLoadFinish(assetInfo))
			{
				SpriteChip.Start = CreateSpr(loader, cmd.ResKey);
				SpriteChip.Target = SpriteChip.Start;
			}
			else if (!loader.isLoading(assetInfo))
			{
				CreateSpr(loader, cmd.ResKey);
				activeVal = false;
			}
			else
			{
				activeVal = false;
			}
		}
		image.sprite = SpriteChip.Start;
		image.SetNativeSize();
	}

	private float GetPriorityPercent(int priority)
	{
		if (_cachepercent.TryGetValue(priority, out var value))
		{
			return value;
		}
		return -1f;
	}

	public void SetPriorityPercent(int priority, float percent)
	{
		_cachepercent[priority] = percent;
	}

	public void JumpTo(IUiResourcesLoader loader, PvetdmessageViewModel viewModel, ref ImgTxtShowCmd cmd, float percent)
	{
		SetPriorityPercent(cmd.Priority, Mathf.Clamp01((float)cmd.Time * percent));
		if (_activeChip != null)
		{
			_activeChip.JumpToPercent(percent);
			FixShow(viewModel.UI.Get(cmd.ResComponent), _activeChip.Value);
		}
		bool activeVal = ActiveChip.Value;
		if (_colChip != null)
		{
			_colChip.JumpToPercent(percent);
			DoColChipStep(loader, 0, viewModel, ref cmd, ref activeVal);
		}
		if (_spriteChip != null)
		{
			_spriteChip.JumpToPercent(percent);
			DoImageChipStep(loader, 0, viewModel, ref cmd, ref activeVal);
		}
		if (_textChip != null)
		{
			_textChip.JumpToPercent(percent);
			DoTextChipStep(loader, 0, viewModel, ref cmd, ref activeVal);
		}
		if (_sizeChip != null)
		{
			_sizeChip.JumpToPercent(percent);
			DoSizeChipStep(loader, 0, viewModel, ref cmd, ref activeVal);
		}
		if (ActiveChip.Time < 1E-06f && cmd.StartEvent != null)
		{
			cmd.StartEvent();
		}
		if (cmd.UpdateEvent != null)
		{
			cmd.UpdateEvent(0);
		}
		if (ActiveChip.IsOver && cmd.EndEvent != null)
		{
			cmd.EndEvent();
		}
	}

	public void Reset(PvetdmessageViewModel viewModel, ref ImgTxtShowCmd cmd, bool finish = false)
	{
		if (_colChip != null)
		{
			_colChip.Start = Color.white;
			_colChip.Target = Color.white;
			_colChip.Step = 1f;
		}
		if (_spriteChip != null)
		{
			_spriteChip.Step = 1f;
			_spriteChip.Start = null;
			_spriteChip.Target = null;
		}
		if (_textChip != null)
		{
			_textChip.Step = 1f;
			_textChip.Start = 0;
			_textChip.Target = 0;
		}
		if (_activeChip != null)
		{
			_activeChip.Step = 1f;
			_activeChip.Start = true;
			_activeChip.Target = false;
		}
		if (_sizeChip != null)
		{
			_sizeChip.Step = 1f;
			_sizeChip.Start = Vector2.zero;
			_sizeChip.Target = Vector2.zero;
		}
		if (finish)
		{
			SetPriorityPercent(cmd.Priority, 0f);
		}
	}
}
