using System.Collections.Generic;
using Assets.Sources.Components.GameRule.Common;
using Assets.Sources.Components.GameRule.Rpg;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Common;

public class AchievementModel : AbstractModel, IPlaybackSystem
{
	private AchievementViewModel _viewModel;

	private readonly List<object> _keys = new List<object>();

	private const int MaxCount = 3;

	private int[] _backs = new int[6];

	private Dictionary<object, float> _progresses;

	private Dictionary<object, int> _remainTimes;

	private int[] _showTimes = new int[6];

	private int _effectTime;

	private AchievementComponent.AchievementInfo _limitedAchieve;

	private int _limitedIndex;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new AchievementViewModel();
	}

	public void OnPlayback()
	{
		if (!_viewModel.IsInited)
		{
			return;
		}
		UpdateChips();
		_effectTime += _timeComponent.FrameInterval;
		if (_remainTimes != null)
		{
			foreach (KeyValuePair<object, int> remainTime in _remainTimes)
			{
				object key = remainTime.Key;
				_keys.Add(key);
			}
			foreach (object key2 in _keys)
			{
				_remainTimes[key2] -= _timeComponent.FrameInterval;
			}
			_keys.Clear();
		}
		for (int i = 1; i <= 3; i++)
		{
			if (_showTimes[i] > 0)
			{
				_showTimes[i] -= _timeComponent.FrameInterval;
				float value = (float)_showTimes[i] / 300f;
				_viewModel.SetAchievementItemAlpha(i, value);
				_viewModel.SetEffectPosition(i, new Vector3(-130f + (float)(_effectTime % 2000) / 2000f * 260f, 0f));
			}
			else
			{
				_viewModel.SetAchievementItemShow(i, value: false);
			}
		}
		if (_limitedAchieve != null)
		{
			if (_limitedAchieve.RemainTime > 44000)
			{
				int num = 45000 - _limitedAchieve.RemainTime;
				int num2 = 0;
				int num3 = Screen.height / 2 - 180;
				int num4 = -Screen.width / 2 + 20;
				int num5 = Screen.height / 2 - 400 - 62 * (_limitedIndex - 2);
				_viewModel.LimitedTimeRewardPosition = new Vector3((float)num2 + (float)((num4 - num2) * num) / 1000f, (float)num3 + (float)((num5 - num3) * num) / 1000f);
			}
			else
			{
				_limitedAchieve = null;
				_viewModel.LimitedTimeRewardShow = false;
			}
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		for (int j = 1; j <= 5; j++)
		{
			_viewModel.SetAchievementItemAlpha(j, 0f);
			_viewModel.SetAchievementItemShow(j, value: false);
			int i1 = j;
			base.Loader.RetriveSprite("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/cross/progress.png", delegate(Sprite sprite)
			{
				_viewModel.SetProgressSprite(i1, sprite);
				_viewModel.SetMaskSprite(i1, sprite);
			});
			base.Loader.RetriveSprite("ui/halfloadedres/achievement", "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/achievement/effect.png", delegate(Sprite sprite)
			{
				_viewModel.SetEffectSprite(i1, sprite);
			});
		}
		base.Loader.RetriveSprite("ui/halfloadedres/achievement", "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/achievement/moveeffect.png", delegate(Sprite sprite)
		{
			_viewModel.LimitedTimeRewardSprite = sprite;
		});
		_viewModel.LimitedTimeRewardShow = false;
		_progresses = new Dictionary<object, float>();
		_remainTimes = new Dictionary<object, int>();
		NotifyManager.MakeNotifyClass(47, UiIEventCondition.Get_achievement_Achievements, SetAchievements, initinvoke: true);
		NotifyManager.MakeNotifyClass(10, UiIEventCondition.Get_task_TaskList, SetTaskList, initinvoke: true);
	}

	private void SetTaskList(List<TaskInfo> arg1, List<TaskInfo> arg2)
	{
		AddUpdateHandler(UpdateAchievements);
	}

	private void SetAchievements(List<AchievementComponent.AchievementInfo> arg1, List<AchievementComponent.AchievementInfo> arg2)
	{
		AddUpdateHandler(UpdateAchievements);
	}

	private void UpdateAchievements(int idx)
	{
		if (_progresses == null)
		{
			return;
		}
		int i = 1;
		_limitedIndex = 0;
		_limitedAchieve = null;
		List<AchievementComponent.AchievementInfo> achievement_Achievements = UiIEventCondition.Get_achievement_Achievements();
		for (int j = 0; j < achievement_Achievements.Count; j++)
		{
			if (i > 3)
			{
				break;
			}
			AchievementComponent.AchievementInfo achievementInfo = achievement_Achievements[j];
			i = ShowData("", i, achievementInfo.CurrentProgress, achievementInfo.TotalProgress, achievementInfo.AchievementType, achievementInfo.RemainTime, achievementInfo);
			if (achievementInfo.IsLimitedTimeReward)
			{
				_limitedIndex = i;
				_limitedAchieve = achievementInfo;
			}
		}
		_viewModel.LimitedTimeRewardShow = _limitedAchieve != null && _limitedAchieve.RemainTime > 44000;
		List<TaskInfo> task_TaskList = UiIEventCondition.Get_task_TaskList();
		for (int k = 0; k < task_TaskList.Count; k++)
		{
			if (i > 3)
			{
				break;
			}
			TaskInfo taskInfo = task_TaskList[k];
			i = ShowData(taskInfo.Name, i, taskInfo.Progress, taskInfo.Total, -1, taskInfo.RemainTime, taskInfo);
		}
		for (; i <= 3; i++)
		{
			_viewModel.SetAchievementItemShow(i, value: false);
		}
	}

	private int ShowData(string name, int index, int progress, int total, int image, int remainTime, object obj)
	{
		_viewModel.SetTaskNameString(index, name);
		_viewModel.SetCurrString(index, progress.ToString());
		_viewModel.SetTotalString(index, total.ToString());
		float num = ((total > 0) ? ((float)((progress >= 0) ? progress : 0) / (float)total) : 0f);
		if (obj is TaskInfo)
		{
			if (_progresses.ContainsKey(obj))
			{
				if (num > _progresses[obj])
				{
					_showTimes[index] = remainTime;
					_remainTimes[obj] = remainTime;
					_progresses[obj] = num;
					_viewModel.SetAchievementItemShow(index, value: true);
				}
				else if (_remainTimes[obj] > 0)
				{
					_showTimes[index] = _remainTimes[obj];
					_viewModel.SetAchievementItemShow(index, value: true);
				}
				else
				{
					_showTimes[index] = 0;
				}
			}
			else
			{
				_progresses[obj] = num;
				if (((TaskInfo)obj).IsUpdate)
				{
					_remainTimes[obj] = remainTime;
					_showTimes[index] = remainTime;
					_viewModel.SetAchievementItemShow(index, value: true);
				}
				else
				{
					_remainTimes[obj] = 0;
					_showTimes[index] = 0;
				}
			}
		}
		else
		{
			_showTimes[index] = remainTime;
			_remainTimes[obj] = remainTime;
			_progresses[obj] = num;
			_viewModel.SetAchievementItemShow(index, value: true);
		}
		_viewModel.SetProgressFillamount(index, num);
		_viewModel.SetMaskFillamount(index, num);
		if (num >= 1f)
		{
			_viewModel.SetProgressColor(index, new Color(0.32f, 0.67f, 0.94f));
		}
		else
		{
			_viewModel.SetProgressColor(index, new Color(1f, 0.79f, 0f));
		}
		if (_backs[index] != image)
		{
			_backs[index] = image;
			_viewModel.SetBackSprite(index, base.Loader.RetriveSprite("ui/halfloadedres/achievement", "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/achievement/" + image + ".png", delegate(Sprite sprite)
			{
				if (_backs[index] == image)
				{
					_viewModel.SetBackSprite(index, sprite);
					_viewModel.CallBackNtvsize(index);
				}
			}));
		}
		return index + 1;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
