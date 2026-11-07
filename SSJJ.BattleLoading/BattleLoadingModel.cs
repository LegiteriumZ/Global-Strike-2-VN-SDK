using I2.Loc;
using SSJJUniRx;
using UnityEngine;

namespace SSJJ.BattleLoading;

public class BattleLoadingModel
{
	public ReactiveProperty<float> Progress = new ReactiveProperty<float>(0f);

	public ReactiveProperty<int> Loaded = new ReactiveProperty<int>(0);

	public ReactiveProperty<int> Total = new ReactiveProperty<int>(0);

	public ReactiveProperty<string> Tip = new ReactiveProperty<string>(ScriptLocalization.Get("InitGameEngine"));

	public ReactiveProperty<string> GameRuleInfo = new ReactiveProperty<string>();

	public ReactiveProperty<string> TipsInfo = new ReactiveProperty<string>();

	public ReactiveProperty<bool> IsRpg = new ReactiveProperty<bool>(initialValue: false);

	public ReactiveProperty<Sprite> BackSprite = new ReactiveProperty<Sprite>();

	public ReactiveProperty<Sprite> ProgressBackSprite = new ReactiveProperty<Sprite>();

	public ReactiveProperty<Sprite> ProgressSprite = new ReactiveProperty<Sprite>();
}
