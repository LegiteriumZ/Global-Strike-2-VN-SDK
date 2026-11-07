using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Blast;
using Assets.Sources.Utils.Chip;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Blast;

public class BlastByLikesModel : AbstractModel, IPlaybackSystem
{
	private const int LikesCount = 10;

	private BlastbylikesViewModel _viewModel = new BlastbylikesViewModel();

	private int _index;

	private ScaleChip[] _imageScaleChips;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		base.Initialize();
		InitChips();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			UpdateChips();
		}
	}

	protected override void DoSubscribe()
	{
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_peekabooLikes_LikesCount, SetLikesCount, null, initinvoke: true);
	}

	private void SetLikesCount(int ov, int likesCount)
	{
		UpdateLikesImageList(likesCount);
		HideLikes();
	}

	private void HideLikes()
	{
		for (int i = _index; i < 10; i++)
		{
			_viewModel.SetLikesImageShow(i + 1, value: false);
		}
	}

	private void UpdateLikesImageList(int likesCount)
	{
		_index = 0;
		int num = likesCount / 100;
		SetLikesImage(num, "100.png");
		_index += num;
		likesCount %= 100;
		num = likesCount / 50;
		SetLikesImage(num, "50.png");
		_index += num;
		likesCount %= 50;
		num = likesCount / 10;
		SetLikesImage(num, "10.png");
		_index += num;
		likesCount %= 10;
		num = likesCount / 5;
		SetLikesImage(num, "5.png");
		_index += num;
		num = likesCount % 5;
		SetLikesImage(num, "1.png");
		_index += num;
		if (_index > 0 && _index - 1 < _imageScaleChips.Length)
		{
			_imageScaleChips[_index - 1].Scale = Vector3.one * 1.5f;
		}
	}

	private void SetLikesImage(int count, string pic)
	{
		for (int j = _index; j < count + _index; j++)
		{
			int i1 = j;
			base.Loader.RetriveSprite("ui/blastmodel", "Assets/Res/Assets/ui/GameGUIRes/blastModel/bylikes/" + pic, delegate(Sprite sprite)
			{
				_viewModel.SetLikesImageSprite(i1 + 1, sprite);
			});
			_viewModel.SetLikesImageShow(j + 1, value: true);
		}
	}

	private void InitChips()
	{
		_imageScaleChips = new ScaleChip[10];
		for (int i = 0; i < 10; i++)
		{
			_imageScaleChips[i] = new ScaleChip
			{
				Speed = -Vector3.one,
				TargetScale = Vector3.one,
				Scale = Vector3.one
			};
		}
	}

	private void UpdateChips()
	{
		for (int i = 0; i < 10; i++)
		{
			if (_viewModel.GetLikesImageShow(i + 1))
			{
				_viewModel.SetLikesImageScale(i + 1, _imageScaleChips[i].Update(_timeComponent));
			}
		}
	}
}
